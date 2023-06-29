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
    public partial class VratiStanoveZgradeForma : Form
    {
        ZgradaBasic zg;
       /* public VratiStanoveZgradeForma()
        {
            InitializeComponent();
        }*/
        public VratiStanoveZgradeForma(ZgradaBasic z)
        {
            InitializeComponent();
            zg = z;
            PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.DodajStanForma forma = new StambenaZgrada.Forme.DodajStanForma(zg); 
            forma.ShowDialog();
            PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            List<StanPregled> lista = DTOManager.VratiStanoveZgrade(zg.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (StanPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] {r.ID_nivoa.ToString(), r.Sprat.ToString(), r.Redni_broj.ToString() });
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite stan koji želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete stan?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiNivo(idZaposleni);
                MessageBox.Show("Brisanje stana je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite stan koji želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            StanBasic r = DTOManager.VratiStan(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniStanForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniStanForma(r,zg);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite stan za koji želite da prikažete stanare!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            StanBasic r = DTOManager.VratiStan(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiStanareForma forma = new StambenaZgrada.Forme.Vrati.VratiStanareForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiStanoveZgradeForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
    }
}
