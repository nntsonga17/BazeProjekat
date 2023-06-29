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
    public partial class VratiUpravnikeForma : Form
    {
        ProfesionalniUpravnikBasic pub;
        public VratiUpravnikeForma()
        {
            InitializeComponent();
            pub = new ProfesionalniUpravnikBasic();
        }
        public VratiUpravnikeForma(ProfesionalniUpravnikBasic p)
        {
            InitializeComponent();
            pub = p;
        }


        public int brojZaposlenih = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            DodajUpravnikaForma forma = new DodajUpravnikaForma();
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void VratiUpravnikeForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            this.brojZaposlenih = 0;

            List<ProfesionalniUpravnikBasic> lista = DTOManager.VratiSveUpravnike();
            this.listView1.Items.Clear();

            foreach (ProfesionalniUpravnikBasic r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.JMBG.ToString(), r.Licno_ime, r.Ime_roditelja, r.Prezime, r.Br_telefona1, r.Br_telefona2, r.Mesto_stanovanja, r.Ulica, r.Broj, r.Broj_licne_karte.ToString(), r.Mesto_izdavanja, r.Datum_rodjenja.ToShortDateString(), r.Zvanje,r.Naziv_institucije,r.Datum_sticanja_diplome.ToShortDateString() });
                this.listView1.Items.Add(item);
                this.brojZaposlenih++;
            }

            textBox1.Text = this.brojZaposlenih.ToString();
            this.listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite upravnika koga želite da izmenite!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ProfesionalniUpravnikBasic r = DTOManager.VratiUpravnika(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniUpravnikaForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniUpravnikaForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite upravnika koga želite da obrišete!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete izabranog upravnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiUpravnika(idZaposleni);
                MessageBox.Show("Brisanje upravnika je uspešno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite upravnika za koga želite da menjate/dodate licencu!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ProfesionalniUpravnikBasic r = DTOManager.VratiUpravnika(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiLicencuForma forma = new StambenaZgrada.Forme.Vrati.VratiLicencuForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite upravnika za koga želite da vidite kojim zgradama upravlja!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            ProfesionalniUpravnikBasic r = DTOManager.VratiUpravnika(idZaposleni);
            StambenaZgrada.Forme.Vrati.VratiZgradeUpravnikaForma forma = new StambenaZgrada.Forme.Vrati.VratiZgradeUpravnikaForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

    }
}
