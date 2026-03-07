using Day2502;

namespace Day2502
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }
        public void CalculateStats()
        {
            if(BallsFaced != 0)
            {
                StrikeRate = (RunsScored / (double)BallsFaced) * 100;
            }
            else
            {
                StrikeRate = 0;
            }

            if (IsOut)
            {
                Average = RunsScored/1.0;
            }
            else
            {
                Average = RunsScored;
            }
        }
    }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Player> players = new List<Player>();
        try
        {
            //string directory = @"..\..\..\";
            //string file = "player.csv";
            //string path = Path.Combine(directory, file);
            //Console.WriteLine(Directory.GetCurrentDirectory());
            Console.Write("Enter CSV file path: ");
            string path = Console.ReadLine();
            //string directory = @"..\..\..\";
            //string filePath = Path.Combine(directory, path);
            foreach (string line in File.ReadLines(path))
            {
                try
                {
                    string[] data = line.Split(',');
                    Player p = new Player
                    {
                        Name = data[0].Trim(),
                        RunsScored = int.Parse(data[1]),
                        BallsFaced = int.Parse(data[2]),
                        IsOut = bool.Parse(data[3])
                    };
                    if (p.BallsFaced < 10)
                    {
                        continue;
                    }
                    p.CalculateStats();
                    players.Add(p);
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number format in line : "+line);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division by zero in line: "+line);
                }
            }
            var sortedPlayers = players.OrderByDescending(p => p.StrikeRate).ToList();

            Console.WriteLine("\nName\t\tRuns\tSR\tAvg");
            Console.WriteLine("-----------------------------------------");
            foreach(var p in sortedPlayers)
            {
                Console.WriteLine($"{p.Name}\t{p.RunsScored}\t{p.StrikeRate:F2}\t{p.Average:F2}");
            
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("CSV file not found.Please check the path.");
        }
    }
}
