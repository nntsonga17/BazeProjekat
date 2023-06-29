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

namespace StambenaZgrada.Forme
{
    public partial class DodajLicencuForma : Form
    {
        ProfesionalniUpravnikBasic pub;
        public DodajLicencuForma()
        {
            InitializeComponent();
            pub = new ProfesionalniUpravnikBasic();
        }

        public DodajLicencuForma(ProfesionalniUpravnikBasic pu)
        {
            InitializeComponent();
            pub = pu;
        }

       /* private void DodajLicencuForma_Load(object sender, EventArgs e)
        {
            //
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            LicencaBasic lb = new LicencaBasic();

            lb.Datum_sticanja_obnavljanja = dateTimePicker1.Value;
            lb.Naziv_insitucije = textBox2.Text;
            lb.Broj_licence = Convert.ToInt32(textBox1.Text);
            lb.Upravnik = pub;

            DTOManager.SacuvajLicencu(lb);
            MessageBox.Show("Dodata licenca.");
            this.Close();
        }
    }
}
