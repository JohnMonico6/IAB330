using WheresMyStuff.Core.Interfaces;
using WheresMyStuff.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheresMyStuff
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}
