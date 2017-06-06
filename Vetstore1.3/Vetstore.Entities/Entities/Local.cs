using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Local
    {
       

        public int LocalId { get; set; }

        public int DireccionId { get; set; }

        public Direccion Direccion { get; set; }

        public List<Venta> Ventas { get; set; }


        public Local()
        {
            Ventas = new List<Venta>();

        }

    }
}
