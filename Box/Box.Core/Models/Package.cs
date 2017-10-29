using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using System.Collections.ObjectModel;
using SqliteTutorial.Core.ViewModels;

namespace SqliteTutorial.Core.Models
{
    public class Package
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

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

        /*Can't figure out how to get this to work when handling exceptions. Because it's called from BrowsePackagePage, if there's ever a package without
         an item in it, it will crash the app. Problem is, you can remove all the items from pacakges in PackagePage and create packages with no items in AddPackagePage.
         */
        public string Items { get; set; }

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
        public List<Item> AddItem(List<Item> items, string Name, int Quantity)
        {
            items.Add(new Item(Name, Quantity));
            return items;
        }
    }

}
