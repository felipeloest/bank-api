using Bank.Application.CommandStack.Interfaces;
using Bank.Domain.Repositories;

namespace Bank.Application.CommandStack
{
    public class ResetAppService : IResetAppService
    {
        private readonly IAccountRepository _accountRepository;

        public ResetAppService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task ResetAsync()
        {
            await _accountRepository.Reset();
        }
    }
}
