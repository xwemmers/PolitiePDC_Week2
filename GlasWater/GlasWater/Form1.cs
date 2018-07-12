using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlasWater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Glas glasWater = new Glas();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Met += geef je aan dat het formulier naar de Event gaat luisteren
            glasWater.TemperatuurChanged += GlasWater_TemperatuurChanged;

            // Registreren voor events
            glasWater.Koken += GlasWater_Koken;
            glasWater.Bevriezen += GlasWater_Bevriezen;
            glasWater.Normaal += GlasWater_Normaal;

            // Deze aanroep is nodig zodat het label ook de initiele temperatuur toont
            glasWater.Temperatuur = 20;
        }

        private void GlasWater_Normaal(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
        }

        private void GlasWater_Bevriezen(object sender, EventArgs e)
        {
            label1.BackColor = Color.Blue;
            label1.ForeColor = Color.White;
        }

        private void GlasWater_Koken(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
            label1.ForeColor = Color.White;
        }

        private void GlasWater_TemperatuurChanged(DateTime dt)
        {
            label1.Text = string.Format("{0:HH:mm:ss} - De temperatuur is {1}.", dt, glasWater.Temperatuur);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            glasWater.Temperatuur--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            glasWater.Temperatuur++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            glasWater.Temperatuur -= 20;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            glasWater.Temperatuur += 20;
        }
    }
}
