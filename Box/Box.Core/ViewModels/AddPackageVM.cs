using SqliteTutorial.Core.Database;
using SqliteTutorial.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteTutorial.Core.ViewModels
{
    public class AddPackageVM : ViewModelBase
    {

        private readonly PackageDatabase db;

        public string Name { get; set; }
        public string Room { get; set; }

        public ObservableCollection<Item> Items { get; set; }

        public ICommand SubmitCommand { protected set; get; }
        public ICommand AddItemCommand { protected set; get; }

        public AddPackageVM()
        {
            db = new PackageDatabase();
            Items = new ObservableCollection<Item>();
            SubmitCommand = new Command(Submit);
            AddItemCommand = new Command(AddItem);
        }

        public void AddItem()
        {
            Items.Add(new Item("",0));
        }

        public void Submit()
        {
            db.Insert(new Package()
            {
                Name = Name,
                Room = Room
            });
            Name = String.Empty;
            Room = String.Empty;
        }

    }
}
