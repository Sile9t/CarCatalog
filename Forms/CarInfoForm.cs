using CarInfo.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInfo
{
    public partial class CarInfoForm : Form
    {
        public CarInfoForm()
        {
            InitializeComponent();
        }

        public bool formExist(string form)
        {
            bool result = false;
            foreach (Form f in Application.OpenForms)
            {
                result = f.Text == form ? true : false;
                if (result == true) { f.Focus(); return result; }
            }
            return result;
        }

        public void SaveAll()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().ToString() == "CarInfoForm.TableForm")
                {
                    TableForm q = new TableForm();
                    q = f as TableForm;
                    q.bindingNavigatorSaveItem_Click(null, null);
                }
            }
        }

        private void CarInfoForm_Load(object sender, EventArgs e)
        {
            //if (Info.Position != "Director") employeesToolStripMenuItem.Visible = false;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Catalog")
                if (!formExist(e.ClickedItem.Text))
                {
                    CatalogForm f = new CatalogForm();
                    f.MdiParent = this;
                    f.Text = e.ClickedItem.Text;
                    f.Show();
                }
            if ((e.ClickedItem.Name != "") && (e.ClickedItem.Text != "Window") && (e.ClickedItem.Text != "Catalog"))
                if (!formExist(e.ClickedItem.Text))
                {
                    TableForm f = new TableForm();
                    f.MdiParent = this;
                    f.Text = e.ClickedItem.Text;
                    f.Show();
                }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
