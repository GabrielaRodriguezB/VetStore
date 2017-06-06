using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
   public class MedioPagoConfiguration : EntityTypeConfiguration<MedioPago>
    {
        
        public MedioPagoConfiguration()
        {
            ToTable("MediosPago");
            HasKey(c => c.MedioPagoId);

            //Relations Configuration

            HasMany(c => c.Ventas)
                .WithRequired(c => c.MedioPago)
                 .HasForeignKey(c => c.MedioPagoId);
        }
    }
}
