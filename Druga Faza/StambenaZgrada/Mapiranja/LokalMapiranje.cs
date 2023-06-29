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
    class LokalMapiranje : SubclassMap<Lokal>
    {
        public LokalMapiranje()
        {
            Table("LOKAL");

            KeyColumn("ID_nivoa");

            Map(x => x.Naziv_firme).Column("NAZIV_FIRME");

        }
    }
}
