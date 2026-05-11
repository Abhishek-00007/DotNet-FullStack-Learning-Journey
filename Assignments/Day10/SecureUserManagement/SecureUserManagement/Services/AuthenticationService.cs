using SecureUserManagement.Models;
using SecureUserManagement.Utilities;

namespace SecureUserManagement.Services
{
    public class AuthenticationService
    {
        private readonly List<User> users = new();

        public bool Register(string username, string password)
        {
            try
            {
                if (users.Any(u => u.Username == username))
                {
                    return false;
                }

                string hashedPassword =
                    HashUtility.ComputeSha256Hash(password);

                users.Add(new User
                {
                    Username = username,
                    HashedPassword = hashedPassword
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                string hashedPassword =
                    HashUtility.ComputeSha256Hash(password);

                User user = users.FirstOrDefault(
                    u => u.Username == username);

                if (user == null)
                {
                    return false;
                }

                return user.HashedPassword == hashedPassword;
            }
            catch
            {
                return false;
            }
        }
    }
}