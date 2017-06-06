using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;
using Vetstore.Entities.IRepositories;

namespace Vetstore.Persistence.Repositories
{
    public class RazaRepository : Repository<Raza>, IRazaRepository
    {
        public RazaRepository(VetStoreDbContext context)
            : base(context)
        {

        }
    }
}
