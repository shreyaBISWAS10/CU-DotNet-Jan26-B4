using System.ComponentModel.Design;

namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool validate = true;
            bool standard= true;
            string status  = string.Empty;

            //input 
            Console.WriteLine("Enter your name and message in format <UserName>|<LoginMessage>");
            string input = Console.ReadLine();
            string[]inputs = input.Split("|");
            // cleaning of login message 
            inputs[1].Trim().ToLower();
           
            if (!inputs[1].Contains("successful"))
            {
                validate = false;
            }

            if ( inputs[1].Equals("login successful"))
            {
                standard = true;
            }

            if (!validate)
            {
                status = "LOGIN FAILED";
            }
            else if(validate & standard)
            {
                status = "LOGIN SUCCESS";
            }
            else if(validate | standard)
            {
                status = "LOGIN SUCCESS(CUSTOM MESSAGE)";
            }
            Console.WriteLine($"User    :{inputs[0]}");
            Console.WriteLine($"Message :{inputs[1]}");
            Console.WriteLine($"Status  :{status}");






        }
    }
}
