namespace BankingApi.Services
{
    public interface IDownloadService
    {
        byte[] DownloadPdfStatement();
        byte[] DownloadWordStatement();
    }
}