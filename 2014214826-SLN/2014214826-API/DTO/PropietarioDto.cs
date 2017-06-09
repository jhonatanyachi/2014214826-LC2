using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2014214826_API.DTO
{
    public class PropietarioDto
    {
        public int PropietarioId { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string LicenciaConducir { get; set; }
    }
}