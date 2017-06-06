using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;
using Vetstore.Entities.IRepositories;

namespace Vetstore.Persistence.Repositories
{
    public class ProvinciaRepository : Repository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(VetStoreDbContext context): base(context)
        {

        }
    }
}
