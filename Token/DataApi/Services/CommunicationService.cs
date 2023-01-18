using DataApi.Modeles;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;

namespace DataApi.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly MimeMessage mimeMessage = new();
        private readonly SmtpClient emailClient = new();
        private readonly HttpClient httpClient = new();

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

        public HttpStatusCode SendSMS(string content, SmsModel smsModel)
        {
            var request = httpClient.GetAsync($"https://platform.clickatell.com/messages/http/send?apiKey=fhlOJRDERgqU2bTDhyWM_Q==&to=4{smsModel.ReciverPhoneNumber}&content={content}").Result;

            return request.StatusCode;
        }

    }
}
