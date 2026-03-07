namespace Day18._2
{
    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int eid, string ename, decimal bsal, int experience) : base(eid, ename, bsal, experience)
        {

        }

        public new decimal CalculateAnnualSalary()
        {
            decimal hra = 0.2m * BasicSalary;
            decimal allowance = 0.1m * BasicSalary;
            decimal loyaltyBonus = (ExperienceInYears >= 5) ? 50000 : 0;
            return base.CalculateAnnualSalary() + hra + allowance + loyaltyBonus;
        }
       
    }
    class ContractEmployee : Employee
    {
        public ContractEmployee(int eid, string ename, decimal bsal, int experience, int duration) : base(eid, ename, bsal, experience)
        {
            ContractDurationInMonths = duration;
        }
        public int ContractDurationInMonths { get; set; }

        public new decimal CalculateAnnualSalary()
        {
            decimal bonus = (ContractDurationInMonths >= 12) ? 30000 : 0;
            return base.CalculateAnnualSalary() + bonus;
        }
    }
    class InternEmployee : Employee
    {
        public InternEmployee(int eid, string ename, decimal bsal, int experience): base(eid,ename,bsal,experience)
        {

        }
        public new decimal CalculateAnnualSalary()
        {
            return base.CalculateAnnualSalary();
        }
    }
        

    internal class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }

        public int ExperienceInYears { get; set; }

        public Employee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            BasicSalary = basicSalary;
            ExperienceInYears = experienceInYears;
        }
        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
        public string DisplayEmployeeDetails()
        {
            return $"Employee ID: {EmployeeId}, Employee Name: {EmployeeName}, Basic Salary:{BasicSalary}, Experience:{ExperienceInYears}, Annual Salary: {CalculateAnnualSalary():F2}";

        }
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(101, "Shreya", 30000, 6);
            PermanentEmployee emp2 = new PermanentEmployee(102, "Deepshikha", 30000, 6);

            Employee emp3 = new ContractEmployee(103, "Raj", 25000, 2, 14);
            Employee emp4 = new InternEmployee(104, "Parth", 15000, 0);

            Console.WriteLine("---- Salary Calculations ----");
            Console.WriteLine(emp1.CalculateAnnualSalary());   
            Console.WriteLine(emp2.CalculateAnnualSalary());  
            Console.WriteLine(emp3.CalculateAnnualSalary());
            Console.WriteLine(emp4.CalculateAnnualSalary());

            Console.WriteLine("\n---- Employee Details ----");
            Console.WriteLine(emp1.DisplayEmployeeDetails());
            Console.WriteLine(emp2.DisplayEmployeeDetails());
            Console.WriteLine(emp3.DisplayEmployeeDetails());
            Console.WriteLine(emp4.DisplayEmployeeDetails());
        }
    }
    
}
