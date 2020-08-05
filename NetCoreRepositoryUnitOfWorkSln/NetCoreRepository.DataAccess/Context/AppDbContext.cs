using Microsoft.EntityFrameworkCore;
using NetCoreRepository.DataAccess.Domain;

namespace NetCoreRepository.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext() { }
    }
}
