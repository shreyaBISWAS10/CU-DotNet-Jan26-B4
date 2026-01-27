
namespace Day18._1
{
    internal class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan()
        {
            LoanNumber = "L1";
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYears = 0;

        }
        public Loan(string Lnum, string Cname, decimal Pamount, int TInYears)
        {
            LoanNumber = Lnum;
            CustomerName = Cname;
            PrincipalAmount = Pamount;
            TenureInYears = TInYears;

        }
        public double CalculateEMI()
        {
            double SI = (double)(PrincipalAmount * 10 * TenureInYears) / 100;
            return SI;

        }
        public static void Main(string[] args)
        {

            Loan[] loans = new Loan[4]
            {
                new HomeLoan("HL1", "Shreya", 500000, 10),
                new HomeLoan("HL2", "Deepshikha", 600000, 15),
                new CarLoan("CL1", "Raj", 400000, 5),
                new CarLoan("CL2", "Parth", 350000, 4)
            };

            foreach (Loan loan in loans)
            {
                Console.WriteLine(
                    $"{loan.LoanNumber} - EMI Interest: {loan.CalculateEMI()}"
                );
            }
        }
    }
    class HomeLoan : Loan
    {
        public HomeLoan() { }
        public HomeLoan(string lnum, string cname, decimal pamount, int tenure) : base(lnum, cname, pamount, tenure)
        {

        }
        public new double CalculateEMI()
        {
            decimal processingFee = PrincipalAmount * 1 / 100;
            double interest = (double)(PrincipalAmount * 8 * TenureInYears) / 100;
            return interest + (double)processingFee;
        }
    }


    class CarLoan : Loan
    {
        public CarLoan() { }

        public CarLoan(string lnum, string cname, decimal pamount, int tenure)
            : base(lnum, cname, pamount, tenure)
        {
        }
        public new double CalculateEMI()
        {
            PrincipalAmount += 15000;
            double interest = (double)(PrincipalAmount * 9 * TenureInYears) / 100;
            return interest;
        }

    }



}
