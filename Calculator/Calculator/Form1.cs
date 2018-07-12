using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int getal = int.Parse(textBox1.Text);

            var machine = new Rekenmachine();

            // Dit is de oldfashioned oude versie: synchroon! 
            // Dus blokkeert de UI :-(
            int antwoord = machine.Kwadraat(getal);

            listBox1.Items.Add(string.Format("Het kwadraat van {0} is {1}.", getal, antwoord));

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int getal = int.Parse(textBox1.Text);

            var machine = new Rekenmachine();

            // Hier roepen we de Asynchrone variant aan
            // User interface blijft actief!
            int antwoord = await machine.KwadraatAsync(getal);

            listBox1.Items.Add(string.Format("Het kwadraat van {0} is {1}.", getal, antwoord));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Persoon();
                p.Voornaam = "Xander";
                p.Achternaam = "W";
                p.Salaris = 100;

                Persoon p2 = p;

                // p en p2 zijn beide een reference naar een en hetzelfde object!

                p.Voornaam = "Simone";

                // Dit is een echte copy
                // Dit is ook een nieuw object in het geheugen!
                var p3 = new Persoon();
                p3.Voornaam = p.Voornaam;
                p3.Achternaam = p.Achternaam;
                p3.Salaris = p.Salaris;

                p3.Voornaam = "Jasper";

                // Dit toont twee keer Simone
                MessageBox.Show(p.Voornaam); // Simone
                MessageBox.Show(p2.Voornaam); // Simone
                // En deze toont Jasper
                MessageBox.Show(p3.Voornaam); // Jasper
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
