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

        public async Task<IEnumerable<Loan>> GetLoans()
        {
            return await _context.Loans.ToListAsync();
        }
    }
}
