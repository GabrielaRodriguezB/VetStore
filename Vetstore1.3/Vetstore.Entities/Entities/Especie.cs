using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
   public class Especie
    {
       
        public int EspecieId { get; set; }


        public List<Raza> Razas { get; set; }



        public int MascotaId { get; set; }

        public Mascota Mascota { get; set; }

        public Especie()
        {
            Razas = new List<Raza>();

        }
    }
}
