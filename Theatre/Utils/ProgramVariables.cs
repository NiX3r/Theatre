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

        public static bool CheckProductionExists(string name)
        {
            foreach(ProductionInstance product in Productions)
            {
                if (product.Name.Equals(name))
                    return true;
            }
            return false;
        }

        public static bool CheckPlayExists(int id, DateTime playTime)
        {
            foreach(PlayInstance play in Plays)
            {
                if (play.ID == id && play.PlayDate.Equals(playTime))
                    return true;
            }
            return false;
        }

        public static int GetProductionID(string name)
        {
            foreach(ProductionInstance production in Productions)
            {
                if (production.Name.Equals(name))
                    return production.ID;
            }
            return -1;
        }

        public static string GetProductionName(int id)
        {
            foreach (ProductionInstance production in Productions)
            {
                if (production.ID.Equals(id))
                    return production.Name;
            }
            return null;
        }

        public static List<ActorInstance> GetActors(string fullname, char sex, string email, string phone, double salary)
        {

            List<ActorInstance> output = new List<ActorInstance>();

            foreach(ActorInstance actor in Actors)
            {

                bool valid = true;

                if (fullname != "")
                    if (!actor.Fullname.Contains(fullname))
                        valid = false;
                if (email != "")
                    if (!actor.Email.Contains(email))
                        valid = false;
                if (sex != ' ')
                    if (!actor.Sex.Equals(sex))
                        valid = false;
                if (phone != "")
                    if (actor.Phone.Contains(phone))
                        valid = false;
                if (salary != -1.0)
                    if (actor.Salary != (salary))
                        valid = false;

                if(valid)
                    output.Add(actor);

            }

            return output;

        }

        public static List<ProductionInstance> GetProductions(string name, string author, DateTime premier, DateTime denier, bool searchByDate)
        {
            List<ProductionInstance> output = new List<ProductionInstance>();

            foreach (ProductionInstance product in Productions)
            {

                bool valid = true;

                if (name != "")
                    if (!product.Name.Contains(name))
                        valid = false;
                if (author != "")
                    if (!product.Author.Contains(author))
                        valid = false;
                if (searchByDate)
                    if (!product.Premier.Equals(premier) && product.Denier.Equals(denier))
                        valid = false;

                if(valid)
                    output.Add(product);

            }

            return output;
        }

        public static List<PlayInstance> GetPlays(DateTime playTime, int participate, int production_id, bool searchByDate)
        {

            List<PlayInstance> output = new List<PlayInstance>();

            foreach(PlayInstance play in Plays)
            {

                bool valid = true;

                if (searchByDate)
                    if (!play.PlayDate.Equals(playTime))
                        valid = false;
                if (participate >= 0)
                    if (play.Participate != participate)
                        valid = false;
                if (production_id >= 0)
                    if (play.Production_ID != production_id)
                        valid = false;

                if (valid)
                    output.Add(play);

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

        public static void RemoveProduction(int ID)
        {
            foreach(ProductionInstance product in Productions)
            {
                if(product.ID == ID)
                {
                    Productions.Remove(product);
                    return;
                }
            }
        }

        public static void RemovePlay(int ID)
        {
            foreach (PlayInstance play in Plays)
            {
                if (play.ID == ID)
                {
                    Plays.Remove(play);
                    return;
                }
            }
        }

        public static void UpdateActor(int ID, string fullname, char sex, string email, string phone, double salary)
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

        public static void UpdateProduction(int ID, string name, string author, DateTime premier, DateTime denier, string description)
        {

            foreach(ProductionInstance production in Productions)
            {
                if(production.ID == ID)
                {
                    production.Name = name;
                    production.Author = author;
                    production.Premier = premier;
                    production.Denier = denier;
                    production.Description = description;
                    return;
                }
            }

        }

        public static void UpdatePlay(int ID, DateTime playDate, int participate, int production_id)
        {
            foreach (PlayInstance play in Plays) {

                if (play.ID == ID)
                {
                    play.PlayDate = playDate;
                    play.Participate = participate;
                    play.Production_ID = production_id;
                }

            }
        }

    }
}
