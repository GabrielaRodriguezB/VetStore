using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;
using Vetstore.Persistence.EntitiesConfiguration;

namespace Vetstore.Persistence
{
   public class VetStoreDbContext : DbContext
    {
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<CategoriaProducto> CategoriasProducto { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<MedioPago> MedioPagos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioClinico> ServiciosClinico { get; set; }
        public DbSet<ServicioEstetico> ServiciosEstetico { get; set; }
        public DbSet<ServicioHospedaje> ServiciosHospedaje { get; set; }
        public DbSet<ServicioRecreativo> ServiciosRecreativo { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        public VetStoreDbContext()
            : base("VetStore")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AtencionConfiguration());
            modelBuilder.Configurations.Add(new CategoriaProductoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new EspecieConfiguration());
            modelBuilder.Configurations.Add(new LocalConfiguration());
            modelBuilder.Configurations.Add(new MascotaConfiguration());
            modelBuilder.Configurations.Add(new MedioPagoConfiguration());
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new RazaConfiguration());
            modelBuilder.Configurations.Add(new ServicioConfiguration());
            modelBuilder.Configurations.Add(new TecnicoConfiguration());
            modelBuilder.Configurations.Add(new UbigeoConfiguration());
            modelBuilder.Configurations.Add(new VacunaConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());
            modelBuilder.Configurations.Add(new VeterinarioConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
