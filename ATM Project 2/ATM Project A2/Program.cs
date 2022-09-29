using ATM_Project_A2;


public class ATMOperatingSystem
{  
    CardHolder Chance = new CardHolder("Chance", "Smith", "123456789", 4177, 780.07f);
    CardHolder Emma = new CardHolder("Emma", "Smith", "987654321", 1594, 15000.89f);
    CardHolder Colby = new CardHolder("Colby", "Smith", "123459876", 4277, 550.79f);
    public static List<CardHolder> Cards = new List<CardHolder>();


    private void AddList()
    {
        Cards.Add(Chance);
        Cards.Add(Emma);
        Cards.Add(Colby);
    }

    private static void CallAddList()
    {
        ATMOperatingSystem info = new ATMOperatingSystem();
        info.AddList();
    }
   
    public static void Main(string[] args)
    {
        Console.Title = "ATM Machine";
        ReturnToWhiteText();
        CallAddList();
        WelcomeUser();
        GetUserInfo(); //Initialize Actions is Called inside Get User Info.
    }

    public static void WelcomeUser()
    {
        Console.WriteLine("-----Welcome to Your Chance ATM-----");
        Console.WriteLine("Press enter to continue...");
        Console.ReadKey();
    }

    public static void GetUserInfo()
    {
        Console.WriteLine("Please enter your Card Number");
        string debitCardNum = "";
        CardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine(); 
                currentUser = Cards.FirstOrDefault(a => a.cardNumber == debitCardNum);
                if (currentUser != null) { break; }
                else
                {
                    ChangeToRedText();
                    Console.WriteLine("Incorrect card number. Please try again");
                    ReturnToWhiteText(); 
                }
            }
            catch {
                ChangeToRedText();
                Console.WriteLine("Incorrect card number. Please try again");
                ReturnToWhiteText(); 
            }
        }

        Console.WriteLine("Thank you. Now please enter your Pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.GetPin() == userPin) { break; }
                else
                {
                    ChangeToRedText();
                    Console.WriteLine("Incorrect Pin number. Please try again");
                    ReturnToWhiteText();
                }
            }
            catch 
            {
                ChangeToRedText();
                Console.WriteLine("Incorrect Pin number. Please try again");
                ReturnToWhiteText(); 
            }
        }
        ChangeToGreenText();
        Console.WriteLine($"Welcome {currentUser.GetFirstName()}!");
        ReturnToWhiteText();
        InitializeActions(currentUser);//This might not work and you have to place this inside this method...
    }

    public static void InitializeActions(CardHolder currentUser)
    {
        int option = 0;
        do
        {
            AvailableActions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {Console.WriteLine("Please choose a correct option");}
            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdrawal(currentUser); }
            else if (option == 3) { CurrencyExchange(currentUser); }
            else if (option == 4) { DisplayBalance(currentUser); }
            
            else if (option == 5) { break; }
            else { option = 0; }
        } while (option != 5);
        ChangeToGreenText();
        Console.WriteLine("Thank you, have a nice day!");
        ReturnToWhiteText();
    }

    public static void AvailableActions()
    {
        Console.WriteLine("Please select one of the following actions");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Currency Exchange");
        Console.WriteLine("4. See Balance");
        Console.WriteLine("5. Exit");
    }

    public static void Deposit(CardHolder currentUser)
    {
        Console.WriteLine("How much would you like to deposit?");
        try
        {
            float deposit = float.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.GetBalance() + deposit);
            ChangeToGreenText();
            Console.WriteLine($"Thank you! Your new balance is : ${currentUser.GetBalance().ToString("c2")}");
            ReturnToWhiteText();
        }
        catch (Exception)
        {
            ChangeToRedText();
            Console.WriteLine("Please enter a valid number");
            ReturnToWhiteText();
            Deposit(currentUser);
        }
    }

    public static void Withdrawal(CardHolder currentUser)
    {
        Console.WriteLine("How much would you like to withdraw?");
        try
        {
            float withdrawal = float.Parse(Console.ReadLine());
            if (currentUser.GetBalance() > withdrawal)
            {
                currentUser.SetBalance(currentUser.GetBalance() - withdrawal);
                ChangeToGreenText();
                Console.WriteLine($"Thank you! Your new balance is : ${currentUser.GetBalance().ToString("c2")}");
                ReturnToWhiteText();
            }
            else
            {
                ChangeToRedText();
                Console.WriteLine("You do not have enough in your account to make that withdrawal");
                ReturnToWhiteText();
                Withdrawal(currentUser);
            }
           
            
        }
        catch (Exception)
        {
            ChangeToRedText();
            Console.WriteLine("Please enter a valid number");
            ReturnToWhiteText();
            Withdrawal(currentUser);
        }
    }

    public static void CurrencyExchange(CardHolder currentUser)
    {
        //Ask how much they want to exchange
        Console.WriteLine("How much would you like to withdraw and exchange?");
        try
        {
            float currencyExchange = float.Parse(Console.ReadLine());
            if (currentUser.GetBalance() > currencyExchange)
            {
                currentUser.SetBalance(currentUser.GetBalance() - currencyExchange);
                int option = 0;
                do
                {
                    AvailableCurrencies();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch {
                        ChangeToRedText();
                        Console.WriteLine("Please choose a correct option");
                        ReturnToWhiteText();}
                    if (option == 1) {CalculateEuro(currencyExchange); }
                    else if (option == 2) { CalculateYen(currencyExchange); }
                    else if (option == 3) { CalculatePound(currencyExchange); }
                    else if (option == 4) { CalculateYuan(currencyExchange); }
                    else if (option == 5) { break; }
                    else { option = 0; }
                } while (option != 5);
                DisplayBalance(currentUser);
                //Console.WriteLine("Thank you, have a nice day!");
            }
            else
            {
                ChangeToRedText();
                Console.WriteLine("You do not have enough in your account to make that withdrawal/exchange");
                ReturnToWhiteText();
            }
        }
        catch
        {
            ChangeToRedText();
            Console.WriteLine("Invalid amount. Please try again.");
            ReturnToWhiteText(); }
       
        //Check if they have that much in their account, treat as withdraw
        //Ask which currency they would like to transfer it into
        //Make Transfer, (withdrawal x currency multiplier)
        //Display withdrawl
    }

    private static void ReturnToWhiteText()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void ChangeToRedText()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public static void AvailableCurrencies()
    {
        Console.WriteLine("Please select one of the following currencies");
        Console.WriteLine("1. Euro");
        Console.WriteLine("2. Yen");
        Console.WriteLine("3. Pound");
        Console.WriteLine("4. Yuan");
        Console.WriteLine("5. Exit");
    }

    public static void DisplayBalance(CardHolder currentUser)
    {
        ChangeToGreenText();
        Console.WriteLine($"Your current balance is {currentUser.GetBalance().ToString("c2")}");
        Console.WriteLine("");
        ReturnToWhiteText();

    }

    private static void ChangeToGreenText()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public static void CalculateEuro(float currencyExchange)
    {
        currencyExchange *= 1.03f;
        ChangeToGreenText();
        Console.WriteLine($"Your withdrawl has been converted into {currencyExchange.ToString("c2")} Euros!");
        ReturnToWhiteText(); 
    }
    public static void CalculateYen(float currencyExchange)
    {
        currencyExchange *= 144.11f;
        ChangeToGreenText();
        Console.WriteLine($"Your withdrawl has been converted into {currencyExchange.ToString("c2")} Yen!");
        ReturnToWhiteText();
    }
    public static void CalculatePound(float currencyExchange)
    {
        currencyExchange *= 0.92f;
        ChangeToGreenText();
        Console.WriteLine($"Your withdrawl has been converted into {currencyExchange.ToString("c2")} Pounds!");
        ReturnToWhiteText();
    }
    public static void CalculateYuan(float currencyExchange)
    {
        currencyExchange *= 7.20f;
        ChangeToGreenText();
        Console.WriteLine($"Your withdrawl has been converted into {currencyExchange.ToString("c2")} Yuan!");
        ReturnToWhiteText();
    }
}
