using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaExpressies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string eerste = namen.First();

            //MessageBox.Show(eerste);

            // Gebruik LINQ om de eerste naam met lengte 7 te vinden
            var query = from n in namen
                        where n.Length == 7
                        select n;

            string eersteVanZeven = query.First();

            // Alternatief: gebruik Lambda expressie om hetzelfde te doen:

            string eersteMetLambda = namen.First(n => n.Length == 7);

            var gesorteerd = namen.OrderBy(n => n.Length);
            listBox1.DataSource = gesorteerd.ToList();

            var korteNamen = namen.Where(n => n.Length == 4);


        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Dit is easy:
            //int som = getallen.Sum();

            // Maar hoe zit het met namen?
            // Gebruik een LambdaExpressie om te sommeren over de Length van de string
            int som = namen.Sum(n => n.Length);

            // Geef me alle even getallen mbv een Lambda
            var evenGetallen = getallen.Where(g => g % 2 == 0).OrderBy(g => g);

            listBox1.DataSource = evenGetallen.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Terug naar LINQ!
            // Geef me alle even getallen gesorteerd

            var query = from g in getallen.Distinct()
                        where g % 2 == 0
                        orderby g
                        select g;

            listBox1.DataSource = query.ToList();
        }

        int Optellen(int a, int b)
        {
            return a + b;
        }

        int Vermenigvuldigen(int a, int b) => a * b;

        private void button4_Click(object sender, EventArgs e)
        {
            // 
            Action actie1 = () => MessageBox.Show("Hello");
            Action actie2 = () => MessageBox.Show("World");

            Parallel.Invoke(actie1, actie2);

            // Hetzelfde maar dan in kortere notatie:
            Parallel.Invoke(
                    () => MessageBox.Show("Hello"),
                    () => MessageBox.Show("World")
                );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // TPL: Task Parallel Library

            Action<string> actie = (str) => MessageBox.Show(str);
            Action<int> actie2 = (num) => MessageBox.Show(num.ToString());

            // actie is gedefinieerd op type string
            //Parallel.ForEach(namen, actie);

            // actie2 werkt met int
            //Parallel.ForEach(getallen, actie2);

            // For werkt met from en to getallen
            Parallel.For(10, 20, actie2);
        }

        string[] namen = new[] { "Erik", "Jantinus", "Eric", "Maureen", "Sandy", "Henk", "Xander" };
        int[] getallen = new[] { 10, 9, 6, 12, 2, 8, 10, 2 };

        private void button6_Click(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();

            // De AsParallel() functie zorgt er voor dat de kwadraten
            // in parallel worden berekend.
            // Dit heet PLinq
            var query = from g in getallen.AsParallel().WithDegreeOfParallelism(8)
                        where Kwadraat(g) > 100
                        select g;

            // Dit kan ook in de lambda-syntax:
            var query2 = getallen.AsParallel().WithDegreeOfParallelism(8).Where(g => Kwadraat(g) > 100);

            // Hoe lang gaat dit duren?
            listBox1.DataSource = query.ToList();

            sw.Stop();
            label1.Text = string.Format("Dat duurde {0} milliseconden", sw.ElapsedMilliseconds);
        }

        int Kwadraat(int getal)
        {
            // Deze berekening duurt lang!
            System.Threading.Thread.Sleep(getal * 1000);
            return getal * getal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Action<string> actie = (naam) => MessageBox.Show(naam);

            // De actie mag je ook aanroepen alsof het een 'gewone' functie is:
            actie("Xander");

            // Kun je Kwadraat ook als een Action definieren?

            // Een Func is een lambda expressie met een return waarde (return type)
            // Func<inputtype, outputtype>

            Func<int, int> kwadraat = (num) => num * num;

            // Een hele korte schrijfwijze (lambda expr) voor een optellen functie
            // De laatste (vierde) int is het return type
            Func<int, int, int, int> som = (a, b, c) => a + b + c;

            //Func<List<int>, int> som2 = numbers => numbers.Sum();

            // De Func som mag je aanroepen alsof het een 'gewone' functie is:
            int totaal = som(2, 3, 4);

            MessageBox.Show(totaal.ToString());
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            int getal = int.Parse(textBox1.Text);

            // actie heeft een return waarde dus moet een Func<int> worden
            // Geen Action!
            Func<int> actie = () =>
            {
                int antwoord = Kwadraat(getal);
                return antwoord;
            };

            // Een taak is een actie die op de achtergrond gaat draaien!
            // Dus deze taak zal de UI niet doen bevriezen
            var taak = new Task<int>(actie);

            taak.Start();

            // Het opvragen van taak.Result is een 'blocking call'

            // Dit wacht op de taak zonder de UI te blokkeren
            // await en async (bij de functie definitie) gaan samen!
            // Als de taak is afgelopen zal hij taak.Result in de variabele result stoppen
            int result = await taak;

            listBox1.Items.Add(string.Format("Het kwadraat van {0} is {1}.", getal, result));
        }
    }
}
