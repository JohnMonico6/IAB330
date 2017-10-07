﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SqliteTutorial.Core.Models
{
    class Package
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Items { get; set; } // Serialized CSV
        public string Room { get; set; }
        public List<string> GetItemList()
        {
            return null; // sup
        }
        public void SetItemList(List<string> items)
        {

        }
    }

}
