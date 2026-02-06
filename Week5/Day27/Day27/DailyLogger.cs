namespace Day27
{
    internal class DailyLogger
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\..\";
            string file = "journal.txt";
            string filePath = Path.Combine(directory, file);
            Console.WriteLine("Enter your Daily Reflection:");
            string reflection = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"[{DateTime.Now}]");
                sw.WriteLine(reflection);
                sw.WriteLine();

            }
            Console.WriteLine("Your reflection was saved successfully");
        }
    }
}