using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StambenaZgrada.Forme.Izmeni
{
    public partial class IzmeniUpravnikaForma : Form
    {
        ProfesionalniUpravnikBasic z = new ProfesionalniUpravnikBasic();
        public IzmeniUpravnikaForma()
        {
            InitializeComponent();
        }

        public IzmeniUpravnikaForma(ProfesionalniUpravnikBasic u)
        {
            InitializeComponent();
            z = u;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            textBox1.Text =Convert.ToString(z.JMBG);
            textBox1.Enabled = false;
            textBox3.Text = z.Ime_roditelja;
            textBox2.Text = z.Licno_ime;
            textBox4.Text = z.Prezime;
            textBox5.Text = z.Br_telefona1;
            textBox6.Text = z.Br_telefona2;
            textBox7.Text = z.Mesto_stanovanja;
            textBox8.Text = z.Ulica;
            textBox9.Text = z.Broj;
            textBox10.Text =Convert.ToString( z.Broj_licne_karte);
            textBox11.Text = z.Mesto_izdavanja;
            dateTimePicker2.Value = z.Datum_rodjenja;

            z.Zvanje = textBox13.Text;
            z.Naziv_institucije = textBox14.Text;
            z.Datum_sticanja_diplome = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //z.JMBG = Convert.ToInt64(textBox1.Text);
            z.Ime_roditelja = textBox3.Text;
            z.Licno_ime = textBox2.Text;
            z.Prezime = textBox4.Text;
            z.Br_telefona1 = textBox5.Text;
            z.Br_telefona2 = textBox6.Text;
            z.Mesto_stanovanja = textBox7.Text;
            z.Ulica = textBox8.Text;
            z.Broj = textBox9.Text;
            z.Broj_licne_karte = Convert.ToInt32(textBox10.Text);
            z.Mesto_izdavanja = textBox11.Text;
            z.Datum_rodjenja = dateTimePicker2.Value;

            z.Zvanje = textBox13.Text;
            z.Naziv_institucije = textBox14.Text;
            z.Datum_sticanja_diplome = dateTimePicker1.Value;


            DTOManager.IzmeniUpravnika(z);
            MessageBox.Show("Izmenjen upravnik.");
            this.Close();
        }
    }
}
