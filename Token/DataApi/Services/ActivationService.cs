using DataApi.Modeles;
using DataApi.src;


namespace DataApi.Services
{
    public class ActivationService : IActivationService
    {
        private readonly ICredentialsProvider _credentials;
        private readonly ICommunicationProvider _communicationService;
        public ActivationService(ICredentialsProvider credentials, ICommunicationProvider communicationService)
        {
            _credentials = credentials;
            _communicationService = communicationService;
        }

        public bool EmailSentSuccesfully(EmailModel emailModel)
        {
            var credentials = _credentials.ReadUserCredentials(emailModel.CustomerName);
            bool status;

            if (credentials.CustomerPin is not null && _communicationService.SendEmail(credentials.CustomerPin, emailModel) is System.Net.HttpStatusCode.OK)
            {
                status = true;
            }
            else
            {
                status = false;

            }

            return status;
        }

        public bool SmsSentSuccesfully(SmsModel smsModel)
        {
            var credentials = _credentials.ReadUserCredentials(smsModel.CustomerName);

            bool smsSent;

            if (credentials.CustomerPin is not null && _communicationService.SendSMS($"Activation Pin:{credentials.CustomerPin}", smsModel) is System.Net.HttpStatusCode.OK)
            {
                smsSent = true;
            }
            else
            {
                smsSent = false;
            }

            return smsSent;
        }
    }
}
