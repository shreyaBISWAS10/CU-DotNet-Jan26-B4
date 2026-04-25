using FluentValidation;
using Loans.DTOs;

namespace Loans.Validators
{
    public class LoanRequestValidator : AbstractValidator<LoanRequestDto>
    {
        public LoanRequestValidator()
        {
            RuleFor(x => x.ApplicantName).NotEmpty();

            RuleFor(x => x.LoanAmount).GreaterThan(1000);

            RuleFor(x => x.TenureMonths)
                .InclusiveBetween(6, 360);

            RuleFor(x => x.InterestRate)
                .InclusiveBetween(5, 20);
        }
    }

}
