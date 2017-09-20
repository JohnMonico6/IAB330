﻿using SQLite;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace IAB330
{
    class Database
    {
        private SQLiteAsyncConnection con;

        public Database()
        {
            //con = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(),DependencyService.Get<IFileHelper>().GetLocalPath("database.db"));
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
