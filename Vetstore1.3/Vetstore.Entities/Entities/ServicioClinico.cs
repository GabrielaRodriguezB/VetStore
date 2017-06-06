using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class ServicioClinico : Servicio
    {
        public List<Vacuna> Vacunas { get; set; }

        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }

        public ServicioClinico()
        {
            Vacunas = new List<Vacuna>();

        }
    }
}
