using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {
        public ProvinciaConfiguration()
        {
            ToTable("Provincias");
            HasKey(c => c.ProvinciaId);

            //Relations Configuration

            HasMany(c => c.Distritos)
                .WithRequired(c => c.Provincia)
                 .HasForeignKey(c => c.ProvinciaId);
        }
    }
}
