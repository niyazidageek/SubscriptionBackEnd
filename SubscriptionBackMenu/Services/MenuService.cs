using SubscriptionBackMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBackMenu.Services
{
    public class MenuService
    {
        public static User user = null;
        static SubscriptionService method = new();
        //public static void ConstantCheck()
        //{
        //    if (method.Users.Count != 0)
        //        Parallel.Invoke(SendAlertMenu, DeleteCheckMenu);
        //}
        public static void AddUserMenu()
        {
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter the mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter the phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the new password");
            string password = Console.ReadLine();
            try
            {
                method.AddUser(name, surname, mail, phone, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void EditUserMenu()
        {
            Console.WriteLine("Enter the mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter the new name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter the new phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the new password");
            string password = Console.ReadLine();
            try
            {
                method.EditUser(mail, name, surname, phone, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
       public static void AddProductAdminMenu()
       {
           Console.WriteLine("Enter the name of the product please");
           string name = Console.ReadLine();
           try
           {
               method.AddProductAdmin(name);
           }
           catch (Exception e)
           {
               Console.WriteLine("Something went wrong!");
               Console.WriteLine(e.Message);
           }
       }
        public static void EditProductAdminMenu()
        {
            Console.WriteLine("Enter the name of the product please");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new name of the product please");
            string newname = Console.ReadLine();
            try
            {
                method.EditProductAdmin(name, newname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void RemoveProductAdminMenu()
        {
            Console.WriteLine("Enter the name of the product please");
            string name = Console.ReadLine();
            try
            {
                method.RemoveProductAdmin(name);
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
        }
        public static void DeleteUserMenu()
        {
            try
            {
                method.DeleteUser(user);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
        }
        public static void AddProductUserMenu()
        {
            DateTime purchasedate = new();
            int duration = 0;
            Console.WriteLine("Enter the name of the product please");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the purchase date please (mm.dd.yyy)");
            string purchasedatestr = Console.ReadLine();
            while(!DateTime.TryParse(purchasedatestr, out purchasedate))
            {
                Console.WriteLine("The format is wrong. Try to re-insert the date (mm.dd.yyy)");
                purchasedatestr = Console.ReadLine();
            }
            Console.WriteLine("Enter the duration please");
            string durationstr = Console.ReadLine();
            while(!int.TryParse(durationstr, out duration))
            {
                Console.WriteLine("Enter the number please");
                durationstr = Console.ReadLine();
            }
            try
            {
                method.AddProductUser(user, name, purchasedate, duration);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void EditProductUserMenu()
        {
            DateTime newpurchasedate = new();
            int duration = 0;
            Console.WriteLine("Enter the name of the product please");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new purchase date please (mm.dd.yyy)");
            string newpurchasedatestr = Console.ReadLine();
            while (!DateTime.TryParse(newpurchasedatestr, out newpurchasedate))
            {
                Console.WriteLine("The format is wrong. Try to re-insert the date (mm.dd.yyy)");
                newpurchasedatestr = Console.ReadLine();
            }
            string durationstr = Console.ReadLine();
            while (!int.TryParse(durationstr, out duration))
            {
                Console.WriteLine("Enter the number please");
                durationstr = Console.ReadLine();
            }
            try
            {
                method.EditProductUser(user, name, newpurchasedate, duration);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static void RemoveProductUserMenu()
        {
            Console.WriteLine("Enter the name of the product please");
            string name = Console.ReadLine();
            try
            {
                method.RemoveProductUser(user, name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
        }
        public static bool UserLoginMenu()
        {
            Console.WriteLine("Enter the email");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            try
            {
                method.UserLogin(mail, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }
            return method.UserLogin(mail, password);
        }
        public static void SendAlertMenu()
        {
            while (true)
            {
                method.SendAlert();
            }
        }
        public static void DeleteCheckMenu()
        {
            while (true)
            {
                method.DeleteCheck();
            }
            
        }
    }
}
