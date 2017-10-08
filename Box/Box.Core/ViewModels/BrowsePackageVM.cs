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
    public class BrowsePackageVM : ViewModelBase
    {
        private readonly PackageDatabase db;
        public ObservableCollection<Package> Packages { get; set; }

        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> Items { get; set; }


        public BrowsePackageVM()
        {

            db = new PackageDatabase();
            Packages = new ObservableCollection<Package>(db.GetPackages());
            //GenerateLabelCommand = new Command(GenerateLabel);
        }

    }
}
