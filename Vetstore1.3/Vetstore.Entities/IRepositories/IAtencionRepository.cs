using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities.IRepositories
{
   public  interface IAtencionRepository : IRepository <Atencion>
    {        //AYUDA ----------------------------------------------------
             //AYUDA ----------------------------------------------------
             //AYUDA ----------------------------------------------------
             //AYUDA ----------------------------------------------------
             //Obtener la relacion de atenciones con ventas 
             //El resultado se devolvera de acuerdo a parametros de paginacion para no
             //traer toda la tabla de actores a memoria 
      //  IEnumerable<Atencion> GetAtencionesWithVentas(int pageIndex, int pageSize);


        //AYUDA ----------------------------------------------------
        //AYUDA ----------------------------------------------------
        //AYUDA ----------------------------------------------------
        //AYUDA ----------------------------------------------------
        // Obtener la relacion de atenciones que hayan participado en por lo menos
        //una atencion que tenga una atencion especifica
      //  IEnumerable<Atencion> GetAtencionesByClassification(Classification classification);
    }
}
