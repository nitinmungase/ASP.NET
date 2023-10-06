using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ewaste_Collection.Models
{
    public class Ewaste
    {
        public int id { get; set; }

        public string  title { get; set; }
        public DateTime pickupdate { get; set; }
        public int quantity { get; set; }

        public double weight { get; set; }

        public int ecopoints { get; set; }

        public Ewaste()
        {

        }

    }
}
