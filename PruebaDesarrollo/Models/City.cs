using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollo.Models
{
    public partial class City
    {
        public City()
        {
            Sellers = new HashSet<Seller>();
        }

        public int Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
