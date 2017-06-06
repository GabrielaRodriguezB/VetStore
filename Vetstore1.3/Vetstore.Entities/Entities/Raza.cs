using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Raza
    {
        public int RazaId { get; set; }



        public int EspecieId { get; set; }

        public Especie Especie { get; set; }

    }
}
