using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SqliteTutorial.Droid;
using SqliteTutorial.Core.Interfaces;
using System.IO;
using SqliteTutorial.Core.Database;

[assembly: Dependency(typeof(Save))]
namespace SqliteTutorial.Droid {
    class Save : ISave {

        /// <summary>
        /// takes database and creates a new directory for it then renames it to with date/time and saves to storage
        /// </summary>
        /// <param name="database">The database that will be written to storage</param>
        public void SaveFile(PackageDatabase database) {

            var appPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Directory.CreateDirectory(appPath + "/BackupDatabase");
            var fileCopyName = string.Format("Database_{0:dd-MM-yyyy_HH-mm-ss-tt}.db3", System.DateTime.Now);
            var filePath = Path.Combine(appPath+"/BackupDatabase", fileCopyName);
            var bytes = System.IO.File.ReadAllBytes(database.GetDatabase());
            System.IO.File.WriteAllBytes(filePath, bytes);
        }
    }
}


