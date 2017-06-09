using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Property(c => c.NumSerieAsiento)
                .IsRequired()
                .HasMaxLength(10);
            Property(c => c.AsientoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
 
        }

    }
}
