using System;
using System.Collections.Generic;

class MERIELAG
{
    static List<User> users = new List<User>();
    static User loggedInUser = null;

    static void Main(string[] args)
    {
        Console.Clear();
        ShowMenu();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (Login())
                    {
                        Console.Clear();
                        CalculateElectricityBill();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect login. Please try again.");
                    }
                    break;
                case "2":
                    RegisterUser();
                    break;
                case "3":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1, 2, or 3.");
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("=== Registration ===");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (users.Exists(user => user.Username == username))
        {
            Console.WriteLine("Username already exists. Please choose a different one.");
            return;
        }

        users.Add(new User(username, password));
        Console.WriteLine("Registration successful!");
    }

    static bool Login()
    {
        Console.Clear();
        Console.WriteLine("=== Login ===");

        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        loggedInUser = users.Find(user => user.Username == username && user.Password == password);
        return loggedInUser != null;
    }

    static void CalculateElectricityBill()
    {
        double ratePerKWh, previousMonthKWh, currentMonthKWh, previousBill, currentBill;

        Console.WriteLine("\n=== Electricity Bill Calculator ===");

        while (true)
        {
            Console.Write("Enter rate per kWh: ");
            if (double.TryParse(Console.ReadLine(), out ratePerKWh) && ratePerKWh > 0)
                break;
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }

        while (true)
        {
            Console.Write("Enter kWh consumption for the previous month: ");
            if (double.TryParse(Console.ReadLine(), out previousMonthKWh) && previousMonthKWh >= 0)
                break;
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
        }

        previousBill = previousMonthKWh * ratePerKWh;
        Console.WriteLine($"\nPrevious month bill: \u20B1{previousBill:F2}");

        while (true)
        {
            Console.Write("Enter kWh consumption for the current month: ");
            if (double.TryParse(Console.ReadLine(), out currentMonthKWh) && currentMonthKWh >= 0)
                break;
            Console.WriteLine("Invalid input. Please enter a non-negative number.");
        }

        currentBill = currentMonthKWh * ratePerKWh;
        Console.WriteLine($"Current month bill: \u20B1{currentBill:F2}");
        Console.WriteLine($"Difference: \u20B1{Math.Abs(currentBill - previousBill):F2}");

        Console.WriteLine(currentBill > previousBill
            ? "The current bill is higher."
            : currentBill < previousBill
                ? "The current bill is lower."
                : "The current and previous bills are the same.");

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        Console.Clear();
    }
}

class User
{
    public string Username { get; }
    public string Password { get; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}