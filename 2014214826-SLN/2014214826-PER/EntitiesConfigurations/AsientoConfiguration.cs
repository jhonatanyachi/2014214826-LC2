﻿using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class AsientoConfiguration:EntityTypeConfiguration<Asiento>
    {
        public AsientoConfiguration()
        {

            ToTable("Asientos");

            HasKey(c => c.AsientoId);
            //Propiedades
            Property(c => c.NumSerie)
                .IsRequired()
                .HasMaxLength(10);

            //Relaciones
            HasRequired(c => c.Carro)
                .WithMany(c => c.Asiento);
 
        }

    }
}