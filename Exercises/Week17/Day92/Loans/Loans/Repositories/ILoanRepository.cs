using Loans.Models;
namespace Loans.Repositories
{
    public interface ILoanRepository
    {
        Task<LoanApplication> AddAsync(LoanApplication loan);
        Task<List<LoanApplication>> GetAllAsync();
        Task<LoanApplication?> GetByIdAsync(int id);
        Task UpdateAsync(LoanApplication loan);
    }

}
