﻿using SqliteTutorial.Core.Database;
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
    /// View Model for LabelPage
    /// </summary>
    public class ViewLabelVM : ContentView
    {

        /// <summary>
        /// Data bindings
        /// </summary>
        public string Name { get; set; }
        public string Room { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ICommand GenerateLabelCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="p"></param>
        public ViewLabelVM(INavigation navigation, Package p)
        {
            //this.Navigation = navigation;
            //this.GenerateLabelCommand = new Command(async () => await GenerateLabel(p));
            Title = p.Name + " Label";
            Name = p.Name;
            Room = p.Room;
            //Label = p.Name + " - " + p.Room + " - " + p.Items;
            //ItemList = new ObservableCollection<Item>();
            ItemList = new ObservableCollection<Item>(p.GetItemList()); // Useful when we can actually put items within a package in the database
            //ItemList.Add(new Item("Item Name", 0)); // Temporary so we can see 
        }
    }
}