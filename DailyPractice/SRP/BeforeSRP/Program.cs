using System;

namespace SRP_Before
{
    public class UserAccountManager
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public void Register()
        {
            Console.WriteLine($"[LOGIC] Registering {Username}...");

            Console.WriteLine($"[DATABASE] Saving {Username} to SQL Server.");

            Console.WriteLine($"[EMAIL] Sending welcome message to {Email}.");
        }
    }

    class Program
    {
        static void Main()
        {
            var manager = new UserAccountManager { Username = "Alice", Email = "alice@example.com" };
            manager.Register();
        }
    }
}