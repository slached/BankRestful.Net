using hangi_kredi_restful.Models;
using hangi_kredi_restful.Entities;
using AutoMapper;

namespace hangi_kredi_restful.Mapping
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<BankDto, Bank>();
        }
    }
}
