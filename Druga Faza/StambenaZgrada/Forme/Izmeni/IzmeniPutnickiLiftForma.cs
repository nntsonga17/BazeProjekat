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
   
    public partial class IzmeniPutnickiLiftForma : Form
    {
        ZgradaBasic zg;

        PutnickiLiftBasic ub = new PutnickiLiftBasic();
        public IzmeniPutnickiLiftForma()
        {
            InitializeComponent();
        }
        public IzmeniPutnickiLiftForma(PutnickiLiftBasic p,ZgradaBasic zgrada)
        {
            InitializeComponent();
            ub = p;
            zg = zgrada;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            dateTimePicker1.Value = ub.Datum_poslednjeg_kvara;
            dateTimePicker2.Value = ub.Datum_poslednjeg_servisa;
            textBox1.Text = ub.Naziv_proizvodjaca;
            numericUpDown1.Value = ub.Max_broj_osoba;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ub.Datum_poslednjeg_kvara = dateTimePicker1.Value;
            ub.Datum_poslednjeg_servisa = dateTimePicker2.Value;
            ub.Naziv_proizvodjaca = textBox1.Text;
            ub.Max_broj_osoba = Convert.ToInt32(numericUpDown1.Value);


            DTOManager.IzmeniPutnickiLift(ub);
            MessageBox.Show("Izmenjen putnicki lift.");
            this.Close();
        }
    }
}
