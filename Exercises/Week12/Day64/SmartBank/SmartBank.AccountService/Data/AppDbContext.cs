using Microsoft.EntityFrameworkCore;
using SmartBank.AccountService.Models;

namespace SmartBank.AccountService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
    }
}