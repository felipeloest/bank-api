using Bank.Domain;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bank.Data.Domain
{
    public class AccountRepository : IAccountRepository
    {
        protected readonly ILogger<AccountRepository> _logger;
        private readonly Context _context;
        private readonly DbSet<Account> _dbSet;


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

        public async Task<bool> CreateAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddAsync(aggregate, cancellationToken);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Account aggregate, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.Update(aggregate);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> Reset(CancellationToken cancellationToken = default)
        {
            var items = await _dbSet.ToListAsync(cancellationToken);
            _dbSet.RemoveRange(items);

            await _dbSet.AddAsync(new Account { Id = 300, Balance = 0 }, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
