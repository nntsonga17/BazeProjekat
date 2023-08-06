using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class LicencaMapiranje : ClassMap<Licenca>
    {
        public LicencaMapiranje()
        {
            Table("Licenca");

            //mapiranje primarnog kljuca
            Id(x => x.ID_licence, "ID_LICENCE").GeneratedBy.SequenceIdentity("S18309.ID_STANARI_SEQ");


            Map(x => x.Broj_licence).Column("BROJ_LICENCE");
            Map(x => x.Datum_sticanja_obnavljanja).Column("DATUM_STICANJA_OBNAVLJANJA");
            Map(x => x.Naziv_insitucije).Column("NAZIV_INSTITUCIJE");


            //KAKO TREBA REFERENCIRATI S OBZIROM DA JE SLAB ENTITET ??
            References(x => x.Upravnik).Column("UPRAVNIK").Unique().Cascade.All();


        }
    }
}