using hangi_kredi_restful.Models;
using hangi_kredi_restful.Entities;
using AutoMapper;

namespace hangi_kredi_restful.Mapping
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>();
            CreateMap<LoanDto, Loan>();
        }
    }
}
