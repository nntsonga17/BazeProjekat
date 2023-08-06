using NHibernate;
using NHibernate.Event.Default;
using StambenaZgradaLibrary;
using StambenaZgradaLibrary.DTOs;
using System.Collections.Immutable;
using System.Web;

namespace StambenaZgradaLibrary;

public static class DataProvider
{
    #region Zaposlen

    public static async Task<Result<List<ZaposlenView>, string>> VratiSveZaposleneAsync()
    {
        ISession? s = null;

        List<ZaposlenView> zaposleni = new();


        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Zaposlen> sviZaposleni = from o in s.Query<Zaposlen>()
                                                 select o;

            foreach (Zaposlen z in sviZaposleni)
            {
                zaposleni.Add(new ZaposlenView(z));
            }

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve zaposlene.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return zaposleni;
    }
    public static Result<bool, string> ObrisiZaposlenog(long JMBG)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Zaposlen zaposleni = s.Load<Zaposlen>(JMBG);

            s.Delete(zaposleni);
            s.Flush();

            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati zaposlenog.";
        }

        return true;
    }
    public async static Task<Result<ZaposlenView, string>> VratiZaposlenogAsync(long JMBG)
    {
        ISession? s = null;

        ZaposlenView z = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Zaposlen zaposleni = await s.LoadAsync<Zaposlen>(JMBG);

            z = new ZaposlenView(zaposleni);


        }
        catch (Exception)
        {
            return "Nemoguće vratiti zaposlenog.";
        }

        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return z;

    }
    public async static Task<Result<ZaposlenView, string>> IzmeniZaposlenogAsync(ZaposlenView zaposleni)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Zaposlen z = s.Load<Zaposlen>(zaposleni.JMBG);


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

            await s.UpdateAsync(z);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti zaposlenog.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zaposleni;
    }
    public async static Task<Result<bool, string>> DodajZaposlenogAsync(ZaposlenView z)
    {

        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Zaposlen zp = new StambenaZgradaLibrary.Entiteti.Zaposlen();

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

            await s.SaveOrUpdateAsync(zp);

            await s.FlushAsync();

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće dodati zaposlenog.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }


    #endregion

    #region ProfesionalniUpravnik

    public async static Task<Result<List<ProfesionalniUpravnikView>, string>> VratiSveUpravnikeAsync()
    {

        ISession? s = null;

        List<ProfesionalniUpravnikView> zaposleni = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik> sviZaposleni = from o in await s.QueryOver<StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik>().ListAsync()
                                                                                             select o;

            foreach (StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik z in sviZaposleni)
            {
                zaposleni.Add(new ProfesionalniUpravnikView(z));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve profesionalne upravnike.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zaposleni;
    }
    public static Result<bool, string> ObrisiUpravnika(long JMBG)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ProfesionalniUpravnik upravnik = s.Load<ProfesionalniUpravnik>(JMBG);

            s.Delete(upravnik);
            s.Flush();
            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati upravnika.";
        }

        return true;
    }
    public async static Task<Result<ProfesionalniUpravnikView, string>> VratiUpravnikaAsync(long JMBG)
    {

        ISession? s = null;

        ProfesionalniUpravnikView pu = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ProfesionalniUpravnik up = await s.LoadAsync<ProfesionalniUpravnik>(JMBG);

            pu = new ProfesionalniUpravnikView(up);


        }
        catch (Exception)
        {
            return "Nemoguće vratiti upravnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return pu;

    }
    public async static Task<Result<ProfesionalniUpravnikView, string>> IzmeniUpravnikaAsync(ProfesionalniUpravnikView upravnik)
    {

        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik pu = s.Load<ProfesionalniUpravnik>(upravnik.JMBG);


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



            await s.UpdateAsync(pu);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti upravnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return upravnik;
    }
    public async static Task<Result<bool, string>> DodajUpravnikaAsync(ProfesionalniUpravnikView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }


            StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik pu = new StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik();

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

            if (p.Upravlja.Count() != null)
            {
               Zgrada zg = s.Load<Zgrada>(p.Upravlja);
;              zg.Upravnik = pu;
            }

            await s.SaveOrUpdateAsync(pu);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati upravnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }


    #endregion

    #region Zgrada

    public async static Task<Result<List<ZgradaView>, string>> VratiSveZgradeAsync()
    {
        ISession? s = null;

        List<ZgradaView> zgrade = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<StambenaZgradaLibrary.Entiteti.Zgrada> sveZgrade = from o in await s.QueryOver<StambenaZgradaLibrary.Entiteti.Zgrada>().ListAsync()
                                                                           select o;

            foreach (StambenaZgradaLibrary.Entiteti.Zgrada z in sveZgrade)
            {
                zgrade.Add(new ZgradaView(z));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return zgrade;
    }
    public async static Task<Result<bool, string>> DodajZgraduAsync(ZgradaView zg)
    {

        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Zgrada z = new StambenaZgradaLibrary.Entiteti.Zgrada();

            StambenaZgradaLibrary.Entiteti.ProfesionalniUpravnik upravnik = s.Load<ProfesionalniUpravnik>(zg.Upravnik.JMBG);

            z.Mesto = zg.Mesto;
            z.Ulica = zg.Ulica;
            z.Broj = zg.Broj;
            z.Godina_izgradnje = zg.Godina_izgradnje;
            z.Broj_jedinica = zg.Broj_jedinica;
            z.Upravnik = upravnik;


            await s.SaveOrUpdateAsync(z);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati zgradu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<ZgradaView, string>> AzurirajZgraduAsync(ZgradaView zg)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Zgrada z = s.Load<StambenaZgradaLibrary.Entiteti.Zgrada>(zg.ID_zgrade);
            z.Mesto = zg.Mesto;
            z.Ulica = zg.Ulica;
            z.Broj = zg.Broj;
            z.Godina_izgradnje = zg.Godina_izgradnje;
            z.Broj_jedinica = zg.Broj_jedinica;


            await s.UpdateAsync(z);
            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti zgradu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zg;
    }
    public async static Task<Result<ZgradaView, string>> VratiZgraduAsync(int ID_zgrade)
    {

        ISession? s = null;

        ZgradaView zb = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }


            StambenaZgradaLibrary.Entiteti.Zgrada z = await s.LoadAsync<StambenaZgradaLibrary.Entiteti.Zgrada>(ID_zgrade);
            zb = new ZgradaView(z);

        }
        catch (Exception)
        {
            return "Nemoguće vratiti zgradu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zb;
    }

    public static Result<bool, string> ObrisiZgradu(int ID_zgrade)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Zgrada z = s.Load<StambenaZgradaLibrary.Entiteti.Zgrada>(ID_zgrade);

            s.Delete(z);
            s.Flush();

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati zgradu.";
        }

        return true;
    }

    public async static Task<Result<List<ZgradaView>, string>> VratiZgradeNekogUpravnikaAsync(long UpravnikJMBG)
    {

        ISession? s = null;

        List<ZgradaView> zb = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Zgrada> zgrade = from z in s.Query<Zgrada>()
                                         where z.Upravnik.JMBG == UpravnikJMBG
                                         select z;

            foreach (Zgrada z in zgrade)
            {
                var upravnik = await VratiUpravnikaAsync(z.Upravnik?.JMBG ?? -1);

                if (upravnik.IsError)
                {
                    continue;
                }

                zb.Add(new ZgradaView(z));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti zgrade traženog upravnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zb;
    }
    #endregion

    #region Ugovor

    public async static Task<Result<bool, string>> SacuvajUgovorAsync(UgovorView ub)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ugovor u = new Ugovor();

            u.Datum_potpisivanja = ub.Datum_potpisivanja;
            u.Vazenje_ugovora = ub.Vazenje_ugovora;

            Zgrada z = s.Load<Zgrada>(ub.Zgrada.ID_zgrade);
            u.Zgrada = z;


            await s.SaveAsync(u);

            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati ugovor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static Result<bool, string> ObrisiUgovor(int Sifra)
        {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ugovor ugovor = s.Load<Ugovor>(Sifra);

            s.Delete(ugovor);
            s.Flush();

            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati ugovor.";
        }

        return true;
    }

    public async static Task<Result<UgovorView, string>> VratiUgovorAsync(int zgrada)
    {
        ISession? s = null;

        UgovorView ub = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ugovor zgr = await s.LoadAsync<Ugovor>(zgrada);

            if (zgr.Zgrada != null)
                ub = new UgovorView(zgr);
        }
        catch (Exception)
        {
            return "Nemoguće vratiti ugovor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return ub;

    }

    /* public static UgovorView VratiUgovorView(int zgrada)
     {
         UgovorView ub = new UgovorView();
         try
         {
             ISession s = DataLayer.GetSession();

             Zgrada zgr = s.Load<Zgrada>(zgrada);

             int Sifra = zgr.Ugovor.Sifra;

             Ugovor ugovor = s.Load<Ugovor>(Sifra);

             ub = new UgovorView(ugovor.Sifra, ugovor.Datum_potpisivanja, ugovor.Vazenje_ugovora,ugovor.Zgrada);
             s.Close();
         }
         catch (Exception ec)
         {
             Console.WriteLine(ec.Message);

         }

         return ub;

     }*/


    public async static Task<Result<UgovorView, string>> IzmeniUgovorAsync(UgovorView ugovor)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Ugovor u = s.Load<Ugovor>(ugovor.Sifra);


            u.Datum_potpisivanja = ugovor.Datum_potpisivanja;
            u.Vazenje_ugovora = ugovor.Vazenje_ugovora;




            await s.UpdateAsync(u);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti ugovor.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return ugovor;
    }
    #endregion

    #region VlasnikStana

      public async static Task<Result<List<VlasnikStanaView>, string>> VratiSveVlasnikeStanovaAsync()
       {

           ISession? s = null;

           List<VlasnikStanaView> sviVlasnici = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<StambenaZgradaLibrary.Entiteti.VlasnikStana> vlasi = from m in s.Query<StambenaZgradaLibrary.Entiteti.VlasnikStana>()
                                                                             select m;


            foreach (VlasnikStana r in vlasi)
            {
                sviVlasnici.Add(new VlasnikStanaView(r));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti vlasnike stanova ove zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

           return sviVlasnici;
       }

       

    public async static Task<Result<List<VlasnikStanaView>, string>> VratiSveVlasnikeAsync()
    {

        ISession? s = null;

        List<VlasnikStanaView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<VlasnikStana> stanovi = from st in await s.QueryOver<VlasnikStana>().ListAsync()
                                                select st;

            foreach (VlasnikStana st in stanovi)
            {
                lsp.Add(new VlasnikStanaView(st));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve vlasnike stanova.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return lsp;
    }

    public static Result<bool, string> ObrisiVlasnika(long JMBG)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.VlasnikStana vlasnik = s.Load<StambenaZgradaLibrary.Entiteti.VlasnikStana>(JMBG);

            s.Delete(vlasnik);
            s.Flush();

            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati vlasnika stana.";
        }

        return true;
    }

    public async static Task<Result<VlasnikStanaView, string>> VratiVlasnikaAsync(long JMBG)
    {

        ISession? s = null;

        VlasnikStanaView vs = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            VlasnikStana v = await s.LoadAsync<VlasnikStana>(JMBG);

            vs = new VlasnikStanaView(v);

        }
        catch (Exception)
        {
            return "Nemoguće vratiti vlasnika stana.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return vs;

    }

    public async static Task<Result<VlasnikStanaView, string>> IzmeniVlasnikaAsync(VlasnikStanaView vlasnik)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.VlasnikStana vs = s.Load<VlasnikStana>(vlasnik.JMBG);


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
        catch (Exception)
        {
            return "Nemoguće izmeniti vlasnika stana.";
        }
        return vlasnik;
    }

    public async static Task<Result<bool, string>> DodajVlasnikaAsync(VlasnikStanaView v)
    {

        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.VlasnikStana vs = new StambenaZgradaLibrary.Entiteti.VlasnikStana();

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

            await s.SaveOrUpdateAsync(vs);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati vlasnika stana.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }


    #endregion

    #region Licenca

    public async static Task<Result<List<LicencaView>, string>> VratiLicenceUpravnikaAsync(long UpravnikJMBG)
    {

        ISession? s = null;

        List<LicencaView> zb = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Licenca> zgrade = from z in s.Query<Licenca>()
                                          where z.Upravnik.JMBG == UpravnikJMBG
                                          select z;

            foreach (Licenca z in zgrade)
            {
                var upravnik = await VratiUpravnikaAsync(z.Upravnik?.JMBG ?? -1);
                if (upravnik.IsError)
                {
                    continue;
                }
                zb.Add(new LicencaView(z));
            }

            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće vratiti licence traženog upravnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return zb;
    }

    public async static Task<Result<bool, string>> SacuvajLicencuAsync(LicencaView ub)
        {
			ISession? s = null;
			
            try
            {
                
                 s = DataLayer.GetSession();
				 
				 if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }
				 
                StambenaZgradaLibrary.Entiteti.Licenca l = new StambenaZgradaLibrary.Entiteti.Licenca();


    l.Datum_sticanja_obnavljanja= ub.Datum_sticanja_obnavljanja;
                l.Broj_licence = ub.Broj_licence;
                l.Naziv_insitucije = ub.Naziv_insitucije;

                ProfesionalniUpravnik up = s.Load<ProfesionalniUpravnik>(ub.Upravnik.JMBG);

    l.Upravnik = up;
                

                


                await s.SaveAsync(l);

    await s.FlushAsync();


}
           catch (Exception)
        {
            return "Nemoguće dodati licencu.";
        }
        finally
        {
    s?.Close();
    s?.Dispose();
}

return true;
        }

    public static Result<bool, string> ObrisiLicencu(int ID_licence)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }


            Licenca licenca = s.Load<Licenca>(ID_licence);

            s?.Delete(licenca);
            s?.Flush();

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati licencu.";
        }

        return true;
    }
    public async static Task<Result<LicencaView, string>> VratiLicencuAsync(int ID_licence)
    {
        ISession? s = null;

        LicencaView lb = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Licenca licenca = await s.LoadAsync<Licenca>(ID_licence);
            lb = new LicencaView(licenca);

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti licencu";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return lb;
    }

    public async static Task<Result<LicencaView, string>> IzmeniLicencuAsync(LicencaView licenca)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Licenca l = s.Load<Licenca>(licenca.ID_licence);


            l.Broj_licence = licenca.Broj_licence;
            l.Datum_sticanja_obnavljanja = licenca.Datum_sticanja_obnavljanja;
            l.Naziv_insitucije = licenca.Naziv_insitucije;

            await s.UpdateAsync(l);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti licencu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return licenca;
    }

    public async static Task<Result<List<LicencaView>, string>> VratiSveLicenceAsync()
    {
        ISession? s = null;

        List<LicencaView> zaposleni = new();
        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<StambenaZgradaLibrary.Entiteti.Licenca> sviZaposleni = from o in await s.QueryOver<StambenaZgradaLibrary.Entiteti.Licenca>().ListAsync()
                                                                               select o;

            foreach (StambenaZgradaLibrary.Entiteti.Licenca z in sviZaposleni)
            {
                zaposleni.Add(new LicencaView(z));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve licence.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return zaposleni;
    }


    #endregion

    #region Ulaz

    public async static Task<Result<bool, string>> SacuvajUlazAsync(UlazView u)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ulaz o = new Ulaz();

            o.Redni_broj = u.Redni_broj;
            o.Postojanje_kamere = u.Postojanje_kamere;
            o.Vreme_otvaranja = u.Vreme_otvaranja;
            o.Vreme_zatvaranja = u.Vreme_zatvaranja;

           Zgrada z = s.Load<Zgrada>(u.Zgrada.ID_zgrade);
            o.Zgrada = z;


            await s.SaveAsync(o);

            await s.FlushAsync();


        }
        catch (Exception)
        {
            return "Nemoguće dodati ulaz.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public static Result<bool, string> ObrisiUlaz(int ID_ulaza)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ulaz ulaz = s.Load<Ulaz>(ID_ulaza);

            s.Delete(ulaz);
            s.Flush();



            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati ulaz.";
        }

        return true;
    }

    public async static Task<Result<UlazView, string>> VratiUlaz(int ID_ulaza)
    {
        ISession? s = null;

        UlazView u = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Ulaz ulaz = await s.LoadAsync<Ulaz>(ID_ulaza);

            u = new UlazView(ulaz);


        }
        catch (Exception)
        {
            return "Nemoguće vratiti ulaz.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return u;

    }
    public async static Task<Result<UlazView, string>> IzmeniUlazAsync(UlazView ulaz)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Ulaz u = s.Load<Ulaz>(ulaz.ID_ulaza);


            u.Redni_broj = ulaz.Redni_broj;
            u.Postojanje_kamere = ulaz.Postojanje_kamere;
            u.Vreme_zatvaranja = ulaz.Vreme_zatvaranja;
            u.Vreme_otvaranja = ulaz.Vreme_otvaranja;



            await s.UpdateAsync(u);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti ulaz.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return ulaz;
    }
    public async static Task<Result<List<UlazView>, string>> VratiUlazeNekeZgradeAsync(int ZgradaID)
    {
        ISession? s = null;

        List<UlazView> ub = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }
            IEnumerable<Ulaz> ulazi = from u in s.Query<Ulaz>()
                                      where u.Zgrada.ID_zgrade == ZgradaID
                                      select u;

            foreach (Ulaz u in ulazi)
            {
                var zgrada = await VratiZgraduAsync(u.Zgrada?.ID_zgrade ?? -1);

                if (zgrada.IsError)
                {
                    continue;
                }
                ub.Add(new UlazView(u));
            }
        }

        catch (Exception)
        {
            return "Nemoguće vratiti ulaze tražene zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return ub;
    }
    #endregion

    #region Lift

    #region PutnickiLift
    public static Result<bool, string> ObrisiPutnickiLift(int serijskiBroj)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PutnickiLift plift = s.Load<PutnickiLift>(serijskiBroj);

            s.Delete(plift);
            s.Flush();



            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati putnički lift.";
        }

        return true;
    }

    public async static Task<Result<PutnickiLiftView, string>> VratiPutnickiLiftAsync(int serBroj)
    {

        ISession? s = null;

        PutnickiLiftView o = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PutnickiLift plift = await s.LoadAsync<PutnickiLift>(serBroj);

            o = new PutnickiLiftView();

            o.Serijski_broj = plift.Serijski_broj;
            o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
            o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
            o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
            o.Max_broj_osoba = plift.Max_broj_osoba;


        }
        catch (Exception)
        {
            return "Nemoguće vratiti putnički lift.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return o;

    }

    public async static Task<Result<PutnickiLiftView, string>> IzmeniPutnickiLiftAsync(PutnickiLiftView plift)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PutnickiLift o = s.Load<PutnickiLift>(plift.Serijski_broj);

            o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
            o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
            o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
            o.Max_broj_osoba = plift.Max_broj_osoba;



            await s.SaveOrUpdateAsync(o);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti putnički lift.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return plift;
    }

    public async static Task<Result<bool, string>> SacuvajPutnickiLiftAsync(PutnickiLiftView plift)
        {
			ISession? s = null;
			
            try
            {
                 s = DataLayer.GetSession();
				 
				 if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

                PutnickiLift o = new PutnickiLift();

    o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
                o.Datum_poslednjeg_kvara= plift.Datum_poslednjeg_kvara;
                o.Datum_poslednjeg_servisa =plift.Datum_poslednjeg_servisa;
                o.Max_broj_osoba = plift.Max_broj_osoba;
				
                Zgrada z = s.Load<Zgrada>(plift.Ima_lift.ID_zgrade);
    o.Ima_lift = z;


                await s.SaveAsync(o);

    await s.FlushAsync();

}
            catch (Exception)
        {
            return "Nemoguće dodati putnički lift.";
        }
        finally
        {
    s?.Close();
    s?.Dispose();
}

return true;
        }

        public async static Task<Result<List<PutnickiLiftView>, string>> VratiPutnickeLiftoveZgradeAsync(int IDzgrade)
{
    ISession? s = null;

    List<PutnickiLiftView> lp = new();

    try
    {
        s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        IEnumerable<PutnickiLift> liftovi = from o in s.Query<PutnickiLift>()
                                            where o.Ima_lift.ID_zgrade == IDzgrade
                                            select o;

        foreach (PutnickiLift o in liftovi)
        {
            var zgrada = await VratiZgraduAsync(o.Ima_lift?.ID_zgrade ?? -1);

            if (zgrada.IsError)
            {
                continue;
            }

            lp.Add(new PutnickiLiftView(o));
        }

    }
    catch (Exception)
    {
        return "Nemoguće vratiti putničke liftove tražene zgrade.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }

    return lp;
}

#endregion

#region TeretniLift

public static Result<bool, string> ObrisiTeretniLift(int serijskiBroj)
{
    try
    {
        ISession? s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        TeretniLift plift = s.Load<TeretniLift>(serijskiBroj);

        s.Delete(plift);
        s.Flush();



        s.Close();

    }
    catch (Exception)
    {
        return "Nemoguće obrisati teretni lift.";
    }

    return true;
}

public async static Task<Result<TeretniLiftView, string>> VratiTeretniLiftAsync(int serBroj)
{

    ISession? s = null;

    TeretniLiftView o = default!;

    try
    {
        s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        TeretniLift plift = await s.LoadAsync<TeretniLift>(serBroj);

        o = new TeretniLiftView();

        o.Serijski_broj = plift.Serijski_broj;
        o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
        o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
        o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
        o.Nosivost = plift.Nosivost;


    }
    catch (Exception)
    {
        return "Nemoguće vratiti teretni lift.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }
    return o;
}

public async static Task<Result<TeretniLiftView, string>> IzmeniTeretniLiftAsync(TeretniLiftView plift)
{
    ISession? s = null;

    try
    {
        s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        TeretniLift o = s.Load<TeretniLift>(plift.Serijski_broj);

        o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
        o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
        o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
        o.Nosivost = plift.Nosivost;



        await s.SaveOrUpdateAsync(o);

        await s.FlushAsync();

    }
    catch (Exception)
    {
        return "Nemoguće izmeniti teretni lift.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }

    return plift;
}

public async static Task<Result<bool, string>> SacuvajTeretniLiftAsync(TeretniLiftView plift)
        {
    ISession? s = null;

    try
    {
        s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        TeretniLift o = new TeretniLift();

        o.Naziv_proizvodjaca = plift.Naziv_proizvodjaca;
        o.Datum_poslednjeg_kvara = plift.Datum_poslednjeg_kvara;
        o.Datum_poslednjeg_servisa = plift.Datum_poslednjeg_servisa;
        o.Nosivost = plift.Nosivost;

        Zgrada z = s.Load<Zgrada>(plift.Ima_lift.ID_zgrade);
        o.Ima_lift = z;


        await s.SaveAsync(o);

        await s.FlushAsync();

    }
    catch (Exception)
    {
        return "Nemoguće dodati teretni lift.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }

    return true;
}

public async static Task<Result<List<TeretniLiftView>, string>> VratiTeretneLiftoveZgradeAsync(int IDzgrade)
{
    ISession? s = null;

    List<TeretniLiftView> lp = new();

    try
    {
        s = DataLayer.GetSession();

        if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

        IEnumerable<TeretniLift> liftovi = from o in s.Query<TeretniLift>()
                                           where o.Ima_lift.ID_zgrade == IDzgrade
                                           select o;

        foreach (TeretniLift o in liftovi)
        {
            var zgrada = await VratiZgraduAsync(o.Ima_lift?.ID_zgrade ?? -1);

            if (zgrada.IsError)
            {
                continue;
            }

            lp.Add(new TeretniLiftView(o));
        }

    }
    catch (Exception)
    {
        return "Nemoguće vratiti teretne liftove tražene zgrade.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }

    return lp;
}

    #endregion

    #endregion

    #region Nivo
    public async static Task<Result<List<NivoView>, string>> VratiSveNivoeZgradeAsync(int ID_zgrade)
    {

        ISession? s = null;

        List<NivoView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Nivo> nivoi = from st in s.Query<Nivo>()
                                      where st.Zgrada.ID_zgrade == ID_zgrade
                                      select st;

            foreach (Nivo st in nivoi)
            {
                var zgrada = await VratiZgraduAsync(st.Zgrada?.ID_zgrade ?? -1);
                if (zgrada.IsError)
                {
                    continue;
                }

                lsp.Add(new NivoView(st));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanove tražene zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return lsp;
    }
    public static Result<bool, string> ObrisiNivo(int ID_nivoa)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Nivo n = s.Load<StambenaZgradaLibrary.Entiteti.Nivo>(ID_nivoa);

            s.Delete(n);
            s.Flush();

            s.Close();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati nivo.";
        }

        return true;
    }
    public async static Task<Result<NivoView, string>> VratiNivoAsync(int ID_nivoa)
    {

        ISession? s= null;

        NivoView nb = default!;

        try
        {
             s = DataLayer.GetSession();

             if (!(s?.IsConnected ?? false))
        {
            return "Nemoguće otvoriti sesiju.";
        }

            StambenaZgradaLibrary.Entiteti.Nivo n = await s.LoadAsync<StambenaZgradaLibrary.Entiteti.Nivo>(ID_nivoa);
            nb = new NivoView(n);

        }
        catch (Exception)
    {
        return "Nemoguće vratiti nivo.";
    }
    finally
    {
        s?.Close();
        s?.Dispose();
    }

        return nb;
    }
    public async static Task<Result<bool, string>> SacuvajLokalAsync(LokalView lokal)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Lokal l = new StambenaZgradaLibrary.Entiteti.Lokal();

            l.ID_nivoa = lokal.ID_nivoa;
            l.Sprat = lokal.Sprat;
            l.Redni_broj = lokal.Redni_broj;
            l.Naziv_firme = lokal.Naziv_firme;

            Zgrada z = s.Load<Zgrada>(lokal.Zgrada.ID_zgrade);
            l.Zgrada = z;

            await s.SaveAsync(l);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati lokal.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<bool, string>> SacuvajStanAsync(StanView stan)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }


            StambenaZgradaLibrary.Entiteti.Stan st = new StambenaZgradaLibrary.Entiteti.Stan();

            st.ID_nivoa = stan.ID_nivoa;
            st.Sprat = stan.Sprat;
            st.Redni_broj = stan.Redni_broj;

            Zgrada z = s.Load<Zgrada>(stan.Zgrada.ID_zgrade);
            st.Zgrada = z;
            VlasnikStana v = s.Load<VlasnikStana>(stan.Vlasnik.JMBG);
            st.Vlasnik = v;

            await s.SaveAsync(st);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati stan.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<bool, string>> SacuvajParkingMestoAsync(ParkingMestoView parkingmesto)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.ParkingMesto pm = new StambenaZgradaLibrary.Entiteti.ParkingMesto();

            pm.ID_nivoa = parkingmesto.ID_nivoa;
            pm.Sprat = parkingmesto.Sprat;
            pm.Redni_broj = parkingmesto.Redni_broj;
            pm.Rezervisano = parkingmesto.Rezervisano;

            Zgrada z = s.Load<Zgrada>(parkingmesto.Zgrada.ID_zgrade);
            pm.Zgrada = z;

            await s.SaveAsync(pm);

            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće dodati parking mesto.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public async static Task<Result<LokalView, string>> VratiLokalAsync(int ID_nivoa)
    {
        ISession? s = null;

        LokalView lb = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Lokal l = await s.LoadAsync<StambenaZgradaLibrary.Entiteti.Lokal>(ID_nivoa);
            lb = new LokalView(l);

        }
        catch (Exception)
        {
            return "Nemoguće vratiti traženi lokal.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }


        return lb;
    }
    public async static Task<Result<StanView, string>> VratiStanAsync(int ID_nivoa)
    {
        ISession? s = null;

        StanView sb = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Stan st = await s.LoadAsync<StambenaZgradaLibrary.Entiteti.Stan>(ID_nivoa);
            sb = new StanView(st);

        }
        catch (Exception)
        {
            return "Nemoguće vratiti radnika sa zadatim ID-jem.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }


        return sb;
    }
    public async static Task<Result<ParkingMestoView, string>> VratiPMestoAsync(int ID_nivoa)
    {
        ISession? s = null;

        ParkingMestoView pb = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.ParkingMesto pm = await s.LoadAsync<StambenaZgradaLibrary.Entiteti.ParkingMesto>(ID_nivoa);
            pb = new ParkingMestoView(pm);

        }
        catch (Exception)
        {
            return "Nemoguće vratiti traženo parking mesto.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return pb;
    }
    public async static Task<Result<LokalView, string>> AzurirajLokalAsync(LokalView l)
    {
        ISession? s = null;
        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Lokal lk = s.Load<StambenaZgradaLibrary.Entiteti.Lokal>(l.ID_nivoa);

            lk.Sprat = l.Sprat;
            lk.Redni_broj = l.Redni_broj;
            lk.Naziv_firme = l.Naziv_firme;


            await s.UpdateAsync(lk);
            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti lokal.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return l;
    }
    public async static Task<Result<StanView, string>> AzurirajStanAsync(StanView st)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.Stan stn = s.Load<StambenaZgradaLibrary.Entiteti.Stan>(st.ID_nivoa);

            stn.Sprat = st.Sprat;
            stn.Redni_broj = st.Redni_broj;



            await s.UpdateAsync(stn);
            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti stan.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return st;
    }
    public async static Task<Result<ParkingMestoView, string>> AzurirajParkingMestoAsync(ParkingMestoView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.ParkingMesto pm = s.Load<StambenaZgradaLibrary.Entiteti.ParkingMesto>(p.ID_nivoa);

            pm.Sprat = p.Sprat;
            pm.Redni_broj = p.Redni_broj;
            pm.Rezervisano = p.Rezervisano;


            await s.UpdateAsync(pm);
            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti parking mesto.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return p;
    }

    public async static Task<Result<List<StanView>, string>> VratiStanoveZgradeAsync(int IDzgrade)
    {
        ISession? s = null;

        List<StanView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                        where st.Zgrada.ID_zgrade == IDzgrade
                                        select st;

            foreach (Stan st in stanovi)
            {
                var zgrada = await VratiZgraduAsync(st.Zgrada?.ID_zgrade ?? -1);
                if (zgrada.IsError)
                {
                    continue;
                }

                lsp.Add(new StanView(st));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanove tražene zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return lsp;
    }

    public async static Task<Result<List<StanView>, string>> VratiStanoveVlasnikaAsync(long IDvlasnika)
    {

        ISession? s = null;

        List<StanView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                        where st.Vlasnik.JMBG == IDvlasnika
                                        select st;

            foreach (Stan st in stanovi)
            {
                var vlasnik = await VratiVlasnikaAsync(st.Vlasnik?.JMBG ?? -1);

                if (vlasnik.IsError)
                {
                    continue;
                }

                lsp.Add(new StanView(st));
            }


        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanove vlasnika.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return lsp;
    }

    public async static Task<Result<List<LokalView>, string>> VratiLokaleZgradeAsync(int IDzgrade)
    {
        ISession? s = null;

        List<LokalView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Lokal> stanovi = from st in s.Query<Lokal>()
                                         where st.Zgrada.ID_zgrade == IDzgrade
                                         select st;

            foreach (Lokal st in stanovi)
            {

                var zgrada = await VratiZgraduAsync(st.Zgrada?.ID_zgrade ?? -1);

                if (zgrada.IsError)
                {
                    continue;
                }

                lsp.Add(new LokalView(st));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti lokale zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return lsp;
    }

    public async static Task<Result<List<ParkingMestoView>, string>> VratiPMestaZgradeAsync(int IDzgrade)
    {

        ISession? s = null;

        List<ParkingMestoView> lsp = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<ParkingMesto> stanovi = from st in s.Query<ParkingMesto>()
                                                where st.Zgrada.ID_zgrade == IDzgrade
                                                select st;

            foreach (ParkingMesto st in stanovi)
            {
                var zgrada = await VratiZgraduAsync(st.Zgrada?.ID_zgrade ?? -1);

                if (zgrada.IsError)
                {
                    continue;
                }

                lsp.Add(new ParkingMestoView(st));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti parking mesta tražene zgrade.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return lsp;
    }

    /* public async static Task<Result<List<StanView>, string>> VratiStanoveVlasnikaAsync(int VlasnikJMBG)
     {
         ISession? s = null;

         List<StanView> lsp = new();

         try
         {
             s = DataLayer.GetSession();

             if (!(s?.IsConnected ?? false))
         {
             return "Nemoguće otvoriti sesiju.";
         }

             IEnumerable<Stan> stanovi = from st in s.Query<Stan>()
                                                   where st.Vlasnik.JMBG == VlasnikJMBG
                                                   select st;

             foreach (Stan st in stanovi)
             {
                 var vlasnik= await VratiVlasnikaAsync(st.Vlasnik?.JMBG ?? -1);

                 if(vlasnik.IsError)
                 {
                     continue;
                 }

                 lsp.Add(new StanView(st.ID_nivoa, st.Redni_broj, st.Sprat, st.Zgrada,st.Vlasnik));
             }

         }
        catch (Exception)
     {
         return "Nemoguće vratiti stanove vlasnika.";
     }
     finally
     {
         s?.Close();
         s?.Dispose();
     }
         return lsp;
     }*/
    #endregion

    #region ImenaStanara

    public async static Task<Result<ImenaStanaraView, string>> AzurirajImeStanaraAsync(int idStanara, string ime)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            StambenaZgradaLibrary.Entiteti.ImenaStanara stn = s.Load<StambenaZgradaLibrary.Entiteti.ImenaStanara>(idStanara);

            stn.Ime_stanara = ime;


            await s.UpdateAsync(stn);
            await s.FlushAsync();

        }
        catch (Exception)
        {
            return "Nemoguće izmeniti ime stanara.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return ime;
    }

    public async static Task<Result<ImenaStanaraView, string>> VratiStanaraAsync(int idS)
    {

        ISession? s = null;

        ImenaStanaraView z = default!;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ImenaStanara zaposleni = await s.LoadAsync<ImenaStanara>(idS);

            z = new ImenaStanaraView(zaposleni);


        }
        catch (Exception)
        {
            return "Nemoguće vratiti stanara.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return z;

    }

    public async static Task<Result<bool, string>> SacuvajImeStanaraAsync(ImenaStanaraView isb)
    {

        ISession? s = null;


        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ImenaStanara ims = new ImenaStanara();

            ims.Ime_stanara = isb.Ime_stanara;

            Nivo n = s.Load<Nivo>(isb.Nivo.ID_nivoa);
            ims.Nivo = n;

            await s.SaveAsync(ims);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati stanara.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    public static Result<bool, string> ObrisiStanara(int ID_stanar)
    {
        try
        {
            ISession? s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            ImenaStanara stanar = s.Load<ImenaStanara>(ID_stanar);

            s.Delete(stanar);
            s.Flush();



            s.Close();

        }
        catch (Exception)
        {
            return "Nemoguće obrisati stanara.";
        }

        return true;
    }


    public async static Task<Result<List<ImenaStanaraView>, string>> VratiStanareZgradeiStanaAsync(int ID_nivo)
    {

        ISession? s = null;

        List<ImenaStanaraView> listaStanara = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<ImenaStanara> stanari = from o in s.Query<ImenaStanara>()
                                                where o.Nivo.ID_nivoa == ID_nivo
                                                select o;


            foreach (ImenaStanara ism in stanari)
            {
                var nivo = await VratiNivoAsync(ism.Nivo?.ID_nivoa ?? -1);

                if (nivo.IsError)
                {
                    continue;
                }

                listaStanara.Add(new ImenaStanaraView(ism));
            }

        }
        catch (Exception)
        {
            return "Nemoguće vratiti stanare.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }
        return listaStanara;

    }
    /* public static void IzmeniStanare(ImenaStanaraView stanari)
     {
         try
         {
             ISession s = DataLayer.GetSession();

             StambenaZgradaLibrary.Entiteti.ImenaStanara ims = s.Load<ImenaStanara>(stanari.ID_stanari);


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