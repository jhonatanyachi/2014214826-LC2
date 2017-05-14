﻿using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class VolanteConfiguration:EntityTypeConfiguration<Volante>
    {
        public VolanteConfiguration()
        {
            ToTable("Volantes");
            //Propiedades
            Property(c => c.NumSerie)
                .IsRequired()
                .HasMaxLength(10);

            //Relaciones
            HasKey(c => c.VolanteId);
            HasRequired(c => c.Carro)
                .WithRequiredPrincipal(c => c.Volante);
        }
    }
}
