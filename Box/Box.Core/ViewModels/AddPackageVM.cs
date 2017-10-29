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

    /// <summary>
    /// View Model for the AddPackagePage
    /// Handles package creation and data bindings
    /// </summary>
    public class AddPackageVM : ViewModelBase
    {

        private readonly PackageDatabase db;

        /// <summary>
        /// The name of the new package, binded to the value within the View
        /// </summary>
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

        /// <summary>
        /// The room/detination of the new package, binded to the value within the View
        /// </summary>
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

        /// <summary>
        /// The name of the new item that may be added, binded to a text box value within the View
        /// </summary>
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

        /// <summary>
        /// The height of the ListView that displays the items on the Page
        /// </summary>
        private int height;
        public int Height {
            get {
                return height;
            }
            set {
                height = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Command and data bindings
        /// </summary>
        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ICommand ChangeListViewSizeCommand { get; }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand AddItemCommand { protected set; get; }
        public ICommand DeleteItemCommand { protected set; get; }

        /// <summary>
        /// Constructor
        /// Initializes a database link, item list and commands
        /// </summary>
        public AddPackageVM()
        {
            db = new PackageDatabase();
            Items = new ObservableCollection<Item>();
            SubmitCommand = new Command(Submit);
            AddItemCommand = new Command(AddItem);
            DeleteItemCommand = new Command(DeleteItem);
        }

        /// <summary>
        /// DeleteItem()
        /// Removes the select item in the item list, if one is selected
        /// </summary>
        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                Items.Remove(SelectedItem);
                Height = (Items.Count * 45);
            }
        }

        /// <summary>
        /// AddItem()
        /// Adds an item to the item list
        /// </summary>
        public void AddItem()
        {
            try {
                Items.Add(new Item(ItemName, 0));
                ItemName = String.Empty;
                Height = (Items.Count * 45);
            } catch (Exception e) {
                DisplayAlert("Error!", e.Message);
            }
        }

        /// <summary>
        /// Submit()
        /// Adds the constructed package to the database and clears up the form
        /// </summary>
        public void Submit()
        {
            try {
                var p = new Package() {
                    Name = Name,
                    Room = Room
                };
                p.SetItemList(new List<Item>(Items));
                db.Insert(p);
                Items.Clear();

                Name = String.Empty;
                Room = String.Empty;
            } catch (Exception e) {
                DisplayAlert("Error!", e.Message);
            }   
        }

        /// <summary>
        /// DisplayAlert(title,message)
        /// Safely displays a message with the specified parameters
        /// </summary>
        /// <param name="title">The title of the message</param>
        /// <param name="message">The message</param>
        public void DisplayAlert(string title, string message) {

            string[] values = { title, message };
            MessagingCenter.Send(this, "Display Alert", values);
        }
    }

}
