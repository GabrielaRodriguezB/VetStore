using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
        public class AtencionConfiguration : EntityTypeConfiguration<Atencion>
        {
            public AtencionConfiguration()
            {
                ToTable("Atenciones");
            HasKey(c => c.AtencionId);

            //Relations Configuration

            HasMany(c => c.Ventas)
                .WithRequired(c => c.Atencion);

            //Relations Configuration

            HasMany(c => c.Servicios)
                .WithRequired(c => c.Atencion)
                .HasForeignKey(c =>c.AtencionId) ;


         //   HasRequired(c => c.Mascota);
           // HasMany(c => c.Mascotas);
              //  .WithMany(c => c.Atenciones)
               // .Map(m => m.ToTable("AtencionMascotas"));
        }
        }
}
