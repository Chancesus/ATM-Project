
namespace ATM_Project
{
    public class User
    {
        private string name;
        private string password;
        public float amountInBank;

        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password, float amountInBank)
        {
            this.Name = name;
            this.Password = password;
            this.amountInBank = amountInBank;
        }

        public static void CheckPassword()
        {
            
        }

    }
}
