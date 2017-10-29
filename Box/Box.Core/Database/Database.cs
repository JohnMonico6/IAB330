using SqliteTutorial.Core.Interfaces;
using SqliteTutorial.Core.Models;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net.Interop;
using SQLite.Net;
using Xamarin.Forms;
using System;

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
           
            if (database.Table<Package>().Any(x=> x.Name ==package.Name)) {
                throw new Exception("There is already a Package with the name " + package.Name);
            }

            database.Insert(package);
            database.Commit();
        }

        /// <summary>
        /// Update(package)
        /// Update a package in the database
        /// </summary>
        /// <param name="package">The package to update</param>
        public void Update(Package package)
        {
            if (database.Table<Package>().Any(x => x.Id == package.Id))
            {
                database.Update(package);
                database.Commit();
            }
        }

        /// <summary>
        /// DeleteItem(package)
        /// Deletes a specified package, it must have an Id
        /// </summary>
        /// 
        /// <param name="package"></param>
        public void DeleteItem(Package package, Item item) {

            if (database.Table<Package>().Any(x => x.Id == package.Id)) {
                List<Item> newList = new List<Item>();
                newList = package.GetItemList();
                newList.Remove(item);
                package.SetItemList(newList);
            }
            database.Update(package);
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
