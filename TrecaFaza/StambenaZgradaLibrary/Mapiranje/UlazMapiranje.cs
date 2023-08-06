using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class UlazMapiranje : ClassMap<Entiteti.Ulaz>
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

            
        }
    }
}
