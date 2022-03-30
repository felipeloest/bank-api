using Bank.Application.CommandStack.Interfaces;

namespace Bank.Application.CommandStack
{
    public class ResetAppService : IResetAppService
    {
        public Task ResetAsync()
        {
            return Task.CompletedTask;
        }
    }
}
