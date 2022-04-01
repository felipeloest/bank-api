using Bank.ApiModels.CommandModels.Event;
using Bank.ApiModels.QueryModels.Balance;

namespace Bank.Application.CommandStack.Interfaces
{
    public interface IAccountAppService
    {
        Task<GetAccountBalance.Response> GetBalanceAsync(GetAccountBalance.Request request);
        Task<Deposit.Response> DepositAsync(Deposit.Request request);

        Task<Withdraw.Response> WithdrawAsync(Withdraw.Request request);
        Task<Transfer.Response> TransferAsync(Transfer.Request request);
    }
}
