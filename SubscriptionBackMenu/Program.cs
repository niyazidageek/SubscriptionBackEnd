using SubscriptionBackMenu.Services;
using System;

namespace SubscriptionBackMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            bool temp = false;
            do
            {
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Register");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select an option please");
                string selectionstr = Console.ReadLine();
                while (!int.TryParse(selectionstr, out selection))
                {
                    Console.WriteLine("Enter a number please");
                    selectionstr = Console.ReadLine();
                }
                switch (selection)
                {
                    case 1:
                        temp = MenuService.UserLoginMenu();   
                        break;
                    case 2:
                        MenuService.AddUserMenu();
                        break;
                    case 0:
                        Console.WriteLine("Shutting down...");
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (temp != true || selection == 2);
            int option = 0;
            do
            {
                Console.WriteLine("1. Add product");
                Console.WriteLine("0. Back");
                Console.WriteLine("Select an option please");
                string optionstr = Console.ReadLine();
                while (!int.TryParse(optionstr, out option))
                {
                    Console.WriteLine("Select an option please");
                    optionstr = Console.ReadLine();
                }
                switch (option)
                {
                    case 1:
                        MenuService.AddProductUserMenu();
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (option !=0);
        }
    }
}
