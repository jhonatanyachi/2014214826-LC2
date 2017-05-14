using _2014214826_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_PER.EntitiesConfigurations
{
    public class BusConfiguration:EntityTypeConfiguration<Bus>
    {
        public BusConfiguration()
        {
            ToTable("Buses");

            HasKey(c => c.BusId);
        }
    }
}
