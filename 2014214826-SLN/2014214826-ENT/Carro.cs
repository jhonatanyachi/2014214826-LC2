using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public class Carro
    {
        public int CarroId { get; set; }
        public string NumSerieMotor { get; set; }
        public string NumSerieChasis { get; set; }
        public List<Asiento> Asiento { get; set; }
        public List<Llanta> Llanta { get; set; }
        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }

        //Considerando que el carro tiene 2 parabrisas - frontal y trasera (1 a *)
        public List<Parabrisas> Parabrisas { get; set; }

        public Volante Volante { get; set; }
        public int VolanteId { get; set; }


        public Carro()
        {
            Asiento = new List<Asiento>();
            Llanta = new List<Llanta>();
            Parabrisas = new List<Parabrisas>();
        }
    }       

}
