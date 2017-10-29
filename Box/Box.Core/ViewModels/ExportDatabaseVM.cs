using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Interfaces;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteTutorial.Core.ViewModels {
    class ExportDatabaseVM : ViewModelBase {

        private readonly PackageDatabase db;

        public ICommand ExportCommand { protected set; get; }

        public ExportDatabaseVM() {
            db = new PackageDatabase();
            ExportCommand = new Command(ExportDatabase);
        }

        public void ExportDatabase() {

            DependencyService.Get<ISave>().SaveFile(db);
        }  
    }
}
