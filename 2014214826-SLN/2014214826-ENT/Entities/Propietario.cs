using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT
{
    public class Propietario
    {
        //Considerando que cada propietario tiene un carro (1 a 1)
        public int PropietarioId { get; set; }
        // Considero que el DNI podria ser "int" pero acato al PDF
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string LicenciaConducir { get; set; }
        public Carro Carro { get; set; }
        public int CarroId { get; set; }

    }
}
