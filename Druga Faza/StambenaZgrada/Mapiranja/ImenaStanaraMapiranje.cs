using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StambenaZgrada.Entiteti;
using FluentNHibernate.Mapping;

namespace StambenaZgrada.Mapiranja
{
    class ImenaStanaraMapiranje : ClassMap<ImenaStanara>
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