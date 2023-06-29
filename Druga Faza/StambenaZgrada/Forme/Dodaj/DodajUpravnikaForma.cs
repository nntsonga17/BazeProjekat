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
    public partial class DodajUpravnikaForma : Form
    {
        //LicencaBasic l;
        public DodajUpravnikaForma()
        {
            InitializeComponent();
        }

       /* public DodajUpravnikaForma(LicencaBasic lb)
        {
            InitializeComponent();
            l = lb;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {

            ProfesionalniUpravnikBasic z = new ProfesionalniUpravnikBasic();
            z.JMBG = Convert.ToInt64(textBox1.Text);
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

           // z.Ima_licencu = l;

            DTOManager.DodajUpravnika(z);
            MessageBox.Show("Uspešno dodat novi upravnik.");
            this.Close();
        }
    }
}
