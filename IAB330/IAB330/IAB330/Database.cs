using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IAB330
{
    class Database
    {
        private SQLiteAsyncConnection con;

        public Database()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db");
            con = new SQLiteAsyncConnection(path);
        }

        public bool Exists()
        {
            //con.ExecuteScalarAsync<bool>()
            return false;
        }

        private string Create()
        {
            try
            {
                con.CreateTableAsync<Package>();
                return "Created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}
