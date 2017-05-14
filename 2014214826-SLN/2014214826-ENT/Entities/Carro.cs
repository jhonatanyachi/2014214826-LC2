using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public abstract class Carro
    {
        public int CarroId { get; set; }
        public string NumSerieMotor { get; set; }
        public string NumSerieChasis { get; set; }
        public List<Asiento> Asiento { get; set; }
        public List<Llanta> Llanta { get; set; }
        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }

        //Considerando que el carro tiene 1 parabrisas - frontal y no posee la trasera (1 a 1)
        public Parabrisas Parabrisas { get; set; }

        public int ParabrisasId { get; set; }
        public Volante Volante { get; set; }
        public int VolanteId { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public Ensambladora Ensambladora { get; set; }
        public int EnsambladoraId { get; set; }

        public Carro(Volante volante, Parabrisas parabrisas, int numLlantas,
             int numAsientos, Propietario propietario, TipoCarro tipoCarro)
        {
            Llanta = new List<Llanta>(numLlantas);
            Asiento = new List<Asiento>(numAsientos);
            Parabrisas = parabrisas;
            Volante = volante;
            Propietario = propietario;

            TipoCarro = tipoCarro;
        }

        public Carro()
        {
            Asiento = new List<Asiento>();
            Llanta = new List<Llanta>();
        }
    }       

}
