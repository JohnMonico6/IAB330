using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.Interfaces
{
    public interface IFileHelper
    {
        string GetLocalPath(string filename);
    }
}
