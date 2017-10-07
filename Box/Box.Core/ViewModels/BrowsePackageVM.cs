using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SqliteTutorial.Core.Models;

namespace SqliteTutorial.Core.ViewModels
{
    public class BrowsePackageVM : ViewModelBase
    {
        public ObservableCollection<Package> Packages
        {
            get
            {
                var oc = new ObservableCollection<Package>();
                oc.Add(new Package
                {
                    Name = "Name1",
                    Room = "Room",
                    Items = "Items"
                });
                oc.Add(new Package
                {
                    Name = "Name2",
                    Room = "Room",
                    Items = "Items"
                });
                return oc;
            }
            set
            {
            }
        }

        public BrowsePackageVM()
        {
            // TODO: Get packages here, store them in the variable Packages
        }
    }
}
