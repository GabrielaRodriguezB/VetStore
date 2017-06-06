using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }


        public List<Producto> Productos { get; set; }


        public int MedioPagoId { get; set; }

        public MedioPago MedioPago { get; set; }


        public int LocalId { get; set; }

        public Local Local { get; set; }


        public int AtencionId { get; set; }

        public Atencion Atencion { get; set; }



        public Venta()
        {
            Productos = new List<Producto>();

        }

    }
}
