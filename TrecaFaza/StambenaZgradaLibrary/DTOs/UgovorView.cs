namespace StambenaZgradaLibrary.DTOs;

public class UgovorView
{
		public int Sifra  { get; set; }
        public DateTime? Datum_potpisivanja { get; set; }
        public int? Vazenje_ugovora { get; set; }
        public ZgradaView? Zgrada { get; set; }

    public UgovorView()
    {
    }

    internal UgovorView(Ugovor? z)
    {
        if (z != null)
        {
           Sifra = z.Sifra;
		   Datum_potpisivanja = z.Datum_potpisivanja;
		   Vazenje_ugovora = z.Vazenje_ugovora;
		   
		   //Zgrada = z.Zgrada;
        }
    }
}
