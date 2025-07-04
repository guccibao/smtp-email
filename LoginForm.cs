using System;
using System.Windows.Forms;

namespace GmailStyleWinFormsApp
{
    public partial class LoginForm : Form
    {
        public string Email { get; private set; }
        public string AppPassword { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            Email = txtEmail.Text;
            AppPassword = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}