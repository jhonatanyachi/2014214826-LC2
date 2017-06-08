using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public class Asiento
    {
        public int AsientoId { get; set; }
        public string NumSerie { get; set; }
        public int CinturonId { get; set; }
        public Cinturon Cinturon { get; set; }
        public List<Carro> Carros { get; set; }
        //public Carro Carro { get; set; }
        public Asiento()
        {
            Carros = new List<Carro>();
        }

    }
}
