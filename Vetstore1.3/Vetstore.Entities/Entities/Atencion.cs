using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
   public class Atencion
    {
        public int AtencionId { get; set; }

       // public ICollection<Mascota> Mascotas { get; set; }



        public List<Venta> Ventas { get; set; }

        public List<Servicio> Servicios { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }


        public Atencion()
        {
           // Mascotas = new HashSet<Mascota>();
            Ventas = new List<Venta>();
            Servicios = new List<Servicio>();
        }



    }
}
