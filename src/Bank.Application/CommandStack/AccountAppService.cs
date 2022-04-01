using Bank.ApiModels.QueryModels.Balance;
using Bank.Application.CommandStack.Interfaces;
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

        public async Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request)
        {
            var resposse = new GetAccountBalance.Response();
            var result = await _accountRepository.FindAsync(request.Id);
            if (result == null)
            {
                resposse.StatusCode = 404;
                resposse.Data = 0;
                return resposse;
            }

            resposse.Data = new { result.Balance };
            return resposse;
        }
    }
}
