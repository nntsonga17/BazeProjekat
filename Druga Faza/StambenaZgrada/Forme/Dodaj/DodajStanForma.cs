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
    public partial class DodajStanForma : Form
    {
        ZgradaBasic zb;
        VlasnikStanaBasic vsb;
        public DodajStanForma()
        {
            InitializeComponent();
        }

        public DodajStanForma(/*VlasnikStanaBasic v,*/ ZgradaBasic z)
        {
            InitializeComponent();
           // vsb = v;
            zb = z;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {

            List<VlasnikStanaBasic> Lista = DTOManager.VratiSveVlasnike();
            foreach (VlasnikStanaBasic r in Lista)
                comboBox1.Items.Add(r);
        }

        private void button1_Click(object sender, EventArgs e)
        {

           StanBasic ub = new StanBasic();
            ub.Sprat = Convert.ToInt32(numericUpDown1.Value);
            ub.Redni_broj = Convert.ToInt32(numericUpDown2.Value);


            vsb = (VlasnikStanaBasic)comboBox1.SelectedItem;

            ub.Vlasnik = vsb; 
            ub.Zgrada = zb;

            DTOManager.SacuvajStan(ub);
            MessageBox.Show("Dodat stan.");
            this.Close();
        }

        
    }
}
