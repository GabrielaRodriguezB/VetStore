using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Clientes");
            HasKey(c => c.ClienteId);

            //Relations Configuration

            HasMany(c => c.Mascotas)
                .WithRequired(c => c.Cliente)
                 .HasForeignKey(c => c.ClienteId);

            //Relations Configuration

            HasMany(c => c.Atenciones)
                .WithRequired(c => c.Cliente)
                 .HasForeignKey(c => c.ClienteId);
        }
    }
}
