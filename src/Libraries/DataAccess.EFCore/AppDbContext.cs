using Microsoft.EntityFrameworkCore;
using DataAccess.EFCore.Entities;

namespace DataAccess.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<IdempotentRequest> IdempotentRequests => Set<IdempotentRequest>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
