using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public abstract class Servicio
    {
        public int ServicioId { get; set; }

        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }


        public int AtencionId { get; set; }
        public Atencion Atencion { get; set; }
    }
}
