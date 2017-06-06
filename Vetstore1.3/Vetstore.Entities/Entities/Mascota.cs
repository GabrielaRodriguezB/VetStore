using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
   public class Mascota
    {
       

        public int MascotaId { get; set; }


        public List<Vacuna> Vacunas { get; set; }

        public List<Especie> Especies { get; set; }


        public int ClienteId { get; set; }

        public Cliente Cliente{ get; set; }

        public List<Atencion> Atenciones { get; set; }

        public Mascota()
        {

            Vacunas = new List<Vacuna>();
            Especies = new List<Especie>();
            Atenciones = new List<Atencion>();
        }


       

      

    }
}
