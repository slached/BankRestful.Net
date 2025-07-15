using AutoMapper;
using hangi_kredi_restful.Models;
using hangi_kredi_restful.Repository;
using hangi_kredi_restful.Entities;

namespace hangi_kredi_restful.Services
{
    public class BankService : IBankService
    {
        private readonly ILogger<BankService> _logger;
        public readonly IBankRepository bankRepository;
        public readonly IMapper mapper;

        public BankService(ILogger<BankService> logger, IBankRepository bankRepository_, IMapper mapper_)
        {
            bankRepository = bankRepository_;
            _logger = logger;
            mapper = mapper_;
        }

        public BankDto CreateBank(BankDto bank)
        {
            // convert dto to entity
            Bank bankAsEntity = mapper.Map<Bank>(bank);
            // send entity to repo also repo returns as entity so we need to reconvert this into dto
            BankDto newBankAsDto = mapper.Map<BankDto>(bankRepository.CreateBank(bankAsEntity));
            return newBankAsDto;
        }

        public BankDto DeleteBank(int id)
        {
            // first look is there bank by this id
            Bank? bank = bankRepository.FindBankById(id);
            return bank == null ? throw new Exception($"bank {id} could not founded.") : mapper.Map<BankDto>(bankRepository.DeleteBank(bank));

        }

        public BankDto GetBankById(int id)
        {
            Bank? bank = bankRepository.FindBankById(id);
            return bank == null ? throw new Exception($"bank {id} could not founded.") : mapper.Map<BankDto>(bank);
        }

        public BankReturnType GetBanks(int currentPage, int perPage)
        {
            int totalBankAmount = bankRepository.CountBankAmount();

            BankReturnType formattedBankItems = new()
            {
                TotalItem = totalBankAmount,
                Banks = [],
                NextPage = (currentPage + 1) * perPage < totalBankAmount ? currentPage + 1 : null,
                PreviousPage = currentPage != 0 ? currentPage - 1 : null
            };

            var banks = bankRepository.GetBanks(currentPage, perPage).ToList();
            banks.ForEach(bank =>
            {
                // convert items to dto from entity and add into formattedBankItems's banks
                formattedBankItems.Banks?.Add(mapper.Map<BankDto>(bank));
            });

            return formattedBankItems;

        }

        public BankDto UpdateBank(int id, BankDto updatedBank)
        {
            Bank? bank = bankRepository.FindBankById(id);
            return bank == null ? throw new Exception($"bank {id} could not founded.") : mapper.Map<BankDto>(bankRepository.UpdateBank(bank, updatedBank));

        }
    }
}
