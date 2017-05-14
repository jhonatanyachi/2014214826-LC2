using _2014214826_ENT;
using _2014214826_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.Repositories
{
    public class ParabrisasRepository : Repository<Parabrisas>, IParabrisasRepository
    {
        private readonly EnsambladoraDbContext _Context;

        public ParabrisasRepository(EnsambladoraDbContext _Context)
        {
            this._Context = _Context;
        }
        private ParabrisasRepository()
        {

        }
    }
}
