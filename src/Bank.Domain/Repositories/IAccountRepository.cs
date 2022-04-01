namespace Bank.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> FindAsync(int id);
        //Task<IList<Account>> ListAsync(CancellationToken cancellationToken = default);

        Task<bool> CreateAsync(Account aggregate, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Account aggregate, CancellationToken cancellationToken = default);

        Task<bool> Reset(CancellationToken cancellationToken = default);
    }
}
