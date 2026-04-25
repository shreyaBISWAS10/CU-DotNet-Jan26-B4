using Loans.Data;
using Loans.Models;
using Microsoft.EntityFrameworkCore;
namespace Loans.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LoanApplication> AddAsync(LoanApplication loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<List<LoanApplication>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<LoanApplication?> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task UpdateAsync(LoanApplication loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }

}
