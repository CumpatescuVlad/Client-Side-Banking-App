using DataApi.Modeles;
using DataApi.src;

namespace DataApi.Services
{
    public class ActivationService : IActivationService
    {
        private readonly ICredentials _credentials;
        private readonly ICommunicationService _communicationService;
        public ActivationService(ICredentials credentials, ICommunicationService communicationService)
        {
            _credentials = credentials;
            _communicationService = communicationService;
        }

        public bool EmailSentSuccesfully(EmailModel emailModel)
        {
            var credentials = _credentials.ReadUserCredentials(emailModel.CustomerName);

            bool emailSent;

            if (credentials.CustomerPin is null)
            {
                emailSent = false;
            }
            else
            {
                _communicationService.SendEmail(credentials.CustomerPin, emailModel);

                emailSent = true;
            }

            return emailSent;
        }

        public bool SmsSentSuccesfully(SmsModel smsModel)
        {
            var credentials = _credentials.ReadUserCredentials(smsModel.CustomerName);

            bool smsSent;

            if (credentials.CustomerPin is null)
            {
                smsSent = false;
            }
            else
            {
                _communicationService.SendSMS($"Activation Pin:{credentials.CustomerPin}", smsModel);

                smsSent = true;
            }

            return smsSent;
        }
    }
}
