using ATM;
using ATM_Project;
using System.ComponentModel;

namespace ATM;

public class ATM
{
    public float money;

    public static void FirstAttempt()
    {
        User Chance = new User("Chance", "Dana7116", 3000);
        Console.WriteLine("Please enter password");
        string testString = Console.ReadLine();
        if (testString == Chance.Password)
        {

        }
        string person1 = "Chance";
        string person2 = "Emma";

        Console.WriteLine("Do you have a username and password?");
        string response0 = Console.ReadLine();
        if (response0 == "Yes")
        {
            Console.WriteLine("Please enter your name");
            string nameResponse = Console.ReadLine();
            if (nameResponse == "Chance")
                ATMDialog(2000);
            if (nameResponse == "Emma")
                ATMDialog(5000);
        }
        else
        {
            CreateUsernameAndPassword();
            ATMDialog(0);
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

    public static void CreateUsernameAndPassword()
    {
        Console.WriteLine("What is your Name");
        string name = Console.ReadLine();
        Console.WriteLine("Welcome " + name);
        Console.WriteLine("Please create a password");
        string password = Console.ReadLine();
        Console.WriteLine("Your password is : " + password);
       
    }


}
