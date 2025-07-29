using AutoMapper;
using hangi_kredi_restful.Models;
using hangi_kredi_restful.Repository;
using hangi_kredi_restful.Entities;

namespace hangi_kredi_restful.Services;

public class LoanService : ILoanService
{
    public readonly ILoanRepository loanRepository;
    public readonly IMapper mapper;

    public LoanService(ILoanRepository _loanRepository, IMapper _mapper)
    {
        loanRepository = _loanRepository;
        mapper = _mapper;
    }

    public async Task CreateLoan(Loan loan)
    {
       await loanRepository.CreateLoan(loan);
    }

    public async Task<LoanReturnType> GetLoans(int id)
    {
        LoanReturnType loanReturnType = new() { Loans = [] };
        List<Loan> loans = (await loanRepository.GetLoans(id)).ToList();

        loans.ForEach(loan =>
        {
            loanReturnType.Loans.Add(mapper.Map<LoanDto>(loan));
        });

        return loanReturnType;
    }
}
