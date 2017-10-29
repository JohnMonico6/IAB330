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
    /// View Model for the PackagePage
    /// Binds to PackagePage.
    /// </summary>
    public class PackagePageVM : ViewModelBase
    {

        private readonly PackageDatabase db;

        /// <summary>
        /// Data bindings
        /// </summary>
        private Package package;
        public string Name { get; set; }
        public string Room { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ICommand GenerateLabelCommand { protected set; get; }
        public ICommand MoveItemCommand { protected set; get; }
        public ICommand OnAppearingCommand { set; get; }
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Constructor
        /// General initialization
        /// </summary>
        /// <param name="navigation">Navigation object</param>
        /// <param name="p">Package</param>
        public PackagePageVM(INavigation navigation, Package p)
        {
            this.Navigation = navigation;
            this.GenerateLabelCommand = new Command(async () => await GenerateLabel(p));
            MoveItemCommand = new Command(MoveItem);
            OnAppearingCommand = new Command(OnAppearing);

            db = new PackageDatabase();
            package = p;
            Name = p.Name;
            Room = p.Room;
            //ItemList = new ObservableCollection<Item>();
            ItemList = new ObservableCollection<Item>(p.GetItemList()); // Useful when we can actually put items within a package in the database
            //ItemList.Add(new Item("Item Name", 0)); // Temporary so we can see items
        }

        public void OnAppearing()
        {
            //
        }

        public void MoveItem(object i)
        {
            var mip = new MoveItemPage()
            {
                BindingContext = new MoveItemVM(Navigation,package, i as Item)
            };
            Navigation.PushAsync(mip);
        }

        /// <summary>
        /// GenerateLabel()
        /// Generates a given label
        /// </summary>
        /// <param name="p">The package that the label will generate</param>
        /// <returns></returns>
        public async Task GenerateLabel(Package p)
        {
            var pvm = new ViewLabelVM(Navigation, p);
            var page = new LabelPage()
            {
                BindingContext = pvm
            };
            await Navigation.PushAsync(page);
        }

        /// <summary>
        /// DeleteItem()
        /// Removes the selected item
        /// </summary>
        public ICommand DeleteItem {

            get {
                return new Command((e) => {

                    var item = (e as Item);

                    ItemList.Remove(item);
                    package.SetItemList(new List<Item>(ItemList));
                    db.DeleteItem(package, item);
                });
            }
            
        }

    }

}
