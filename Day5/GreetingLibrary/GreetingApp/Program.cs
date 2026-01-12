using GreetingLibrary;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            string getName = GreetingHelper.GetGreeting(name);
            Console.WriteLine("Hello, "+ getName);
        }
    }
}
