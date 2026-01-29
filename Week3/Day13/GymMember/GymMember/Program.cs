namespace GymMember
{
    internal class Program
    {
        public static double GymMembership(bool treadMill, bool weight, bool zumba)
        {
            double result = 1000.0;
            if (!(treadMill || (weight && zumba)))
            {
                Console.WriteLine("You have to opt for some service.");

            }
            if (treadMill)result += 300;
            if (weight)result += 500;
            if (zumba)result += 250;
            result += (0.05 * result);
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Your gym membership amount is : {GymMembership(true, false, true)}");
        }
    }
}
