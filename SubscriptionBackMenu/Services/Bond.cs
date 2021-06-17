using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBackMenu.Services
{
    public class Bond
    {
        public static void Startup()
        {
            Parallel.Invoke(Menu, MenuService.SendAlertMenu, MenuService.DeleteCheckMenu);
        }
        
        public static void Menu()
        {
            int selection = 0;
            int option = 5;
            int selection1 = 5;
            bool temp = false;

            do
            {
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Admin panel");
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
                    case 3:
                        do
                        {
                            Console.WriteLine("1. Add product");
                            Console.WriteLine("2. Edit product");
                            Console.WriteLine("3. Remove product");
                            Console.WriteLine("0.Back to home page");
                            Console.WriteLine("Select an option please");
                            string selection1str = Console.ReadLine();
                            while (!int.TryParse(selection1str, out selection1))
                            {
                                Console.WriteLine("Enter a number please");
                                selection1str = Console.ReadLine();
                            }
                            switch (selection1)
                            {
                                case 1:
                                    MenuService.AddProductAdminMenu();
                                    break;
                                case 2:
                                    MenuService.EditProductAdminMenu();
                                    break;
                                case 3:
                                    MenuService.RemoveProductAdminMenu();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("There is no such option");
                                    break;
                            }
                        } while (selection1 != 0);
                        break;
                    case 0:
                        throw new Exception("Shutting down!");
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
                if (temp == true)
                {
                    do
                    {
                        Console.WriteLine("1. Add subcription");
                        Console.WriteLine("2. Edit subcription");
                        Console.WriteLine("3. Remove subcription");
                        Console.WriteLine("4. Delete account");
                        Console.WriteLine("0. Log out");
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
                            case 2:
                                MenuService.EditProductUserMenu();
                                break;
                            case 3:
                                MenuService.RemoveProductUserMenu();
                                break;
                            case 4:
                                MenuService.DeleteUserMenu();
                                temp = false;
                                MenuService.user = null;
                                break;
                            case 0:
                                Console.WriteLine("Logged out!");
                                temp = false;
                                MenuService.user = null;
                                break;
                            default:
                                Console.WriteLine("There is no such option");
                                break;
                        }
                    } while (option != 0 && option != 4);
                }
            } while (temp != true || selection == 2 || option == 0 || selection1 == 0);
        }
    }
}
