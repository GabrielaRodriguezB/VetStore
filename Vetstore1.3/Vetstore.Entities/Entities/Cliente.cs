using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public List<Mascota> Mascotas { get; set; }
        public List<Atencion> Atenciones { get; set; }


        public Cliente()
        {
            Mascotas = new List<Mascota>();
            Atenciones = new List<Atencion>();


        }

    }
}
