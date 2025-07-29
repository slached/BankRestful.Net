using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Services
{
    public interface IBankService
    {
        Task<BankReturnType> GetBanks(int currentPage, int perPage);
        Task<BankDto> GetBankById(int id);
        Task<BankDto> CreateBank(BankDto bank);
        Task<BankDto> UpdateBank(int id, BankDto updatedBank);
        Task<BankDto> DeleteBank(int id);
    }
}
