using DataApi.Modeles;

namespace DataApi.Services
{
    public interface ICommunicationService
    {
        void SendEmail(string content, EmailModel emailModel);
        void SendSMS();
    }
}