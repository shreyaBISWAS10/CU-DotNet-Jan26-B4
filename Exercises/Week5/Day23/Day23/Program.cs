using System.Collections.Concurrent;

namespace Day23
{
    class InvalidStudentAgeException : Exception {
        public InvalidStudentAgeException(string message) : base(message){ }
    }
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine($"Result: {a/b}");

            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Error:Cannot divide by zero");

            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            try
            {
                Console.WriteLine("Enter an integer: ");
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format");
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }

            try
            {
                int[] arr = { 10, 20, 30 };
                Console.WriteLine("Enter index: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine(arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Index out of range");
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }


            try
            {
                Console.WriteLine("Enter student name:");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new InvalidStudentNameException("Student name cannot be empty");
                }
            }
            catch(InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message);
            }

            int age = 0;
            bool validAge = false;
            while (!validAge)
            {
                try
                {
                    Console.WriteLine("Enter student age: ");
                    age = int.Parse(Console.ReadLine());
                    if(age < 18 || age > 60)
                    {
                        throw new InvalidStudentAgeException("Age must be between 18 and 60");
                    }
                    validAge = true;

                }
                catch (InvalidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Age must be a number");
                }
            }
            try
            {
                try
                {
                    throw new InvalidStudentAgeException("Invalid age entered");
                }
                catch (InvalidStudentAgeException ex)
                {
                    throw new Exception("Student validation failed", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("InnerException: " + ex.InnerException.Message);
            }

        }
    }
}
