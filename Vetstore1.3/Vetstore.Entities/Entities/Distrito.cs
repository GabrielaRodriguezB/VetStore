using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
   public class Distrito
    {
        public int DistritoId { get; set; }


        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }


        public int UbigeoId { get; set; }

        public Ubigeo Ubigeo { get; set; }
    }
}
