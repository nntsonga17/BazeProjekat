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
    public partial class DodajTeretniLiftForma : Form
    {
        ZgradaBasic zb;
        public DodajTeretniLiftForma()
        {
            InitializeComponent();
        }

        public DodajTeretniLiftForma(ZgradaBasic z)
        {
            InitializeComponent();
            zb = z;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeretniLiftBasic ub = new TeretniLiftBasic();
            ub.Datum_poslednjeg_kvara = dateTimePicker1.Value;
            ub.Datum_poslednjeg_servisa = dateTimePicker2.Value;
            ub.Naziv_proizvodjaca = textBox1.Text;
            ub.Nosivost = Convert.ToDouble(numericUpDown1.Value);

            ub.Ima_lift = zb;

            DTOManager.SacuvajTeretniLift(ub);
            MessageBox.Show("Dodat novi teretni lift.");
            this.Close();
        }
    }
}
