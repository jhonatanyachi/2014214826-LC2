using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class CinturonConfiguration:EntityTypeConfiguration<Cinturon>
    {
        public CinturonConfiguration()
        {
            ToTable("Cinturones");

            HasKey(c => c.CinturonId);
            //Propiedades
            Property(c => c.NumSerie)
                .IsRequired()
                .HasMaxLength(10);

            //Relaciones

            HasRequired(c => c.Asiento)
                .WithRequiredPrincipal(c => c.Cinturon);
        }
    }
}
