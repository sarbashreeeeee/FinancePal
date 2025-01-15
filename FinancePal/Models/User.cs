namespace FinancePal.Models
{
    public class User
    {
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        //public decimal Wallet { get; set; } = 0;
        public string Currency { get; set; } = "USD";


        public User(string Username, string Password, string Currency)
        {
            this.Username = Username;
            this.Password = Password;
            this.Currency = Currency;
        }

        public User()
        {
            this.Username = null;
            this.Password = null;
            this.Currency = null;
        }

        public static List<string> AvailableCurrencies => new List<string>
        {
            "USD (United States Dollar)",
            "EUR (Euro)",
            "NPR (Nepalese Rupee)",
            "INR (Indian Rupee)",
            "GBP (British Pound)",
            "JPY (Japanese Yen)"
        };
    }
}




