using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> FindAsync(int id);

        Task<IList<Account>> GetAllAsync(CancellationToken cancellationToken = default);

        Task SaveAsync(Account aggregate, CancellationToken cancellationToken = default);

        Task UpdateAsync(Account aggregate);
    }
}
