using StambenaZgrada.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StambenaZgrada.Forme.Vrati
{
    public partial class OdaberiTipLiftaForma : Form
    {
        ZgradaBasic zgrada;
       /* public OdaberiTipLiftaForma()
        {
            InitializeComponent();
            zgrada = new ZgradaBasic();
        }*/

        public OdaberiTipLiftaForma(ZgradaBasic zg)
        {
            InitializeComponent();
            zgrada = zg;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VratiSvePutnickeLForma forma = new VratiSvePutnickeLForma(zgrada);
            forma.ShowDialog();
        }

        private void OdaberiTipLiftaForma_Load(object sender, EventArgs e)
        {
            //PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {

            VratiSveTeretneLForma forma = new VratiSveTeretneLForma(zgrada);
            forma.ShowDialog();
        }
    }
}
