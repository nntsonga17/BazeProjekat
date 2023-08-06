namespace StambenaZgradaLibrary.Entiteti
{
    internal class Licenca
    {
        internal protected virtual int ID_licence { get; protected set; }
        internal protected virtual long? Broj_licence { get; set; }
        internal protected virtual DateTime? Datum_sticanja_obnavljanja { get; set; }
        internal protected virtual String? Naziv_insitucije { get; set; }

        internal protected virtual ProfesionalniUpravnik? Upravnik { get; set; }
    }
}