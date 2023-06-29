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
    public partial class DodajPutnickiLiftForma : Form
    {
        ZgradaBasic zb;
        public DodajPutnickiLiftForma()
        {
            InitializeComponent();
        }

        public DodajPutnickiLiftForma(ZgradaBasic z)
        {
            InitializeComponent();
            zb = z;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PutnickiLiftBasic ub = new PutnickiLiftBasic();
            ub.Datum_poslednjeg_kvara = dateTimePicker1.Value;
            ub.Datum_poslednjeg_servisa = dateTimePicker2.Value;
            ub.Naziv_proizvodjaca = textBox1.Text;
            ub.Max_broj_osoba = Convert.ToInt32(numericUpDown1.Value);
            
            ub.Ima_lift= zb;

            DTOManager.SacuvajPutnickiLift(ub);
            MessageBox.Show("Dodat novi putnicki lift.");
            this.Close();
        }
    }
}
