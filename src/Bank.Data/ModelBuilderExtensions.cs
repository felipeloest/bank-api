using Bank.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data
{
    public static class ModelBuilderExtensions
    {
        public static void UseSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account { Id = 1 });
        }
    }
}
