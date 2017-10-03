using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SqliteTutorial.Core;
using System.IO;
using SqliteTutorial.Core.Interfaces;

namespace SqliteTutorial.iOS
{
    public class FileHelperIos : IFileHelper
    {
        public string GetLocalPath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}