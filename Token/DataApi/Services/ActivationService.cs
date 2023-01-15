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

            bool result;

            if (credentials.CustomerPin is null)
            {
                result = false;
            }
            else
            {
                _communicationService.SendEmail(credentials.CustomerPin, emailModel);

                result = true;
            }

            return result;
        }

        public void ActivateTroughSMS()
        {



        }
    }
}
