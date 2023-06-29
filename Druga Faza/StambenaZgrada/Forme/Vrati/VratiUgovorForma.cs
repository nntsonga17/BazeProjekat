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
    public partial class VratiUgovorForma : Form
    {
        //private static DateTime V = (Convert.ToDateTime(00-00-00));

        ZgradaBasic zg;

        /*public VratiUgovorForma()
        {
            InitializeComponent();       
        }*/

        public VratiUgovorForma(ZgradaBasic z)
        {
            zg = z;
            InitializeComponent();
            PopuniPodacima();
        }
        public void PopuniPodacima()
        {
           UgovorPregled ub = DTOManager.VratiUgovor(zg.ID_zgrade);

            //dateTimePicker1.Value = ub.Datum_potpisivanja ;
            textBox2.Text = Convert.ToString(ub.Datum_potpisivanja);
            if (ub.Vazenje_ugovora == 1)
                textBox1.Text = "1 godina";
            else
                if (ub.Vazenje_ugovora == 2)
                textBox1.Text = "2 godine";
            else
                      if (ub.Vazenje_ugovora == 3)
                textBox1.Text = "3 godine";

        }

        private void VratiUgovorForma_Load(object sender, EventArgs e)
        {
            //PopuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            UgovorPregled ub = DTOManager.VratiUgovor(zg.ID_zgrade);

            string poruka = "Da li želite da obrišete ugovor?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiUgovor(ub.Sifra);
                MessageBox.Show("Brisanje ugovora sa zgradom je uspešno obavljeno!");

                //this.dateTimePicker1.Value = V;
                this.textBox1.Text = "Ugovor je obrisan";
               
            }
            else
            {
                MessageBox.Show("Brisanje neuspešno.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            UgovorBasic ub = DTOManager.VratiUgovorBasic(zg.ID_zgrade);
            StambenaZgrada.Forme.Izmeni.IzmeniUgovorForma forma = new StambenaZgrada.Forme.Izmeni.IzmeniUgovorForma(ub, zg);
            forma.ShowDialog();
            PopuniPodacima();
        }
    }
}
