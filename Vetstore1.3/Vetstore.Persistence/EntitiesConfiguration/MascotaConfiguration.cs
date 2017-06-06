using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class MascotaConfiguration : EntityTypeConfiguration<Mascota>
    {
        public MascotaConfiguration()
        {
            ToTable("Mascotas");
            HasKey(c => c.MascotaId);

            //Relations Configuration

            HasMany(c => c.Vacunas)
                .WithRequired(c => c.Mascota)
                 .HasForeignKey(c => c.MascotaId);



            HasMany(c => c.Especies)
                .WithRequired(c => c.Mascota)
                 .HasForeignKey(c => c.MascotaId);


            HasMany(c => c.Atenciones)
                .WithRequired(c => c.Mascota)
                .HasForeignKey(c => c.MascotaId);
        }
    }
}
