using System;
using System.Threading;
class Program
{
    static string registeredUsername = "";
    static string registeredPassword = "";

    static void Main(string[] args)
    {
        // Registration (moved to a separate function for better organization)
        RegisterUser();

        // Login
        if (!Login())
        {
            Console.WriteLine("Incorrect login. Exiting program.");
            return;
        }

        // Clear the console after successful login
        Console.Clear();

        //Simulate loading screen (Improved version)
        SimulateLoading();

        // Electricity Bill Calculation (moved to a separate function)
        CalculateElectricityBill();


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Separate function for user registration
    static void RegisterUser()
    {
        Console.WriteLine(@"
                                                    ======================================================
                                                   |      _  _
___
__      _    _     __
_      |
                                                   |     |  \/  | ____|  _ \    / \  | |   / ___/ _ \     |
                                                   |     | |\/| |  | | |) |  / _ \ | |  | |  | | | |    |
                                                   |     | |  | | |___|  _ <  / _ \| |__| |__| |_| |    |
                                                   |     |_|  |_|_____|_| \_\/_/   \_\_____\____\___/     |
                                                   |                                                      |
                                                    ======================================================

                                              ");
        Console.WriteLine("============================================================================================================================================================");
        Console.WriteLine(" ");

        Console.WriteLine(@"  __________________________________
 |  _   __  _     _  _  _  __  |
 | |__) |__  / _ | /__  |  |__  |__) |
 | |  \ |___ \__> | .__/  |  |___ |  \ |");
        Console.WriteLine("  __________________________________");

        Console.Write("Enter username: ");
        registeredUsername = Console.ReadLine();
        Console.Write(@"Enter password: ");
        registeredPassword = Console.ReadLine();
    }


    // Separate function for login
    static bool Login()
    {
        Console.WriteLine(@"
");
        Console.WriteLine("============================================================================================================================================================");
        Console.WriteLine("");

        Console.WriteLine(@"
                                                             ________________________________
                                                             |    _    _   _
_ _  _     |
                                                             |   | |  / _ \ / _| _| \| |    |
                                                             |   | |_| () | ( || || .` |    |
                                                             |   |____\___/ \___|___|_|\_     |
                                                             ________________________________");

        Console.Write(@"
                                                                Username: ");
        string username = Console.ReadLine();
        Console.Write(@"
                                                                Password: ");
        string password = Console.ReadLine();

        // Check if username and password match the registered ones
        return username == registeredUsername && password == registeredPassword;
    }

    // Separate function for electricity bill calculation.  Improved error handling.
    static void CalculateElectricityBill()
    {
        double ratePerKWh;
        double previousMonthKWh;
        double currentMonthKWh;
        double previousBill;
        double currentBill;


        Console.WriteLine(@"
============================================================================================================================================================");

        Console.WriteLine(@"                                         _______________________________________________________________________________
                                        |   _
_ _    _       _
_  _  _ _ _   _ _  _
_
___
_
_  _  _   |
                                        |  | _ )_ | |  | |     / __/ _ \| \| / __| | | |  \/  | _ \   | _/ _ \| \| |  |
                                        |  | _ \| || |__| |__  | (| () | .` \__ \ |_| | |\/| |  / | |  | | () | .` |  |
                                        |  |___/___|____|____|  \___\___/|_|\_|___/\___/|_|  |_|_|   |_| |___\___/|_|\_|  |
                                         ---------------------------------------------------------------------------------");

        //Input with error handling
        while (true)
        {
            Console.Write("\nEnter rate per kWh: ");
            if (double.TryParse(Console.ReadLine(), out ratePerKWh) && ratePerKWh > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }

        while (true)
        {
            Console.Write("Enter kWh consumption for the previous month: ");
            if (double.TryParse(Console.ReadLine(), out previousMonthKWh) && previousMonthKWh >= 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
        }

        // Calculate the previous Bill
        previousBill = previousMonthKWh * ratePerKWh;
        // Total Bill
        Console.WriteLine($"\nPrevious month bill: \u20B1{previousBill:F2}");

        while (true)
        {
            Console.Write("Enter kWh consumption for the current month: ");
            if (double.TryParse(Console.ReadLine(), out currentMonthKWh) && currentMonthKWh >= 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
        }

        // Calculate the curent Bill
        currentBill = currentMonthKWh * ratePerKWh;

        // Show bills and comparison
        Console.WriteLine($"Current month bill: \u20B1{currentBill:F2}");
        Console.WriteLine($"Previous month bill: \u20B1{previousBill:F2}");

        // Calculate the difference between the two bills and remove the negative sign if applicable
        double difference = currentBill - previousBill;
        Console.WriteLine($"Difference between previous and current month: \u20B1{Math.Abs(difference):F2}");

        // Compare bills and show which one is higher
        if (currentBill > previousBill)
        {
            Console.WriteLine("The current bill is higher than the previous bill.");
        }
        else if (currentBill < previousBill)
        {
            Console.WriteLine("The current bill is lower than the previous bill.");
        }
        else
        {
            Console.WriteLine("The current and previous bills are the same.");
        }
    }

    //Improved loading screen
    static void SimulateLoading()
    {
        Console.Write("Loading");
        for (int i = 0; i < 50; i++)

        {
            Thread.Sleep(20); //Reduced delay for better UX
            Console.Write("█");

        }

        Console.WriteLine("\nLoading complete!");
        Console.Clear();
    }

}