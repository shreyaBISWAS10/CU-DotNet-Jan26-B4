using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sales values for Day 1 to 7:");
            decimal[] arr = new decimal[7];
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            int minIndex = 0;
            int maxIndex = 0;
            int count = 0;

            decimal totSales = 0;

            for( int i =0;i< 7; i++)
            {
                arr[i] = Decimal.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    Console.WriteLine("Invaid input re-enter the value:");
                    arr[i] = Decimal.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i]> max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
                totSales += arr[i];
            }
            decimal average = totSales / arr.Length;
            string[] arr2 = new string[arr.Length];
            for( int i =0; i < arr.Length; i++)
            {
                if (arr[i]> average)
                {
                    count++;
                }
                if (arr[i] < 5000)
                {
                    arr2[i] = "Low";
                }
                else if (arr[i]< 15000 || arr[i] > 5000)
                {
                    arr2[i] = "Medium";
                }
                else 
                {
                    arr2[i] = "High";
                }
            }
            Console.WriteLine($"Total Sales: {totSales:F2}");
            Console.WriteLine($"Average Daily Sale: {average:F2}");
            Console.WriteLine($"Highest Sale: {max:F2} (Day {maxIndex})");
            Console.WriteLine($"Lowest Sale: {min:F2} (Day {minIndex})");
            Console.WriteLine($"Days Above Average: {count}");
            for( int i =0; i < arr2.Length; i++)
            {
                Console.WriteLine($"Day {i+1} : {arr2[i]}");
            }



        }
    }
}
