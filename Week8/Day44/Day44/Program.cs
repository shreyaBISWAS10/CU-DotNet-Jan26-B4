using System.Text;

namespace Day44
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public Subscriber(string name,DateTime joinDate)
        {
            ID = Guid.NewGuid();
            Name = name;
            JoinDate = joinDate;
        }
        public abstract decimal CalculateMonthlyBill();
        public override bool Equals(object? obj)
        {
            if (obj is Subscriber other)
                return this.ID ==other.ID;
            return false;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public int CompareTo(Subscriber other)
        {
            int result = this.JoinDate.CompareTo(other.JoinDate);
            if (result == 0)
                result = this.Name.CompareTo(other.Name);
            return result;
        }
    }
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }
        public BusinessSubscriber(string name,DateTime joinDate, decimal fixedRate,decimal taxRate) : base(name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }
        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGb { get; set; }
        public decimal PricePerGB { get; set; }
        public ConsumerSubscriber(string name, DateTime joinDate,decimal dataUsage,decimal pricePerGB) : base(name, joinDate)
        {
            DataUsageGb = dataUsage;
            PricePerGB = pricePerGB;
        }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGb * PricePerGB;
        }
    }

    public class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== Revenue Report =====");
            sb.AppendLine("Type\t\tName\t\tBill");
            foreach(var s in subscribers)
            {
                string type = s is BusinessSubscriber ? "Business" : "Consumer";
                sb.AppendLine($"{type}\t{s.Name}\t\t{s.CalculateMonthlyBill():C}");

            }
            Console.WriteLine(sb.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers =
                new Dictionary<string, Subscriber>();

            subscribers["biz1@email.com"] =
                new BusinessSubscriber("TechCorp", new DateTime(2023, 1, 10), 5000, 0.18m);

            subscribers["biz2@email.com"] =
                new BusinessSubscriber("DataSys", new DateTime(2023, 2, 5), 7000, 0.15m);

            subscribers["con1@email.com"] =
                new ConsumerSubscriber("Alice", new DateTime(2024, 3, 1), 120, 10);

            subscribers["con2@email.com"] =
                new ConsumerSubscriber("Bob", new DateTime(2024, 1, 20), 80, 12);

            subscribers["con3@email.com"] =
                new ConsumerSubscriber("Charlie", new DateTime(2024, 4, 5), 200, 9);


            var sortedList = subscribers
                .OrderByDescending(kvp => kvp.Value.CalculateMonthlyBill())
                .Select(kvp => kvp.Value)
                .ToList();

            ReportGenerator.PrintRevenueReport(sortedList);
        

        }
    }
}
