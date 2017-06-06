﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vetstore.Entities;
using Vetstore.Entities.IRepositories;

namespace Vetstore.Persistence.Repositories
{
    public class TecnicoRepository : Repository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(VetStoreDbContext context)
            : base(context)
        {

        }
    }
}
