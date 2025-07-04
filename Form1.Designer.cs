namespace GmailStyleWinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ListBox lstInbox;
        private System.Windows.Forms.TextBox txtEmailDetail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.lstInbox = new System.Windows.Forms.ListBox();
            this.txtEmailDetail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            int margin = 10;

            this.txtFrom.SetBounds(margin, 20, 360, 27);
            this.txtPassword.SetBounds(margin, 55, 360, 27);
            this.txtPassword.PasswordChar = '*';
            this.txtTo.SetBounds(margin, 90, 360, 27);
            this.txtSubject.SetBounds(margin, 125, 360, 27);
            this.txtBody.SetBounds(margin, 160, 360, 100);
            this.txtBody.Multiline = true;

            this.btnAttach.SetBounds(margin, 270, 100, 30);
            this.btnAttach.Text = "📎 Đính kèm";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);

            this.btnSend.SetBounds(120, 270, 100, 30);
            this.btnSend.Text = "✉️ Gửi";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.btnReceive.SetBounds(230, 270, 140, 30);
            this.btnReceive.Text = "📥 Nhận Email";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);

            this.lstInbox.SetBounds(margin, 310, 360, 100);
            this.lstInbox.SelectedIndexChanged += new System.EventHandler(this.lstInbox_SelectedIndexChanged);

            this.txtEmailDetail.SetBounds(margin, 420, 360, 120);
            this.txtEmailDetail.Multiline = true;
            this.txtEmailDetail.ReadOnly = true;

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtFrom, txtPassword, txtTo, txtSubject, txtBody,
                btnAttach, btnSend, btnReceive, lstInbox, txtEmailDetail
            });

            this.ClientSize = new System.Drawing.Size(400, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "GmailStyle - Gửi & Nhận Email";
            this.ResumeLayout(false);
        }
    }
}
