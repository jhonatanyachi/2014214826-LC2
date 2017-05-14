using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class CarroConfiguration:EntityTypeConfiguration<Carro>
    {
        public CarroConfiguration()
        {
            ToTable("Carros");

            HasKey(c => c.CarroId);
            //Propiedades
            Property(c => c.NumSerieChasis)
                .IsRequired()
                .IsMaxLength();
            Property(c => c.NumSerieMotor)
               .IsRequired()
               .HasMaxLength(10)
               .IsMaxLength();

            //Relaciones
            HasRequired(c => c.Ensambladora)
                .WithMany(c => c.Carro)
                .HasForeignKey(c => c.Ensambladora);
        }
    }
}
