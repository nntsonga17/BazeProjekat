namespace StambenaZgradaLibrary.Entiteti
{
    internal class Ulaz
    {

        internal protected virtual int ID_ulaza { get; protected set; }
        internal protected virtual int? Redni_broj { get; set; }
        internal protected virtual int? Postojanje_kamere { get; set; }
        internal protected virtual string? Vreme_otvaranja { get; set; }
        internal protected virtual string? Vreme_zatvaranja { get; set; }

        internal protected virtual Zgrada? Zgrada { get; set; }
    }

}
