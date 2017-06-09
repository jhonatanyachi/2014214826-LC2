using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2014214826_API.DTO
{
    public class CarroDto
    {
        public int CarroId { get; set; }
        public string NumSerieMotor { get; set; }
        public string NumSerieChasis { get; set; }
        public int PropietarioId { get; set; }
        //Considerando que el carro tiene 1 parabrisas - frontal y no posee la trasera (1 a 1)
        public int ParabrisasId { get; set; }
        public int VolanteId { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public int AsientoId { get; set; }
        public int LlantaId { get; set; }
        public int EnsambladoraId { get; set; }
    }
}