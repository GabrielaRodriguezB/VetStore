using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Tecnico
    {
        public int TecnicoId { get; set; }



        public List<Servicio> Servicios { get; set; }



        public Tecnico()
        {
            Servicios = new List<Servicio>();

        }
    }
}
