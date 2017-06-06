using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class LocalConfiguration : EntityTypeConfiguration<Local>
    {
        public LocalConfiguration ()
        {
            ToTable("Locales");
            HasKey(c => c.LocalId);

            //Relations Configuration

            HasRequired(c => c.Direccion);


        }
    }
}
