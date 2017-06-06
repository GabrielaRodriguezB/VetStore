using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Veterinario
    {
        public int VeterinarioId { get; set; }


        public List<ServicioClinico> ServiciosClinico { get; set; }
        public List<Vacuna> Vacunas { get; set; }


        public Veterinario()
        {
            ServiciosClinico = new List<ServicioClinico>();
            Vacunas = new List<Vacuna>();


        }
    }
}
