using Bank.ApiModels.QueryModels;

namespace Bank.Application.CommandStack.Interfaces
{
    public interface IAccountAppService
    {
        Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request);
    }
}
