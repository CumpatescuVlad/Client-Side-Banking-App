using DataApi.Modeles;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;

namespace DataApi.src
{
    public class CommunicationProvider : ICommunicationProvider
    {
        private readonly MimeMessage mimeMessage = new();
        private readonly SmtpClient emailClient = new();
        private readonly HttpClient httpClient = new();
        private readonly ILogger<CommunicationProvider> _logger;
        public CommunicationProvider(ILogger<CommunicationProvider> logger)
        {
            _logger = logger;
        }

        public HttpStatusCode SendEmail(string content, EmailModel emailModel)
        {
            HttpStatusCode statusCode;

            mimeMessage.From.Add(new MailboxAddress(emailModel.SenderName, emailModel.SenderAdress));

            mimeMessage.To.Add(MailboxAddress.Parse(emailModel.ReciverAdress));

            mimeMessage.Subject = emailModel.Subject;

            mimeMessage.Body = new TextPart("plain")
            {
                Text = content
            };
            try
            {
                emailClient.Connect("smtp-relay.sendinblue.com", 587, SecureSocketOptions.StartTls);

                emailClient.Authenticate(emailModel.AuthentificationEmail, emailModel.AuthentificationPassword);

                emailClient.Send(mimeMessage);

                return statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return statusCode = HttpStatusCode.InternalServerError;

            }
            finally
            {
                emailClient.Disconnect(true);

            }

        }

        public HttpStatusCode SendSMS(string content, SmsModel smsModel)
        {
            try
            {
                var request = httpClient.GetAsync($"https://platform.clickatell.com/messages/http/send?apiKey=fhlOJRDERgqU2bTDhyWM_Q==&to=4{smsModel.ReciverPhoneNumber}&content={content}").Result;

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return HttpStatusCode.InternalServerError;

            }

        }

    }
}
