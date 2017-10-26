﻿using SqliteTutorial.Core.Database;
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

        private readonly PackageDatabase db;
        private Package package;
        public string Name { get; set; }
        public string Room { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ICommand GenerateLabelCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public PackagePageVM(INavigation navigation, Package p)
        {
            this.Navigation = navigation;
            this.GenerateLabelCommand = new Command(async () => await GenerateLabel(p));

            db = new PackageDatabase();
            package = p;
            Name = p.Name;
            Room = p.Room;
            //ItemList = new ObservableCollection<Item>();
            ItemList = new ObservableCollection<Item>(p.GetItemList()); // Useful when we can actually put items within a package in the database
            //ItemList.Add(new Item("Item Name", 0)); // Temporary so we can see items
        }
        public async Task GenerateLabel(Package p)
        {
            var pvm = new ViewLabelVM(Navigation, p);
            var page = new LabelPage()
            {
                BindingContext = pvm
            };
            await Navigation.PushAsync(page);
        }

        public ICommand DeleteItem {

            get {
                return new Command((e) => {
                    List<Item> tempList = new List<Item>(package.GetItemList());
                    var item = (e as Item);

                    ItemList.Remove(item);
                    tempList.Remove(item);
                    package.SetItemList(new List<Item>(ItemList));
                    db.DeleteItem(package);
                });
            }
            
        }
    }
}
