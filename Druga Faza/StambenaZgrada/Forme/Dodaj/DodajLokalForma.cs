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
    public partial class DodajLokal : Form
    {
        ZgradaBasic zb;
        public DodajLokal()
        {
            InitializeComponent();
        }
        public DodajLokal(ZgradaBasic z)
        {
            InitializeComponent();
            zb = z;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LokalBasic ub = new LokalBasic();
            ub.Sprat= Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj= Convert.ToInt32(numericUpDown2.Value);
            ub.Naziv_firme = textBox1.Text;
            
            ub.Zgrada = zb;

            DTOManager.SacuvajLokal(ub);
            MessageBox.Show("Dodat novi lokal.");
            this.Close();
        }
    }
}
