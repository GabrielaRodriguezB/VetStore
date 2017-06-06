using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetstore.Entities.IRepositories
{
    //Debe heredar de IDisposable para que el Garbage Collector 
    //Puda liberar memoria que ya no utilize.
   public interface IUnityOfWork : IDisposable
    {
        //Cada una de las propiedades deben ser de solo lectura 
        IAtencionRepository Atenciones { get; }
        ICategoriaProductoRepository CategoriasProducto { get; }
        IClienteRepository Clientes { get; }
        IDepartamentoRepository Departamentos { get; }
        IDireccionRepository Direcciones { get; }
        IDistritoRepository Distritos { get; }
        IEspecieRepository Especies { get; }
        ILocalRepository Locales { get; }
        IMascotaRepository Mascotas { get; }
        IMedioPagoRepository MediosPago { get; }
        IProductoRepository Productos { get; }
        IProvinciaRepository Provincias { get; }
        IRazaRepository Razas { get; }
        IServicioClinicoRepository ServiciosClinico { get; }
        IServicioEsteticoRepository ServiciosEstetico { get; }
        IServicioHospedajeRepository ServiciosHospedaje { get; }
        IServicioRecreativoRepository ServiciosRecreativo { get; }
        IServicioRepository Servicios { get; }
        ITecnicoRepository Tecnicos { get; }
        IUbigeoRepository Ubigeos { get; }
        IVacunaRepository Vacunas { get; }
        IVentaRepository Ventas { get; }
        IVeterinarioRepository Veterinarios { get; }

        //Metodo que guardara los cambios en la base de datos.
        int SaveChanges();

        void StateModified(object entity);
    }
}
