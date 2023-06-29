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
    public partial class IzmeniParkingMForma : Form
    {
        ZgradaBasic zgrada;
        ParkingMestoBasic ub = new ParkingMestoBasic();
        public IzmeniParkingMForma()
        {
            InitializeComponent();
        }
        public IzmeniParkingMForma(ParkingMestoBasic p,ZgradaBasic z)
        {
            InitializeComponent();
            ub = p;
            zgrada = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
             numericUpDown2.Value = ub.Sprat;
             numericUpDown1.Value = ub.Redni_broj;
            if (ub.Rezervisano == 1)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false; ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ub.Sprat = Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj = Convert.ToInt32(numericUpDown2.Value);
            if (checkBox1.Checked == true)
                ub.Rezervisano = 1;
            else
                ub.Rezervisano = 0;


            DTOManager.AzurirajParkingMesto(ub);
            MessageBox.Show("Izmenjeno parking mesto.");
            this.Close();
        }
    }
}
