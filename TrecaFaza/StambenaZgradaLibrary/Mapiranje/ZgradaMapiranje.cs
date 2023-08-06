using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class ZgradaMapiranje : ClassMap<Entiteti.Zgrada>
    {
        public ZgradaMapiranje()
        {
            //Mapiranje tabele
            Table("ZGRADA");

            //mapiranje primarnog kljuca
            Id(x => x.ID_zgrade).Column("ID_ZGRADE").GeneratedBy.SequenceIdentity("S18309.ID_ZGRADE_SEQ");

            //mapiranje svojstava.
            Map(x => x.Mesto, "MESTO");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj, "BROJ");
            Map(x => x.Broj_jedinica, "BROJ_JEDINICA");
            Map(x => x.Godina_izgradnje, "GODINA_IZGRADNJE");


            //mapiranje veze 1:N Prodavnica-Odeljenje
            References(x => x.Upravnik).Column("UPRAVNIK").LazyLoad();


            // 1:1 sa Ugovor
            HasOne(x => x.Ugovor).Cascade.All();
            //HasOne(x => x.Ugovor).PropertyRef(x => x.Zgrada);

            HasMany(x => x.Ima_lift).KeyColumn("ZGRADA").LazyLoad().Cascade.All();
            HasMany(x => x.Ima_ulaz).KeyColumn("ZGRADA").LazyLoad().Cascade.All();
            HasMany(x => x.Ima_nivo).KeyColumn("ZGRADA").LazyLoad().Cascade.All();
        }
    }
}
