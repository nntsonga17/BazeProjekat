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
    public partial class VratiSveTeretneLForma : Form
    {
        ZgradaBasic zbp;
      /*  public VratiSveTeretneLForma()
        {
            InitializeComponent();
            zbp = new ZgradaBasic();
        }*/

        public VratiSveTeretneLForma(ZgradaBasic t)
        {
            zbp = t;
            InitializeComponent();
            PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajTeretniLiftForma forma = new DodajTeretniLiftForma(zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiSveTeretneLForma_Load(object sender, EventArgs e)
        {
            //PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            List<TeretniLiftPregled> lista = DTOManager.VratiTeretneLiftoveZgrade(zbp.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (TeretniLiftPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] {r.Serijski_broj.ToString(), r.Naziv_proizvodjaca, r.Datum_poslednjeg_servisa.ToShortDateString(), r.Datum_poslednjeg_kvara.ToShortDateString(), r.Nosivost.ToString() });
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
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
                DTOManager.ObrisiTeretniLift(idZaposleni);
                MessageBox.Show("Brisanje lifta je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lift koji želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TeretniLiftBasic r = DTOManager.VratiTeretniLift(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniTeretniLiftForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniTeretniLiftForma(r, zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }
    }
}
