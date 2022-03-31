using Bank.Domain;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bank.Data.Domain
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ILogger<AccountRepository> Logger;
        protected Context Context { get; }
        protected DbSet<Account> DbSet { get; }


        public AccountRepository(Context context, ILogger<AccountRepository> logger)
        {
            Logger = logger;
            Context = context;
            DbSet = Context.Set<Account>();
        }

        public virtual async Task<Account> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await DbSet.FindAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao consultar objeto no repositório");
                throw;
            }
        }

        public virtual async Task SaveAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                await DbSet.AddAsync(aggregate, cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao salvar objeto no repositório");
                throw;
            }
        }

        public virtual Task UpdateAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                DbSet.Update(aggregate);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao atualizar objeto no repositório");
                throw;
            }
        }

        public Task DeleteAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            Context.Set<Account>().Remove(aggregate);
            return Task.CompletedTask;
        }

        public Task<IList<Account>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
