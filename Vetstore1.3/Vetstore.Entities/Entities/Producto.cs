using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities
{
    public class Producto
    {
      
        


        public int ProductoId { get; set; }

        public int CategoriaProductoId { get; set; }

        public CategoriaProducto CategoriaProducto { get; set; }


        public int VentaId { get; set; }

        public Venta Venta { get; set; }



    }
}
