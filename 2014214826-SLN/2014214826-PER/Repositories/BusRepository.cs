﻿using _2014214826_ENT;
using _2014214826_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _2014214826_PER.Repositories
{
    public class BusRepository : Repository<Bus>, IBusRepository
    {
        public BusRepository(EnsambladoraDbContext context) : base(context)
        {
        }
    }
}
