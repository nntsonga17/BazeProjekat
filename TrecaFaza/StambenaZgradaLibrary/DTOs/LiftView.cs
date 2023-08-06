using StambenaZgradaLibrary.Entiteti;

namespace StambenaZgradaLibrary.DTOs;

public class LiftView
{
		 public int Serijski_broj { get; set; }
        public string? Naziv_proizvodjaca { get; set; }
        public DateTime? Datum_poslednjeg_kvara { get; set; }
        public DateTime? Datum_poslednjeg_servisa { get; set; }
		
        public ZgradaView? Ima_lift { get; set; }

    public LiftView()
    {
    }

    internal LiftView(Lift? z)
    {
        if (z != null)
        {
          Serijski_broj = z.Serijski_broj;
		  Naziv_proizvodjaca = z.Naziv_proizvodjaca;
		  Datum_poslednjeg_kvara = z.Datum_poslednjeg_kvara;
		  Datum_poslednjeg_servisa = z.Datum_poslednjeg_servisa;
		  
		  //Ima_lift = z.Ima_lift;
        }
    }
}



public class PutnickiLiftView : LiftView
{
	 public int? Max_broj_osoba {get; set;}
		 
    public PutnickiLiftView()
    {
    }

    internal PutnickiLiftView(PutnickiLift? z) : base(z)
    {
        if (z != null)
        {
          Max_broj_osoba = z.Max_broj_osoba;
        }
    }
}



public class TeretniLiftView : LiftView
{
    public double? Nosivost { get; set; }

    public TeretniLiftView()
    {
    }

    internal TeretniLiftView(TeretniLift? z) : base(z)
    {
        if (z != null)
        {
            Nosivost = z.Nosivost;
        }
    }
}