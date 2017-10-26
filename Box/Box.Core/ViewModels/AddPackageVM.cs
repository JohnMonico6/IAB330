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

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string room;
        public string Room
        {
            get { return room; }
            set
            {
                room = value;
                OnPropertyChanged();
            }
        }
        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                OnPropertyChanged();
            }
        }

        
        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand AddItemCommand { protected set; get; }
        public ICommand DeleteItemCommand { protected set; get; }

        public AddPackageVM()
        {
            db = new PackageDatabase();
            Items = new ObservableCollection<Item>();
            SubmitCommand = new Command(Submit);
            AddItemCommand = new Command(AddItem);
            DeleteItemCommand = new Command(DeleteItem);
        }

        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
            }
        }

        public void AddItem()
        {
            if (string.IsNullOrWhiteSpace(ItemName)) {
                DisplayAlert("Error!", "Items must have a Name");
                return;
            }

            Items.Add(new Item(ItemName, 0));
            ItemName = String.Empty;
        }

        public void Submit()
        {

            if (string.IsNullOrWhiteSpace(Name)) {
                DisplayAlert("Error!", "Packages must have a Name");
                return;
            }

            if (string.IsNullOrWhiteSpace(Room)) {
                DisplayAlert("Error!", "Packages must have a Destination");
                return;
            }

            var p = new Package()
            {
                Name = Name,
                Room = Room
            };
            p.SetItemList(new List<Item>(Items));
            db.Insert(p);
            Items.Clear();
            Name = String.Empty;
            Room = String.Empty;         
        }

        public void DisplayAlert(string title, string message) {

            string[] values = { title, message };
            MessagingCenter.Send(this, "Display Alert", values);
        }
    }
}
