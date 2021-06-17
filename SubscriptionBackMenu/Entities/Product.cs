using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBackMenu.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Product(string name)
        {
            Name = name;
            Status = "Active";  
        }
    }
}
