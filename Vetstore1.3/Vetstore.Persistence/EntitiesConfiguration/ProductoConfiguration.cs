using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;

namespace Vetstore.Persistence.EntitiesConfiguration
{
    public class ProductoConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
            ToTable("Productos");
            HasKey(c => c.ProductoId);

        }
    }
}
