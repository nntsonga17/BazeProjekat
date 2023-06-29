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
    public partial class IzmeniLicencuForma : Form
    {
        LicencaBasic lb = new LicencaBasic();
        ProfesionalniUpravnikBasic pb;
        public IzmeniLicencuForma()
        {
            InitializeComponent();
        }
        public IzmeniLicencuForma(LicencaBasic l,ProfesionalniUpravnikBasic p)
        {
            InitializeComponent();
            lb = l;
            pb = p;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            dateTimePicker1.Value = lb.Datum_sticanja_obnavljanja;
            textBox2.Text = lb.Naziv_insitucije;
            textBox1.Text =Convert.ToString( lb.Broj_licence);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lb.Datum_sticanja_obnavljanja = dateTimePicker1.Value;
            lb.Naziv_insitucije = textBox2.Text;
            lb.Broj_licence = Convert.ToInt32(textBox1.Text);

            DTOManager.IzmeniLicencu(lb);
            MessageBox.Show("Izmenjena licenca.");
            this.Close();
        }
    }
}
