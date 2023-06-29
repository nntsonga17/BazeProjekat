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

namespace StambenaZgrada.Forme
{
    public partial class DodajZaposlenogForma : Form
    {
        

        public DodajZaposlenogForma()
        {
            InitializeComponent();
        }

        

       /* private void label4_Click(object sender, EventArgs e)
        {
            //
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            ZaposlenBasic zb = new ZaposlenBasic();
            zb.JMBG = Convert.ToInt64(textBox1.Text); //meni baca izuzetak i kad je int64 i kad je int32, vama više sreće s ovim želim
            zb.Ime_roditelja = textBox3.Text;
            zb.Licno_ime = textBox2.Text;
            zb.Prezime = textBox4.Text;
            zb.Br_telefona1 = textBox5.Text;
            zb.Br_telefona2 = textBox6.Text;
            zb.Mesto_stanovanja = textBox7.Text;
            zb.Ulica = textBox8.Text;
            zb.Broj = textBox9.Text;
            zb.Broj_licne_karte =Convert.ToInt32(textBox10.Text);
            zb.Mesto_izdavanja = textBox11.Text;
            zb.Datum_rodjenja = dateTimePicker1.Value;

            DTOManager.DodajZaposlenog(zb);
            MessageBox.Show("Uspesno dodat novi zaposleni.");
            this.Close();
            

        }
    }
}
