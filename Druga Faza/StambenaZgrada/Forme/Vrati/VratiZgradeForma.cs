using StambenaZgrada.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StambenaZgrada.Forme.Vrati
{
    public partial class VratiZgradeForma : Form
    {
        ZgradaBasic zgr;
        public VratiZgradeForma()
        {
            InitializeComponent();
            zgr = new ZgradaBasic();
        }
        public VratiZgradeForma(Zgrada z)
        {
            InitializeComponent();
            zgr = new ZgradaBasic(z.ID_zgrade, z.Mesto, z.Ulica, z.Broj, z.Broj_jedinica, z.Godina_izgradnje);
        }

       
        public void VratiZgradeForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            listView1.Items.Clear();
            List<ZgradaBasic> lista = DTOManager.VratiSveZgrade();
            

            foreach (ZgradaBasic r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.ID_zgrade.ToString(), r.Mesto, r.Ulica, r.Broj, r.Godina_izgradnje.ToString(), r.Broj_jedinica.ToString() }); ;
                listView1.Items.Add(item);
            }

            listView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajZgraduForma forma = new DodajZgraduForma();
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu koju želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniZgraduForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniZgraduForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu koju želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu zgradu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiZgradu(idZaposleni);
                MessageBox.Show("Brisanje zgrade je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da vidite podatke o liftovima!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            OdaberiTipLiftaForma forma = new OdaberiTipLiftaForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiUlazeZgradeForma forma = new StambenaZgrada.Forme.Vrati.VratiUlazeZgradeForma(r);
            forma.ShowDialog();
            PopuniPodacima();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da dodate ugovor!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.DodajUgovorForma forma = new StambenaZgrada.Forme.DodajUgovorForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da prikažete ugovor!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            
            StambenaZgrada.Forme.Vrati.VratiUgovorForma forma = new StambenaZgrada.Forme.Vrati.VratiUgovorForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da prikažete parking mesta!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiPMestaZgradeForma forma = new StambenaZgrada.Forme.Vrati.VratiPMestaZgradeForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da prikažete lokale!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiLokaleZgradeForma forma = new StambenaZgrada.Forme.Vrati.VratiLokaleZgradeForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zgradu za koju želite da prikažete stanove!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZgradaBasic r = DTOManager.VratiZgradu(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiStanoveZgradeForma forma = new StambenaZgrada.Forme.Vrati.VratiStanoveZgradeForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

    }
}
