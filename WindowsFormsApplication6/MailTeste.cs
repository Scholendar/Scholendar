using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApplication6
{
    public partial class MailTeste : Form
    {
        public MailTeste()
        {
            InitializeComponent();
        }

        private void MailTeste_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("scholendar@gmail.com");
                mail.To.Add(textBox1.Text);
                mail.Subject = textBox2.Text;
                mail.Body = textBox3.Text + Environment.NewLine + "Ola";

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(lblLocation.Text);
                //mail.Attachments.Add(attachment);

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("scholendar@gmail.com", "Teste123");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Email Enviado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
