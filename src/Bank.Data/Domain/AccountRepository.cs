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

        public virtual async Task<Account?> FindAsync(int id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
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
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public virtual Task UpdateAsync(Account aggregate)
        {
            try
            {
                DbSet.Update(aggregate);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Task DeleteAsync(Account aggregate)
        {
            DbSet.Remove(aggregate);
            return Task.CompletedTask;
        }

        public Task<IList<Account>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
