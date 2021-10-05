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
        public char Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }

        public ActorInstance(int ID, string Fullname, char Sex, string Email, string Phone, double Salary)
        {
            this.ID = ID;
            this.Fullname = Fullname;
            this.Sex = Sex;
            this.Email = Email;
            this.Phone = Phone;
            this.Salary = Salary;
        }

    }
}
