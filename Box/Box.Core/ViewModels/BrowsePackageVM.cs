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
    /// View Model for the BrowsePackagePage
    /// TODO: Move search functionality here
    /// </summary>
    public class BrowsePackageVM : ViewModelBase
    {

        private readonly PackageDatabase db;

        /// <summary>
        /// Data bindings
        /// </summary>
        public ObservableCollection<Package> Packages { get; set; }
        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        /// <summary>
        /// Constructor
        /// Establishes a database link, shows all the Packages in a list
        /// </summary>
        public BrowsePackageVM()
        {

            db = new PackageDatabase();
            Packages = new ObservableCollection<Package>(db.GetPackages());
            //GenerateLabelCommand = new Command(GenerateLabel);
        }

    }

}
