namespace StambenaZgradaLibrary.DTOs;

public class UlazView
{
		public int ID_ulaza { get; set; }
        public int? Redni_broj { get; set; }
        public int? Postojanje_kamere { get; set; }
        public string? Vreme_otvaranja { get; set; }
        public string? Vreme_zatvaranja { get; set; }

        public  ZgradaView?  Zgrada { get; set; }

    public UlazView()
    {
	}

    internal UlazView(Ulaz? z)
    {
        if (z != null)
        {
          ID_ulaza = z.ID_ulaza;
		  Redni_broj = z.Redni_broj;
		  Postojanje_kamere = z.Postojanje_kamere;
		  Vreme_otvaranja = z.Vreme_otvaranja;
		  Vreme_zatvaranja = z.Vreme_zatvaranja;
		  
		  //Zgrada = z.Zgrada;
        }
    }
}
