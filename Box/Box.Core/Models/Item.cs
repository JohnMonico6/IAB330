using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.Models
{
    public class Item
    {
        private string itemName;
        public string Name {
            get {
                return itemName;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new Exception("Items must have a Name");
                }
                itemName = value;
            }      
        }

        public int Quantity { get; set; }
        public Item(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }
    }
}
