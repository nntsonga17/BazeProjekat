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
    public partial class StanoviVlasnikaForma : Form
    {
        VlasnikStanaBasic vsb;
        public StanoviVlasnikaForma()
        {
            InitializeComponent();
        }

        public StanoviVlasnikaForma(VlasnikStanaBasic v)
        {
            InitializeComponent();
            vsb= v;
        }
            private void StanoviVlasnikaForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
        public void PopuniPodacima()
        {
            List<StanBasic> lista = DTOManager.VratiStanoveVlasnika(vsb.JMBG);
            this.listView1.Items.Clear();

            foreach (StanBasic r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.Sprat.ToString(),r.Redni_broj.ToString(), r.Zgrada.ToString() });

                this.listView1.Items.Add(item);
            }

            this.listView1.Refresh();
        }
    }
}
