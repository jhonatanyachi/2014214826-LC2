using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class LlantaConfiguration:EntityTypeConfiguration<Llanta>
    {
        public LlantaConfiguration()
        {
            ToTable("Llantas");

            HasKey(c => c.LlantaId);
            //Propiedades 
            Property(c => c.NumSerie)
                .IsRequired();


            //Relaciones
            HasRequired(c => c.Carro)
                .WithMany(c => c.Llanta);

        }
    }
}
