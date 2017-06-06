using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Ubigeo
    {
      
        public int UbigeoId { get; set; }


        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }


        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }


        public int DistritoId { get; set; }

        public Distrito Distrito { get; set; }




        public List<Direccion> Direcciones { get; set; }




        public Ubigeo()
        {
            Direcciones = new List<Direccion>();

        }
    }
}
