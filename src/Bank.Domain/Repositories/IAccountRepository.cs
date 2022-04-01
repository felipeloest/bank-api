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
        //Task<IList<Account>> ListAsync(CancellationToken cancellationToken = default);

        Task<int> CreateAsync(Account aggregate, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(Account aggregate, CancellationToken cancellationToken = default);

        Task<int> Reset(CancellationToken cancellationToken = default);
    }
}
