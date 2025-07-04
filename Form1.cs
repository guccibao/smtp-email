using System;
using System.IO;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;

namespace GmailStyleWinFormsApp
{
    public partial class Form1 : Form
    {
        private string attachedFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = dialog.FileName;
                btnAttach.Text = $"📎 {Path.GetFileName(attachedFilePath)}";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(txtFrom.Text));
                message.To.Add(MailboxAddress.Parse(txtTo.Text));
                message.Subject = txtSubject.Text;

                var builder = new BodyBuilder { TextBody = txtBody.Text };
                if (!string.IsNullOrEmpty(attachedFilePath))
                    builder.Attachments.Add(attachedFilePath);

                message.Body = builder.ToMessageBody();

                using var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(txtFrom.Text, txtPassword.Text);
                client.Send(message);
                client.Disconnect(true);

                MessageBox.Show("Đã gửi email thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email:\n" + ex.Message);
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                using var client = new ImapClient();
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(txtFrom.Text, txtPassword.Text);

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);
                lstInbox.Items.Clear();

                for (int i = inbox.Count - 1; i >= 0 && i > inbox.Count - 21; i--)
                {
                    var msg = inbox.GetMessage(i);
                    lstInbox.Items.Add(msg.Subject);
                }

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận email:\n" + ex.Message);
            }
        }

        private void lstInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using var client = new ImapClient();
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(txtFrom.Text, txtPassword.Text);

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                int index = inbox.Count - lstInbox.SelectedIndex - 1;
                var message = inbox.GetMessage(index);

                txtEmailDetail.Text =
                    $"Từ: {message.From}\r\n" +
                    $"Tiêu đề: {message.Subject}\r\n" +
                    $"Ngày: {message.Date}\r\n" +
                    $"Nội dung:\r\n{message.TextBody}";

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                txtEmailDetail.Text = "Lỗi khi xem nội dung: " + ex.Message;
            }
        }
    }
}
