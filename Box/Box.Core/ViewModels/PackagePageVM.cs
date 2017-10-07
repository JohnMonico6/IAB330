using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.ViewModels
{
    public class PackagePageVM : ViewModelBase
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public PackagePageVM(Package p)
        {
            Name = "Test Package";
            Room = "Test Room";
            ItemList = new ObservableCollection<Item>();
            ItemList.Add(new Item("Item Name", 0));
        }
    }
}
