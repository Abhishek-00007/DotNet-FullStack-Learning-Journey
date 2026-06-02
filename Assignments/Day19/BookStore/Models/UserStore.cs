using BookStore.Models;

namespace BookStore.Models
{
    public static class UserStore
    {
        public static List<User> Users = new()
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            }
        };
    }
}