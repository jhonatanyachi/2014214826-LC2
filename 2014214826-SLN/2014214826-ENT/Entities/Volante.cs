using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public class Volante
    {
        public int VolanteId { get; set; }
        public string NumSerie { get; set; }
        public Carro Carro { get; set; }
        public int CarroId { get; set; }

    }
}
