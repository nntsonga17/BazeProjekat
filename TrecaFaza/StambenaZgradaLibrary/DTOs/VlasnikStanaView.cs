namespace StambenaZgradaLibrary.DTOs;

public class VlasnikStanaView
{
		public long JMBG { get; set; }
        public string? Licno_ime { get; set; }
        public string? Ime_roditelja { get; set; }
        public string? Prezime { get; set; }
        public string? Br_telefona1 { get; set; }
        public string? Br_telefona2 { get; set; }
        public string? Mesto_stanovanja { get; set; }
        public string? Ulica { get; set; }
        public string? Broj { get; set; }
		public int? Tip_u_skupstini {get; set; }
		
        public  IList<StanView>? Ima_stan { get; set; }

		public VlasnikStanaView()
		{
			Ima_stan = new List<StanView>();
		}

		internal VlasnikStanaView(VlasnikStana? z)
		{
			if (z != null)
			{
			   JMBG = z.JMBG;
			   Licno_ime = z.Licno_ime;
			   Ime_roditelja = z.Ime_roditelja;
			   Prezime = z.Prezime;
			   Br_telefona1 = z.Br_telefona1;
			   Br_telefona2 = z.Br_telefona2;
			   Mesto_stanovanja = z.Mesto_stanovanja;
			   Ulica = z.Ulica;
			   Broj = z.Broj;
			   Tip_u_skupstini = z.Tip_u_skupstini; 
			   
			}
		}
}
