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
    public partial class DodajParkingMestoForma : Form
    {
        ZgradaBasic zb;
        public DodajParkingMestoForma()
        {
            InitializeComponent();
        }

        public DodajParkingMestoForma(ZgradaBasic z)
        {
            InitializeComponent();
            zb = z;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParkingMestoBasic ub = new ParkingMestoBasic();
            ub.Sprat = Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj = Convert.ToInt32(numericUpDown2.Value);
            if (checkBox1.Checked == true)
                ub.Rezervisano = 1;
            else
                ub.Rezervisano = 0;

            ub.Zgrada = zb;

            DTOManager.SacuvajParkingMesto(ub);
            MessageBox.Show("Dodato novo parking mesto.");
            this.Close();
        }
    }
}
