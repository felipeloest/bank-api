using Bank.ApiModels.CommandModels.Event;
using Bank.ApiModels.QueryModels.Balance;
using Bank.Application.CommandStack.Interfaces;
using Bank.Domain;
using Bank.Domain.Repositories;

namespace Bank.Application.CommandStack
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountAppService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<Deposit.Response> CreateAsync(Deposit.Request request)
        {
            var response = new Deposit.Response();
            var item = new Account { Balance = request.Amount, Id = request.Id };
            response.Success = await _accountRepository.CreateAsync(item);

            response.Balance = item.Balance;
            response.Id = item.Id;

            return response;
        }

        public async Task<Deposit.Response> DepositAsync(Deposit.Request request)
        {
            var response = new Deposit.Response();
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                var account = await CreateAsync(request);
                return account;
            }

            result.Balance += request.Amount;

            response.Success = await _accountRepository.UpdateAsync(result);

            response.Balance = result.Balance;
            response.Id = result.Id;

            return response;
        }

        public async Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request)
        {
            var resposse = new GetAccountBalance.Response();
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                resposse.Success = false;
                return resposse;
            }

            resposse.Success = true;
            resposse.Id = request.Id;
            resposse.Balance = result?.Balance ?? 0;
            return resposse;
        }

        public async Task<Transfer.Response> TransferAsync(Transfer.Request request)
        {
            var response = new Transfer.Response();
            var source = await _accountRepository.FindAsync(request.SourceId);
            if (source == null)
            {
                response.Success = false;
                return response;
            }

            var target = await _accountRepository.FindAsync(request.TargetId);
            if (target == null)
            {
                response.Success = false;
                return response;
            }

            source.Balance -= request.Amount;
            target.Balance += request.Amount;

            response.Success = await _accountRepository.UpdateAsync(source);
            response.Success = await _accountRepository.UpdateAsync(target);

            response.SourceId = source.Id;
            response.SourceBalance = source.Balance;

            response.TargetId = target.Id;
            response.TargetBalance = target.Balance;


            return response;
        }

        public async Task<Withdraw.Response> WithdrawAsync(Withdraw.Request request)
        {
            var response = new Withdraw.Response();
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                response.Success = false;
                return response;
            }

            result.Balance -= request.Amount;

            response.Success = await _accountRepository.UpdateAsync(result);

            response.Balance = result.Balance;
            response.Id = result.Id;

            return response;
        }
    }
}
