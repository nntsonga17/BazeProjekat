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
    public partial class IzmeniZgraduForma : Form
    {
        ZgradaBasic z = new ZgradaBasic();
        public IzmeniZgraduForma()
        {
            InitializeComponent();
        }

        public IzmeniZgraduForma(ZgradaBasic zb)
        {
            InitializeComponent();
            z = zb;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            textBox1.Text = z.Mesto;
            textBox2.Text = z.Ulica;
            textBox3.Text = z.Broj;
            textBox4.Text = Convert.ToString(z.Broj_jedinica);
            numericUpDown1.Value =z.Godina_izgradnje;
        }
       /* private void label1_Click(object sender, EventArgs e)
        {
            //
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            z.Mesto = textBox1.Text;
            z.Ulica = textBox2.Text;
            z.Broj = textBox3.Text;
            z.Godina_izgradnje = Convert.ToInt32(textBox4.Text);
            z.Broj_jedinica = Convert.ToInt32(numericUpDown1.Value);


            DTOManager.AzurirajZgradu(z);
            MessageBox.Show("Izmenjena zgrada.");
            this.Close();
        }
    }
}
