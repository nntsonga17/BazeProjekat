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
    public partial class VratiPMestaZgradeForma : Form
    {
        ZgradaBasic zg;
       /* public VratiPMestaZgradeForma()
        {
            InitializeComponent();
        }*/
        public VratiPMestaZgradeForma(ZgradaBasic c)
        { 
            zg = c;
            InitializeComponent();
            PopuniPodacima();
        }

            private void VratiPMestaZgradeForma_Load(object sender, EventArgs e)
            {
                // PopuniPodacima();
            }

        public void PopuniPodacima()
        {
            List<ParkingMestoPregled> lista = DTOManager.VratiPMestaZgrade(zg.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (ParkingMestoPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] {r.ID_nivoa.ToString(), r.Sprat.ToString(),r.Redni_broj.ToString(),r.Rezervisano.ToString()});
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.DodajParkingMestoForma forma = new DodajParkingMestoForma(zg);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite parking mesto koje želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ParkingMestoBasic r = DTOManager.VratiPMesto(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniParkingMForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniParkingMForma(r, zg);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite parking mesto koje želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete ovo mesto?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiNivo(idZaposleni);
                MessageBox.Show("Brisanje parking mesta je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }
    }
}
