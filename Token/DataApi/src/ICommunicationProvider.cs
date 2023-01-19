using DataApi.Modeles;
using System.Net;

namespace DataApi.src
{
    public interface ICommunicationProvider
    {
        HttpStatusCode SendEmail(string content, EmailModel emailModel);
        HttpStatusCode SendSMS(string content, SmsModel smsModel);
    }
}