using StambenaZgradaLibrary.Entiteti;

namespace StambenaZgradaLibrary.DTOs;

public class ProfesionalniUpravnikView : ZaposlenView
{
		
        public string? Naziv_institucije { get; set; }
        public string? Zvanje { get; set; }
        public DateTime? Datum_sticanja_diplome { get; set; }

        public IList<ZgradaView>? Upravlja { get; set; }

        public LicencaView? Ima_licencu;

		public ProfesionalniUpravnikView()
		{
			Upravlja = new List<ZgradaView>();
		}

		internal ProfesionalniUpravnikView(ProfesionalniUpravnik? z) : base(z)
		{
			if (z != null)
			{
				Naziv_institucije = z.Naziv_institucije;
				Zvanje = z.Zvanje;
				Datum_sticanja_diplome = z.Datum_sticanja_diplome;
				
				//Ima_licencu = z.Ima_licencu;
			   
			}
		}
}
