namespace Week8Assessment
{
    public class EmployeeBonus
    {
        public int BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0m;

                decimal percent = PerformanceRating switch
                {
                    5 => 0.25m,
                    4 => 0.18m,
                    3 => 0.12m,
                    2 => 0.05m,
                    1 => 0.00m,
                    _ => throw new InvalidOperationException()
                };

                decimal bonus = BaseSalary * percent;

                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                if (AttendancePercentage < 85)
                    bonus *= 0.8m;

                bonus *= DepartmentMultiplier;

                decimal cap = BaseSalary * 0.40m;
                if (bonus > cap)
                    bonus = cap;

                decimal tax =
                    bonus <= 150000 ? 0.10m :
                    bonus <= 300000 ? 0.20m :
                                      0.30m;

                bonus *= (1 - tax);

                return Math.Round(bonus, 2);

            }
 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    }


























































}