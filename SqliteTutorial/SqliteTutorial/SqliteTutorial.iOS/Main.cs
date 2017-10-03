using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using SqliteTutorial.Core;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;

namespace SqliteTutorial.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

            DependencyService.Register<FileHelperIos>();
            DependencyService.Register<ISQLitePlatform, SQLitePlatformIOS>();
        }
    }
}
