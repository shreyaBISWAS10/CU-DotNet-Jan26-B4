using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Day8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keyword = false;
            bool standard = false;
            string category = null;
            Console.WriteLine("Enter your details in the following format:<TransactionId>#<AccountHolderName>#<TransactionNarration>");
            string input = Console.ReadLine();
            string[] inputs = input.Split("#");
            string transaction = inputs[0];
            string name = inputs[1];
            string narration = inputs[2].Trim().ToLower();
            while (narration.Contains("  "))
            {
                narration = narration.Replace("  ", " ");
            }
            if (narration.Contains("transfer") || narration.Contains("deposit") || narration.Contains("withdrawal"))
            {
                keyword = true;
            }
            if (narration.Contains("cash deposit successful"))
            {
                standard = true;
            }
            if (!keyword)
            {
                category = "NON-FINANCIAL TRANSACTION";

            }
            else if (keyword && standard)
            {
                category = "STANDARD TRANSACTION";
            }
            else
            {
                category = "CUSTOM TRANSACTION";
            }

            Console.WriteLine($"Transaction ID :{transaction}");
            Console.WriteLine($"Account Holder :{name}");
            Console.WriteLine($"Narration :{narration}");
            Console.WriteLine($"Category :{category}");




        }
    }
}
