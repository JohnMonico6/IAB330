using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
                private ObservableCollection<ToDoItem> toDoItems;

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return toDoItems; }
            set { toDoItems = value;
                OnPropertyChanged();
            }
        }

        public SecondViewModel()
        {
      
      
        }
    }
}
