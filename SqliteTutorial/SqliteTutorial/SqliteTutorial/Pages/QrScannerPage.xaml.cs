using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrScannerPage : ContentPage
    {
        public QrScannerPage()
        {
            InitializeComponent();
        }
    }
}