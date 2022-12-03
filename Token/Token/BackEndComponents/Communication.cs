using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;

namespace Token.BackEndComponents
{
    public class Communication
    {
        #region Objects
        private readonly WebClient client = new();
        private readonly MimeMessage message = new();
        private readonly SmtpClient emailClient = new();
        #endregion

        public void SendSMS(string phoneNumber, string content)
        {
            Stream stream = client.OpenRead(string.Format(Data.SMSApi(phoneNumber, content)));

            var reader = new StreamReader(stream);

            Temp.CreateFile("SmsResponseCode.json", $"{reader.ReadToEnd()}");

        }


        public void SendEmail(string reciverEmail, string customerPassword)
        {
            message.From.Add(new MailboxAddress("BANK-APP", "cumpatescuvlad@yahoo.com"));

            message.To.Add(MailboxAddress.Parse(reciverEmail));

            message.Subject = "APP ACTIVATION";

            message.Body = new TextPart("plain")
            {
                Text = $"Your Password Is:{customerPassword}"
            };

            emailClient.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);

            emailClient.Authenticate("Cumpatescuvlad@yahoo.com", "3ANj6M2JskzQG4cX");

            emailClient.Send(message);

        }


    }

}
