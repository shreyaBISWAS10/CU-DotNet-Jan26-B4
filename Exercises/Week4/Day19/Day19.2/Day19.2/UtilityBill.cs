using System;

namespace Day19._2
{
    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int CId, string CName, decimal UConsumed, decimal RPUnit) : base(CId, CName, UConsumed, RPUnit)
        {

        }

        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;

            if (UnitsConsumed > 300)
            {
                amount += amount * 0.10m; 
            }

            return amount;
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate)
        : base(id, name, units, rate) 
        { 
        }

        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }
    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed * RatePerUnit) + 150;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0; 
        }
    }

    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

       

        public UtilityBill(int CId, string CName, decimal UConsumed, decimal RPUnit)
        {
            ConsumerId = CId;
            ConsumerName = CName;
            UnitsConsumed = UConsumed;
            RatePerUnit = RPUnit;
              
        }
        public virtual decimal CalculateTax(decimal billAmount)
        {
            return(decimal)0.05 * billAmount;
        }
        public abstract decimal CalculateBillAmount();
        
        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal total = billAmount + tax;
            Console.WriteLine("--------------- BILL ---------------");
            Console.WriteLine($"Consumer ID   : {ConsumerId}");
            Console.WriteLine($"Consumer Name : {ConsumerName}");
            Console.WriteLine($"Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"Bill Amount   : ₹{billAmount}");
            Console.WriteLine($"Tax           : ₹{tax}");
            Console.WriteLine($"Total Payable : ₹{total}");
            Console.WriteLine("------------------------------------");
        }
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>
        {
            new ElectricityBill(101, "Shreya", 350, 6),
            new WaterBill(102, "Sweta", 120, 3),
            new GasBill(103, "Anuva", 50, 4)
        };

            foreach (UtilityBill bill in bills)
            {
                bill.PrintBill(); 
            }
        }

        }
    }
