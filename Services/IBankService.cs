using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Services
{
    public interface IBankService
    {
        BankReturnType GetBanks(int currentPage, int perPage);
        BankDto GetBankById(int id);
        BankDto CreateBank(BankDto bank);
        BankDto UpdateBank(int id, BankDto updatedBank);
        BankDto DeleteBank(int id);
    }
}
