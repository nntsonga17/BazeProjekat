namespace StambenaZgradaLibrary.Entiteti
{
    internal class Ugovor

    {
        internal protected virtual int Sifra { get; protected set; }
        internal protected virtual DateTime? Datum_potpisivanja { get; set; }
        internal protected virtual int? Vazenje_ugovora { get; set; }

        //veza 1:1 sa Zgradom
        internal protected virtual Zgrada? Zgrada { get; set;  }
    }
}