using System;

namespace SRP_After
{
    public class User { public string Username { get; set; } public string Email { get; set; } }

    public class UserRepository
    {
        public void Save(User user) => Console.WriteLine($"[DATABASE] Saved {user.Username}.");
    }

    public class EmailService
    {
        public void SendWelcome(User user) => Console.WriteLine($"[EMAIL] Sent to {user.Email}.");
    }

    public class UserRegistrationService
    {
        private readonly UserRepository _repo = new UserRepository();
        private readonly EmailService _email = new EmailService();

        public void Register(User user)
        {
            Console.WriteLine($"[LOGIC] Processing registration...");
            _repo.Save(user);
            _email.SendWelcome(user);
        }
    }

    class Program
    {
        static void Main()
        {
            var service = new UserRegistrationService();
            service.Register(new User { Username = "Bob", Email = "bob@example.com" });
        }
    }
}