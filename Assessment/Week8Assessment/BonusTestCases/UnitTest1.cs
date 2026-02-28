using NuGet.Frameworks;
using Week8Assessment;

namespace BonusTestCases
{
    public class Tests
    {
        

        [Test]
        public void NormalHighPerformer()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.1m,
                AttendancePercentage =95
            };


            Assert.AreEqual(123200.00m, e.NetAnnualBonus);
        }

        [Test]
        public void AttendancePenalty()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 400000,
                PerformanceRating = 4,
                YearsOfExperience = 8,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 80
            };
            Assert.AreEqual(60480.00m, e.NetAnnualBonus);
        }
        [Test]
        public void CapTrigger()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 1000000,
                PerformanceRating =5,
                YearsOfExperience= 15,
                DepartmentMultiplier= 1.5m,
                AttendancePercentage = 95

            };
            Assert.AreEqual(280000.00m,e.NetAnnualBonus);
        }

        [Test]
        public void ZeroSalary()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 0,
                
            };
            Assert.AreEqual(0.00m,e.NetAnnualBonus);

        }
        [Test]
        public void LowPerformer()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 300000,
                PerformanceRating = 2,
                YearsOfExperience = 3,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage = 90

            };
            Assert.AreEqual(13500.00m, e.NetAnnualBonus);
            
        }

        [Test]
        public void TaxBoundary()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 600000,
                PerformanceRating = 3,
                YearsOfExperience = 0,
                DepartmentMultiplier = 1.0m,
                AttendancePercentage=100

            };
            Assert.AreEqual(64800.00, e.NetAnnualBonus);

        }
        [Test]
        public void HighTaxSlab()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 900000,
                PerformanceRating = 5,
                YearsOfExperience = 11,
                DepartmentMultiplier = 1.2m,
                AttendancePercentage = 100

            };
            Assert.AreEqual(226800.00m, e.NetAnnualBonus);
        }
        [Test]
        public void RoundingPrecision()
        {
            var e = new EmployeeBonus
            {
                BaseSalary = 555555,
                PerformanceRating = 4,
                YearsOfExperience = 6,
                DepartmentMultiplier = 1.13m,
                AttendancePercentage = 92


            };
            Assert.AreEqual(118649.88, e.NetAnnualBonus);
        }
    }
}