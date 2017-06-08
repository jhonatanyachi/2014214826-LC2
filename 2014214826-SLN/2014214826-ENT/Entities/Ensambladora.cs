using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public class Ensambladora
    {
        public int EnsambladoraId { get; set; }
        public string _Ensambladora { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public List<Carro> Carro { get; set; }
        public Ensambladora()
        {
            Carro = new List<Carro>();
        }
    }
}
