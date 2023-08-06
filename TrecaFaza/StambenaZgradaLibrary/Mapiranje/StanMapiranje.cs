using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class StanMapiranje : SubclassMap<Stan>
    {
        public StanMapiranje()
        {
            Table("STAN");

            KeyColumn("ID_nivoa");

            References(x => x.Vlasnik).Column("VLASNIK").LazyLoad();

        }
    }
}
