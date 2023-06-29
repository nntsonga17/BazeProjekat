using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using StambenaZgrada.Entiteti;
using System.Windows.Forms;

namespace StambenaZgrada
{
    public class DTOManager
    {
        #region Zaposlen

        public static List<ZaposlenPregled> VratiSveZaposlene()
        {
            List<ZaposlenPregled> zaposleni = new List<ZaposlenPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StambenaZgrada.Entiteti.Zaposlen> sviZaposleni = from o in s.Query<StambenaZgrada.Entiteti.Zaposlen>()
                                                                        select o;

                foreach (StambenaZgrada.Entiteti.Zaposlen z in sviZaposleni)
                {
                    zaposleni.Add(new ZaposlenPregled(z.JMBG, z.Licno_ime, z.Ime_roditelja, z.Prezime, z.Br_telefona1, z.Br_telefona2, z.Mesto_stanovanja, z.Ulica, z.Broj_licne_karte, z.Mesto_izdavanja, z.Datum_rodjenja, z.Broj));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return zaposleni;
        }
        public static void ObrisiZaposlenog(long JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposlen zaposleni = s.Load<Zaposlen>(JMBG);

                s.Delete(zaposleni);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        public static ZaposlenBasic VratiZaposlenog(long JMBG)
        {
            ZaposlenBasic z = new ZaposlenBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposlen zaposleni = s.Load<Zaposlen>(JMBG);

                z = new ZaposlenBasic(zaposleni.JMBG, zaposleni.Licno_ime, zaposleni.Ime_roditelja, zaposleni.Prezime, zaposleni.Br_telefona1, zaposleni.Br_telefona2,
                                    zaposleni.Mesto_stanovanja, zaposleni.Ulica, zaposleni.Broj_licne_karte, zaposleni.Mesto_izdavanja, zaposleni.Datum_rodjenja, zaposleni.Broj);
                    
                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return z;

        }
        public static ZaposlenBasic IzmeniZaposlenog(ZaposlenBasic zaposleni)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Zaposlen z = s.Load<Zaposlen>(zaposleni.JMBG);


                z.Licno_ime = zaposleni.Licno_ime;
                z.Ime_roditelja = zaposleni.Ime_roditelja;
                z.Prezime = zaposleni.Prezime;
                z.Br_telefona1 = zaposleni.Br_telefona1;
                z.Br_telefona2 = zaposleni.Br_telefona2;
                z.Mesto_stanovanja = zaposleni.Mesto_stanovanja;
                z.Ulica = zaposleni.Ulica;
                z.Broj = zaposleni.Broj;
                z.Broj_licne_karte = zaposleni.Broj_licne_karte;
                z.Mesto_izdavanja = zaposleni.Mesto_izdavanja;
                s.Update(z);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return zaposleni;
        }
        public static void DodajZaposlenog(ZaposlenBasic z)
        {
                try
                {
                    ISession s = DataLayer.GetSession();

                    StambenaZgrada.Entiteti.Zaposlen zp = new StambenaZgrada.Entiteti.Zaposlen();

                    zp.JMBG = z.JMBG;
                    zp.Licno_ime = z.Licno_ime;
                    zp.Ime_roditelja = z.Ime_roditelja;
                    zp.Prezime = z.Prezime;
                    zp.Br_telefona1 = z.Br_telefona1;
                    zp.Br_telefona2 = z.Br_telefona2;
                    zp.Mesto_stanovanja = z.Mesto_stanovanja;
                    zp.Ulica = z.Ulica;
                    zp.Broj = z.Broj;
                    zp.Broj_licne_karte = z.Broj_licne_karte;
                    zp.Mesto_izdavanja = z.Mesto_izdavanja;

                    s.SaveOrUpdate(zp);

                    s.Flush();

                    s.Close();
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.Message);
                }
            
        }


        #endregion

        #region ProfesionalniUpravnik

        public static List<ProfesionalniUpravnikBasic> VratiSveUpravnike()
        {
            List<ProfesionalniUpravnikBasic> zaposleni = new List<ProfesionalniUpravnikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StambenaZgrada.Entiteti.ProfesionalniUpravnik> sviZaposleni = from o in s.Query<StambenaZgrada.Entiteti.ProfesionalniUpravnik>()
                                                                             select o;

                foreach (StambenaZgrada.Entiteti.ProfesionalniUpravnik z in sviZaposleni)
                {
                    zaposleni.Add(new ProfesionalniUpravnikBasic(z.JMBG, z.Licno_ime, z.Ime_roditelja, z.Prezime, z.Br_telefona1,z.Br_telefona2, z.Mesto_stanovanja, z.Ulica, z.Broj, z.Broj_licne_karte, z.Mesto_izdavanja, z.Datum_rodjenja, z.Naziv_institucije,z.Zvanje, z.Datum_sticanja_diplome));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return zaposleni;
        }
        public static void ObrisiUpravnika(long JMBG)
        {
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        ProfesionalniUpravnik upravnik= s.Load<ProfesionalniUpravnik>(JMBG);

                        s.Delete(upravnik);
                        s.Flush();
                        s.Close();

                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
        }
                public static ProfesionalniUpravnikBasic VratiUpravnika(long JMBG)
                {
                    ProfesionalniUpravnikBasic pu = new ProfesionalniUpravnikBasic();
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        ProfesionalniUpravnik up= s.Load<ProfesionalniUpravnik>(JMBG);

                        pu = new ProfesionalniUpravnikBasic(up.JMBG, up.Licno_ime, up.Ime_roditelja, up.Prezime, up.Br_telefona1,
                                               up.Br_telefona2, up.Mesto_stanovanja, up.Ulica, up.Broj, up.Broj_licne_karte, up.Mesto_izdavanja,up.Datum_rodjenja,
                                               up.Naziv_institucije,up.Zvanje,up.Datum_sticanja_diplome);

                        s.Close();

                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);

                    }

                    return pu;

                }
                public static ProfesionalniUpravnikBasic IzmeniUpravnika(ProfesionalniUpravnikBasic upravnik)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        StambenaZgrada.Entiteti.ProfesionalniUpravnik pu= s.Load<ProfesionalniUpravnik>(upravnik.JMBG);


                        pu.Licno_ime = upravnik.Licno_ime;
                        pu.Ime_roditelja = upravnik.Ime_roditelja;
                        pu.Prezime = upravnik.Prezime;
                        pu.Br_telefona1 = upravnik.Br_telefona1;
                        pu.Br_telefona2 = upravnik.Br_telefona2;
                        pu.Mesto_stanovanja = upravnik.Mesto_stanovanja;
                        pu.Ulica = upravnik.Ulica;
                        pu.Broj = upravnik.Broj;
                        pu.Broj_licne_karte = upravnik.Broj_licne_karte;
                        pu.Mesto_izdavanja = upravnik.Mesto_izdavanja;
                        pu.Datum_rodjenja = upravnik.Datum_rodjenja;
                        pu.Naziv_institucije = upravnik.Naziv_institucije;
                        pu.Datum_sticanja_diplome = upravnik.Datum_sticanja_diplome;
                        pu.Zvanje = upravnik.Zvanje;



                        s.Update(pu);

                        s.Flush();

                        s.Close();
                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
                    return upravnik;
                }
                public static void DodajUpravnika(ProfesionalniUpravnikBasic p)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        StambenaZgrada.Entiteti.ProfesionalniUpravnik pu = new StambenaZgrada.Entiteti.ProfesionalniUpravnik();

                         pu.JMBG = p.JMBG;
                        pu.Licno_ime = p.Licno_ime;
                        pu.Ime_roditelja = p.Ime_roditelja;
                        pu.Prezime = p.Prezime;
                        pu.Br_telefona1 = p.Br_telefona1;
                        pu.Br_telefona2 = p.Br_telefona2;
                        pu.Mesto_stanovanja = p.Mesto_stanovanja;
                        pu.Ulica = p.Ulica;
                        pu.Broj = p.Broj;
                        pu.Broj_licne_karte = p.Broj_licne_karte;
                        pu.Mesto_izdavanja = p.Mesto_izdavanja;
                        pu.Datum_rodjenja = p.Datum_rodjenja;
                        pu.Naziv_institucije = p.Naziv_institucije;
                        pu.Datum_sticanja_diplome = p.Datum_sticanja_diplome;
                        pu.Zvanje = p.Zvanje;

                        s.SaveOrUpdate(pu);

                        s.Flush();

                        s.Close();
                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
                }


        #endregion

        #region VlasnikStana

      /*  public static List<VlasnikStanaBasic> VratiSveVlasnikeNekeZgrade(int idZgrada) 
        {
            List<VlasnikStanaBasic> zaposleni = new List<VlasnikStanaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                 IEnumerable<StambenaZgrada.Entiteti.Stan> stanovi = from m in s.Query<StambenaZgrada.Entiteti.Stan>()
                                                                     where m.Zgrada.ID_zgrade == idZgrada
                                                                     select m;       //stanovi koji pripadaju prosleđenoj zgradi

                 s.Close();
             }
             catch (Exception ec)
             {
                 Console.WriteLine(ec.Message);
             }

             return zaposleni;

            }

       
        }*/

        public static List<VlasnikStanaBasic> VratiSveVlasnike()
        {
            List<VlasnikStanaBasic> lsp = new List<VlasnikStanaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<VlasnikStana> stanovi = from st in s.Query<VlasnikStana>()
                                            select st;

                foreach (VlasnikStana st in stanovi)
                {
                    lsp.Add(new VlasnikStanaBasic(st.JMBG,st.Licno_ime,st.Ime_roditelja,st.Prezime,st.Br_telefona1,st.Br_telefona2,st.Mesto_stanovanja,st.Ulica,st.Broj,st.Tip_u_skupstini));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return lsp;
        }
        public static void ObrisiVlasnika(long JMBG)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.VlasnikStana vlasnik = s.Load<StambenaZgrada.Entiteti.VlasnikStana>(JMBG);

                s.Delete(vlasnik);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static VlasnikStanaBasic VratiVlasnika(long JMBG)
        {
            VlasnikStanaBasic vs = new VlasnikStanaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                VlasnikStana v = s.Load<VlasnikStana>(JMBG);

                vs = new VlasnikStanaBasic(v.JMBG, v.Licno_ime, v.Ime_roditelja, v.Prezime, v.Br_telefona1,
                    v.Br_telefona2, v.Mesto_stanovanja, v.Ulica, v.Broj, v.Tip_u_skupstini);
                


                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return vs;

        }
        public static VlasnikStanaBasic IzmeniVlasnika(VlasnikStanaBasic vlasnik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.VlasnikStana vs = s.Load<VlasnikStana>(vlasnik.JMBG);


                vs.Licno_ime = vlasnik.Licno_ime;
                vs.Ime_roditelja = vlasnik.Ime_roditelja;
                vs.Prezime = vlasnik.Prezime;
                vs.Br_telefona1 = vlasnik.Br_telefona1;
                vs.Mesto_stanovanja = vlasnik.Mesto_stanovanja;
                vs.Ulica = vlasnik.Ulica;
                vs.Broj = vlasnik.Broj;
                vs.Tip_u_skupstini = vlasnik.Tip_u_skupstini;



                s.SaveOrUpdate(vs);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return vlasnik;
        }
        public static void DodajVlasnika(VlasnikStanaBasic v)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.VlasnikStana vs = new StambenaZgrada.Entiteti.VlasnikStana();

                vs.JMBG = v.JMBG;
                vs.Licno_ime = v.Licno_ime;
                vs.Ime_roditelja = v.Ime_roditelja;
                vs.Prezime = v.Prezime;
                vs.Br_telefona1 = v.Br_telefona1;
                vs.Br_telefona2 = v.Br_telefona2;
                vs.Mesto_stanovanja = v.Mesto_stanovanja;
                vs.Ulica = v.Ulica;
                vs.Broj = v.Broj;
                vs.Tip_u_skupstini = v.Tip_u_skupstini;

                s.SaveOrUpdate(vs);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }


        #endregion

        #region Zgrada

        public static List<ZgradaBasic> VratiSveZgrade()
        {
            List<ZgradaBasic> zgrade = new List<ZgradaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StambenaZgrada.Entiteti.Zgrada> sveZgrade = from o in s.Query<StambenaZgrada.Entiteti.Zgrada>()
                                                                        select o;

                foreach (StambenaZgrada.Entiteti.Zgrada z in sveZgrade)
                {
                    zgrade.Add(new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return zgrade;
        }
        public static void DodajZgradu(ZgradaBasic zg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Zgrada z = new StambenaZgrada.Entiteti.Zgrada();

                StambenaZgrada.Entiteti.ProfesionalniUpravnik upravnik = s.Load<ProfesionalniUpravnik>(zg.Upravnik.JMBG);

                z.Mesto = zg.Mesto;
                z.Ulica = zg.Ulica;
                z.Broj = zg.Broj;
                z.Godina_izgradnje = zg.Godina_izgradnje;
                z.Broj_jedinica = zg.Broj_jedinica;
                z.Upravnik = upravnik;


                s.SaveOrUpdate(z);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        public static ZgradaBasic AzurirajZgradu(ZgradaBasic zg)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Zgrada z = s.Load<StambenaZgrada.Entiteti.Zgrada>(zg.ID_zgrade);
                z.Mesto = zg.Mesto;
                z.Ulica = zg.Ulica;
                z.Broj = zg.Broj;
                z.Godina_izgradnje = zg.Godina_izgradnje;
                z.Broj_jedinica = zg.Broj_jedinica;
                

                s.Update(z);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return zg;
        }
        public static ZgradaBasic VratiZgradu(int ID_zgrade)
        {
            ZgradaBasic zb = new ZgradaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Zgrada z = s.Load<StambenaZgrada.Entiteti.Zgrada>(ID_zgrade);
                zb = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Godina_izgradnje, z.Broj_jedinica);

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return zb;
        }

        public static void ObrisiZgradu(int ID_zgrade)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Zgrada z = s.Load<StambenaZgrada.Entiteti.Zgrada>(ID_zgrade);

                s.Delete(z);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        
        public static List<ZgradaPregled> VratiZgradeNekogUpravnika(long UpravnikJMBG)
        {
            List<ZgradaPregled> zb = new List<ZgradaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zgrada> zgrade = from z in s.Query<Zgrada>()
                                             where z.Upravnik.JMBG == UpravnikJMBG
                                             select z;

                foreach (Zgrada z in zgrade)
                {
                    zb.Add(new ZgradaPregled(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Godina_izgradnje, z.Broj_jedinica));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return zb;
        }
        #endregion

        

        #region Ugovor

        public static void SacuvajUgovor(UgovorBasic ub)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor u = new Ugovor();

                u.Datum_potpisivanja = ub.Datum_potpisivanja;
                u.Vazenje_ugovora = ub.Vazenje_ugovora;
               
                Zgrada z = s.Load<Zgrada>(ub.Zgrada.ID_zgrade);
                u.Zgrada = z;


                s.Save(u);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }

        public static void ObrisiUgovor(int Sifra)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor ugovor= s.Load<Ugovor>(Sifra);

                s.Delete(ugovor);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static UgovorPregled VratiUgovor(int zgrada)
        {
            UgovorPregled ub = new UgovorPregled();
            try
            {
                ISession s = DataLayer.GetSession();

                Zgrada zgr = s.Load<Zgrada>(zgrada);

                //int Sifra = zgr.Ugovor.Sifra;

                // ugovor = s.Load<Ugovor>(Sifra);
                if(zgr.Ugovor != null)
                    ub = new UgovorPregled(zgr.Ugovor.Sifra, zgr.Ugovor.Datum_potpisivanja, zgr.Ugovor.Vazenje_ugovora);
                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return ub;

        }

        public static UgovorBasic VratiUgovorBasic(int zgrada)
        {
            UgovorBasic ub = new UgovorBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Zgrada zgr = s.Load<Zgrada>(zgrada);

                int Sifra = zgr.Ugovor.Sifra;

                Ugovor ugovor = s.Load<Ugovor>(Sifra);

                ub = new UgovorBasic(ugovor.Sifra, ugovor.Datum_potpisivanja, ugovor.Vazenje_ugovora,ugovor.Zgrada);
                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return ub;

        }


        public static void IzmeniUgovor(UgovorBasic ugovor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Ugovor u = s.Load<Ugovor>(ugovor.Sifra);


                u.Datum_potpisivanja = ugovor.Datum_potpisivanja;
                u.Vazenje_ugovora = ugovor.Vazenje_ugovora;
                



                s.Update(u);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        #endregion

        #region Licenca

        public static List<LicencaPregled> VratiLicenceUpravnika(long UpravnikJMBG)
        {
            List<LicencaPregled> zb = new List<LicencaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Licenca> zgrade = from z in s.Query<Licenca>()
                                             where z.Upravnik.JMBG == UpravnikJMBG
                                             select z;

                foreach (Licenca z in zgrade)
                {
                    zb.Add(new LicencaPregled(z.ID_licence,z.Broj_licence,z.Datum_sticanja_obnavljanja,z.Naziv_insitucije));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return zb;
        }
        public static void SacuvajLicencu(LicencaBasic ub)
        {
            try
            {
                
                ISession s = DataLayer.GetSession();
                StambenaZgrada.Entiteti.Licenca l = new StambenaZgrada.Entiteti.Licenca();


                l.Datum_sticanja_obnavljanja= ub.Datum_sticanja_obnavljanja;
                l.Broj_licence = ub.Broj_licence;
                l.Naziv_insitucije = ub.Naziv_insitucije;

                ProfesionalniUpravnik up = s.Load<ProfesionalniUpravnik>(ub.Upravnik.JMBG);

                l.Upravnik = up;
                

                


                s.Save(l);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }
        public static void ObrisiLicencu(int ID_licence)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        Licenca licenca= s.Load<Licenca>(ID_licence);

                        s.Delete(licenca);
                        s.Flush();

                        s.Close();
                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
                }
                public static LicencaBasic VratiLicencu(int ID_licence)
                {
                    LicencaBasic lb = new LicencaBasic();
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        Licenca licenca = s.Load<Licenca>(ID_licence);
                        lb = new LicencaBasic(licenca.ID_licence, licenca.Broj_licence, licenca.Datum_sticanja_obnavljanja, licenca.Naziv_insitucije, licenca.Upravnik);
                       
                        s.Close();
                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
                    return lb;
                }
                public static void IzmeniLicencu(LicencaBasic licenca)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();

                        StambenaZgrada.Entiteti.Licenca l = s.Load<Licenca>(licenca.ID_licence);


                        l.Broj_licence = licenca.Broj_licence;
                        l.Datum_sticanja_obnavljanja = licenca.Datum_sticanja_obnavljanja;
                        l.Naziv_insitucije = licenca.Naziv_insitucije;

                        s.Update(l);

                        s.Flush();

                        s.Close();
                    }
                    catch (Exception ec)
                    {
                        Console.WriteLine(ec.Message);
                    }
                }

        public static List<LicencaBasic> VratiSveLicence()
        {
            List<LicencaBasic> zaposleni = new List<LicencaBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StambenaZgrada.Entiteti.Licenca> sviZaposleni = from o in s.Query<StambenaZgrada.Entiteti.Licenca>()
                                                                                          select o;

                foreach (StambenaZgrada.Entiteti.Licenca z in sviZaposleni)
                {
                    zaposleni.Add(new LicencaBasic(z.ID_licence,z.Broj_licence,z.Datum_sticanja_obnavljanja,z.Naziv_insitucije, z.Upravnik));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return zaposleni;
        }

            #endregion

        #region Ulaz

            public static void SacuvajUlaz(UlazBasic u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ulaz o = new Ulaz();

                o.Redni_broj = u.Redni_broj;
                o.Postojanje_kamere= u.Postojanje_kamere;
                o.Vreme_otvaranja = u.Vreme_otvaranja;
                o.Vreme_zatvaranja = u.Vreme_zatvaranja;

                Zgrada z = s.Load<Zgrada>(u.Zgrada.ID_zgrade);
                o.Zgrada = z;


                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }
        public static void ObrisiUlaz(int ID_ulaza)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ulaz ulaz = s.Load<Ulaz>(ID_ulaza);

                s.Delete(ulaz);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static UlazBasic VratiUlaz(int ID_ulaza)
        {
            UlazBasic u = new UlazBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Ulaz ulaz = s.Load<Ulaz>(ID_ulaza);

                u = new UlazBasic(ulaz.ID_ulaza, ulaz.Redni_broj, ulaz.Postojanje_kamere, ulaz.Vreme_otvaranja, ulaz.Vreme_zatvaranja, ulaz.Zgrada);

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return u;

        }
        public static void IzmeniUlaz(UlazBasic ulaz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Ulaz u = s.Load<Ulaz>(ulaz.ID_ulaza);


                u.Redni_broj = ulaz.Redni_broj;
                u.Postojanje_kamere = ulaz.Postojanje_kamere;
                u.Vreme_zatvaranja = ulaz.Vreme_zatvaranja;
                u.Vreme_otvaranja = ulaz.Vreme_otvaranja;



                s.Update(u);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        public static List<UlazPregled> VratiUlazeNekeZgrade(int ZgradaID)
        {
            List<UlazPregled> ub = new List<UlazPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ulaz> ulazi = from u in s.Query<Ulaz>()
                                          where u.Zgrada.ID_zgrade == ZgradaID
                                          select u;

                foreach (Ulaz u in ulazi)
                {
                    ub.Add(new UlazPregled(u.ID_ulaza, u.Redni_broj, u.Postojanje_kamere, u.Vreme_otvaranja, u.Vreme_zatvaranja));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return ub;
        }
        #endregion

        #region Lift

        #region PutnickiLift
        public static void ObrisiPutnickiLift(int serijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PutnickiLift plift = s.Load<PutnickiLift>(serijskiBroj);

                s.Delete(plift);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static PutnickiLiftBasic VratiPutnickiLift(int serBroj)
        {
            PutnickiLiftBasic o = new PutnickiLiftBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                PutnickiLift plift = s.Load<PutnickiLift>(serBroj);

                o.Serijski_broj = plift.Serijski_broj;
                o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
                o.Max_broj_osoba = plift.Max_broj_osoba;

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return o;

        }

        public static void IzmeniPutnickiLift(PutnickiLiftBasic plift)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PutnickiLift o = s.Load<PutnickiLift>(plift.Serijski_broj);

                o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
                o.Max_broj_osoba = plift.Max_broj_osoba;



                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static void SacuvajPutnickiLift(PutnickiLiftBasic plift)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PutnickiLift o = new PutnickiLift();

                o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara= plift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa =plift.Datum_poslednjeg_servisa;
                o.Max_broj_osoba = plift.Max_broj_osoba;
                Zgrada z= s.Load<Zgrada>(plift.Ima_lift.ID_zgrade);
                o.Ima_lift = z;


                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }

        public static List<PutnickiLiftPregled> VratiPutnickeLiftoveZgrade(int IDzgrade)
        {
            List<PutnickiLiftPregled> lp= new List<PutnickiLiftPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<PutnickiLift> liftovi = from o in s.Query<PutnickiLift>()
                                                      where o.Ima_lift.ID_zgrade== IDzgrade
                                                      select o;

                foreach (PutnickiLift o in liftovi)
                {
                    lp.Add(new PutnickiLiftPregled(o.Serijski_broj, o.Naziv_proizvodjaca, o.Datum_poslednjeg_kvara, o.Datum_poslednjeg_servisa, o.Max_broj_osoba));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return lp;
        }

        #endregion


        #region TeretniLift

        public static void ObrisiTeretniLift(int serijskiBroj)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TeretniLift tlift = s.Load<TeretniLift>(serijskiBroj);

                s.Delete(tlift);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static TeretniLiftBasic VratiTeretniLift(int serBroj)
        {
            TeretniLiftBasic o = new TeretniLiftBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                TeretniLift tlift = s.Load<TeretniLift>(serBroj);

                o.Serijski_broj = tlift.Serijski_broj;
                o.Naziv_proizvodjaca = tlift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara = tlift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa = tlift.Datum_poslednjeg_servisa;
                o.Nosivost = tlift.Nosivost;

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return o;

        }

        public static void IzmeniTeretniLift(TeretniLiftBasic tlift)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TeretniLift o = s.Load<TeretniLift>(tlift.Serijski_broj);

                o.Naziv_proizvodjaca = tlift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara = tlift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa = tlift.Datum_poslednjeg_servisa;
                o.Nosivost = tlift.Nosivost;



                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static void SacuvajTeretniLift(TeretniLiftBasic tlift)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TeretniLift o = new TeretniLift();

                o.Naziv_proizvodjaca = tlift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara = tlift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa = tlift.Datum_poslednjeg_servisa;
                o.Nosivost = tlift.Nosivost;
                Zgrada z = s.Load<Zgrada>(tlift.Ima_lift.ID_zgrade);
                o.Ima_lift = z;


                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }

        public static List<TeretniLiftPregled> VratiTeretneLiftoveZgrade(int IDzgrade)
        {
            List<TeretniLiftPregled> tp = new List<TeretniLiftPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<TeretniLift> liftovi = from o in s.Query<TeretniLift>()
                                                    where o.Ima_lift.ID_zgrade == IDzgrade
                                                    select o;

                foreach (TeretniLift o in liftovi)
                {
                    tp.Add(new TeretniLiftPregled(o.Serijski_broj, o.Naziv_proizvodjaca,  o.Datum_poslednjeg_kvara, o.Datum_poslednjeg_servisa, o.Nosivost));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return tp;
        }

        #endregion

        #endregion

        #region Nivo
        public static List<NivoPregled> VratiSveNivoe()
        {
            List<NivoPregled> nivoi = new List<NivoPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<StambenaZgrada.Entiteti.Nivo> sviNivoi = from n in s.Query<StambenaZgrada.Entiteti.Nivo>()
                                                                         select n;

                foreach (StambenaZgrada.Entiteti.Nivo n in sviNivoi)
                {
                    nivoi.Add(new NivoPregled(n.ID_nivoa, n.Sprat, n.Redni_broj));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return nivoi;
        }
        public static void ObrisiNivo(int ID_nivoa)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Nivo n = s.Load<StambenaZgrada.Entiteti.Nivo>(ID_nivoa);

                s.Delete(n);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }
        }
        public static NivoBasic VratiNivo(int ID_nivoa)
        {
            NivoBasic nb = new NivoBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Nivo n = s.Load<StambenaZgrada.Entiteti.Nivo>(ID_nivoa);
                nb = new NivoBasic(n.ID_nivoa, n.Sprat, n.Redni_broj, n.Zgrada);

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return nb;
        }
        public static void SacuvajLokal(LokalBasic lokal)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Lokal l = new StambenaZgrada.Entiteti.Lokal();

                l.ID_nivoa = lokal.ID_nivoa;
                l.Sprat = lokal.Sprat;
                l.Redni_broj = lokal.Redni_broj;
                l.Naziv_firme = lokal.Naziv_firme;

                Zgrada z = s.Load<Zgrada>(lokal.Zgrada.ID_zgrade);
                l.Zgrada = z;

                s.Save(l);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        public static void SacuvajStan(StanBasic stan)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Stan st = new StambenaZgrada.Entiteti.Stan();

                st.ID_nivoa = stan.ID_nivoa;
                st.Sprat = stan.Sprat;
                st.Redni_broj = stan.Redni_broj;

                Zgrada z = s.Load<Zgrada>(stan.Zgrada.ID_zgrade);
                st.Zgrada = z;
                VlasnikStana v = s.Load<VlasnikStana>(stan.Vlasnik.JMBG);
                st.Vlasnik = v;

                s.Save(st);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
        public static void SacuvajParkingMesto(ParkingMestoBasic parkingmesto)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.ParkingMesto pm = new StambenaZgrada.Entiteti.ParkingMesto();

                pm.ID_nivoa = parkingmesto.ID_nivoa;
                pm.Sprat = parkingmesto.Sprat;
                pm.Redni_broj = parkingmesto.Redni_broj;
                pm.Rezervisano = parkingmesto.Rezervisano;

                Zgrada z = s.Load<Zgrada>(parkingmesto.Zgrada.ID_zgrade);
                pm.Zgrada = z;

                s.Save(pm);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }

        public static LokalBasic VratiLokal(int ID_nivoa)
        {
            LokalBasic lb = new LokalBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Lokal l = s.Load<StambenaZgrada.Entiteti.Lokal>(ID_nivoa);
                lb = new LokalBasic(l.ID_nivoa, l.Redni_broj , l.Sprat, l.Zgrada, l.Naziv_firme) ;

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return lb;
        }
        public static StanBasic VratiStan(int ID_nivoa)
        {
            StanBasic sb = new StanBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Stan st = s.Load<StambenaZgrada.Entiteti.Stan>(ID_nivoa);
                sb = new StanBasic(st.ID_nivoa, st.Redni_broj, st.Sprat, st.Zgrada,st.Vlasnik);

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return sb;
        }
        public static ParkingMestoBasic VratiPMesto(int ID_nivoa)
        {
            ParkingMestoBasic pb = new ParkingMestoBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.ParkingMesto pm = s.Load<StambenaZgrada.Entiteti.ParkingMesto>(ID_nivoa);
                pb = new ParkingMestoBasic(pm.ID_nivoa, pm.Redni_broj, pm.Sprat, pm.Zgrada, pm.Rezervisano);

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return pb;
        }
        public static LokalBasic AzurirajLokal(LokalBasic l)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Lokal lk = s.Load<StambenaZgrada.Entiteti.Lokal>(l.ID_nivoa);

                lk.Sprat = l.Sprat;
                lk.Redni_broj = l.Redni_broj;
                lk.Naziv_firme = l.Naziv_firme;
                

                s.Update(lk);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return l;
        }
        public static StanBasic AzurirajStan(StanBasic st)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.Stan stn = s.Load<StambenaZgrada.Entiteti.Stan>(st.ID_nivoa);

                stn.Sprat = st.Sprat;
                stn.Redni_broj =st.Redni_broj;
                


                s.Update(stn);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return st;
        }
        public static ParkingMestoBasic AzurirajParkingMesto(ParkingMestoBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.ParkingMesto pm= s.Load<StambenaZgrada.Entiteti.ParkingMesto>(p.ID_nivoa);

                pm.Sprat = p.Sprat;
                pm.Redni_broj = p.Redni_broj;
                pm.Rezervisano = p.Rezervisano;


                s.Update(pm);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return p;
        }

        public static List<StanPregled> VratiStanoveZgrade(int IDzgrade)
        {
            List<StanPregled> lsp = new List<StanPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                            where st.Zgrada.ID_zgrade == IDzgrade
                                            select st;

                foreach (Stan st in stanovi)
                {
                    lsp.Add(new StanPregled(st.ID_nivoa, st.Redni_broj, st.Sprat));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
              return lsp;
        }

        public static List<StanBasic> VratiStanoveVlasnika(long IDvlasnika)
        {
            List<StanBasic> lsp = new List<StanBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                            where st.Vlasnik.JMBG == IDvlasnika
                                            select st;

                foreach (Stan st in stanovi)
                {
                    lsp.Add(new StanBasic(st.ID_nivoa, st.Redni_broj, st.Sprat, st.Zgrada,st.Vlasnik));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return lsp;
        }

        public static List<LokalPregled> VratiLokaleZgrade(int IDzgrade)
        {
            List<LokalPregled> lsp = new List<LokalPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Lokal> stanovi = from st in s.Query<Lokal>()
                                            where st.Zgrada.ID_zgrade == IDzgrade
                                            select st;

                foreach (Lokal st in stanovi)
                {
                    lsp.Add(new LokalPregled(st.ID_nivoa, st.Sprat,st.Redni_broj,st.Naziv_firme));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return lsp;
        }

        public static List<ParkingMestoPregled> VratiPMestaZgrade(int IDzgrade)
        {
            List<ParkingMestoPregled> lsp = new List<ParkingMestoPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ParkingMesto> stanovi = from st in s.Query<ParkingMesto>()
                                             where st.Zgrada.ID_zgrade == IDzgrade
                                             select st;

                foreach (ParkingMesto st in stanovi)
                {
                    lsp.Add(new ParkingMestoPregled(st.ID_nivoa, st.Sprat, st.Redni_broj, st.Rezervisano));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return lsp;
        }

        public static List<StanBasic> VratiStanoveVlasnika(int VlasnikJMBG)
        {
            List<StanBasic> lsp = new List<StanBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                                      where st.Vlasnik.JMBG == VlasnikJMBG
                                                      select st;

                foreach (Stan st in stanovi)
                {
                    lsp.Add(new StanBasic(st.ID_nivoa, st.Redni_broj, st.Sprat, st.Zgrada,st.Vlasnik));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                  Console.WriteLine(ec.Message);           
            }

            return lsp;
        }
        #endregion

        #region ImenaStanara

        public static void AzurirajImeStanara(int idStanara, string ime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.ImenaStanara stn = s.Load<StambenaZgrada.Entiteti.ImenaStanara>(idStanara);

                stn.Ime_stanara = ime;


                s.Update(stn);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }

            return;
        }

        public static ImenaStanaraBasic VratiStanara(int idS)
        {
            ImenaStanaraBasic z = new ImenaStanaraBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                ImenaStanara zaposleni = s.Load<ImenaStanara>(idS);

                z = new ImenaStanaraBasic(zaposleni.ID_stanari,zaposleni.Ime_stanara,zaposleni.Nivo);

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);

            }

            return z;

        }

        public static void SacuvajImeStanara(ImenaStanaraBasic isb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ImenaStanara ims = new ImenaStanara();

                ims.Ime_stanara = isb.Ime_stanara;

                Nivo n = s.Load<Nivo>(isb.Nivo.ID_nivoa);
                ims.Nivo = n;

                s.Save(ims);
                s.Flush();
                s.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ObrisiStanara(int ID_stanar)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ImenaStanara stanar = s.Load<ImenaStanara>(ID_stanar);

                s.Delete(stanar);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }


        public static List<ImenaStanaraBasic> VratiStanareZgradeiStana(int ID_nivo)
        {
            List<ImenaStanaraBasic> listaStanara = new List<ImenaStanaraBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ImenaStanara> stanari = from o in s.Query<ImenaStanara>()
                                                    //where o.Nivo.Zgrada.ID_zgrade == ID_zgrada
                                                    where o.Nivo.ID_nivoa == ID_nivo
                                                    select o;
                NivoBasic nb = VratiNivo(ID_nivo);

                foreach(ImenaStanara ism in stanari)
                {
                    listaStanara.Add(new ImenaStanaraBasic(ism.ID_stanari, ism.Ime_stanara, ism.Nivo));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
            return listaStanara;

        }
       /* public static void IzmeniStanare(ImenaStanaraBasic stanari)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StambenaZgrada.Entiteti.ImenaStanara ims = s.Load<ImenaStanara>(stanari.ID_stanari);


                ims.Ime_stanara = stanari.Ime_stanara;
                
               
                s.Update(ims);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }*/
        #endregion

    }
}
