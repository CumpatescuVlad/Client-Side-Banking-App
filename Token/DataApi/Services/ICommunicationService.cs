using DataApi.Modeles;
using System.Net;

namespace DataApi.Services
{
    public interface ICommunicationService
    {
        void SendEmail(string content, EmailModel emailModel);
        HttpStatusCode SendSMS(string content, SmsModel smsModel);
    }
}