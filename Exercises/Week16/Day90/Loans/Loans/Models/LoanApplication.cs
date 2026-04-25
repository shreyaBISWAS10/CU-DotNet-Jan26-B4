namespace Loans.Models;
public class LoanApplication
{
    public int Id { get; set; }
    public string ApplicantName { get; set; }
    public int UserId { get; set; }

    public decimal LoanAmount { get; set; }
    public int TenureMonths { get; set; }
    public decimal InterestRate { get; set; }

    public decimal MonthlyPremium { get; set; }
    public decimal TotalPayableAmount { get; set; }

    public string Status { get; set; } // Pending, Approved

    public DateTime CreatedDate { get; set; }
}