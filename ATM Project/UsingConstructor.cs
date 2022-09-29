

namespace ATM_Project
{
    public class UsingConstructor
    {
        public static void Main(string[] args)
        {
            User Chance = new User("Chance", "Dana7116", 10000);
            User Emma = new User("Emma", "CoolPool", 15000);
            User NewUser = new User("", "", 0);

            Console.WriteLine("Are you an existing user?");
            string response1 = Console.ReadLine();
            if (response1 == "Yes")
            {
                Console.WriteLine("Please Enter your password");
                string password = Console.ReadLine();
                if (password == Chance.Password)
                {
                    ATMDialog(Chance.amountInBank);
                }
                if (password == Emma.Password)
                {
                    ATMDialog(Emma.amountInBank);
                }
                else
                {
                    Console.WriteLine("Password is incorrect");
                }

            }
            else
            {
                CreateNewUser(NewUser);
            }

        }

        public static void CreateNewUser(User NewUser)
        {
            Console.WriteLine("Please create a username");
            string newUsername = Console.ReadLine();
            newUsername += NewUser.Name;
            Console.WriteLine("Please create a password");
            string newPassword = Console.ReadLine();
            newPassword += NewUser.Password;
            Console.WriteLine("Please enter your password");
            string newPasswordEntered = Console.ReadLine();
            if (newPasswordEntered == newPassword)
            {
                ATMDialog(NewUser.amountInBank);
            }
            else
            {
                Console.WriteLine("Wrong Username");
            }

        }

        public static void ATMDialog(float money)
        {
            Console.WriteLine($"You have {money} dollars in your account");
            Console.WriteLine("Would you like to make a deposit?");
            string response1 = Console.ReadLine();
            if (response1 == "Yes")
            {
                Console.WriteLine("Please enter how much you would like to Deposit");
                string enteredDeposit = Console.ReadLine();

                float amountDeposit = float.Parse(enteredDeposit);
                money += amountDeposit;

                Console.WriteLine($"Your new total is {money}");
            }
            else if (response1 == "No")
            {
                Console.WriteLine("Would you like to make a withdrawl?");
                string response2 = Console.ReadLine();
                if (response2 == "Yes")
                {
                    Console.WriteLine("Please enter how much you would like to withdrawl");
                    string enteredWithdrawl = Console.ReadLine();

                    float amountWithdrawn = float.Parse(enteredWithdrawl);
                    money -= amountWithdrawn;
                    if (money < 0)
                    {
                        Console.WriteLine("You don't have enough money in the account to make that withdrawl");
                    }
                    else
                        Console.WriteLine($"Your new total is {money}");
                }
                else
                {
                    Console.WriteLine("Thank you have a good day");
                }
            }
            else
            {
                Console.WriteLine("Thank you have a good day");
            }
        }
    }
}
