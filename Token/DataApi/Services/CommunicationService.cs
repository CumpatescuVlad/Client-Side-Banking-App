using DataApi.Modeles;
using DataApi.src;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace DataApi.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly MimeMessage mimeMessage = new();
        private readonly SmtpClient emailClient = new();

        public void SendEmail(string content, EmailModel emailModel)
        {
            mimeMessage.From.Add(new MailboxAddress(emailModel.SenderName, emailModel.SenderAdress));

            mimeMessage.To.Add(MailboxAddress.Parse(emailModel.ReciverAdress));

            mimeMessage.Subject = emailModel.Subject;

            mimeMessage.Body = new TextPart("plain")
            {
                Text = content
            };

            emailClient.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);

            emailClient.Authenticate(emailModel.AuthentificationEmail, emailModel.AuthentificationPassword);

            emailClient.Send(mimeMessage);

            emailClient.Disconnect(true);

        }

        public void SendSMS()
        {



        }

    }
}
