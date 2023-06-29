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
    public partial class DodajUlaz : Form
    {
        ZgradaBasic zb;
        public DodajUlaz()
        {
            InitializeComponent();
        }

        public DodajUlaz(ZgradaBasic m)
        {
            InitializeComponent();
            zb = m;
        }

        /*private void label1_Click(object sender, EventArgs e)
        {
            //
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            UlazBasic ub = new UlazBasic();
            ub.Redni_broj =Convert.ToInt32( numericUpDown1.Value);
            if (checkBox1.Checked == true)
                ub.Postojanje_kamere = 1;
            else
                ub.Postojanje_kamere = 0;

            ub.Vreme_otvaranja = textBox1.Text;
            ub.Vreme_zatvaranja = textBox2.Text;

            ub.Zgrada = zb;
           
            DTOManager.SacuvajUlaz(ub);
            MessageBox.Show("Dodat novi ulaz.");
            this.Close();

        }

       /* private void label2_Click(object sender, EventArgs e)
        {
            //
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //
        }*/
    }
}
