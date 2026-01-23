namespace Day16
{
    internal class ApplicationConfig
    {
        static string ApplicationName {  get; set; }
        static string Environment {  get; set; }
        static int AccessCount {  get; set; }
        static bool IsInitialised {  get; set; }

        static ApplicationConfig() {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialised = false;
            Console.WriteLine("Static Constructor executed");
        }

        public static void Initializer(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialised = true;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            return $"Application Name: {ApplicationName}\nEnvironment: {Environment}\nAccess Count: {AccessCount}\nInitialization status: {IsInitialised}\n";
        }
        public static void ResetConfiguratoin()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialised = false;
        } 
        static void Main(string[] args)
        {
            string appName = "AllinOne Games";
            string prod = "Development";
            ApplicationConfig.Initializer(appName, prod);
            string summary = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("Application Before Reset: ");
            Console.WriteLine(summary);
            ApplicationConfig.ResetConfiguratoin();
            Console.WriteLine("Application After Reset: ");
            string resum = ApplicationConfig.GetConfigurationSummary(); 
            Console.WriteLine(resum);





        }
    }
}
