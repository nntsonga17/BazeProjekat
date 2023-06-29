using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StambenaZgrada
{
    public partial class PocetnaStrana : Form
    {
        public PocetnaStrana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StambenaZgrada.Forme.Vrati.VratiZaposleneForma f = new StambenaZgrada.Forme.Vrati.VratiZaposleneForma();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           StambenaZgrada.Forme.Vrati.VratiZgradeForma f = new StambenaZgrada.Forme.Vrati.VratiZgradeForma();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           StambenaZgrada.Forme.Vrati.VratiVlasnikeForma forma = new StambenaZgrada.Forme.Vrati.VratiVlasnikeForma();
            forma.ShowDialog();
        }
    }
}
