using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Vacuna
    {
        public int VacunaId { get; set; }


        public int MascotaId { get; set; }

        public Mascota Mascota { get; set; }

        public int ServicioClinicoId { get; set; }
        public ServicioClinico ServicioClinico { get; set; }

    }
}
