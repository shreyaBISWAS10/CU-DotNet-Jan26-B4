using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Week2Assessment
{
    internal class Program
    {
        static void GetDetails(string[] policyHolderNames, decimal[] annualPremium)
        {
            for( int i =0; i < 5; i++)
            {
                Console.WriteLine($"{ i+1})Enter name of the customer:");
                policyHolderNames[i] = Console.ReadLine();
                while(policyHolderNames[i].Equals(" "))
                {
                    Console.WriteLine("Invalid Name, Please Enter again:");
                    policyHolderNames[i] = Console.ReadLine();

                }
                Console.WriteLine($"{i + 1})Enter annual premium of the customer:");
                annualPremium[i] = decimal.Parse(Console.ReadLine());
                while (!(annualPremium[i]>0))
                {
                    Console.WriteLine("Invalid annual premium. Enter a valid amount:");
                    policyHolderNames[i] = Console.ReadLine();

                }

            }
        }
       
        static decimal GetTotalPremium(decimal[] annualPremium)
        {
            decimal Total= 0;   
            for( int i =0; i < annualPremium.Length; i++)
            {
                Total += annualPremium[i];
            }
            return Total;
        }
        static decimal GetHighest(decimal[] annualPremium)
        {
            decimal Highest = decimal.MinValue;
            for (int i = 0; i < annualPremium.Length; i++)
            {
                if (annualPremium[i] > Highest)
                {
                    Highest = annualPremium[i];

                }

            }
            return Highest;
        }
        static decimal GetLowest(decimal[] annualPremium)
        {
            decimal Lowest = decimal.MaxValue;
            for (int i = 0; i < annualPremium.Length; i++)
            {
                if (annualPremium[i] < Lowest)
                {
                    Lowest = annualPremium[i];

                }

            }
            return Lowest;
        }
    
        static void Display(string[] policyHolderNames, decimal[] annualPremium, decimal Total, decimal Avg, decimal HighestAnnualPremium, decimal LowestAnnualPremium)
        {
            string Category = null;
            Console.WriteLine();
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Name            Premium            Category");
            Console.WriteLine("-------------------------------------------");
            for( int i =0; i < annualPremium.Length; i++)
            {
                if (annualPremium[i] < 10000)
                {
                    Category= "LOW";
                }
                else if (annualPremium[i]> 10000 && annualPremium[i]< 25000)
                {
                    Category = "MEDIUM";
                }
                else{
                    Category = "HIGH";
                }

                Console.WriteLine($"{policyHolderNames[i].ToUpper(),-15} {annualPremium[i],-18:F2} {Category}");
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Total Premium   : {Total:F2}");
            Console.WriteLine($"Average Premium : {Avg:F2}");
            Console.WriteLine($"Highest Premium : {HighestAnnualPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {LowestAnnualPremium:F2}");


        }
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremium = new decimal[5];
            GetDetails(policyHolderNames, annualPremium);
            decimal TotalPremium = GetTotalPremium(annualPremium);
            decimal Avg = TotalPremium / annualPremium.Length;
            decimal HighestAnnualPremium = GetHighest(annualPremium);
            decimal LowestAnnualPremium = GetLowest(annualPremium);
            Display(policyHolderNames, annualPremium, TotalPremium,Avg, HighestAnnualPremium, LowestAnnualPremium);
        }
    }
}
