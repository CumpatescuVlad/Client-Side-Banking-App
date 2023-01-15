using DataApi.Modeles;

namespace DataApi.Services
{
    public interface IActivationService
    {
        void ActivateTroughSMS();
        bool EmailSentSuccesfully(EmailModel emailModel);
    }
}