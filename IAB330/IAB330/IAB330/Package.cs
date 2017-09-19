using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAB330
{
    class Package
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public Byte[] Photograph { get; set; }

        public List<Item> Items { get; set; }
    }
}
