using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SendEmailFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            string to, from, pass, mail;
            to=(txtreceiver.Text).ToString();
            from = (txtsenemail.Text).ToString();
            mail = (txtmail.Text).ToString();
            pass = (txtpass.Text).ToString();
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = mail;
            message.Subject = "Testing Mail";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Email send successfuly", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            //string txtpass = "qkdvsxiojgpadgvk";
        }
    }
}