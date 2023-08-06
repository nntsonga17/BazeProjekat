namespace StambenaZgradaLibrary.Entiteti
{
    internal class ProfesionalniUpravnik : Zaposlen
    {
        internal protected virtual string? Naziv_institucije { get; set; }
        internal protected virtual string? Zvanje { get; set; }
        internal protected virtual DateTime? Datum_sticanja_diplome { get; set; }

        internal protected virtual IList<Zgrada>? Upravlja { get; set; }

        //1:1  s Licencom
        internal protected virtual Licenca? Ima_licencu { get; set; }

        internal ProfesionalniUpravnik()
        {
            Upravlja = new List<Zgrada>();
        }

    }
}