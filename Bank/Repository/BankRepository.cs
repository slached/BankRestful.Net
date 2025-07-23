using hangi_kredi_restful.Data;
using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;
using Microsoft.EntityFrameworkCore;
 
namespace hangi_kredi_restful.Repository
{
    public class BankRepository : IBankRepository
    {
        public readonly AppDbContext _context;
        public BankRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountBankAmount()
        {
            return await _context.Banks.CountAsync();
        }

        public async Task<Bank> CreateBank(Bank bank)
        {
            await _context.Banks.AddAsync(bank);
            await _context.SaveChangesAsync();
            return bank;
        }

        public async Task<Bank> DeleteBank(Bank bank)
        {
            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();
            return bank;
        }

        public async Task<Bank> FindBankById(int id)
        {
#pragma warning disable CS8603
            return await _context.Banks.FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task<IEnumerable<Bank>> GetBanks(int currentPage, int perPage)
        {
            return await _context.Banks
        .OrderBy(b => b.Id)
        .Skip(currentPage * perPage)
        .Take(perPage)
        .ToListAsync();
        }

        public async Task<Bank> UpdateBank(Bank bank, BankDto updatedBank)
        {
            _context.Banks.Attach(bank);

            bank.UpdatedAt = DateTime.UtcNow;
            bank.Name = updatedBank.Name;

            _context.Entry(bank).Property(e => e.Name).IsModified = true;
            _context.Entry(bank).Property(e => e.UpdatedAt).IsModified = true;

            await _context.SaveChangesAsync();

            return bank;
        }
    }
}
