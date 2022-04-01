using Bank.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.UseSeed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
