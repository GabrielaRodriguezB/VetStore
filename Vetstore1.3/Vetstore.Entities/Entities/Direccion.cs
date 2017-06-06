using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Direccion
    {
        public int DireccionId { get; set; }


        public int LocalId { get; set; }

        public Local Local { get; set; }

        public int UbigeoId { get; set; }

        public Ubigeo Ubigeo { get; set; }

    }
}
