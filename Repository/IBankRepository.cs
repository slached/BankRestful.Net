using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Repository
{
    public interface IBankRepository
    {
        public IEnumerable<Bank> GetBanks(int currentPage = 0, int perPage = 10);
        public Bank CreateBank(Bank bank);
        public Bank FindBankById(int id);
        public Bank DeleteBank(Bank bank);
        public Bank UpdateBank(Bank bank, BankDto updatedBank);
        public int CountBankAmount();
    }
}
