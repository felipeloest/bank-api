using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> FindAsync(int id, CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<Account>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task SaveAsync(Account aggregate, CancellationToken cancellationToken = default(CancellationToken));

        Task UpdateAsync(Account aggregate, CancellationToken cancellationToken = default(CancellationToken));
    }
}
