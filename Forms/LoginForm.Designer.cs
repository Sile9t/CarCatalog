namespace CarInfo
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(93, 124);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(171, 20);
            this.loginTextBox.TabIndex = 0;
            this.loginTextBox.Text = "Login";
            this.loginTextBox.Enter += new System.EventHandler(this.loginTextBox_Enter);
            this.loginTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginTextBox_KeyDown);
            this.loginTextBox.Leave += new System.EventHandler(this.loginTextBox_Leave);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(93, 176);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(171, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(137, 230);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 371);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginBtn;
    }
}

