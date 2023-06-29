using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StambenaZgrada.Forme.Vrati
{
    public partial class VratiLicencuForma : Form
    {
        ProfesionalniUpravnikBasic upr;
        public VratiLicencuForma()
        {
            InitializeComponent();
            upr = new ProfesionalniUpravnikBasic();
        }
        public VratiLicencuForma(ProfesionalniUpravnikBasic p)
        {
            InitializeComponent();
            upr = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajLicencuForma forma = new DodajLicencuForma(upr);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiLicencuForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {

            listView1.Items.Clear();
            List<LicencaPregled> podaci = DTOManager.VratiLicenceUpravnika(upr.JMBG);

            foreach (LicencaPregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.ID_licence.ToString(),p.Broj_licence.ToString(),p.Datum_sticanja_obnavljanja.ToShortDateString(),p.Naziv_insitucije});
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite licencu koju želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            LicencaBasic r = DTOManager.VratiLicencu(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniLicencuForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniLicencuForma(r,upr);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite licencu koju želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete izabranu licencu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiLicencu(idZaposleni);
                MessageBox.Show("Brisanje licence je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }
    }
}
