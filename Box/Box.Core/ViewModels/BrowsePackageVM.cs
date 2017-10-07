using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SqliteTutorial.Core.Models;
using SqliteTutorial.Core.Database;

namespace SqliteTutorial.Core.ViewModels
{
    public class BrowsePackageVM : ViewModelBase
    {
        private readonly PackageDatabase db;
        public ObservableCollection<Package> Packages { get; set; }

        public BrowsePackageVM()
        {
            db = new PackageDatabase();
            Packages = new ObservableCollection<Package>(db.GetPackages());
        }
    }
}
