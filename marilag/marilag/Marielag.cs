using System;

class Marielag
{
    static string registeredUsername = "";
    static string registeredPassword = "";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string username, password;
        double ratePerKWh, currentMonthKWh, previousMonthKWh, currentBill, previousBill;
        Console.Clear();
        // Register a user
        Console.WriteLine(@"
                                                    ======================================================
                                                   |      __  __ _____ ____      _    _     ____ ___      |
                                                   |     |  \/  | ____|  _ \    / \  | |   / ___/ _ \     |
                                                   |     | |\/| |  _| | |_) |  / _ \ | |  | |  | | | |    |
                                                   |     | |  | | |___|  _ <  / ___ \| |__| |__| |_| |    |
                                                   |     |_|  |_|_____|_| \_\/_/   \_\_____\____\___/     |
                                                   |                                                      |
                                                    ======================================================

                                              ");
        Console.WriteLine("============================================================================================================================================================");
        Console.WriteLine(" ");

        Console.WriteLine(@"  _____________________________________
 |  __   ___  __     __  ___  ___  __  |
 | |__) |__  / _` | /__`  |  |__  |__) |
 | |  \ |___ \__> | .__/  |  |___ |  \ |
 |_____________________________________|");

        Console.Write(" Enter username: ");
        registeredUsername = Console.ReadLine();
        Console.Write(" Enter password: ");
        registeredPassword = Console.ReadLine();
        Console.WriteLine("  Registration successful!!");

        // Login

        if (!Login())
        {
            Console.WriteLine("Incorrect login. Exiting program.");
            return;
        }
        Console.Clear();
        // Input rate per kWh
        Console.WriteLine(@"
============================================================================================================================================================");

        Console.WriteLine(@"                                         _________________________________________________________________________________ 
                                        |   ___ ___ _    _       ___ ___  _  _ ___ _   _ __  __ ___ _____ ___ ___  _  _   |
                                        |  | _ )_ _| |  | |     / __/ _ \| \| / __| | | |  \/  | _ \_   _|_ _/ _ \| \| |  |
                                        |  | _ \| || |__| |__  | (_| (_) | .` \__ \ |_| | |\/| |  _/ | |  | | (_) | .` |  |
                                        |  |___/___|____|____|  \___\___/|_|\_|___/\___/|_|  |_|_|   |_| |___\___/|_|\_|  |
                                        |_________________________________________________________________________________|");


        Console.Write("\nEnter rate per kWh: ");
        ratePerKWh = Convert.ToDouble(Console.ReadLine());

        // Input previous
        Console.Write("Enter kWh consumption for the previous month: ");
        previousMonthKWh = Convert.ToDouble(Console.ReadLine());
        // Calculate the previous Bill

        previousBill = previousMonthKWh * ratePerKWh;
        // Total Bill
        Console.WriteLine($"\nPrevious month bill: \u20B1{previousBill:F2}");

        // Input Current Bill
        Console.Write("Enter kWh consumption for the current month: ");
        currentMonthKWh = Convert.ToDouble(Console.ReadLine());

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


        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static bool Login()
    {
        Console.WriteLine(@"
");
        Console.WriteLine("============================================================================================================================================================");
        Console.WriteLine("");

        Console.WriteLine(@"
                                                             __________________________________
                                                             |    _    ___   ___ ___ _  _     |
                                                             |   | |  / _ \ / __|_ _| \| |    |
                                                             |   | |_| (_) | (_ || || .` |    |
                                                             |   |____\___/ \___|___|_|\_     |
                                                             __________________________________");

        Console.Write(@"
                                                                Username: ");
        string username = Console.ReadLine();
        Console.Write(@"
                                                                Password: ");
        string password = ReadPassword();

        // Check if username and password match the registered ones
        return username == registeredUsername && password == registeredPassword;
    }
    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[..^1];
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}
