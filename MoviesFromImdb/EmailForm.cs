using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesFromImdb
{
    public partial class EmailForm : Form
    {
        public EmailForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSendEmail.Text))
            {
                MessageBox.Show("Please enter friend's email!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("yourgmail@gmail.com");
                mail.To.Add(tbSendEmail.Text);
                mail.Subject = "My wishlist";
                mail.Body = "Look at my wishlist in the attachment";

                System.Net.Mail.Attachment attachment;
                if (!File.Exists(@"C:\Users\your\Documents\My_Wishlist.xls"))
                {
                    MessageBox.Show("Please make wishlist first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                attachment = new System.Net.Mail.Attachment(@"C:\Users\your\Documents\My_Wishlist.xls");
                mail.Attachments.Add(attachment);
                

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("yourgmail@gmail.com", "yourpass");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                MessageBox.Show("Email sent!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally  
            {

                tbSendEmail.Clear();
                tbSendEmail.Focus();

            }

          
        }
    }
}
