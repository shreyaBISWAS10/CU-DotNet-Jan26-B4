using SmartBank.AccountService.Exceptions;
using SmartBank.AccountService.DTOs;
using SmartBank.AccountService.Helpers;
using SmartBank.AccountService.Models;
using SmartBank.AccountService.Repositories;
using SmartBank.AccountService.Services;

namespace SmartBank.AccountService.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepository _repo;

        public AccountServices(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
            {
                throw new BadRequestException("Minimum deposit is ₹1000");
            }

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit
            };

            await _repo.CreateAsync(account);

            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);
            await _repo.UpdateAsync(account);

            return Map(account);
        }

        public async Task<List<AccountDto>> GetAllAsync()
        {
            var accounts = await _repo.GetAllAsync();
            return accounts.Select(Map).ToList();
        }

        public async Task<AccountDto> GetByIdAsync(int id)
        {
            var account = await _repo.GetByIdAsync(id)
                ?? throw new NotFoundException("Account not found");

            return Map(account);
        }

        public async Task DepositAsync(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId)
                ?? throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;
            await _repo.UpdateAsync(account);
        }

        public async Task WithdrawAsync(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetByIdAsync(dto.AccountId)
                ?? throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance ₹1000 required");

            account.Balance -= dto.Amount;
            await _repo.UpdateAsync(account);
        }

        private static AccountDto Map(Account a)
        {
            return new AccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Balance = a.Balance,
                AccountNumber = a.AccountNumber
            };
        }
    }
}