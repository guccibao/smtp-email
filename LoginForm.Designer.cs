namespace GmailStyleWinFormsApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // === txtFrom ===
            this.txtEmail.Location = new System.Drawing.Point(12, 12);
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            this.txtEmail.PlaceholderText = "Gmail của bạn";
            txtFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // === txtPassword ===
            this.txtPassword.Location = new System.Drawing.Point(12, 41);
            this.txtPassword.Size = new System.Drawing.Size(260, 23);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Mật khẩu ứng dụng";
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // === btnLogin ===
            this.btnLogin.Location = new System.Drawing.Point(12, 70);
            this.btnLogin.Size = new System.Drawing.Size(260, 30);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Text = "Đăng nhập Gmail";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}