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
    public partial class VratiZgradeUpravnikaForma : Form
    {
        ProfesionalniUpravnikBasic upr;
        public VratiZgradeUpravnikaForma()
        {
            InitializeComponent();
        }
        public VratiZgradeUpravnikaForma(ProfesionalniUpravnikBasic p)
        {
            InitializeComponent();
            upr = p;
        }

        public int brojZaposlenih = 0;
        private void VratiZgradeUpravnikaForma_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            this.brojZaposlenih = 0;

            List<ZgradaPregled> lista = DTOManager.VratiZgradeNekogUpravnika(upr.JMBG);
            this.listView1.Items.Clear();

            foreach (ZgradaPregled r in lista)
            {

                ListViewItem item = new ListViewItem(new string[] { r.Mesto,r.Ulica,r.Broj,r.Broj_jedinica.ToString(),r.Godina_izgradnje.ToString()});
                this.listView1.Items.Add(item);
                this.brojZaposlenih++;
            }

            textBox1.Text = this.brojZaposlenih.ToString();
            this.listView1.Refresh();
        }
    }
}
