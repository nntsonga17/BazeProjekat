namespace StambenaZgradaLibrary.DTOs;

public class NivoView
{
		public int ID_nivoa { get; set; }
        public int? Sprat { get; set; }
        public int? Redni_broj { get; set; }

        public ZgradaView? Zgrada { get; set; }


    public NivoView()
    {
    }

    internal NivoView(Nivo? z)
    {
        if (z != null)
        {
          ID_nivoa = z.ID_nivoa;
		  Sprat = z.Sprat;
		  Redni_broj = z.Redni_broj;
		  
		  //Zgrada = z.Zgrada;
        }
    }
}



public class StanView : NivoView
{
	public VlasnikStanaView? Vlasnik {get; set;}
	
	public StanView()
	{
	}
	
	internal StanView(Stan? z) : base(z)
	{
		//Vlasnik = z.Vlasnik;
	}
	
}



public class LokalView : NivoView
{
	public string? Naziv_firme {get; set;}
	
	public LokalView()
	{
	}
	
	internal LokalView(Lokal? z) : base(z)
	{
		Naziv_firme = z.Naziv_firme;
	}
	
}




public class ParkingMestoView : NivoView
{
	public int? Rezervisano {get; set;}
	
	public ParkingMestoView()
	{
	}
	
	internal ParkingMestoView(ParkingMesto? z) : base(z)
	{
		Rezervisano = z.Rezervisano;
	}
	
}