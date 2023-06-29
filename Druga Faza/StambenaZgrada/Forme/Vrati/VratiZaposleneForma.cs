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
    public partial class VratiZaposleneForma : Form
    {
        ZaposlenBasic zap;
        public VratiZaposleneForma()
        {
            InitializeComponent();
            zap = new ZaposlenBasic();
        }
        public int brojZaposlenih = 0;

        public VratiZaposleneForma(ZaposlenBasic z)
        {
            InitializeComponent();
            zap = z;
        }
        private void VratiZaposleneForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            this.brojZaposlenih = 0;

            List<ZaposlenPregled> lista = DTOManager.VratiSveZaposlene(); 
            this.listView1.Items.Clear();

            foreach (ZaposlenPregled r in lista)
            {
               
                ListViewItem item = new ListViewItem(new string[] { r.JMBG.ToString(), r.Licno_ime, r.Ime_roditelja, r.Prezime, r.Br_telefona1,r.Br_telefona2,r.Mesto_stanovanja,r.Ulica,r.Broj, r.Broj_licne_karte.ToString(), r.Mesto_izdavanja, r.Datum_rodjenja.ToString()});
                this.listView1.Items.Add(item);
                this.brojZaposlenih++;
            }

            textBox1.Text = this.brojZaposlenih.ToString();
            this.listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajZaposlenogForma forma = new DodajZaposlenogForma();
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog koga želite da izmenite!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ZaposlenBasic r = DTOManager.VratiZaposlenog(idZaposleni);
            IzmeniZaposlenogForma forma = new IzmeniZaposlenogForma(r);
            forma.ShowDialog();
            PopuniPodacima();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog koga želite da obrišete!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranog zaposlenog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //long m = 1839573923536;
                DTOManager.ObrisiZaposlenog(idZaposleni);
                MessageBox.Show("Brisanje zaposlenog je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VratiUpravnikeForma forma = new VratiUpravnikeForma();
            forma.ShowDialog();

        }
    }
}
