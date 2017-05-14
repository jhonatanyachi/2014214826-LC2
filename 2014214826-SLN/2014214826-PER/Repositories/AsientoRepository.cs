using _2014214826_ENT;
using _2014214826_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.Repositories
{
    public class AsientoRepository:Repository<Asiento>,IAsientoRepository
    {
        private readonly EnsambladoraDbContext _context;

        private AsientoRepository()
        {

        }
        public AsientoRepository(EnsambladoraDbContext dbcontext)
        {
            _context = dbcontext;
        }
    }
}
