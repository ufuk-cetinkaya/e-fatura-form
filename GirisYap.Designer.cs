namespace EFaturaForm
{
    partial class GirisYap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login = new Button();
            username = new TextBox();
            password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // login
            // 
            login.Location = new Point(73, 93);
            login.Name = "login";
            login.Size = new Size(75, 23);
            login.TabIndex = 0;
            login.Text = "Giriş Yap";
            login.UseVisualStyleBackColor = true;
            login.Click += Login_Click;
            // 
            // username
            // 
            username.Location = new Point(102, 24);
            username.Name = "username";
            username.Size = new Size(100, 23);
            username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(102, 53);
            password.Name = "password";
            password.Size = new Size(100, 23);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 27);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 56);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Şifre";
            // 
            // GirisYap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 128);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(login);
            Name = "GirisYap";
            Text = "Giriş Yap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login;
        private TextBox username;
        private TextBox password;
        private Label label1;
        private Label label2;
    }
}