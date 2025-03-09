using System;


class Marielag
{
    static List<(string Username, string Password)> users = new();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("1. Register User\n2. Login\n3. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    if (Login())
                    {
                        CalculateElectricityBill();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect login. Returning to menu...");
                    }
                    break;
                case "3":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        users.Add((username, password));
        Console.WriteLine("Registration successful!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static bool Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = ReadPassword();
        return users.Exists(user => user.Username == username && user.Password == password);
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

    static void CalculateElectricityBill()
    {
        Console.Write("Enter rate per kWh: ");
        double ratePerKWh = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter kWh consumption for the previous month: ");
        double previousMonthKWh = Convert.ToDouble(Console.ReadLine());
        double previousBill = previousMonthKWh * ratePerKWh;
        Console.WriteLine($"Previous month bill: \u20B1{previousBill:F2}");

        Console.Write("Enter kWh consumption for the current month: ");
        double currentMonthKWh = Convert.ToDouble(Console.ReadLine());
        double currentBill = currentMonthKWh * ratePerKWh;

        Console.WriteLine($"Current month bill: \u20B1{currentBill:F2}");
        Console.WriteLine($"Previous month bill: \u20B1{previousBill:F2}");
        Console.WriteLine($"Difference: \u20B1{Math.Abs(currentBill - previousBill):F2}");

        Console.WriteLine(currentBill > previousBill ? "Current bill is higher." : currentBill < previousBill ? "Current bill is lower." : "Bills are the same.");

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
}
