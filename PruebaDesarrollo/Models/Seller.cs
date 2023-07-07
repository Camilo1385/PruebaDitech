using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollo.Models
{
    public partial class Seller
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
    }
}
