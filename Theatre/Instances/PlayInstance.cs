using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Instances
{
    class PlayInstance
    {

        public int ID { get; set; }
        public DateTime PlayDate { get; set; }
        public int Participate { get; set; }
        public int Production_ID { get; set; }

        public PlayInstance(int ID, DateTime PlayDate, int Participate, int Production_ID)
        {
            this.ID = ID;
            this.PlayDate = PlayDate;
            this.Participate = Participate;
            this.Production_ID = Production_ID;
        }

    }
}
