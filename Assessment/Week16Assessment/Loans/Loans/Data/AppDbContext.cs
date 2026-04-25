
using Loans.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Loans.Models;
namespace Loans.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoanApplication> Loans { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new LoanConfig().Configure(modelBuilder.Entity<LoanApplication>());
        }
    }

}
