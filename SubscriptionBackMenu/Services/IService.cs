using SubscriptionBackMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBackMenu.Services
{
    public interface IService
    {
        public void AddUser(string name, string surname, string mail, string phone, string password);
        public void EditUser(string mail, string newname, string newsurname, string newphone, string newpassword);
        public void DeleteUser(User user);
        public void AddProductAdmin(string name);
        public void EditProductAdmin(string name, string newname);
        public void RemoveProductAdmin(string name);
        public void AddProductUser(User user, string name, DateTime purchasedate, int duration);
        public void EditProductUser(User user, string name, DateTime newpurchasedate, int duration);
        public void RemoveProductUser(User user, string name);
        public bool UserLogin(string mail, string password);
        public void SendAlert();
    }

}