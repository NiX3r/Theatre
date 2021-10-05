using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theatre.Utils;

namespace Theatre
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            ProgramVariables.InitializeProgramVariables();

            // try to open mysql connection
            if (!DatabaseClass.OpenConnection())
                DatabaseClass.LoadDataIntoCache();
            else
                Application.Exit();

            Application.EnableVisualStyles();
            Application.Run(ProgramVariables.MainFrame);

        }

    }
}
