using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    class EnsambladoraConfiguration:EntityTypeConfiguration<Ensambladora>
    {
        public EnsambladoraConfiguration()
        {
            ToTable("Ensambladora");

            HasKey(c => c.EnsambladoraId);

           
        }
    }
}
