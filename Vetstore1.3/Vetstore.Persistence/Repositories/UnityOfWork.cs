using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities.IRepositories;

namespace Vetstore.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly VetStoreDbContext _Context;
      
        public IAtencionRepository Atenciones { get; private set; }
        public ICategoriaProductoRepository CategoriasProducto { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDireccionRepository Direcciones  { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEspecieRepository Especies  { get; private set; }
        public ILocalRepository Locales  { get; private set; }
        public IMascotaRepository Mascotas  { get; private set; }
        public IMedioPagoRepository MediosPago  { get; private set; }
        public IProductoRepository Productos  { get; private set; }
        public IProvinciaRepository Provincias  { get; private set; }
        public IRazaRepository Razas  { get; private set; }
        public IServicioClinicoRepository ServiciosClinico  { get; private set; }
        public IServicioEsteticoRepository ServiciosEstetico  { get; private set; }
        public IServicioHospedajeRepository ServiciosHospedaje  { get; private set; }
        public IServicioRecreativoRepository ServiciosRecreativo  { get; private set; }
        public IServicioRepository Servicios  { get; private set; }
        public ITecnicoRepository Tecnicos  { get; private set; }
        public IUbigeoRepository Ubigeos  { get; private set; }
        public IVacunaRepository Vacunas  { get; private set; }
        public IVentaRepository Ventas  { get; private set; }
        public IVeterinarioRepository Veterinarios  { get; private set; }

        public UnityOfWork()
        {

        }

        //Se define el constructor por defecto como privado para que 
        //se fuerce a utilizar la propiedad Instance
        public UnityOfWork(VetStoreDbContext context)
        {
            //Se crea un icono contexto de base de datos
            //para apuntar todos los repositorios a la misma base de datos 
            _Context = context;

            Atenciones = new AtencionRepository(_Context);
            CategoriasProducto = new CategoriaProductoRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Direcciones = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Especies = new EspecieRepository(_Context);
            Locales = new LocalRepository(_Context);
            Mascotas = new MascotaRepository(_Context);
            MediosPago = new MedioPagoRepository(_Context);
            Productos = new ProductoRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            Razas = new RazaRepository(_Context);
            Servicios = new ServicioRepository(_Context);
            Tecnicos = new TecnicoRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Vacunas = new VacunaRepository(_Context);
            Ventas = new VentaRepository(_Context);
            Veterinarios = new VeterinarioRepository(_Context);

        }


       public  void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
           return  _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
