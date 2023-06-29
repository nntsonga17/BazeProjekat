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
    public partial class IzmeniStanForma : Form
    {
        ZgradaBasic zgrada;
        StanBasic ub = new StanBasic();
        public IzmeniStanForma()
        {
            InitializeComponent();
        }
        public IzmeniStanForma(StanBasic s,ZgradaBasic z)
        {
            InitializeComponent();
            ub = s;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            numericUpDown2.Value = ub.Sprat;
            numericUpDown1.Value = ub.Redni_broj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ub.Sprat = Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj = Convert.ToInt32(numericUpDown2.Value);

            DTOManager.AzurirajStan(ub);
            MessageBox.Show("Izmenjen stan.");
            this.Close();
        }
    }
}
