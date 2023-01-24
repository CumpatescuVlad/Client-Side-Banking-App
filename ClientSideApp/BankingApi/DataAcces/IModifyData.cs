using BankingApi.DTO;
using BankingApi.Models;
using System.Net;

namespace BankingApi.DataAcces
{
    public interface IModifyData
    {
        HttpStatusCode InsertTransaction(TransferModel transferModel);
        HttpStatusCode UpdateBallance(TransferModel transferModel);
    }
}