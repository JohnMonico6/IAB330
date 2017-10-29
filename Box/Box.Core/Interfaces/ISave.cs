using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTutorial.Core.Interfaces {
    public interface ISave {

        void SaveFile(SqliteTutorial.Core.Database.PackageDatabase database);
        void exportAsCSV(SqliteTutorial.Core.Database.PackageDatabase database);
    }
}
