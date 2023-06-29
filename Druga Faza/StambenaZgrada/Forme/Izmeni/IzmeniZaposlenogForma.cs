using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StambenaZgrada.Forme
{
    public partial class IzmeniZaposlenogForma : Form
    {
        ZaposlenBasic zb = new ZaposlenBasic();
        public IzmeniZaposlenogForma()
        {
            InitializeComponent();
        }
        public IzmeniZaposlenogForma(ZaposlenBasic z)
        {
            InitializeComponent();
            zb = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            textBox1.Text = Convert.ToString(zb.JMBG);
            textBox1.Enabled = false;
            textBox3.Text = zb.Ime_roditelja;
            textBox2.Text = zb.Licno_ime;
            textBox4.Text = zb.Prezime;
            textBox5.Text = zb.Br_telefona1;
            textBox6.Text = zb.Br_telefona2;
            textBox7.Text = zb.Mesto_stanovanja;
            textBox8.Text = zb.Ulica;
            textBox9.Text = zb.Broj;
            textBox10.Text = Convert.ToString(zb.Broj_licne_karte);
            textBox11.Text = zb.Mesto_izdavanja;
            dateTimePicker1.Value = zb.Datum_rodjenja;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //zb.JMBG = Convert.ToInt64(textBox1.Text);
            zb.Ime_roditelja = textBox3.Text;
            zb.Licno_ime = textBox2.Text;
            zb.Prezime = textBox4.Text;
            zb.Br_telefona1 = textBox5.Text;
            zb.Br_telefona2 = textBox6.Text;
            zb.Mesto_stanovanja = textBox7.Text;
            zb.Ulica = textBox8.Text;
            zb.Broj = textBox9.Text;
            zb.Broj_licne_karte = Convert.ToInt32(textBox10.Text);
            zb.Mesto_izdavanja = textBox11.Text;
            zb.Datum_rodjenja = dateTimePicker1.Value;

            DTOManager.IzmeniZaposlenog(zb);
            MessageBox.Show("Uspesno izmenjen zaposleni.");
            this.Close();
        }
    }
}
