using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Instances;

namespace Theatre.Utils
{
    class ProgramVariables
    {

        public static List<ActorInstance> Actors { get; set; }
        public static List<PlayInstance> Plays { get; set; }
        public static List<ProductionInstance> Productions { get; set; }
        public static MainUI MainFrame { get; set; }
        public static MySqlConnection Connection { get; set; }

        public static void InitializeProgramVariables()
        {

            Actors = new List<ActorInstance>();
            Plays = new List<PlayInstance>();
            Productions = new List<ProductionInstance>();
            MainFrame = new MainUI();
            Connection = new MySqlConnection(ProgramUtils.GetMySqlConnectionString());

        }

    }
}
