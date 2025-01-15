using FinancePal.Models;
using System.IO.Pipelines;
using System.Text.Json;

namespace FinancePal.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _filePath = Path.Combine(FileSystem.Current.CacheDirectory, "user.json");
        private User _currentUser;

        public void AddUser(string Username, string Password, string Currency)
        {
           _currentUser = new User(Username, Password, Currency);
            Flush();   //stores User obj in json file
        }

        private void Flush()
        {
            var jsonUser = JsonSerializer.Serialize(_currentUser);
            File.WriteAllText(_filePath, jsonUser);

        }

        public void Initialize()
        {
            if (File.Exists(_filePath))
            {
                var jsonUser = File.ReadAllText(_filePath);
                _currentUser = JsonSerializer.Deserialize<User>(jsonUser) ?? null;
            }
            else
            {
                _currentUser = null; 
            }
        }

        public User GetUser()
        {
            return _currentUser;
        }

        public AuthService()
        {
            Initialize();
        }

        public bool ValidateUser(string Password)
        {
            if (_currentUser != null && _currentUser.Password == Password)
            {
                return true; 
            }
            return false;
        }

        public bool UserExists()
        {
            return _currentUser != null;
        }
    }
}
