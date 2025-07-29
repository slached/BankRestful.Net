using hangi_kredi_restful.Data;
using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;
using Microsoft.EntityFrameworkCore;

namespace hangi_kredi_restful.Repository
{
    public class LoanRepository : ILoanRepository
    {
        public readonly AppDbContext _context;
        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateLoan(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoans(int id)
        {
            return await _context.Loans.Where(loan => loan.BankId == id).ToListAsync();
        }
    }
}
