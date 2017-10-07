using SQLite.Net;
using SQLite.Net.Interop;
using SqliteTutorial.Core.Interfaces;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteTutorial.Core.Database
{
    public class PackageDatabase
    {
        private SQLiteConnection database;
        public PackageDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),
                DependencyService.Get<IFileHelper>().GetLocalPath("Packages.db3"));
            //database.DropTable<Package>();
            database.CreateTable<Package>();
        }

        public List<Package> GetPackages()
        {
            return database.Table<Package>().ToList();
        }

        public void Insert(Package package)
        {
            database.Insert(package);
            database.Commit();
        }

    }

    // TODO: Remove prac code
    public class MyDatabase
    {
        static SQLiteConnection database;
       
        public MyDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), 
                DependencyService.Get<IFileHelper>().GetLocalPath("ToDoSqlite.db3"));
            database.CreateTable<ToDoItem>();
        }

        public int Insert(ToDoItem toDoItem)
        {
            var item = database.Insert(toDoItem);
            database.Commit();
            return item;

        }

        public int InsertOrUpdate(ToDoItem toDoItem)
        {
            int num;
            if (database.Table<ToDoItem>().Any(x=> x.Id == toDoItem.Id))
            {
                num = database.Update(toDoItem);
            }
            num = database.Insert(toDoItem);
            database.Commit();
            return num;
        }

        public int Delete(ToDoItem toDoItem)
        {
            int num;
            num = database.Delete<ToDoItem>(toDoItem.Id);
            database.Commit();
            return num;
        }

        public List<ToDoItem> GetAllToDoItems()
        {
            return database.Table<ToDoItem>().ToList();
        }

        public ToDoItem GetToDoItem(int key)
        {
            return database.Table<ToDoItem>().Where(x => x.Id == key).FirstOrDefault();
        }

    }
}
