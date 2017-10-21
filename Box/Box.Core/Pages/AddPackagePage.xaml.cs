using SqliteTutorial.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTutorial {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPackagePage : ContentPage {

        public AddPackagePage() {
         
            InitializeComponent();
            BindingContext = new AddPackageVM();
        }


        public void AddButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {

        }

        protected override void OnAppearing() {

            base.OnAppearing();

            MessagingCenter.Subscribe<AddPackageVM, string[]>(this, "Display Alert", (sender, values) => {
                DisplayAlert(values[0], values[1], "Ok");
            });
        }

        protected override void OnDisappearing() {

            MessagingCenter.Unsubscribe<AddPackageVM, string[]>(this, "Display Alert");
        }
    }
}