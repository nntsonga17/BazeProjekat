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
    public partial class IzmeniVlasnikaForma : Form
    {
        VlasnikStanaBasic z = new VlasnikStanaBasic();

        /*public IzmeniVlasnikaForma()
        {
            InitializeComponent();
        }*/

        public IzmeniVlasnikaForma(VlasnikStanaBasic vb)
        {
            InitializeComponent();
            z = vb;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            textBox1.Text = Convert.ToString(z.JMBG);
            textBox1.Enabled = false;
            textBox3.Text = z.Ime_roditelja;
            textBox2.Text = z.Licno_ime;
            textBox4.Text = z.Prezime;
            textBox5.Text = z.Br_telefona1;
            textBox6.Text = z.Br_telefona2;
            textBox7.Text = z.Mesto_stanovanja;
            textBox8.Text = z.Ulica;
             textBox9.Text = z.Broj;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            if (z.Tip_u_skupstini == 1)
                radioButton1.Checked = true;
            else
                if (z.Tip_u_skupstini == 2)
                radioButton2.Checked = true;
            else
                if (z.Tip_u_skupstini == 3)
                radioButton3.Checked = true;
            else
                if (z.Tip_u_skupstini == 0)
                radioButton4.Checked = true;


        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //z.JMBG = Convert.ToInt64(textBox1.Text);
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
                if (radioButton4.Checked==true)
                z.Tip_u_skupstini = 0;



            DTOManager.IzmeniVlasnika(z);
            MessageBox.Show("Izmenjen vlasnik stana.");
            this.Close();
        }
    }
}
