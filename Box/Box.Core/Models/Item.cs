using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Item(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }
    }
}
