using Bank.ApiModels.CommandModels.Event;
using Bank.ApiModels.QueryModels.Balance;

namespace Bank.Application.CommandStack.Interfaces
{
    public interface IAccountAppService
    {
        Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request);
        Task<InsertBalance.Response> DepositAsync(InsertBalance.Request request);
    }
}
