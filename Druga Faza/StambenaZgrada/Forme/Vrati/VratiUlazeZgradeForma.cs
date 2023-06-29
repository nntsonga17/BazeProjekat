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
    public partial class VratiUlazeZgradeForma : Form
    {
       ZgradaBasic zbp;
        /*public VratiUlazeZgradeForma()
        {
            InitializeComponent();
        }*/

        public VratiUlazeZgradeForma(ZgradaBasic z)
        {
            zbp = z;
            InitializeComponent();
            PopuniPodacima();
        }

        private void VratiUlazeZgradeForma_Load(object sender, EventArgs e)
        {
            //  PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            List<UlazPregled> lista = DTOManager.VratiUlazeNekeZgrade(zbp.ID_zgrade);
            this.listView1.Items.Clear();

            foreach (UlazPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.ID_ulaza.ToString(), r.Vreme_otvaranja, r.Vreme_zatvaranja, r.Postojanje_kamere.ToString(), r.Redni_broj.ToString() });
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.DodajUlaz forma = new DodajUlaz(zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite ulaz koji želite da izmenite!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            UlazBasic r = DTOManager.VratiUlaz(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniUlazForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniUlazForma(r,zbp);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite ulaz koji želite da obrišete!");
                return;
            }

            int idZaposleni = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete ulaz?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiUlaz(idZaposleni);
                MessageBox.Show("Brisanje ulaza u zgradu je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }
    }
}
