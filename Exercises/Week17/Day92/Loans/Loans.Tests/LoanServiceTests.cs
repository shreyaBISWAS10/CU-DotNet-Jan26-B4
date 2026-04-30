using Xunit;
using Moq;
using AutoMapper;
namespace Loans.Tests
{
    public class LoanServiceTests
    {
        private readonly Mock<ILoanRepository> _repoMock;
        private readonly IMapper _mapper;
        private readonly LoanService _service;

        public LoanServiceTests()
        {
            _repoMock = new Mock<ILoanRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();

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
            Assert.True(result.MonthlyPremium > 0);
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

            // Act + Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _service.CreateLoanAsync(dto));
        }

        [Fact]
        public async Task CreateLoanAsync_ShouldCalculateCorrectEMI()
        {
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

            var result = await _service.CreateLoanAsync(dto);

            Assert.Equal(16607.15m, result.MonthlyPremium);
        }
    }
}