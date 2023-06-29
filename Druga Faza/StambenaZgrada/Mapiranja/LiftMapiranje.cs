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
    class LiftMapiranje : ClassMap<Entiteti.Lift>
    {
        public LiftMapiranje()
        {

            //Mapiranje tabele
            Table("LIFT");

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("TIPLIFTA");

            //mapiranje primarnog kljuca
            // Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity().UnsavedValue(-1);
            Id(x => x.Serijski_broj, "SERIJSKI_BROJ").GeneratedBy.SequenceIdentity("S18309.SERIJSKI_BR_LIFTA_SEQ");

            //mapiranje svojstava
            //Map(x => x.Tip, "TIP");
            Map(x => x.Naziv_proizvodjaca, "NAZIV_PROIZVODJACA");
            Map(x => x.Datum_poslednjeg_kvara, "DATUM_POSLEDNJEG_KVARA");
            Map(x => x.Datum_poslednjeg_servisa, "DATUM_POSLEDNJEG_SERVISA");

            //mapiranje veze 1:N Prodavnica-Odeljenje
            References(x => x.Ima_lift).Column("ZGRADA").LazyLoad();

        }
    }

    class PutnickiLiftMapiranje : SubclassMap<Entiteti.PutnickiLift>
    {
        public PutnickiLiftMapiranje()
        {
            DiscriminatorValue(0);
            Map(x => x.Max_broj_osoba, "MAX_BROJ_OSOBA");
        }
    }

    class TeretniLiftMapiranje : SubclassMap<Entiteti.TeretniLift>
    {
        public TeretniLiftMapiranje()
        {
            DiscriminatorValue(1);
            Map(x => x.Nosivost, "NOSIVOST");
        }
    }

}

