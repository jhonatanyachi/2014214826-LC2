using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class AutomovilConfiguration:EntityTypeConfiguration<Automovil>
    {
        public AutomovilConfiguration()
        {
            ToTable("Automoviles");

            HasKey(c => c.AutomovilId);
        }
    }
}
