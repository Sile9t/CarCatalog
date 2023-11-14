using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInfo
{
    public partial class TableForm : Form
    {
        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Resize(object sender, EventArgs e)
        {
            dataGridView.Width = this.Width - 15;
            dataGridView.Height = this.Height - 67;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            ds = SQLHelper.LoadData(this.Text);
            dt = ds.Tables[0];
            bs.DataSource = dt;
            this.bindingNavigator.BindingSource = bs;
            this.dataGridView.DataSource = dt;
            this.dataGridView.AutoResizeColumns();
            toolStripProgressBar.Value = 100;
            this.dataGridView.Columns["Id"].ReadOnly = true;
            if (this.Text == "Car_catalog") this.dataGridView.Columns["Image"].Width = 128;
            if (this.Text == "Clients") this.dataGridView.Columns["Order_status"].ReadOnly = true;
            if (this.Text == "Employees")
            {
                this.dataGridView.Columns["Login"].ReadOnly = true;
                this.dataGridView.Columns["Password"].Visible = false;
            }
            foreach (DataColumn col in dt.Columns)
                searchColumnComboBox.Items.Add(col.Caption);
        }

        public void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SQLHelper.Reseed(this.Text, (dataGridView.RowCount - 2));
            SQLHelper.UpdateData(this.Text, ds);
            toolStripProgressBar.Value = 100;
        }

        private void TableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) {
                dataGridView.EndEdit();
                bindingNavigatorSaveItem_Click(null, null); }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E) 
                dataGridView.BeginEdit(true);
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Confirm delete?", "Warning!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dt.Rows.RemoveAt(dataGridView.CurrentRow.Index);
                    bindingNavigatorSaveItem_Click(null, null);
                }
                else this.Focus();
            }
        }

        public void comboClear()
        {
            variationComboBox.Items.Clear();
            variationComboBox.Text = "";
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try 
            { 
                switch (this.Text)
                {
                    case "Car_catalog":
                        switch (dataGridView.CurrentCell.ColumnIndex)
                        {
                            case 1:
                                OpenFileDialog ofd = new OpenFileDialog();
                                DialogResult result = MessageBox.Show("Do you want to change image?",
                                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1);
                                if (result == DialogResult.Yes) 
                                { 
                                    ofd.ShowDialog();
                                    SQLHelper.UpdateTable("Car_catalog", 
                                        "Image = (SELECT * FROM OPENROWSET(BULK N'" + ofd.FileName + "', " +
                                        "SINGLE_BLOB) AS Image)",
                                        "Id = @Id", new SqlParameter[] { 
                                            new SqlParameter ("@Image", ofd.FileName),
                                            new SqlParameter ("@Id", dataGridView.CurrentRow.Cells[0].Value)});
                                    
                                }
                                break;
                            case 3:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Brand_name"));
                                break;
                            case 4:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Body_type"));
                                break;
                            case 5:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Gearbox_type"));
                                break;
                            case 6:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Engine_type"));
                                break;
                            case 7:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Drive_type"));
                                break;
                            case 8:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.Add("Left");
                                variationComboBox.Items.Add("Right");
                                break;
                            default: comboClear();
                                break;
                        }
                        break;
                    case "Orders":
                        switch (dataGridView.CurrentCell.ColumnIndex)
                        {
                            case 2:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Model","Car_catalog"));
                                break;
                            case 3:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("VIN", "Cars_VINs"));
                                break;
                            case 4:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Order_status_type"));
                                break;
                            case 5:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Id", "Suppliers"));
                                break;
                            case 6:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Id", "Employees"));
                                break;
                            default: comboClear();
                                break;
                        }
                        break;
                    case "Employees":
                        if (dataGridView.CurrentCell.ColumnIndex == 1)
                        {
                            variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                            variationComboBox.Items.Add("Saler");
                            variationComboBox.Items.Add("Director");
                        } else comboClear();
                        break;
                    case "Clients":
                        switch (dataGridView.CurrentCell.ColumnIndex) {
                            case 2:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Id", "Orders"));
                                break;
                            case 3:
                                comboClear();
                                variationComboBox.Text = dataGridView.CurrentCell.Value.ToString();
                                variationComboBox.Items.AddRange(SQLHelper.Items("Name", "Order_status_type"));
                                break;
                            default : comboClear();
                                break;
                        }
                        break;
                }
                if (dataGridView.CurrentRow.Index > 0) toolStripProgressBar.Value = dt
                        .Rows[dataGridView.CurrentRow.Index - 1].RowState != DataRowState
                        .Unchanged ? 0 : 100;
            }
            catch (NullReferenceException) { return; }
        }

        private void variationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView.CurrentCell.Value = variationComboBox.SelectedItem;
                if (this.Text == "Clients") dataGridView.Rows[dataGridView.CurrentCell.RowIndex]
                        .Cells[dataGridView.CurrentCell.ColumnIndex + 1].Value = SQLHelper
                        .ExecuteReaderFrom("Status", "Orders", "Id",
                        new System.Data.SqlClient.SqlParameter("@Id", dataGridView.CurrentCell.Value));
            }
            catch (NullReferenceException) { return; }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchColumnComboBox.SelectedItem == null) MessageBox.Show("Select filtering column"); 
            else bs.Filter = String.Format(searchColumnComboBox.SelectedItem + " like '%"
                + searchTextBox.Text + "%'");
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.Text == "Car_catalog") && (e.ColumnIndex == 14))
            {

            }
            if ((this.Text == "Employees") && (e.ColumnIndex == 5)
                && (dataGridView.CurrentRow.Cells[6].Value.ToString() == ""))
            {
                bindingNavigatorSaveItem_Click(null, null);
                LoginForm lf = new LoginForm();
                lf.Text = "Register";
                lf.Show();
            }
        }
    }
}
