using System.Collections.Generic;
using SQLite.Net.Attributes;
using System.Linq;
using System;

namespace SqliteTutorial.Core.Models
{

    /// <summary>
    /// Package
    /// Its structure is used in SQLite to build the database
    /// Contains a list of items, an id, name and destination
    /// </summary>
    public class Package
    {

        /// <summary>
        /// Id
        /// Automatically set by the database
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// The name of the package, must be human readable text
        /// </summary>
        private string packageName;
        public string Name {
            get {
                return packageName;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new Exception("Packages must have a Name");
                }
                packageName = value;
            }
        }

        /// <summary>
        /// Items
        /// The list of items serialized to a string
        /// Should NOT be accessed directly, it is only public so that SQLite picks it up and uses it
        /// If you want to get the items within this package, use GetItemList() and SetItemList(...)
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// Room/Destination
        /// Can only be set to human readable text
        /// </summary>
        private string packageRoom;
        public string Room {
            get {
                return packageRoom;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new Exception("Packages must have a Room");
                }
                packageRoom = value;
            }
        }

        /// <summary>
        /// GetItemList()
        /// Builds and returns the list of items contained within this package
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItemList()
        {
            List<string> tempList = Items.Split(',').ToList();
            List<Item> items = new List<Item>();
            for (int x = 0; x < tempList.Count; x++)
            {
                if (x % 2 != 0)
                {
                       
                    items.Add(new Item(tempList[x - 1], Int32.Parse(tempList[x])));
                }
            }
            return items;
        }

        /// <summary>
        /// SetItemList(items)
        /// The item list to assign to the package
        /// </summary>
        /// <param name="items">The list of items to assign</param>
        public void SetItemList(List<Item> items)
        {
            string temp = "";
            foreach (Item it in items)
            {
                if (temp != "")
                {
                    temp += ",";
                }
                temp += it.Name;
                temp += ",";
                temp += it.Quantity;
            }
            Items = temp;
        }

        /// <summary>
        /// AddItem(items,Name,Quantity)
        /// Generates an item with the given name and quantity, adds it to the specified list?
        /// </summary>
        /// <param name="items">The list of items</param>
        /// <param name="Name">The name of the new item</param>
        /// <param name="Quantity">The quantity of that new item</param>
        /// <returns></returns>
        public List<Item> AddItem(List<Item> items, string Name, int Quantity)
        {
            items.Add(new Item(Name, Quantity));
            return items;
        }

    }

}
