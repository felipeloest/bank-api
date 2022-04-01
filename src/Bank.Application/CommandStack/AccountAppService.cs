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

        public async Task<CreateAccount.Response> CreateAsync(CreateAccount.Request request)
        {
            var response = new CreateAccount.Response();
            var result = new Account { Balance = request.InitialBalance, Id = request.Id };
            await _accountRepository.CreateAsync(result);

            response.StatusCode = 201;
            response.Data = new { result.Balance };
            return response;
        }

        public async Task<InsertBalance.Response> DepositAsync(InsertBalance.Request request)
        {
            var response = new InsertBalance.Response();
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                var account = await CreateAsync(new CreateAccount.Request { Id = request.Id, InitialBalance = request.Amount });

                response.StatusCode = 201;
                response.Data = new { account.Balance };
                return response;
            }

            result.Balance += request.Amount;

            await _accountRepository.UpdateAsync(result);

            response.StatusCode = 201;
            response.Data = new { result.Balance };
            return response;
        }

        public async Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request)
        {
            var resposse = new GetAccountBalance.Response { StatusCode = 200 };
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                resposse.StatusCode = 404;
            }

            resposse.Data = result?.Balance ?? 0;
            return resposse;
        }
    }
}
