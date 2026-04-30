using Loans.Common;
using Loans.DTOs;
using Loans.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loans.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoanRequestDto dto)
        {
            var result = await _service.CreateLoanAsync(dto);

            return Ok(new ApiResponse<LoanResponseDto>
            {
                Success = true,
                Message = "Loan Created",
                Data = result
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(new ApiResponse<List<LoanResponseDto>>
            {
                Success = true,
                Data = result
            });
        }
    }

}
