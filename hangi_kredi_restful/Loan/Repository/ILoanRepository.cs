using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Repository
{
    public interface ILoanRepository
    {
        public Task<IEnumerable<Loan>> GetLoans(int id);
        public Task CreateLoan(Loan loan);
    }
}
