namespace StambenaZgradaLibrary.Entiteti
{
    internal abstract class Lift
    {
        internal protected virtual int Serijski_broj { get;  set; }
        internal protected virtual string? Naziv_proizvodjaca { get; set; }
        internal protected virtual DateTime? Datum_poslednjeg_kvara { get; set; }
        internal protected virtual DateTime? Datum_poslednjeg_servisa { get; set; }
        internal protected virtual int? TipLifta { get; set; }
        internal protected virtual Zgrada? Ima_lift { get; set; }

    }

    internal class PutnickiLift : Lift
    {
        internal protected virtual int? Max_broj_osoba { get; set; }

    }

    internal class TeretniLift : Lift
    {
        internal protected virtual double? Nosivost { get; set; }
    }

}