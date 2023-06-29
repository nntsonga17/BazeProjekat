using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using StambenaZgrada.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada.Mapiranja
{
    class ProfesionalniUpravnikMapiranje : SubclassMap<ProfesionalniUpravnik>
    {
        public ProfesionalniUpravnikMapiranje()
        {
            Table("PROFESIONALNI_UPRAVNIK");

            KeyColumn("JMBG");

            Map(x => x.Naziv_institucije).Column("NAZIV_INSTITUCIJE");
            Map(x => x.Zvanje).Column("ZVANJE");
            Map(x => x.Datum_sticanja_diplome).Column("DATUM_STICANJA_DIPLOME");


        }
    }
}
