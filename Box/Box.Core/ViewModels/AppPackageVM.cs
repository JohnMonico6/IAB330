using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteTutorial.Core.ViewModels
{
    public class AppPackageVM : ViewModelBase
    {

        private readonly PackageDatabase db;

        public string Name { get; set; }
        public string Room { get; set; }

        public ICommand SubmitCommand { protected set; get; }

        public AppPackageVM()
        {
            db = new PackageDatabase();
            SubmitCommand = new Command(Submit);
        }

        public void Submit()
        {
            db.Insert(new Package()
            {
                Name = Name,
                Room = Room
            });
            Name = String.Empty;
            Room = String.Empty;
        }

    }
}
