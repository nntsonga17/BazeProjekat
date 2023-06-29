using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using StambenaZgrada.Entiteti;

namespace StambenaZgrada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void VratiZaposlenog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Zaposlen o = s.Load<Zaposlen>(Convert.ToInt64(1839573923575));

                MessageBox.Show(Convert.ToString(o.Prezime));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiUpravnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                ProfesionalniUpravnik o = s.Load<ProfesionalniUpravnik>(1839573923575);

                MessageBox.Show(Convert.ToString(o.Zvanje));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiVlasnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                VlasnikStana o = s.Load<VlasnikStana>(3883333592033);

                MessageBox.Show(Convert.ToString(o.Licno_ime));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiUlaz_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Ulaz o = s.Load<Ulaz>(104);

                MessageBox.Show(Convert.ToString(o.Redni_broj));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiPMesto_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                ParkingMesto o = s.Load<ParkingMesto>(105);

                MessageBox.Show(Convert.ToString(o.Rezervisano));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiLift_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Lift o = s.Load<Lift>(104);

                MessageBox.Show(Convert.ToString(o.Naziv_proizvodjaca));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiLokal_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Lokal o = s.Load<Lokal>(104);

                MessageBox.Show(Convert.ToString(o.Naziv_firme));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiNivo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Nivo o = s.Load<Nivo>(101);

                MessageBox.Show(Convert.ToString(o.Sprat));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiStan_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Stan o = s.Load<Stan>(106);

                MessageBox.Show(Convert.ToString(o.Vlasnik.Licno_ime + " " + o.Vlasnik.Ime_roditelja + " " + o.Vlasnik.Prezime));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiStanara_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                ImenaStanara o = s.Load<ImenaStanara>(104);

                MessageBox.Show(Convert.ToString(o.Ime_stanara));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Ugovor o = s.Load<Ugovor>(101);

                MessageBox.Show(Convert.ToString(o.Datum_potpisivanja));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiZgradu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Zgrada o = s.Load<Zgrada>(105);

                MessageBox.Show(Convert.ToString(o.Godina_izgradnje));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void VratiLicencu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Licenca o = s.Load<Licenca>(101);

                MessageBox.Show(Convert.ToString(o.Datum_sticanja_obnavljanja));

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
