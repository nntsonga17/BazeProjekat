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
    public partial class VratiVlasnikeForma : Form
    {
        VlasnikStanaBasic vla;
        public VratiVlasnikeForma()
        {
            InitializeComponent();
            vla = new VlasnikStanaBasic();
        }
        public VratiVlasnikeForma(VlasnikStanaBasic v)
        {
            InitializeComponent();
            vla = v;
        }

        public void PopuniPodacima()
        {
            List<VlasnikStanaBasic> lista = DTOManager.VratiSveVlasnike();
            this.listView1.Items.Clear();

            foreach (VlasnikStanaBasic r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.JMBG.ToString(), r.Licno_ime, r.Ime_roditelja, r.Prezime, r.Br_telefona1, r.Br_telefona2, r.Mesto_stanovanja, r.Ulica, r.Broj, r.Tip_u_skupstini.ToString() }) ;
               
                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DodajVlasnikaForma forma = new DodajVlasnikaForma();
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vlasnika kog želite da izmenite!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            VlasnikStanaBasic r = DTOManager.VratiVlasnika(idZaposleni);
            StambenaZgrada.Forme.Izmeni.IzmeniVlasnikaForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniVlasnikaForma(r);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vlasnika kog želite da obrišete!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete vlasnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiVlasnika(idZaposleni);
                MessageBox.Show("Brisanje vlasnika je uspešno obavljeno!");
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
                MessageBox.Show("Izaberite vlasnika za koga želite da vidite stanove!");
                return;
            }

            long idZaposleni = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            VlasnikStanaBasic r = DTOManager.VratiVlasnika(idZaposleni);
            StambenaZgrada.Forme.Vrati.StanoviVlasnikaForma forma = new StambenaZgrada.Forme.Vrati.StanoviVlasnikaForma(r);
            forma.ShowDialog();
            PopuniPodacima();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void VratiVlasnikeForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
    }
}
