using System;

namespace SqliteTutorial.Core.Models
{

    /// <summary>
    /// Item
    /// Treated like an item set, has a name and a quantity
    /// </summary>
    public class Item
    {

        /// <summary>
        /// itemName
        /// Can only be set to something that is readable
        /// </summary>
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

        /// <summary>
        /// Used to work more functionally within lists
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Item) ? String.Equals((obj as Item).Name,Name) : false;
        }

        /// <summary>
        /// Quantity
        /// The amount of this item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor
        /// Builds an item with the given name and quantity
        /// </summary>
        /// <param name="Name">The given name</param>
        /// <param name="Quantity">The given quantity</param>
        public Item(string Name, int Quantity)
        {
            this.Name = Name;
            this.Quantity = Quantity;
        }

    }

}
