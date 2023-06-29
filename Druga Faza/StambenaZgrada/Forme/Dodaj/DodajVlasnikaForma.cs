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
    public partial class DodajVlasnikaForma : Form
    {
        // StambenaZgradaBasic zg;
       
        public DodajVlasnikaForma()
        {
            InitializeComponent();
        }
        /*public DodajVlasnikaForma(ZgradaBasic z)
        {
            InitializeComponent();
            zg = z;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            VlasnikStanaBasic z = new VlasnikStanaBasic();
            z.JMBG = Convert.ToInt64(textBox1.Text);
            z.Ime_roditelja = textBox3.Text;
            z.Licno_ime = textBox2.Text;
            z.Prezime = textBox4.Text;
            z.Br_telefona1 = textBox5.Text;
            z.Br_telefona2 = textBox6.Text;
            z.Mesto_stanovanja = textBox7.Text;
            z.Ulica = textBox8.Text;
            z.Broj = textBox9.Text;

            if (radioButton1.Checked == true)
                z.Tip_u_skupstini = 1;
            else
                if (radioButton2.Checked == true)
                z.Tip_u_skupstini = 2;
            else
                if (radioButton3.Checked == true)
                z.Tip_u_skupstini = 3;
            else
                if(radioButton4.Checked==true)
                z.Tip_u_skupstini = 0;

            

            DTOManager.DodajVlasnika(z);
            MessageBox.Show("Uspesno dodat novi vlasnik stana.");
            this.Close();

        }
    }
}
