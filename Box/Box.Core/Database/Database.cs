using SqliteTutorial.Core.Interfaces;
using SqliteTutorial.Core.Models;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net.Interop;
using SQLite.Net;
using Xamarin.Forms;

namespace SqliteTutorial.Core.Database
{
    
    /// <summary>
    /// PackageDatabase
    /// Manages the database connection, has methods to interact with the database
    /// </summary>
    public class PackageDatabase
    {

        private SQLiteConnection database;
        
        /// <summary>
        /// Constructor
        /// Establishes a link to the SQLite database, creates a table of Packages if one exists
        /// </summary>
        public PackageDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),
                DependencyService.Get<IFileHelper>().GetLocalPath("Packages.db3"));
            database.CreateTable<Package>();
        }

        /// <summary>
        /// GetPackages()
        /// Returns all packages within the database
        /// </summary>
        /// <returns></returns>
        public List<Package> GetPackages()
        {
            return database.Table<Package>().ToList();
        }

        /// <summary>
        /// Insert(package)
        /// Inserts a package into the database
        /// </summary>
        /// <param name="package">The package to insert</param>
        public void Insert(Package package)
        {
            database.Insert(package);
            database.Commit();
        }

        /// <summary>
        /// DeleteItem(package)
        /// Deletes a specified package, it must have an Id
        /// </summary>
        /// <param name="package"></param>
        public void DeleteItem(Package package) {

            if (database.Table<Package>().Any(x => x.Id == package.Id)) {
               database.Delete(package);
            }
            database.Commit();
        }

        /// <summary>
        /// GetDatabase()
        /// Returns the database path
        /// </summary>
        /// <returns></returns>
        public string GetDatabase() {

            return database.DatabasePath;
        }

    }

}
