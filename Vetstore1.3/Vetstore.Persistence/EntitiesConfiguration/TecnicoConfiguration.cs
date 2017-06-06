using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class TecnicoConfiguration : EntityTypeConfiguration<Tecnico>
    {
        public TecnicoConfiguration()
        {
            ToTable("Tecnicos");
            HasKey(c => c.TecnicoId);

            //Relations Configuration

            HasMany(c => c.Servicios)
                .WithRequired(c => c.Tecnico)
                 .HasForeignKey(c => c.TecnicoId); 
        }
    }
}
