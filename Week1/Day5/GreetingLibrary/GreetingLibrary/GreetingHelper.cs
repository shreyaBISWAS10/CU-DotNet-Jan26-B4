namespace GreetingLibrary
{
    public class GreetingHelper
    {
        public static string GetGreeting(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return "Guest!";

            }
            else
            {
                return name + "!";
            }
        }
    }
}
