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
    class StanMapiranje : SubclassMap<Stan>
    {
        public StanMapiranje()
        {
            Table("STAN");

            KeyColumn("ID_nivoa");

            References(x => x.Vlasnik).Column("VLASNIK").LazyLoad();

        }
    }
}
