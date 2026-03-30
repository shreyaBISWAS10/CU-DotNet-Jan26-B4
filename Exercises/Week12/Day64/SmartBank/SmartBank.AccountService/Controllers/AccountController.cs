using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.AccountService.DTOs;
using SmartBank.AccountService.Services;

namespace SmartBank.AccountService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _service;

        public AccountController(IAccountServices service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountDto dto)
        {
            var result = await _service.CreateAccountAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            await _service.DepositAsync(dto);
            return Ok(new { message = "Deposit successful" });
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            await _service.WithdrawAsync(dto);
            return Ok(new { message = "Withdrawal successful" });
        }
    }
}