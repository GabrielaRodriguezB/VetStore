using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class CategoriaProductoConfiguration : EntityTypeConfiguration<CategoriaProducto>
    {
        public CategoriaProductoConfiguration()
        {
            ToTable("CategoriasProducto");
            HasKey(c => c.CategoriaProductoId);


            //Relations Configuration

            HasMany(c => c.Productos)
                .WithRequired(c => c.CategoriaProducto)
                 .HasForeignKey(c => c.CategoriaProductoId);
        }
    }
}
