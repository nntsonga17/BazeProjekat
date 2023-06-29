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
    public partial class IzmeniUgovorForma : Form
    {
        ZgradaBasic zgrada;
        UgovorBasic ub = new UgovorBasic();
        public IzmeniUgovorForma()
        {
            InitializeComponent();
        }
        public IzmeniUgovorForma(UgovorBasic u,ZgradaBasic z)
        {
            InitializeComponent();
            ub = u;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            //dateTimePicker1.Value = ub.Datum_potpisivanja;
            if (ub.Vazenje_ugovora == 1)
                radioButton1.Checked = true;
            else
                if (ub.Vazenje_ugovora == 2)
                radioButton2.Checked = true;
            else
                      if (ub.Vazenje_ugovora == 3)
                radioButton3.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ub.Datum_potpisivanja = dateTimePicker1.Value;
            if (radioButton1.Checked == true)
                ub.Vazenje_ugovora = 1;
            else
                if (radioButton2.Checked == true)
                ub.Vazenje_ugovora = 2;
            else
                      if (radioButton3.Checked == true)
                ub.Vazenje_ugovora = 3;


            DTOManager.IzmeniUgovor(ub);
            MessageBox.Show("Izmenjen ugovor.");
            this.Close();
        }
    }
}
