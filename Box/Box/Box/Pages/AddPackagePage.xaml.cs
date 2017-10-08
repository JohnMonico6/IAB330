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
    }
}