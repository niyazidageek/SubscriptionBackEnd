using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SubscriptionBackMenu.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime DisableCheck { get; set; }
        public List<Product> UserProducts { get; set; }
        public User(string name, string surname, string mail, string phone, string password)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Phone = phone;
            Password = password;
            Status = "Active";
        }
    }
}
