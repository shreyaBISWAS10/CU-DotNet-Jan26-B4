using System.Runtime.CompilerServices;

namespace Day15
{
    class Height
    {
        public int feet { get; set; }
        public double inches { get; set; }

        public Height()
        {
            feet = 0;
            inches = 0.0;
        }
        public Height(int feet, double inches)
        {
            this.feet = feet;
            this.inches = inches;
        }
        public Height(double inches)
        {
            this.inches = inches;
        }
        public Height AddHeights(Height h2)
        {
            double sum1 = (double)feet + h2.feet;
            double sum2 = (double)inches + h2.inches;
            if(sum2 >= 12)
            {
                sum1 += sum2 / 12;
                sum2 = sum2 % 12;
            }
            Height height = new Height()
            {
                feet = (int)sum1,
                inches = sum2
            };
            return height;

        }
        public override string ToString()
        {
            return $"Height -{feet} feet {inches:F1} inches";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Height person1 = new Height()
            {
                feet = 5,
                inches = 6.5
            };  
            Height person2 = new Height()
            {
                feet = 5,
                inches = 7.5
            };
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());
            Console.WriteLine(person1.AddHeights(person2));
        }
    }
}
