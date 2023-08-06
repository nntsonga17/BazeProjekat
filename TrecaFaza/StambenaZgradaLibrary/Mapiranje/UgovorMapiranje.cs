using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class UgovorMapiranje : ClassMap<Entiteti.Ugovor>
    {
        public UgovorMapiranje()
        {
            //Mapiranje tabele
            Table("UGOVOR");

            //mapiranje primarnog kljuca
            Id(x => x.Sifra, "Sifra").GeneratedBy.SequenceIdentity("S18309.SIFRA_UGOVORA_SEQ");

            //mapiranje svojstava.
            Map(x => x.Datum_potpisivanja, "DATUM_POTPISIVANJA");
            Map(x => x.Vazenje_ugovora, "VAZENJE_UGOVORA");


            //1:1 za Zgradom
            References(x => x.Zgrada,"Zgrada").Unique().Cascade.All();
        }
    }
}
