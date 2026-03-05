using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace Day51
{
    public class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        public CreatorStats() { }
        public CreatorStats(string name, double[] likes ) {
            CreatorName = name;
            WeeklyLikes = likes;
        }
       
    }
    internal class Program
    {

        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (CreatorStats creator in records)
            {
                int count = 0;

                foreach (double like in creator.WeeklyLikes)
                {
                    if (like >= likeThreshold)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    result.Add(creator.CreatorName, count);
                }
            }

            return result;

        }
        public double CalculateAverageLikes()
        {
            double sum = 0;
            int total = 0;

            foreach (CreatorStats creator in EngagementBoard)
            {
                foreach (double like in creator.WeeklyLikes)
                {
                    sum += like;
                    total++;
                }
            }

            if (total == 0)
                return 0;

            return sum / total;


        }
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
        static void Main(string[] args)
        {

            Program program = new Program();
            int choice = 0;
            do
            {
                Console.WriteLine($"1.Register Creator");
                Console.WriteLine($"2.Show Top Posts");
                Console.WriteLine($"3.Calculate Average Likes");
                Console.WriteLine($"4.Exit");


                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    CreatorStats cs = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    cs.CreatorName = Console.ReadLine();

                    cs.WeeklyLikes = new double[4];

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        cs.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    program.RegisterCreator(cs);

                    Console.WriteLine("Creator registered successfully");

                }

                else if(choice == 2)
                {
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());
                    Dictionary<String, int> res = program.GetTopPostCounts(EngagementBoard,threshold);
                    if (res.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in res)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }


                }
                else if (choice == 3)
                {
                    double avg = program.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + avg);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                }

            } while (choice != 4);
           
        }
    }
}
