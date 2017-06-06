using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
   public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
            ToTable("Ventas");
            HasKey(c => c.VentaId);

            //Relations Configuration

            HasMany(c => c.Productos)
                .WithRequired(c => c.Venta)
                 .HasForeignKey(c => c.VentaId);
        }
    }
}
