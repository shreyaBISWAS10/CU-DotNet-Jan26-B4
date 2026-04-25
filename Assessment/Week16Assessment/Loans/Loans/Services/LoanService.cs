using AutoMapper;
using Loans.DTOs;
using Loans.Repositories;
using Loans.Models;
namespace Loans.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repo;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LoanResponseDto> CreateLoanAsync(LoanRequestDto dto)
        {
            // Business Rule
            if (dto.LoanAmount > 10000000)
                throw new Exception("Loan exceeds maximum allowed limit.");

            var loan = _mapper.Map<LoanApplication>(dto);

            // EMI Calculation
            loan.MonthlyPremium = CalculateEmi(dto.LoanAmount, dto.InterestRate, dto.TenureMonths);
            loan.TotalPayableAmount = loan.MonthlyPremium * dto.TenureMonths;

            loan.Status = "Pending";
            loan.CreatedDate = DateTime.UtcNow;

            var result = await _repo.AddAsync(loan);

            return _mapper.Map<LoanResponseDto>(result);
        }

        public async Task<List<LoanResponseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<LoanResponseDto>>(data);
        }

        public async Task ApproveLoanAsync(int id)
        {
            var loan = await _repo.GetByIdAsync(id);

            if (loan == null)
                throw new Exception("Loan not found");

            loan.Status = "Approved";

            await _repo.UpdateAsync(loan);
        }

        private decimal CalculateEmi(decimal principal, decimal rate, int months)
        {
            double r = (double)(rate / 12 / 100);

            double emi = (double)principal * r * Math.Pow(1 + r, months) /
                         (Math.Pow(1 + r, months) - 1);

            return Math.Round((decimal)emi, 2);
        }
    }
}
