namespace BankingApi.DTO
{
    public class CompanyDTO
    {
        public CompanyDTO(string? companyName, string? companyService, string? companyIBAN)
        {
            CompanyName = companyName;
            CompanyService = companyService;
            CompanyIBAN = companyIBAN;
        }

        public string? CompanyName { get; set; }
        public string? CompanyService { get; set; }
        public string? CompanyIBAN { get; set; }

    }
}
