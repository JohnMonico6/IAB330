using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SqliteTutorial.Core.ViewModels
{
    /// <summary>
    /// <code>PackagePageVM(Package p)</code>
    /// Binds to PackagePage.
    /// </summary>
    public class PackagePageVM : ViewModelBase
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ICommand GenerateLabelCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public PackagePageVM(INavigation navigation, Package p)
        {
            this.Navigation = navigation;
            this.GenerateLabelCommand = new Command(async () => await GenerateLabel());
            Name = p.Name;
            Room = p.Room;
            //ItemList = new ObservableCollection<Item>();
            ItemList = new ObservableCollection<Item>(p.GetItemList()); // Useful when we can actually put items within a package in the database
            //ItemList.Add(new Item("Item Name", 0)); // Temporary so we can see items
        }
        public async Task GenerateLabel()
        {
            await Navigation.PushAsync(new PackageLabel());
        }
    }
}
