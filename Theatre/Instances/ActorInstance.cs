using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Instances
{
    class ActorInstance
    {

        public int ID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }
        public double Salary { get; set; }

        public ActorInstance(int ID, string Fullname, string Email, string Phone, bool Sex, double Salary)
        {
            this.ID = ID;
            this.Fullname = Fullname;
            this.Email = Email;
            this.Phone = Phone;
            this.Sex = Sex;
            this.Salary = Salary;
        }

    }
}
