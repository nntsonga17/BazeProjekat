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
    public partial class VratiLokaleZgradeForma : Form
    {
        ZgradaBasic zg;
       /* public VratiLokaleZgradeForma()
        {
            InitializeComponent();
        }*/
        public VratiLokaleZgradeForma(ZgradaBasic z)
        {
            zg = z;
            InitializeComponent();
            PopuniPodacima();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.DodajLokal forma = new StambenaZgrada.Forme.DodajLokal(zg);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiLokaleZgradeForma_Load(object sender, EventArgs e)
        {
           // PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            List<LokalPregled> lista = DTOManager.VratiLokaleZgrade(zg.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (LokalPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.ID_nivoa.ToString() ,r.Sprat.ToString(), r.Redni_broj.ToString(), r.Naziv_firme }) ;
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lokal koji želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            LokalBasic r = DTOManager.VratiLokal(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniLokalForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniLokalForma(r,zg);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lokal koji želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete ovaj lokal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiNivo(idZaposleni);
                MessageBox.Show("Brisanje lokala je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }
    }
}
