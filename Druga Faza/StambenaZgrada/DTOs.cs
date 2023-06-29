using StambenaZgrada.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StambenaZgrada
{
    #region Zaposlen
    public class ZaposlenBasic
    {
        public long JMBG;
        public string Licno_ime;
        public string Ime_roditelja;
        public string Prezime;
        public string Br_telefona1;
        public string Br_telefona2;
        public string Mesto_stanovanja;
        public string Ulica;
        public string Broj;
        public int Broj_licne_karte;
        public string Mesto_izdavanja;
        public DateTime Datum_rodjenja;
        public ZaposlenBasic()
        {

        }
       

        public ZaposlenBasic(long jMBG, string licno_ime, string ime_roditelja, string prezime, string br_telefona1, string br_telefona2, string mesto_stanovanja, string ulica, int broj_licne_karte, string mesto_izdavanja, DateTime datum_rodjenja, string broj)
        {
            JMBG = jMBG;
            Licno_ime = licno_ime;
            Ime_roditelja = ime_roditelja;
            Prezime = prezime;
            Br_telefona1 = br_telefona1;
            Br_telefona2 = br_telefona2;
            Mesto_stanovanja = mesto_stanovanja;
            Ulica = ulica;
            Broj_licne_karte = broj_licne_karte;
            Mesto_izdavanja = mesto_izdavanja;
            Datum_rodjenja = datum_rodjenja;
            Broj = broj;
        }

        public override string ToString()
        {
            return Licno_ime + " " + Ime_roditelja + " " + Prezime;
        }
    }
    public class ZaposlenPregled
    {
        public long JMBG;
        public string Licno_ime;
        public string Ime_roditelja;
        public string Prezime;
        public string Br_telefona1;
        public string Br_telefona2;
        public string Mesto_stanovanja;
        public string Ulica;
        public string Broj;
        public int Broj_licne_karte;
        public string Mesto_izdavanja;
        public DateTime Datum_rodjenja;
        public ZaposlenPregled()
        {

        }
       
        public ZaposlenPregled(long jMBG, string licno_ime, string ime_roditelja, string prezime, string br_telefona1, string br_telefona2, string mesto_stanovanja, string ulica, int broj_licne_karte, string mesto_izdavanja, DateTime datum_rodjenja, string broj)
        {
            JMBG = jMBG;
            Licno_ime = licno_ime;
            Ime_roditelja = ime_roditelja;
            Prezime = prezime;
            Br_telefona1 = br_telefona1;
            Br_telefona2 = br_telefona2;
            Mesto_stanovanja = mesto_stanovanja;
            Ulica = ulica;
            Broj_licne_karte = broj_licne_karte;
            Mesto_izdavanja = mesto_izdavanja;
            Datum_rodjenja = datum_rodjenja;
            Broj = broj;
        }
    }
    #endregion

    #region Zgrada
    public class ZgradaBasic
    {

        
        public int ID_zgrade;
        public string Mesto;
        public string Ulica;
        public string Broj;
        public int Broj_jedinica;
        public int Godina_izgradnje;

        public ProfesionalniUpravnikBasic Upravnik; // { get; set; }

        public UgovorBasic Ugovor; // { get; set; }


        public virtual IList<LiftBasic> Ima_lift { get; set; }
        public virtual IList<UlazBasic> Ima_ulaz { get; set; }
        public virtual IList<NivoBasic> Ima_nivo { get; set; }

        public ZgradaBasic()
        {
            Ima_lift = new List<LiftBasic>();

            Ima_ulaz = new List<UlazBasic>();

            Ima_nivo = new List<NivoBasic>();
        }
        public override string ToString()
        {
            return Mesto + ",    " + Ulica + "    br. " + Broj;
        }

        public ZgradaBasic(int id, string mesto, string ulica, string broj, int broj_jedinica, int godina_izgradnje)
        {
                this.ID_zgrade = id;
                this.Mesto = mesto;
                this.Ulica = ulica;
                this.Broj = broj;
                this.Broj_jedinica = broj_jedinica;
                this.Godina_izgradnje = godina_izgradnje;

            /////////
           // Upravnik = new ProfesionalniUpravnikBasic(p.JMBG, p.Licno_ime, p.Ime_roditelja, p.Prezime, p.Br_telefona1, p.Br_telefona2, p.Mesto_stanovanja, p.Ulica, p.Broj, p.Broj_licne_karte, p.Mesto_izdavanja, p.Datum_rodjenja, p.Naziv_institucije, p.Zvanje, p.Datum_sticanja_diplome);
         }



    }
    public class ZgradaPregled
    {
        public int ID_zgrade; //{ get; protected set; }
        public string Mesto; //{ get; set; }
        public string Ulica; // { get; set; }
        public string Broj; //{ get; set; }
        public int Broj_jedinica; //{ get; set; }
        public int Godina_izgradnje; // { get; set; }
        public ZgradaPregled()
        {

        }

        public ZgradaPregled(int id, string mesto, string ulica, string broj, int broj_jedinica, int godina_izgradnje)
        {
            this.ID_zgrade = id;
            this.Mesto = mesto;
            this.Ulica = ulica;
            this.Broj = broj;
            this.Broj_jedinica = broj_jedinica;
            this.Godina_izgradnje = godina_izgradnje;
        }
    }
    #endregion

    #region VlasnikStana
    public class VlasnikStanaBasic
    {
        public  long JMBG;
        public  string Licno_ime;
        public  string Ime_roditelja;
        public string Prezime;
        public string Br_telefona1;
        public string Br_telefona2;
        public string Mesto_stanovanja;
        public int Tip_u_skupstini;
        public string Ulica;
        public string Broj;
        public  IList<StanBasic> Ima_stan { get; set; }

        public VlasnikStanaBasic()
        {
            Ima_stan = new List<StanBasic>();
        }
        public VlasnikStanaBasic(long JMBG, string Licno_ime, string Ime_roditelja, string Prezime, string Br_telefona1, string Br_telefona2, string Mesto_stanovanja, string Ulica, string Broj, int Tip_u_skupstini)
        {
            this.JMBG = JMBG;
            this.Licno_ime = Licno_ime;
            this.Ime_roditelja = Ime_roditelja;
            this.Prezime = Prezime;
            this.Br_telefona1 = Br_telefona1;
            this.Br_telefona2 = Br_telefona2;
            this.Mesto_stanovanja = Mesto_stanovanja;
            this.Ulica = Ulica;
            this.Broj = Broj;
            this.Tip_u_skupstini = Tip_u_skupstini;
        }

        public override string ToString()
        {
            return Licno_ime + " " + Ime_roditelja + " " + Prezime;
        }
    }

    
    public class VlasnikStanaPregled
    {
        public long JMBG;
        public string Licno_ime;
        public string Ime_roditelja;
        public string Prezime;
        public string Br_telefona1;
        public string Br_telefona2;
        public string Mesto_stanovanja;
        public int Tip_u_skupstini;
        public string Ulica;
        public string Broj;

        public VlasnikStanaPregled()
        {

        }
        public VlasnikStanaPregled(long JMBG, string Licno_ime, string Ime_roditelja, string Prezime, string Br_telefona1, string Br_telefona2, string Mesto_stanovanja, string Ulica, string Broj,int Tip_u_skupstini)
        {
            this.JMBG = JMBG;
            this.Licno_ime = Licno_ime;
            this.Ime_roditelja = Ime_roditelja;
            this.Prezime = Prezime;
            this.Br_telefona1 = Br_telefona1;
            this.Br_telefona2 = Br_telefona2;
            this.Mesto_stanovanja = Mesto_stanovanja;
            this.Ulica = Ulica;
            this.Broj = Broj;
            this.Tip_u_skupstini = Tip_u_skupstini;
        }
    }
    #endregion

    #region Ugovor
    public class UgovorBasic
    {
        public int Sifra;
        public DateTime Datum_potpisivanja;
        public int Vazenje_ugovora;
        public ZgradaBasic Zgrada; // { get; set; }
        public UgovorBasic() { }
        public UgovorBasic(int Sifra, DateTime Datum_potpisivanja, int Vazenje_ugovora, Zgrada z)
        {
            this.Sifra = Sifra;
            this.Datum_potpisivanja = Datum_potpisivanja;
            this.Vazenje_ugovora = Vazenje_ugovora;
            Zgrada = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);
        }
    }
    public class UgovorPregled
    {
        public int Sifra;
        public DateTime Datum_potpisivanja;
        public int Vazenje_ugovora;
        public UgovorPregled() { }
        public UgovorPregled(int Sifra, DateTime Datum_potpisivanja, int Vazenje_ugovora)
        {
            this.Sifra = Sifra;
            this.Datum_potpisivanja = Datum_potpisivanja;
            this.Vazenje_ugovora = Vazenje_ugovora;
        }
    }
    #endregion

    #region Licenca
    public class LicencaBasic
    {
        public int ID_licence;
        public long Broj_licence;
        public DateTime Datum_sticanja_obnavljanja;
        public string Naziv_insitucije;

        public ProfesionalniUpravnikBasic Upravnik; // { get; set; }

        public LicencaBasic() { }
        public LicencaBasic(int ID_licence, long Broj_licence, DateTime Datum_sticanja_obnavljanja, string Naziv_institucije, ProfesionalniUpravnik pu)
        {
            this.ID_licence = ID_licence;
            this.Broj_licence = Broj_licence;
            this.Datum_sticanja_obnavljanja = Datum_sticanja_obnavljanja;
            this.Naziv_insitucije = Naziv_institucije;
            Upravnik = new ProfesionalniUpravnikBasic(pu.JMBG, pu.Licno_ime, pu.Ime_roditelja, pu.Prezime, pu.Br_telefona1, pu.Br_telefona2, pu.Mesto_stanovanja, pu.Ulica, pu.Broj, pu.Broj_licne_karte, pu.Mesto_izdavanja, pu.Datum_rodjenja, pu.Naziv_institucije, pu.Zvanje, pu.Datum_sticanja_diplome);

        }
    }
    public class LicencaPregled
    {
        public int ID_licence;
        public long Broj_licence;
        public DateTime Datum_sticanja_obnavljanja;
        public string Naziv_insitucije;


        public LicencaPregled() { }
        public LicencaPregled(int ID_licence, long Broj_licence, DateTime Datum_sticanja_obnavljanja, string Naziv_institucije)
        {
            this.ID_licence = ID_licence;
            this.Broj_licence = Broj_licence;
            this.Datum_sticanja_obnavljanja = Datum_sticanja_obnavljanja;
            this.Naziv_insitucije = Naziv_institucije;
        }
    }
    #endregion

    #region ProfesionalniUpravnik
    public class ProfesionalniUpravnikBasic : ZaposlenBasic
    {
        public string Naziv_institucije;
        public string Zvanje;
        public DateTime Datum_sticanja_diplome;

        public IList<ZgradaBasic> Upravlja; //{ get; set; }

        public LicencaBasic Ima_licencu;
        public ProfesionalniUpravnikBasic()
        {
            Upravlja = new List<ZgradaBasic>();
        }
        public ProfesionalniUpravnikBasic(long JMBG, string Licno_ime, string Ime_roditelja, string Prezime, string Br_telefona1, string Br_telefona2, string Mesto_stanovanja, string Ulica, string Broj, int Broj_licne_karte, string Mesto_izdavanja, DateTime Datum_rodjenja, string Naziv_institucije, string Zvanje, DateTime Datum_sticanja_diplome)
                : base(JMBG, Licno_ime, Ime_roditelja, Prezime, Br_telefona1, Br_telefona2, Mesto_stanovanja, Ulica, Broj_licne_karte, Mesto_izdavanja, Datum_rodjenja, Broj)
        {
            this.Naziv_institucije = Naziv_institucije;
            this.Zvanje = Zvanje;
            this.Datum_sticanja_diplome = Datum_sticanja_diplome;
        }
    }
    public class ProfesionalniUpravnikPregled : ZaposlenPregled
    {
        public string Naziv_institucije;
        public string Zvanje;
        public DateTime Datum_sticanja_diplome;

        public ProfesionalniUpravnikPregled()
        {

        }
        public ProfesionalniUpravnikPregled(long JMBG, string Licno_ime, string Ime_roditelja, string Prezime, string Br_telefona1, string Br_telefona2, string Mesto_stanovanja, string Ulica, string Broj, int Broj_licne_karte, string Mesto_izdavanja, DateTime Datum_rodjenja, string Naziv_institucije, string Zvanje, DateTime Datum_sticanja_diplome)
                : base(JMBG, Licno_ime, Ime_roditelja, Prezime, Br_telefona1, Br_telefona2, Mesto_stanovanja, Ulica, Broj_licne_karte, Mesto_izdavanja, Datum_rodjenja, Broj)
        {
            this.Naziv_institucije = Naziv_institucije;
            this.Zvanje = Zvanje;
            this.Datum_sticanja_diplome = Datum_sticanja_diplome;
        }
    }
    #endregion 

    #region Nivo
    //nap
    public class NivoBasic
    {
        public override string ToString()
        {
            return "Sprat i redni broj: "  +Sprat.ToString() +".    i     " +Redni_broj.ToString()+". " + "     Zgrada: "+Zgrada.ToString();
        }

        public int ID_nivoa;
        public int Sprat;
        public int Redni_broj;



        public ZgradaBasic Zgrada; // { get; set; }
        public NivoBasic() { }
        public NivoBasic(int id_nivoa, int sprat, int redni_broj, Zgrada z)
        {
            this.ID_nivoa = id_nivoa;
            this.Sprat = sprat;
            this.Redni_broj = redni_broj;
            Zgrada = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);       //NOVO DODATO
            
        }
    }
    public class NivoPregled
    {
        public int ID_nivoa;
        public int Sprat;
        public int Redni_broj;
        public NivoPregled() { }
        public NivoPregled(int id_nivoa, int sprat, int redni_broj)
        {
            this.ID_nivoa = id_nivoa;
            this.Sprat = sprat;
            this.Redni_broj = redni_broj;
        }
    }




    #region Stan
    //nap
    public class StanBasic : NivoBasic
    {
        public VlasnikStanaBasic Vlasnik;
        public StanBasic()
        {
            
        }

        public StanBasic(int ID_nivoa, int Sprat, int Redni_broj, Zgrada z,VlasnikStana v) : base(ID_nivoa, Sprat, Redni_broj, z)
        {
            //DODATA ZGRADA U KONSTRUKTORU
            Vlasnik=new VlasnikStanaBasic(v.JMBG,v.Licno_ime,v.Ime_roditelja,v.Prezime,v.Br_telefona1,v.Br_telefona2,v.Mesto_stanovanja,v.Ulica,v.Broj,v.Tip_u_skupstini);
        }

    }
    public class StanPregled : NivoPregled
    {
        //public VlasnikStanaBasic Vlasnik;
        public StanPregled() { }
        public StanPregled(int ID_nivoa, int Sprat, int Redni_broj) : base(ID_nivoa, Sprat, Redni_broj) { }

    }

    #endregion

    #region ParkingMesto 
    //nap
    public class ParkingMestoBasic: NivoBasic
    {
        public int Rezervisano;
        public ParkingMestoBasic()
        {

        }
        public ParkingMestoBasic(int ID_nivoa, int Sprat, int Redni_broj, Zgrada z, int Rezervisano) :base(ID_nivoa, Sprat, Redni_broj, z)
        {
            this.Rezervisano = Rezervisano;
        }
    }
    public class ParkingMestoPregled : NivoPregled
    {
        public int Rezervisano;
        public ParkingMestoPregled()
        {

        }
        public ParkingMestoPregled(int ID_nivoa, int Sprat, int Redni_broj, int Rezervisano) : base(ID_nivoa, Sprat, Redni_broj)
        {
            this.Rezervisano = Rezervisano;
        }
    }
    #endregion

    #region Lokal 
    //nap
    public class LokalBasic : NivoBasic
    {
        public string Naziv_firme;
        public LokalBasic()
        {

        }
        public LokalBasic(int ID_nivoa, int Sprat, int Redni_broj, Zgrada z, string Naziv_firme) : base(ID_nivoa, Sprat, Redni_broj, z)
        {
            this.Naziv_firme = Naziv_firme;
            Zgrada = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);
        }
    }
    public class LokalPregled : NivoPregled
    {
        public string Naziv_firme;
        public LokalPregled()
        {

        }
        public LokalPregled(int ID_nivoa, int Sprat, int Redni_broj, string Naziv_firme) : base(ID_nivoa, Sprat, Redni_broj)
        {
            this.Naziv_firme = Naziv_firme;
        }
    }
    #endregion

    #endregion

    #region Lift
    public class LiftBasic
    {
        public int Serijski_broj { get; set; }
        public string Naziv_proizvodjaca { get; set; }
        public DateTime Datum_poslednjeg_kvara { get; set; }
        public DateTime Datum_poslednjeg_servisa { get; set; }
        public ZgradaBasic Ima_lift { get; set; }
        public LiftBasic() { }
        public LiftBasic(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa, Zgrada z)
        {
            this.Serijski_broj = Serijski_broj;
            this.Naziv_proizvodjaca = Naziv_proizvodjaca;
            this.Datum_poslednjeg_kvara = Datum_poslednjeg_kvara;
            this.Datum_poslednjeg_servisa = Datum_poslednjeg_servisa;
            Ima_lift = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);

        }
    }
    public class LiftPregled
    {
        public int Serijski_broj { get; set; }
        public string Naziv_proizvodjaca { get; set; }
        public DateTime Datum_poslednjeg_kvara { get; set; }
        public DateTime Datum_poslednjeg_servisa { get; set; }
        public LiftPregled() { }
        public LiftPregled(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa)
        {
            this.Serijski_broj = Serijski_broj;
            this.Naziv_proizvodjaca = Naziv_proizvodjaca;
            this.Datum_poslednjeg_kvara = Datum_poslednjeg_kvara;
            this.Datum_poslednjeg_servisa = Datum_poslednjeg_servisa;
        }
    }
   

    #region PutnickiLift
    public class PutnickiLiftBasic : LiftBasic
    {
        public int Max_broj_osoba;
        public PutnickiLiftBasic() { }
        public PutnickiLiftBasic(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa, Zgrada z,  int Max_broj_osoba)
            : base(Serijski_broj, Naziv_proizvodjaca, Datum_poslednjeg_kvara, Datum_poslednjeg_servisa, z)
        {
            this.Max_broj_osoba = Max_broj_osoba;
        }
    }
    public class PutnickiLiftPregled : LiftPregled
    {
        public int Max_broj_osoba;
        public PutnickiLiftPregled(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa,  int Max_broj_osoba)
            : base(Serijski_broj, Naziv_proizvodjaca, Datum_poslednjeg_kvara, Datum_poslednjeg_servisa)
        {
            this.Max_broj_osoba = Max_broj_osoba;
        }
    }
    #endregion

    #region TeretniLift
    public class TeretniLiftBasic : LiftBasic
    {
        public double Nosivost;
        public TeretniLiftBasic() { }
        public TeretniLiftBasic(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa, Zgrada z,  double Nosivost)
            : base(Serijski_broj, Naziv_proizvodjaca, Datum_poslednjeg_kvara, Datum_poslednjeg_servisa, z)
        {
            this.Nosivost = Nosivost;
        }
    }
    public class TeretniLiftPregled : LiftPregled
    {
        public double Nosivost;
        public TeretniLiftPregled(int Serijski_broj, string Naziv_proizvodjaca, DateTime Datum_poslednjeg_kvara, DateTime Datum_poslednjeg_servisa, double Nosivost)
            : base(Serijski_broj, Naziv_proizvodjaca, Datum_poslednjeg_kvara, Datum_poslednjeg_servisa)
        {
            this.Nosivost = Nosivost;
        }
    }
    #endregion

    #endregion

    #region Ulaz
    public class UlazBasic
    {
        public int ID_ulaza;
        public int Redni_broj;
        public int Postojanje_kamere;
        public string Vreme_otvaranja;
        public string Vreme_zatvaranja;
        public  ZgradaBasic Zgrada { get; set; }

        public UlazBasic() { }
        public UlazBasic(int ID_ulaza, int Redni_broj, int Postojanje_kamere, string Vreme_otvaranja, string Vreme_zatvaranja, Zgrada z)
        {
            this.ID_ulaza = ID_ulaza;
            this.Redni_broj = Redni_broj;
            this.Postojanje_kamere = Postojanje_kamere;
            this.Vreme_otvaranja = Vreme_otvaranja;
            this.Vreme_zatvaranja = Vreme_zatvaranja;
            Zgrada = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);
        }
        
    }
    public class UlazPregled
    {
        public int ID_ulaza;
        public int Redni_broj;
        public int Postojanje_kamere;
        public string Vreme_otvaranja;
        public string Vreme_zatvaranja;
        

        public UlazPregled() { }
        public UlazPregled(int ID_ulaza, int Redni_broj, int Postojanje_kamere, string Vreme_otvaranja, string Vreme_zatvaranja)
        {
            this.ID_ulaza = ID_ulaza;
            this.Redni_broj = Redni_broj;
            this.Postojanje_kamere = Postojanje_kamere;
            this.Vreme_otvaranja = Vreme_otvaranja;
            this.Vreme_zatvaranja = Vreme_zatvaranja;
            
        }

    }

    #endregion

    #region ImenaStanara
    public class ImenaStanaraBasic
    {
        public int ID_stanari;

        public string Ime_stanara;
        public NivoBasic Nivo; // { get; set; }
        public ImenaStanaraBasic() { }
        public ImenaStanaraBasic(int ID_stanari, string Ime_stanara, Nivo stan)
        {
            this.ID_stanari = ID_stanari;
            this.Ime_stanara = Ime_stanara;
            this.Nivo = new NivoBasic(stan.ID_nivoa, stan.Sprat, stan.Redni_broj, stan.Zgrada);
        }
    }
    public class ImenaStanaraPregled
    {
        public int ID_stanari;

        public string Ime_stanara;
        public NivoPregled Nivo;
        public ImenaStanaraPregled() { }
        public ImenaStanaraPregled(int ID_stanari, string Ime_stanara, NivoPregled stan)
        {
            this.ID_stanari = ID_stanari;
            this.Ime_stanara = Ime_stanara;
            this.Nivo = stan;
        }
    }

    #endregion
}
