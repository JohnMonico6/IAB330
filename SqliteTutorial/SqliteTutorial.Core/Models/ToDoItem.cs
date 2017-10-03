using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SqliteTutorial.Core.Models
{
    public class ToDoItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Details { get; set; }

        public bool Complete { get; set; }
    }
}
