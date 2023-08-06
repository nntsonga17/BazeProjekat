using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
   internal class VlasnikStanaMapiranje : ClassMap<Entiteti.VlasnikStana>
    {
        public VlasnikStanaMapiranje()
        {
            //Mapiranje tabele
            Table("VLASNIK_STANA");

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
            Map(x => x.Broj, "BROJ");
            Map(x => x.Tip_u_skupstini, "TIP_U_SKUPSTINI");

            HasMany(x => x.Ima_stan).KeyColumn("VLASNIK").LazyLoad().Cascade.All();


        }
    }
}