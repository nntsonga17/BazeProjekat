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
    class UlazMapiranje : ClassMap<Entiteti.Ulaz>
    {
        public UlazMapiranje()
        {
            //Mapiranje tabele
            Table("ULAZ");

            //mapiranje primarnog kljuca
            Id(x => x.ID_ulaza).Column("ID_ULAZA").GeneratedBy.SequenceIdentity("S18309.ID_ULAZA_SEQ");

            //mapiranje svojstava.
            Map(x => x.Redni_broj, "REDNI_BROJ");
            Map(x => x.Vreme_otvaranja, "VREME_OTVARANJA");
            Map(x => x.Vreme_zatvaranja, "VREME_ZATVARANJA");
            Map(x => x.Postojanje_kamere, "POSTOJANJE_KAMERE");


            References(x => x.Zgrada).Column("ZGRADA").LazyLoad();

            //KOD OVIH LAZYLOAD() PAZI KAD ISPITUJETE DODAVANJE I AŽURIRANJE PODATAKA, MOŽDA TREBA DA SE 
            //PROMENI DA BUDE INVERSE!!!!!!! (i kaskadno)
        }
    }
}
