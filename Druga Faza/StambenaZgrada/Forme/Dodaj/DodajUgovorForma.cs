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
    public partial class DodajUgovorForma : Form
    {
        ZgradaBasic zb;

        public DodajUgovorForma(ZgradaBasic z)
        {
            InitializeComponent();
            zb = z;
        }
        public DodajUgovorForma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UgovorBasic ub = new UgovorBasic();
            ub.Datum_potpisivanja = dateTimePicker1.Value;
            if (radioButton1.Checked == true)
                ub.Vazenje_ugovora = 1;
            else
                if (radioButton2.Checked == true)
                ub.Vazenje_ugovora = 2;
                else
                      if (radioButton3.Checked == true)
                      ub.Vazenje_ugovora = 3;

            ub.Zgrada = zb;

            DTOManager.SacuvajUgovor(ub);
            MessageBox.Show("Dodat novi ugovor.");
            this.Close();
        }

        private void DodajUgovorForma_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
