using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;
using Vetstore.Entities.IRepositories;

namespace Vetstore.Persistence.Repositories
{
            public class AtencionRepository : Repository<Atencion>, IAtencionRepository
        {
            public AtencionRepository(VetStoreDbContext context)
                : base(context)
            {

            }
        }
        // BUSCAR ESTA PARTE PARA TODAS LOS REPOSITORIOS DE : Persistence , Repositories

       
    }

