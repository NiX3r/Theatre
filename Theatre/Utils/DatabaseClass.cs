using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Instances;

namespace Theatre.Utils
{
    class DatabaseClass
    {

        public static bool OpenConnection()
        {
            try
            {
                ProgramVariables.Connection.Open();
                Debug.WriteLine("MySQL connection established!");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public static void LoadDataIntoCache()
        {

            var command = new MySqlCommand($"SELECT * FROM Actor;", ProgramVariables.Connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ActorInstance actor = new ActorInstance(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4), reader.GetDouble(5));
                ProgramVariables.Actors.Add(actor);
            }
            reader.Close();

            command = new MySqlCommand("SELECT * FROM Play;", ProgramVariables.Connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                PlayInstance play = new PlayInstance(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3));
                ProgramVariables.Plays.Add(play);
            }
            reader.Close();

            command = new MySqlCommand("SELECT * FROM Production;", ProgramVariables.Connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProductionInstance production = new ProductionInstance(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4));
                ProgramVariables.Productions.Add(production);
            }
            reader.Close();

        }

    }
}
