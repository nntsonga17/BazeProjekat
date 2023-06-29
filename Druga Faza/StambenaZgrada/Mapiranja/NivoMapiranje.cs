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
    class NivoMapiranje : ClassMap<Entiteti.Nivo>
    {
        public NivoMapiranje()
        {

            //Mapiranje tabele
            Table("NIVO");


            //mapiranje primarnog kljuca
            // Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity().UnsavedValue(-1);
            Id(x => x.ID_nivoa, "ID_NIVOA").GeneratedBy.SequenceIdentity("S18309.ID_NIVOA_SEQ");

            Map(x => x.Sprat, "SPRAT");
            Map(x => x.Redni_broj, "REDNI_BROJ");

            //mapiranje veze 1:N Prodavnica-Odeljenje
            References(x => x.Zgrada).Column("ZGRADA").LazyLoad();

        }
    }



}
