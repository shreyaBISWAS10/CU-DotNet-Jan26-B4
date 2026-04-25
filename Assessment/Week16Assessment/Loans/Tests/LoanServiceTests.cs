using AutoMapper;
using Loans.DTOs;
using Loans.Mappings;
using Loans.Models;
using Loans.Repositories;
using Loans.Services;
using Moq;
using Xunit;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Tests
{
    public class LoanServiceTests
    {
        private readonly Mock<ILoanRepository> _repoMock;
        private readonly IMapper _mapper;
        private readonly LoanService _service;

        public LoanServiceTests()
        {
            // Mock repository
            _repoMock = new Mock<ILoanRepository>();

            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();

            // Create service instance
            _service = new LoanService(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateLoanAsync_ShouldReturnValidResponse()
        {
            // Arrange
            var dto = new LoanRequestDto
            {
                ApplicantName = "Sharad",
                LoanAmount = 500000,
                TenureMonths = 36,
                InterestRate = 12
            };

            _repoMock.Setup(x => x.AddAsync(It.IsAny<LoanApplication>()))
                     .ReturnsAsync((LoanApplication loan) =>
                     {
                         loan.Id = 1;
                         return loan;
                     });

            // Act
            var result = await _service.CreateLoanAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sharad", result.ApplicantName);
            Assert.Equal(16607.15m, result.MonthlyPremium);
            Assert.True(result.TotalPayableAmount > 0);
        }

        [Fact]
        public async Task CreateLoanAsync_ShouldThrowException_WhenAmountTooHigh()
        {
            // Arrange
            var dto = new LoanRequestDto
            {
                ApplicantName = "Sharad",
                LoanAmount = 20000000,
                TenureMonths = 36,
                InterestRate = 12
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _service.CreateLoanAsync(dto));
        }
    }
}