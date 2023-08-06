using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class ImenaStanaraMapiranje : ClassMap<ImenaStanara>
    {
        public ImenaStanaraMapiranje()
        {
            //Mapiranje tabele
            Table("IMENA_STANARA");

            //mapiranje primarnog kljuca
            Id(x => x.ID_stanari, "ID_stanari").GeneratedBy.SequenceIdentity("S18309.ID_STANARI_SEQ");

            Map(x => x.Ime_stanara).Column("IME_STANARA");

            //mapiranje veza
            References(x => x.Nivo).Column("NIVO").LazyLoad();
        }
    }
}