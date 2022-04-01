using Bank.Domain;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bank.Data.Domain
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ILogger<AccountRepository> _logger;
        protected Context _context { get; }
        protected DbSet<Account> _dbSet { get; }


        public AccountRepository(Context context, ILogger<AccountRepository> logger)
        {
            _logger = logger;
            _context = context;
            _dbSet = _context.Set<Account>();
        }

        public virtual async Task<Account?> FindAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<int> CreateAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddAsync(aggregate, cancellationToken);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.Update(aggregate);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<int> Reset(CancellationToken cancellationToken = default)
        {
            var items = await _dbSet.ToListAsync();
            _dbSet.RemoveRange(items);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
