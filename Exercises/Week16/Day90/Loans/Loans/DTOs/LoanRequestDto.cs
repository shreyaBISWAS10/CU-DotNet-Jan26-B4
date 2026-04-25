namespace Loans.DTOs
{
    public class LoanRequestDto
    {
        public string ApplicantName { get; set; }
        public decimal LoanAmount { get; set; }
        public int TenureMonths { get; set; }
        public decimal InterestRate { get; set; }
    }

}
