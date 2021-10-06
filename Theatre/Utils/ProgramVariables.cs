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

    }
}
