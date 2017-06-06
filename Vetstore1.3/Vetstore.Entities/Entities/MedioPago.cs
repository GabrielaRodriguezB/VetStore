using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class MedioPago
    {
        public int MedioPagoId { get; set; }


        public List<Venta> Ventas { get; set; }




        public MedioPago()
        {
            Ventas = new List<Venta>();

        }
    }
}
