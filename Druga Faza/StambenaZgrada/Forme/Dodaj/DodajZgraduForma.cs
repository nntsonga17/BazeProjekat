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
    public partial class DodajZgraduForma : Form
    {
        //ProfesionalniUpravnikBasic p;
        //UgovorBasic u;
        /*public DodajZgraduForma()
        {
            InitializeComponent();
        }*/

        public DodajZgraduForma(/*ProfesionalniUpravnikBasic pub, UgovorBasic ub*/)
        {
            InitializeComponent();
            //p = pub;
            //u = ub;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            List<ProfesionalniUpravnikBasic> upravnik = DTOManager.VratiSveUpravnike();
            foreach (ProfesionalniUpravnikBasic b in upravnik)
                comboBox1.Items.Add(b);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ZgradaBasic z = new ZgradaBasic();
            z.Mesto = textBox1.Text;
            z.Ulica = textBox2.Text;
            z.Broj = textBox3.Text;
            z.Godina_izgradnje = Convert.ToInt32(textBox4.Text);
            z.Broj_jedinica = Convert.ToInt32(numericUpDown1.Value);

            z.Upravnik = (ProfesionalniUpravnikBasic)comboBox1.SelectedItem;
            //z.Ugovor = u;
            

            DTOManager.DodajZgradu(z);
            MessageBox.Show("Dodata zgrada.");
            this.Close();
        }

        
    }
}
