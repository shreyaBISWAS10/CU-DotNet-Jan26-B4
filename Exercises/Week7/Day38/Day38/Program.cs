namespace Day38
{
    
    internal class Program
    {
        static bool IsVowel(char c)
        {
            return "aeiou".Contains(c);
        }

        static char NextVowel(char c)
        {
            switch (c)
            {
                case 'a': return 'e';
                case 'e': return 'i';
                case 'i': return 'o';
                case 'o': return 'u';
                case 'u': return 'a';
                default: return c;
            }
        }

        static char NextConsonant(char c)
        {
            char next = (char)(c + 1);

            while (IsVowel(next))
            {
                next = (char)(next + 1);
            }

            return next;
        }

        static void Main()
        {
            Console.Write("Enter lowercase string: ");
            string input = Console.ReadLine();

            char[] result = input.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (IsVowel(result[i]))
                    result[i] = NextVowel(result[i]);
                else
                    result[i] = NextConsonant(result[i]);
            }

            Console.WriteLine("Output: " + new string(result));
        }
    }

}

