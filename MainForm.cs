using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace GmailStyleWinFormsApp
{
    public partial class MainForm : Form
    {
        private string userEmail;
        private string userPassword;
        private string attachmentPath = "";

        public MainForm(string email, string password)
        {
            InitializeComponent();
            userEmail = email;
            userPassword = password;

            txtFrom.Text = userEmail;
            txtPassword.Text = userPassword;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                attachmentPath = ofd.FileName;
                MessageBox.Show("Đã chọn file: " + attachmentPath);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(userEmail, txtTo.Text);
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    mail.Attachments.Add(new Attachment(attachmentPath));
                }

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(userEmail, userPassword);
                client.Send(mail);

                MessageBox.Show("Gửi email thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message);
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(userEmail, userPassword);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    lstInbox.Items.Clear();
                    for (int i = inbox.Count - 1; i >= Math.Max(0, inbox.Count - 10); i--)
                    {
                        var message = inbox.GetMessage(i);
                        lstInbox.Items.Add(message.Subject);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận email: " + ex.Message);
            }
        }

        private void lstInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lstInbox.SelectedIndex;
                if (index < 0) return;

                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(userEmail, userPassword);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    int realIndex = inbox.Count - 1 - index;
                    var message = inbox.GetMessage(realIndex);
                    txtEmailDetail.Text =
                    $"From: {message.From}{Environment.NewLine}" +
                    $"Subject: {message.Subject}{Environment.NewLine}{Environment.NewLine}" +
                    $"{message.TextBody}";

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                txtEmailDetail.Text = "Lỗi đọc nội dung: " + ex.Message;
            }
        }
    }
}