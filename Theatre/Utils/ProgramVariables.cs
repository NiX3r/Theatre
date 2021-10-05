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

        public static bool CheckActorExists(string name)
        {
            foreach (ActorInstance actor in Actors)
            {
                if (actor.Fullname.Equals(name))
                    return true;
            }
            return false;
        }

        public static List<ActorInstance> GetActors(String fullname, char sex, String email, String phone, double salary)
        {

            List<ActorInstance> output = new List<ActorInstance>();

            foreach(ActorInstance actor in Actors)
            {

                bool valid = false;

                if (fullname != "")
                    if (actor.Fullname.Contains(fullname))
                        valid = true;
                    else
                        valid = false;
                if (email != "")
                    if (actor.Email.Contains(email))
                        valid = true;
                    else
                        valid = false;
                if (sex != ' ')
                    if (actor.Sex.Equals(sex))
                        valid = true;
                    else
                        valid = false;
                if (phone != "")
                    if (actor.Phone.Contains(phone))
                        valid = true;
                    else
                        valid = false;
                if (salary != -1.0)
                    if (actor.Salary == (salary))
                        valid = true;
                    else
                        valid = false;

                if (valid)
                    output.Add(actor);

            }

            return output;

        }

        public static void RemoveActor(int ID)
        {
            foreach (ActorInstance actor in Actors)
            {
                if (actor.ID == ID)
                {
                    Actors.Remove(actor);
                    return;
                }
            }
        }

        public static void UpdateActor(int ID, String fullname, char sex, String email, String phone, double salary)
        {
            foreach (ActorInstance actor in Actors)
            {
                if (actor.ID == ID)
                {
                    actor.Fullname = fullname;
                    actor.Sex = sex;
                    actor.Email = email;
                    actor.Phone = phone;
                    actor.Salary = salary;
                    return;
                }
            }
        }

    }
}
