using _2014214826_API.DTO;
using _2014214826_ENT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2014214826_API.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Asiento, AsientosDto>();
            CreateMap<AsientosDto, Asiento>();

            CreateMap<Automovil, AutomovilDto>();
            CreateMap<AutomovilDto, Automovil>();

            CreateMap<Bus, BusDto>();
            CreateMap<BusDto, Bus>();

            CreateMap<Carro, CarroDto>();
            CreateMap<CarroDto, Carro>();

            CreateMap<Cinturon, CinturonDto>();
            CreateMap<CinturonDto, Cinturon>();

            CreateMap<Ensambladora, EnsambladoraDto>();
            CreateMap<EnsambladoraDto, Ensambladora>();

            CreateMap<Llanta, LlantaDto>();
            CreateMap<LlantaDto, Llanta>();

            CreateMap<Parabrisas, ParabrisasDto>();
            CreateMap<ParabrisasDto, Parabrisas>();

            CreateMap<Propietario,PropietarioDto>();
            CreateMap<PropietarioDto, Propietario>();

            CreateMap<Volante, VolanteDto>();
            CreateMap<VolanteDto, Volante>();

        }
    }
}