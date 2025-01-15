using FinancePal.Models;

namespace FinancePal.Services
{
    public interface IAuthService
    {
        public void AddUser(string Username, string Password, string Currency);

        public User GetUser();

        public bool UserExists();

        public bool ValidateUser(string Password);

    }
}
