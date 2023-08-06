namespace StambenaZgradaLibrary.Entiteti
{
   internal class Zaposlen
    {
        internal protected virtual long JMBG { get;   set; }
        internal protected virtual string? Licno_ime { get; set; }
        internal protected virtual string? Ime_roditelja { get; set; }
        internal protected virtual string? Prezime { get; set; }
        internal protected virtual string? Br_telefona1 { get; set; }
        internal protected virtual string? Br_telefona2 { get; set; }

        internal protected virtual string? Mesto_stanovanja { get; set; }
        internal protected virtual string? Ulica { get; set; }
        internal protected virtual string? Broj { get; set; }

        internal protected virtual int? Broj_licne_karte { get; set; }
        internal protected virtual string? Mesto_izdavanja { get; set; }
        internal protected virtual DateTime? Datum_rodjenja { get; set; }
    }
}