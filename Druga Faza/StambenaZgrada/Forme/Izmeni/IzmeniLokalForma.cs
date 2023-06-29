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
    public partial class IzmeniLokalForma : Form
    {
        ZgradaBasic zgrada;
        LokalBasic ub = new LokalBasic();
        public IzmeniLokalForma()
        {
            InitializeComponent();
        }
        public IzmeniLokalForma(LokalBasic l,ZgradaBasic z)
        {
            InitializeComponent();
            ub = l;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            numericUpDown2.Value = ub.Sprat;
            numericUpDown1.Value = ub.Redni_broj;
            textBox1.Text = ub.Naziv_firme;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ub.Sprat = Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj = Convert.ToInt32(numericUpDown2.Value);
            ub.Naziv_firme = textBox1.Text;


            DTOManager.AzurirajLokal(ub);
            MessageBox.Show("Izmenjen lokal.");
            this.Close();
        }
    }
}
