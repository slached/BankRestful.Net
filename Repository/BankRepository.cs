using hangi_kredi_restful.Data;
using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Repository
{
    public class BankRepository : IBankRepository
    {
        public readonly AppDbContext _context;
        public BankRepository(AppDbContext context)
        {
            _context = context;
        }

        public int CountBankAmount()
        {
            return _context.Banks.Count();
        }

        public Bank CreateBank(Bank bank)
        {
            _context.Banks.Add(bank);
            _context.SaveChanges();
            return bank;
        }

        public Bank DeleteBank(Bank bank)
        {
            _context.Banks.Remove(bank);
            _context.SaveChanges();
            return bank;
        }

        public Bank FindBankById(int id)
        {
#pragma warning disable CS8603
            return _context.Banks.FirstOrDefault(b => b.Id == id);

        }

        public IEnumerable<Bank> GetBanks(int currentPage, int perPage)
        {
            return _context.Banks
        .OrderBy(b => b.Id)
        .Skip(currentPage * perPage)
        .Take(perPage)
        .ToList();
        }

        public Bank UpdateBank(Bank bank, BankDto updatedBank)
        {
            _context.Banks.Attach(bank);

            bank.UpdatedAt = DateTime.UtcNow;
            bank.Name = updatedBank.Name;

            _context.Entry(bank).Property(e => e.Name).IsModified = true;
            _context.Entry(bank).Property(e => e.UpdatedAt).IsModified = true;

            _context.SaveChanges();

            return bank;
        }
    }
}
