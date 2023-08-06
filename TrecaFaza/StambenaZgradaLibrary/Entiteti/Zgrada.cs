namespace StambenaZgradaLibrary.Entiteti
{
  internal class Zgrada
    {
        internal protected virtual int ID_zgrade { get; protected set; }
        internal protected virtual string? Mesto { get; set; }
        internal protected virtual string? Ulica { get; set; }
        internal protected virtual string? Broj { get; set; }
        internal protected virtual int? Broj_jedinica { get; set; }
        internal protected virtual int? Godina_izgradnje { get; set; }

        internal protected virtual ProfesionalniUpravnik? Upravnik { get; set; }

        //i veza 1:1 sa Ugovor
        internal protected virtual Ugovor? Ugovor { get; set; }


        internal protected virtual IList<Lift>? Ima_lift { get; set; }
        internal protected virtual IList<Ulaz>? Ima_ulaz { get; set; }
        internal protected virtual IList<Nivo>? Ima_nivo { get; set; }

        internal Zgrada()
        {
            Ima_lift = new List<Lift>();

            Ima_ulaz = new List<Ulaz>();

            Ima_nivo = new List<Nivo>();


        }
    }
}