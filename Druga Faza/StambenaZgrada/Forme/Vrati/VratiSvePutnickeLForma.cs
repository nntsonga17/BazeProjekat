using StambenaZgrada.Entiteti;
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
    public partial class VratiSvePutnickeLForma : Form
    {
        ZgradaBasic zbp;
       /* public VratiSvePutnickeLForma()
        {
            InitializeComponent();
            zbp = new ZgradaBasic();
        }*/
        public VratiSvePutnickeLForma(ZgradaBasic z2)
        {
            zbp = z2;
            InitializeComponent();
            PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajPutnickiLiftForma forma = new DodajPutnickiLiftForma(zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiSvePutnickeLForma_Load(object sender, EventArgs e)
        {
           // PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            List<PutnickiLiftPregled> lista = DTOManager.VratiPutnickeLiftoveZgrade(zbp.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (PutnickiLiftPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] {r.Serijski_broj.ToString(), r.Naziv_proizvodjaca,r.Datum_poslednjeg_servisa.ToShortDateString(),r.Datum_poslednjeg_kvara.ToShortDateString(),r.Max_broj_osoba.ToString()});
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lift koji želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            PutnickiLiftBasic r = DTOManager.VratiPutnickiLift(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniPutnickiLiftForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniPutnickiLiftForma(r,zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lift koji želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrišete lift?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiPutnickiLift(idZaposleni);
                MessageBox.Show("Brisanje lifta je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        
    }
}
