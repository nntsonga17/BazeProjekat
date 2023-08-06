namespace StambenaZgradaLibrary.DTOs;

public class LicencaView
{
		public int ID_licence { get; set; }
        public long? Broj_licence { get; set; }
        public DateTime? Datum_sticanja_obnavljanja { get; set; }
        public string? Naziv_insitucije { get; set; }

        public ProfesionalniUpravnikView? Upravnik { get; set; }


    public LicencaView()
    {
    }

    internal LicencaView(Licenca? z)
    {
        if (z != null)
        {
           ID_licence = z.ID_licence;
		   Broj_licence = z.Broj_licence;
		   Datum_sticanja_obnavljanja = z.Datum_sticanja_obnavljanja;
		   Naziv_insitucije = z.Naziv_insitucije;
		   
		   //Upravnik = z.Upravnik;
        }
    }
}
