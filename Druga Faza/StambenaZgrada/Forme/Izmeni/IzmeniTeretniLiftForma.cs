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
    public partial class IzmeniTeretniLiftForma : Form
    {
        ZgradaBasic zgrada;
        TeretniLiftBasic ub = new TeretniLiftBasic();
        public IzmeniTeretniLiftForma()
        {
            InitializeComponent();
        }
        public IzmeniTeretniLiftForma(TeretniLiftBasic t, ZgradaBasic z)
        {
            InitializeComponent();
            ub = t;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            dateTimePicker1.Value = ub.Datum_poslednjeg_kvara;
            dateTimePicker2.Value = ub.Datum_poslednjeg_servisa;
            textBox1.Text = ub.Naziv_proizvodjaca;
            numericUpDown1.Value = Convert.ToDecimal(ub.Nosivost);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ub.Datum_poslednjeg_kvara = dateTimePicker1.Value;
            ub.Datum_poslednjeg_servisa = dateTimePicker2.Value;
            ub.Naziv_proizvodjaca = textBox1.Text;
            ub.Nosivost = Convert.ToDouble(numericUpDown1.Value);


            DTOManager.IzmeniTeretniLift(ub);
            MessageBox.Show("Izmenjen teretni lift.");
            this.Close();
        }
    }
}
