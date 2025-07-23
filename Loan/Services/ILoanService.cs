using hangi_kredi_restful.Models;

namespace hangi_kredi_restful.Services
{
    public interface ILoanService
    {
        Task<LoanReturnType> GetBanks(int id);
    }
}
