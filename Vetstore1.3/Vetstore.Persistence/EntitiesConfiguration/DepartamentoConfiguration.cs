using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
   public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            ToTable("Departamentos");
            HasKey(c => c.DepartamentoId);

            //Relations Configuration

            HasMany(c => c.Provincias)
                .WithRequired(c => c.Departamento)
                 .HasForeignKey(c => c.DepartamentoId);
        }
    }
}
