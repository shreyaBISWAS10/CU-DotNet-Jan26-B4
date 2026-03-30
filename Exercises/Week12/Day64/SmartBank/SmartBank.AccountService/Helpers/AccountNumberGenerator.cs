namespace SmartBank.AccountService.Helpers
{
    public static class AccountNumberGenerator
    {
        public static string Generate(int id)
        {
            return $"SB-{DateTime.Now.Year}-{id.ToString("D6")}";
        }
    }
}