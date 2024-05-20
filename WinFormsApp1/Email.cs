using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Email 
    {
        public int code;
        private string adress;
        private string name;


        public Email(string adress, string name)
        {
            this.adress = adress;
            this.name = name;
            Initialize();
        }

        private void Initialize()
        {
            Random rand = new Random();
            int verificationCode = rand.Next(1000, 10000);
            code = verificationCode;


            try
            {
                  
                var fromAddress = new MailAddress("email", "NOTFLIX");
                var toAddress = new MailAddress(adress, name);
                const string fromPassword = "password";
                const string subject = "Password reset verification";
                string body = $"Your verification code is: {verificationCode}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                //MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Error: {ex.Message}");
            }
        }
    }
}
