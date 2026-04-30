using Loans.DTOs;

namespace Loans.Services
{
    public interface ILoanService
    {
        Task<LoanResponseDto> CreateLoanAsync(LoanRequestDto request);
        Task<List<LoanResponseDto>> GetAllAsync();
        Task ApproveLoanAsync(int id);
    }

}
