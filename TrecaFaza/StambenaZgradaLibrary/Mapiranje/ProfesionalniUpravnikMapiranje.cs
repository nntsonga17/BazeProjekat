using FluentNHibernate.Mapping;

namespace StambenaZgradaLibrary.Mapiranje
{
    internal class ProfesionalniUpravnikMapiranje : SubclassMap<ProfesionalniUpravnik>
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