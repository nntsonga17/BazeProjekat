using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using StambenaZgrada.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Mapiranja
{
    class ParkingMestoMapiranje : SubclassMap<ParkingMesto>
    {
        public ParkingMestoMapiranje()
        {
            Table("PARKING_MESTO");

            KeyColumn("ID_nivoa");

            Map(x => x.Rezervisano).Column("REZERVISANO");

        }
    }
}
