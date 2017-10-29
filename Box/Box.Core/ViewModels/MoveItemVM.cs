using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteTutorial.Core.ViewModels
{
    class MoveItemVM : ViewModelBase
    {

        private PackageDatabase db;

        private INavigation Navigation;

        private Package package;

        private Item item;

        public ObservableCollection<Package> Packages { get; set; }

        public MoveItemVM(INavigation n, Package p, Item i)
        {
            Navigation = n;
            package = p;
            item = i;
            db = new PackageDatabase();
            Packages = new ObservableCollection<Package>(db.GetPackages());
        }

        private Package _SelectedPackage;
        public Package SelectedPackage
        {
            get
            {
                return _SelectedPackage;
            }
            set
            {
                var items = package.GetItemList();
                items.Remove(item);
                package.SetItemList(items);
                var p2 = (value as Package);
                var items2 = p2.GetItemList();
                items2.Insert(items2.Count,item);
                p2.SetItemList(items2);
                db.Update(package);
                db.Update(p2);
                Navigation.PopAsync();
            }
        }

    }
}
