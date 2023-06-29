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
    public partial class DodajStanaraForma : Form
    {
        StanBasic nb;
        public DodajStanaraForma()
        {
            InitializeComponent();
        }


        public DodajStanaraForma(StanBasic n)
        {
            InitializeComponent();
            nb = n;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ImenaStanaraBasic lb = new ImenaStanaraBasic();

            lb.Ime_stanara = textBox1.Text;

            lb.Nivo = nb;

            DTOManager.SacuvajImeStanara(lb);
            MessageBox.Show("Dodat novi stanar.");
            this.Close();
        }

        
    }
}
