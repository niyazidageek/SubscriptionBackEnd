using SubscriptionBackMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBackMenu.Services
{
    class SubscriptionService:IService
    {
        public static int check = 0;
        public List<User> Users { get; set; }   
        public List<Product> SystemProducts { get; set; }
        public SubscriptionService()
        {
            Users = new();
            SystemProducts = new();
        }

        public void AddUser(string name, string surname, string mail, string phone, string password)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentNullException("Surname is null");
            if (IsValid(mail) != true)
                throw new Exception("Email format is wrong");
            if (string.IsNullOrEmpty(phone))
                throw new ArgumentNullException("Phone is null");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Password is null");

            User user = new(name, surname, mail, phone, password);
            Users.Add(user);
            Console.WriteLine("Registartion has been completed successfully!");
        }

        public void EditUser(string mail, string newname, string newsurname, string newphone, string newpassword)
        {
            var user = Users.Find(s=>s.Mail == mail);
            if (user == null)
                throw new ArgumentNullException("There is no such user!");
            if (string.IsNullOrEmpty(newname))
                throw new ArgumentNullException("Name is null");
            if (string.IsNullOrEmpty(newsurname))
                throw new ArgumentNullException("Surname is null");
            if (string.IsNullOrEmpty(newphone))
                throw new ArgumentNullException("Phone is null");
            if (string.IsNullOrEmpty(newpassword))
                throw new ArgumentNullException("Password is null");
            user.Name = newname;
            user.Surname = newsurname;
            user.Phone = newphone;
            user.Password = newpassword;
            Console.WriteLine("Changes have been saved");
        }

        public void DeleteUser(User user)
        {            
            user.Status = "Account is disabled";
            user.DisableCheck = DateTime.Now;
            Console.WriteLine("Account will be deleted after 3 days");
        }

        public void AddProductAdmin(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            Product product = new(name);
            SystemProducts.Add(product);
            Console.WriteLine("Category has been succeessfully added!");
        }

        public void EditProductAdmin(string name, string newname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(newname))
                throw new ArgumentNullException("Name can not be null");
            var product = SystemProducts.Find(s => s.Name == name);
            if (product == null)
                throw new ArgumentNullException("There is no such category!");
            product.Name = newname;
        }

        public void RemoveProductAdmin(string name)
        {
            var product = SystemProducts.Find(s=>s.Name == name);
            if (product == null)
                throw new ArgumentNullException("There is no such category!");
            SystemProducts.Remove(product);
            Console.WriteLine("Category has been successfully removed");
        }

        public void AddProductUser(User user, string name, DateTime purchasedate, int duration)
        {            
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var product = SystemProducts.Find(s=>s.Name == name);
            if (product == null)
                throw new ArgumentNullException("There is no such product");
            product.PurchaseDate = purchasedate;
            product.ExpireDate = purchasedate.AddDays(duration);
            user.UserProducts.Add(product);
            Console.WriteLine("Product has been successfully added");
        }

        public void EditProductUser(User user,string name, DateTime newpurchasedate, int duration)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var product = SystemProducts.Find(s => s.Name == name);
            if (product == null)
                throw new ArgumentNullException("There is no such product");
            product.PurchaseDate = newpurchasedate;
            product.ExpireDate = newpurchasedate.AddSeconds(duration);
            Console.WriteLine("Changes have been saved");
        }

        public void RemoveProductUser(User user, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is null");
            var product = SystemProducts.Find(s => s.Name == name);
            if (product == null)
                throw new ArgumentNullException("There is no such product");
            user.UserProducts.Remove(product);
            Console.WriteLine("Product has been successfully removed");
        }

        public bool UserLogin(string mail, string password)
        {
            if (string.IsNullOrEmpty(mail))
                throw new ArgumentNullException("Mail is null");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Password is null");
            var user = Users.Find(s => s.Mail == mail && s.Password == password);
            if (user == null)
            {
                return false;
            }
            else
            {
                MenuService.user = user;
                user.Status = "Active";
                return true;
            }        
        }

        public void SendAlert()
        {
            
            //foreach (var product in user.UserProducts)
            //{
            //    DateTime date = DateTime.Now;
            //    if(product.ExpireDate.Second - date.Second != 5)
            //    {
            //        date = DateTime.Now;
            //    }
            //    Console.WriteLine("There are 5 seconds left");
            //    date = DateTime.Now;
            //    if(product.ExpireDate.Second == date.Second)
            //        product.Status = "Expired";
            //}
            //for (int i = 0; i < Users.Count; i++)
            //{
            //    for (int j = 0; j < Users[i].UserProducts.Count; j++)
            //    {
            //        DateTime date = DateTime.Now;
            //        int result = Users[i].UserProducts[j].ExpireDate.Day - date.Day;
            //        while (result >= 0)
            //        {
            //            date = DateTime.Now;
            //        }
            //        Users[i].UserProducts[j].Status = "Expired";
            //        Console.WriteLine("Product has been expired");
            //    }
            //}
            //foreach (var user in Users)
            //{
            //    foreach (var item in user.UserProducts)
            //    {
            //        DateTime date = DateTime.Now;
            //        while (item.ExpireDate.Day - date.Day > 0)
            //        {
            //            date = DateTime.Now;
            //        }
            //        item.Status = "Expired";
            //        Console.WriteLine("Product has been expired");
            //    }
            //}
            Parallel.ForEach(Users, user =>
            {
                Parallel.ForEach(user.UserProducts, product =>
                {
                    DateTime date = DateTime.Now;
                    while (product.ExpireDate.Day - date.Day > 0)
                    {
                        date = DateTime.Now;
                    }
                    product.Status = "Expired";
                    Console.WriteLine("product has expired");
                    check = 1;
                });
            });
            check = 0;
            //DateTime date = DateTime.Now;
            //while (product.ExpireDate.Day - date.Day ! <= 0)
            //{
            //    date = DateTime.Now;
            //}
            //Console.WriteLine("There are 5 seconds left");
            //while (product.ExpireDate.Second != date.Second)
            //{
            //    date = DateTime.Now;
            //}           
            //});
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public void DeleteCheck()
        {
            Parallel.ForEach(Users, user =>
            {
                DateTime datecheck = DateTime.Now;
                while (datecheck.Second != user.DisableCheck.AddSeconds(10).Second)
                {
                    datecheck = DateTime.Now;
                }
                if (user.Status != "Active")
                    Users.Remove(user);
            });
        }
    }
}
