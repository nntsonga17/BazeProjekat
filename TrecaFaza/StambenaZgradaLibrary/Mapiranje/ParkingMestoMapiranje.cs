using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class ParkingMestoMapiranje : SubclassMap<ParkingMesto>
    {
        public ParkingMestoMapiranje()
        {
            Table("PARKING_MESTO");

            KeyColumn("ID_nivoa");

            Map(x => x.Rezervisano).Column("REZERVISANO");

        }
    }
}
