using hangi_kredi_restful.Entities;
using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Services
{
    public interface ILoanService
    {
        Task<LoanReturnType> GetLoans(int id);
        Task CreateLoan(Loan loan);
    }
}
