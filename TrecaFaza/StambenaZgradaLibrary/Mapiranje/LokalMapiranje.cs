using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class LokalMapiranje : SubclassMap<Lokal>
    {
        public LokalMapiranje()
        {
            Table("LOKAL");

            KeyColumn("ID_nivoa");

            Map(x => x.Naziv_firme).Column("NAZIV_FIRME");

        }
    }
}
