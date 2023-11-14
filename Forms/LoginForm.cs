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
    public partial class LoginForm : Form
    {
        public string Pass;
        public string LoginCheck(string login)
        {
            using (SqlDataReader reader = SQLHelper.ExecuteReader("Password,Position",
              "Employees", "Login", new SqlParameter("@Login", login)))
            {
                string res = null;
                reader.Read();
                try { Info.Position = reader.GetString(1); res = reader.GetString(0); }
                catch (InvalidOperationException) { return null; }
                reader.Close();
                return res;
            }
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginTextBox_Enter(object sender, EventArgs e)
        {
            loginTextBox.Clear();
        }

        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text == "Login")
            {
                if (loginTextBox.Text == "")
                {
                    loginTextBox.Text = "Login";
                    loginTextBox.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    Pass = LoginCheck(loginTextBox.Text);
                    loginTextBox.ForeColor = Pass
                        != null ? Color.Green : Color.Red;
                }
            }
            else if (this.Text == "Register")
            {
                if (loginTextBox.Text == "")
                {
                    loginTextBox.Text = "Login";
                    loginTextBox.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    Pass = LoginCheck(loginTextBox.Text);
                    loginTextBox.ForeColor = Pass
                        == null ? Color.Green : Color.Red;
                }
            }
        }
        private void loginTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginTextBox_Leave(sender, e);
                passwordTextBox.Focus();
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text == "Login")
            {
                if (passwordTextBox.Text == "")
                {
                    passwordTextBox.Text = "Password";
                    passwordTextBox.ForeColor = SystemColors.WindowText;
                    passwordTextBox.UseSystemPasswordChar = false;
                }
                else
                {
                    passwordTextBox.ForeColor = Pass
                        == passwordTextBox.Text ? Color.Green : Color.Red;
                }
            }
            else if (this.Text == "Register")
            {
                if (passwordTextBox.Text == "")
                {
                    passwordTextBox.Text = "Password";
                    passwordTextBox.ForeColor = SystemColors.WindowText;
                    passwordTextBox.UseSystemPasswordChar = false;
                }
                else if ((passwordTextBox.Text.Length >= 8) && (passwordTextBox.Text.Length <= 12))
                {
                    passwordTextBox.ForeColor = Pass
                        == null ? Color.Green : Color.Red;
                }
                else 
                { 
                    passwordTextBox.ForeColor = Color.Red;
                    ErrorProvider ep = new ErrorProvider();
                    ep.SetError(passwordTextBox, "Password length can't be less than 8 or more than 12!");
                }
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (passwordTextBox.Text != ""))
            {
                passwordTextBox_Leave(sender, e);
                loginBtn_Click(sender, e);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (this.Text == "Login")
            {
                if ((loginTextBox.ForeColor == Color.Green) && (passwordTextBox.ForeColor
                    == Color.Green))
                {
                    CarInfoForm cif = new CarInfoForm();
                    cif.Activate();
                    this.Dispose();
                }
            }
            else if (this.Text == "Register")
            {
                TableForm parent = new TableForm();
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Employees") { parent = f as TableForm; break; } 
                }
                DataRow newRow = parent.dt.NewRow();
                for (int i = 0; i < 6; i++)
                {
                    newRow[i] = parent.dataGridView.CurrentRow.Cells[i].Value;
                }
                newRow[6] = loginTextBox.Text;
                newRow[7] = passwordTextBox.Text;
                parent.dt.Rows.Add(newRow);
                parent.bindingNavigatorSaveItem_Click(null, null);
                parent.Focus();
                this.Dispose();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((loginTextBox.ForeColor != Color.Green) && (passwordTextBox.ForeColor != Color.Green)) Application.Exit();
        }
    }
    public static class Info
    {
        public static string Position { get; set; }
    }
}
