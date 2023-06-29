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
    public partial class IzmeniUlazForma : Form
    {
        ZgradaBasic zgrada;
        UlazBasic ub = new UlazBasic();
        public IzmeniUlazForma()
        {
            InitializeComponent();
        }

        public IzmeniUlazForma(UlazBasic u, ZgradaBasic z)
        {
            InitializeComponent();
            ub = u;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            numericUpDown1.Value = ub.Redni_broj;
            if (ub.Postojanje_kamere == 1)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            textBox1.Text = ub.Vreme_otvaranja;
            textBox2.Text = ub.Vreme_zatvaranja;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ub.Redni_broj = Convert.ToInt32(numericUpDown1.Value);
            if (checkBox1.Checked == true)
                ub.Postojanje_kamere = 1;
            else
                ub.Postojanje_kamere = 0;

            ub.Vreme_otvaranja = textBox1.Text;
            ub.Vreme_zatvaranja = textBox2.Text;

            DTOManager.IzmeniUlaz(ub);
            MessageBox.Show("Izmenjen ulaz.");
            this.Close();
        }
    }
}
