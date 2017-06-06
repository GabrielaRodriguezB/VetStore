using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class VacunaConfiguration : EntityTypeConfiguration<Vacuna>
    {
        public VacunaConfiguration()
        {
            ToTable("Vacunas");
            HasKey(c => c.VacunaId);
        }
    }
}
