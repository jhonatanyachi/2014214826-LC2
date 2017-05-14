using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class ParabrisasConfiguration:EntityTypeConfiguration<Parabrisas>
    {
        public ParabrisasConfiguration()
        {
            ToTable("Parabrisas");

            HasKey(c => c.ParabrisasId);
            //Propiedades
            Property(c => c.NumSerie)
                .IsRequired()
                .HasMaxLength(10);


            //Relaciones
            HasRequired(c => c.Carro)
                .WithRequiredPrincipal(c => c.Parabrisas);
        }
    }
}
