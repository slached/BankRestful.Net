using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Repository
{
    public interface IBankRepository
    {
        public Task<IEnumerable<Bank>> GetBanks(int currentPage = 0, int perPage = 10);
        public Task<Bank> CreateBank(Bank bank);
        public Task<Bank> FindBankById(int id);
        public Task<Bank> DeleteBank(Bank bank);
        public Task<Bank> UpdateBank(Bank bank, BankDto updatedBank);
        public Task<int> CountBankAmount();
    }
}
