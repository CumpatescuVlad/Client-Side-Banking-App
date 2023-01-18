using DataApi.Modeles;

namespace DataApi.Services
{
    public interface IActivationService
    {
        bool SmsSentSuccesfully(SmsModel smsModel);
        bool EmailSentSuccesfully(EmailModel emailModel);
    }
}