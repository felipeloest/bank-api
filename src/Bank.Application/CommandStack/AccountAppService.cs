using Bank.ApiModels.QueryModels;
using Bank.Application.CommandStack.Interfaces;

namespace Bank.Application.CommandStack
{
    public class AccountAppService : IAccountAppService
    {
        public Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request)
        {
            throw new NotImplementedException();
        }
    }
}
