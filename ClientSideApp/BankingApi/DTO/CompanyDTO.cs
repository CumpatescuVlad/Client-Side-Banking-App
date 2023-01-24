namespace BankingApi.DTO
{
    public class CompanyDTO
    {
        public CompanyDTO(List<string>? companyName, List<string>? companyService, List<string>? companyIBAN)
        {
            CompanyName = companyName;
            CompanyService = companyService;
            CompanyIBAN = companyIBAN;
        }
       
        public List<string>? CompanyName { get; private set; }
        public List<string>? CompanyService { get; private set; }
        public List<string>? CompanyIBAN { get; private set; }

    }
}
