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
    public partial class IzmeniStanaraForma : Form
    {
        ImenaStanaraBasic lb = new ImenaStanaraBasic();
        public IzmeniStanaraForma()
        {
            InitializeComponent();
        }

        public IzmeniStanaraForma(ImenaStanaraBasic s)
        {
            InitializeComponent();
            lb = s;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
           textBox1.Text = lb.Ime_stanara;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            lb.Ime_stanara = textBox1.Text;

            string imeS = textBox1.Text;

            DTOManager.AzurirajImeStanara(lb.ID_stanari, imeS);
            MessageBox.Show("Izmenjen stanar.");
            this.Close();
        }

        private void IzmeniStanaraForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
    }
}
