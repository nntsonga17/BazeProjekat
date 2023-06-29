using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Mapiranja
{
    class ZaposlenMapiranje : ClassMap<Entiteti.Zaposlen>
    {
        public ZaposlenMapiranje()
        {
            //Mapiranje tabele
            Table("ZAPOSLEN");

            //mapiranje primarnog kljuca
            Id(x => x.JMBG).Column("JMBG").GeneratedBy.Assigned();

            //mapiranje svojstava.
            Map(x => x.Licno_ime, "LICNO_IME");
            Map(x => x.Ime_roditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Br_telefona1, "BR_TELEFONA1");
            Map(x => x.Br_telefona2, "BR_TELEFONA2");
            Map(x => x.Mesto_stanovanja, "MESTO_STANOVANJA");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj_licne_karte, "BROJ_LICNE_KARTE");
            Map(x => x.Broj, "BROJ");
            Map(x => x.Mesto_izdavanja, "MESTO_IZDAVANJA");
            Map(x => x.Datum_rodjenja, "DATUM_RODJENJA");
        }
    }
}
