using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInfo.Forms
{
    public partial class CatalogForm : Form
    {
        DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public CatalogForm()
        {
            InitializeComponent();
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            ds = SQLHelper.LoadData("Car_catalog");
            dt = ds.Tables[0];
            bs.DataSource = dt;
            DataGridView grid = new DataGridView();
            grid.DataSource = dt;
            MessageBox.Show(Directory.GetCurrentDirectory());
            /*for (int i = 0; i < grid.RowCount + 1; i++)
            {
                Button btn = new Button();
                btn.Width = 130;
                btn.Height = 82;
                btn.Image = grid.Rows[i].Cells[1].Value as Image;
                btn.Text =  grid.Rows[i].Cells[0].Value.ToString();
                MessageBox.Show(Directory.GetCurrentDirectory());
                flowLayoutPanel1.Controls.Add(btn);
            }*/
        }
    }
}
