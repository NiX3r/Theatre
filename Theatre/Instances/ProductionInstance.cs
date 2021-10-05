using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Instances
{
    class ProductionInstance
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Premier { get; set; }
        public DateTime Denier { get; set; }

        public ProductionInstance(int ID, string Name, string Author, DateTime Premier, DateTime Denier)
        {
            this.ID = ID;
            this.Name = Name;
            this.Author = Author;
            this.Premier = Premier;
            this.Denier = Denier;
        }

    }
}
