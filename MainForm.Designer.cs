namespace GmailStyleWinFormsApp
{
    partial class MainForm
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

        //protected override void Dispose(bool disposing)
        //{
            //if (disposing && (components != null)) components.Dispose();
          //  base.Dispose(disposing);
        //}

        private void InitializeComponent()
        {
            private void InitializeComponent()
        {
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lstInbox = new System.Windows.Forms.ListBox();
            this.txtEmailDetail = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.RowCount = 9;
            for (int i = 0; i < 9; i++)
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));

            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Padding = new Padding(10);

            // txtFrom
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtFrom, 0, 0);
            this.tableLayoutPanel.SetColumnSpan(txtFrom, 3);

            // txtPassword
            this.txtPassword.ReadOnly = true;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtPassword, 0, 1);
            this.tableLayoutPanel.SetColumnSpan(txtPassword, 3);

            // txtTo
            this.txtTo.PlaceholderText = "Địa chỉ người nhận";
            this.txtTo.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtTo, 0, 2);
            this.tableLayoutPanel.SetColumnSpan(txtTo, 3);

            // txtSubject
            this.txtSubject.PlaceholderText = "Tiêu đề email";
            this.txtSubject.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtSubject, 0, 3);
            this.tableLayoutPanel.SetColumnSpan(txtSubject, 3);

            // txtBody
            this.txtBody.Multiline = true;
            this.txtBody.PlaceholderText = "Soạn nội dung email...";
            this.txtBody.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtBody, 0, 4);
            this.tableLayoutPanel.SetColumnSpan(txtBody, 3);
            this.tableLayoutPanel.RowStyles[4].Height = 100;

            // Buttons: Attach, Send, Receive
            this.btnAttach.Text = "📎 Đính kèm";
            this.btnSend.Text = "✉️ Gửi";
            this.btnReceive.Text = "📥 Nhận Email";

            this.btnAttach.Dock = DockStyle.Fill;
            this.btnSend.Dock = DockStyle.Fill;
            this.btnReceive.Dock = DockStyle.Fill;

            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);

            this.tableLayoutPanel.Controls.Add(btnAttach, 0, 5);
            this.tableLayoutPanel.Controls.Add(btnSend, 1, 5);
            this.tableLayoutPanel.Controls.Add(btnReceive, 2, 5);

            // lstInbox
            this.lstInbox.Dock = DockStyle.Fill;
            this.lstInbox.SelectedIndexChanged += new System.EventHandler(this.lstInbox_SelectedIndexChanged);
            this.tableLayoutPanel.Controls.Add(lstInbox, 0, 6);
            this.tableLayoutPanel.SetColumnSpan(lstInbox, 3);
            this.tableLayoutPanel.RowStyles[6].Height = 100;

            // txtEmailDetail
            this.txtEmailDetail.Multiline = true;
            this.txtEmailDetail.ReadOnly = true;
            this.txtEmailDetail.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(txtEmailDetail, 0, 7);
            this.tableLayoutPanel.SetColumnSpan(txtEmailDetail, 3);
            this.tableLayoutPanel.RowStyles[7].Height = 100;

            // Add panel to form
            this.Controls.Add(this.tableLayoutPanel);

            // Form
            this.Text = "Gửi & Nhận Email - Gmail Style";
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);
        }
    }
}