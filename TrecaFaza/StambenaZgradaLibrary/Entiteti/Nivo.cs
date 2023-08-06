namespace StambenaZgradaLibrary.Entiteti
{
    internal class Nivo
    {
        internal protected virtual int ID_nivoa { get;  set; }
        internal protected virtual int? Sprat { get; set; }
        internal protected  virtual int? Redni_broj { get; set; }


        internal protected virtual Zgrada? Zgrada { get; set; }

    }

}