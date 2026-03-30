using SmartBank.AccountService.DTOs;

namespace SmartBank.AccountService.Services
{
    public interface IAccountServices
    {
        Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
        Task<List<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(int id);
        Task DepositAsync(TransactionDto dto);
        Task WithdrawAsync(TransactionDto dto);
    }
}