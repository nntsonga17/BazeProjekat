namespace StambenaZgradaLibrary.DTOs;

public class ZgradaView
{
		public int ID_zgrade { get; set; }
        public string? Mesto { get; set; }
        public string? Ulica { get; set; }
        public string? Broj { get; set; }
        public int? Broj_jedinica { get; set; }
        public int? Godina_izgradnje { get; set; }

        public ProfesionalniUpravnikView? Upravnik { get; set; }

        public UgovorView? Ugovor { get; set; }

        public virtual IList<LiftView>? Ima_lift { get; set; }
        public virtual IList<UlazView>? Ima_ulaz { get; set; }
        public virtual IList<NivoView>? Ima_nivo { get; set; }

    public ZgradaView()
    {
		Ima_lift = new List<LiftView>();
		Ima_ulaz = new List<UlazView>();
		Ima_nivo = new List<NivoView>();
    }

    internal ZgradaView(Zgrada? z)
    {
        if (z != null)
        {
           ID_zgrade = z.ID_zgrade;
		   Mesto = z.Mesto;
		   Ulica = z.Ulica;
		   Broj = z.Broj;
		   Broj_jedinica = z.Broj_jedinica;
		   Godina_izgradnje = z.Godina_izgradnje;
		   
		   //Upravnik = z.Upravnik;
		   //Ugovor = z.Ugovor;
        }
    }
}
