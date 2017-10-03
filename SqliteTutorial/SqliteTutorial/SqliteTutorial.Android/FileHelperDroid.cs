using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WheresMyStuff.Core.Interfaces;
using System.IO;

namespace WheresMyStuff.Android
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalPath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); 
            //TODO must use fully qualified name here for Environment due to overlap with Android.OS, OR remove the reference
            return Path.Combine(path, filename);
        }
    }
}