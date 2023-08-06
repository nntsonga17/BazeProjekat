using StambenaZgradaLibrary.Entiteti;

namespace StambenaZgradaLibrary.DTOs;

public class ZaposlenView
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
        public int? Broj_licne_karte { get; set; }
        public string? Mesto_izdavanja { get; set; }
        public DateTime? Datum_rodjenja { get; set; }

    public ZaposlenView()
    {
    }

    internal ZaposlenView(Zaposlen? z)
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
		   Broj_licne_karte = z.Broj_licne_karte;
		   Mesto_izdavanja = z.Mesto_izdavanja;
		   Datum_rodjenja = z.Datum_rodjenja;
        }
    }
}
