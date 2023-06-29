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
    public partial class VratiStanareForma : Form
    {
        //ZgradaBasic zg;
        StanBasic sb;
        public VratiStanareForma()
        {
            InitializeComponent();
        }
        public VratiStanareForma(/*ZgradaBasic z,*/ StanBasic s)
        {
            InitializeComponent();
            //zg = z;
            sb = s;
        }


        private void VratiStanareForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
        
        public void PopuniPodacima()
        {
            List<ImenaStanaraBasic> lista = DTOManager.VratiStanareZgradeiStana(sb.ID_nivoa);
            this.listView1.Items.Clear();

            foreach (ImenaStanaraBasic r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.ID_stanari.ToString(), r.Ime_stanara, r.Nivo.ToString()});
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.DodajStanaraForma forma = new StambenaZgrada.Forme.DodajStanaraForma(sb);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite stanara kog želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete ovog stanara?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiStanara(idZaposleni);
                MessageBox.Show("Brisanje stanara je uspešno obavljeno!");
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
                MessageBox.Show("Izaberite stanara kog želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ImenaStanaraBasic r = DTOManager.VratiStanara(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniStanaraForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniStanaraForma(r);
            forma.ShowDialog();
            PopuniPodacima();
    }
    }
}
