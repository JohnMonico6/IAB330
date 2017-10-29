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

    /// <summary>
    /// View Model for the ExportDatabasePage
    /// Handes data exporting
    /// </summary>
    class ExportDatabaseVM : ViewModelBase {

        private readonly PackageDatabase db;

        /// <summary>
        /// Data bindings
        /// </summary>
        public ICommand ExportCommand { protected set; get; }
        public ICommand ExportCSVCommand { protected set; get; }

        /// <summary>
        /// Constructor
        /// Establishes a database connection and data bindings
        /// </summary>
        public ExportDatabaseVM() {
            db = new PackageDatabase();
            ExportCommand = new Command(BakckupDatabase);
            ExportCSVCommand = new Command(ExportDatabaseAsCSV);
        }

        /// <summary>
        /// ExportDatabase()
        /// Exports the database to a flat file
        /// </summary>
        public void BakckupDatabase() {
            DependencyService.Get<ISave>().SaveFile(db);
        }

        public void ExportDatabaseAsCSV() {
            DependencyService.Get<ISave>().exportAsCSV(db);
    }
    }
}
