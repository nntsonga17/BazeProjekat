namespace StambenaZgradaLibrary.Entiteti
{
    internal class VlasnikStana
    {
        internal protected virtual long JMBG { get;  set; }
        internal protected virtual string? Licno_ime { get; set; }
        internal protected virtual string? Ime_roditelja { get; set; }
        internal protected virtual string? Prezime { get; set; }
        internal protected virtual string? Br_telefona1 { get; set; }
        internal protected virtual string? Br_telefona2 { get; set; }
        internal protected virtual string? Mesto_stanovanja { get; set; }
        internal protected virtual int? Tip_u_skupstini { get; set; }

        internal protected virtual string? Ulica { get; set; }
        internal protected virtual string? Broj { get; set; }

        internal protected virtual IList<Stan>? Ima_stan { get; set; }

        internal VlasnikStana()
        {
            Ima_stan = new List<Stan>();
        }

    }
}