using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }


        public List<Distrito> Distritos { get; set; }

        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public int UbigeoId { get; set; }

        public Ubigeo Ubigeo { get; set; }


        public Provincia()
        {
            Distritos = new List<Distrito>();
        
        }

    }
}
