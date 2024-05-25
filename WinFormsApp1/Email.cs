using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Email
    {
        public int Code { get; private set; }
        private readonly string _address;
        private readonly string _name;

        public Email(string address, string name)
        {
            _address = address;
            _name = name;
            Initialize();
        }

        private void Initialize()
        {
            Code = GenerateVerificationCode();
            try
            {
                SendEmail(_address, _name, Code);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Error: {ex.Message}");
            }
        }

        private int GenerateVerificationCode()
        {
            Random rand = new Random();
            return rand.Next(1000, 10000);
        }

        private void SendEmail(string toAddress, string toName, int verificationCode)
        {
            string fromAddress = "big802240@gmail.com";
            string fromName = "Notflix";
            string fromPassword = "tzix uyio cfje erjo";
            string subject = "Password reset verification";
            string body = $"Your verification code is: {verificationCode}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };

            using (var message = new MailMessage(new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName))
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
