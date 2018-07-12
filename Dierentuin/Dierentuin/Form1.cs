using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dierentuin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Dier> AllAnimals = new List<Dier>();

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new Aap();
            a.Naam = "Sandy";

            AllAnimals.Add(a);

            RefreshUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var l = new Leeuw();
            l.Naam = "Elsa";

            AllAnimals.Add(l);
            RefreshUI();
        }

        void RefreshUI()
        {
            // Toon de verzameling in UI
            // Vergeet niet om de DataSource te refreshen!
            lbxDieren.DataSource = null;
            dgvDieren.DataSource = null;
            lbxDieren.DataSource = AllAnimals;
            dgvDieren.DataSource = AllAnimals;
        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            var o = new Olifant();
            o.Naam = "Mauk";
            AllAnimals.Add(o);
            RefreshUI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Dier d in AllAnimals)
            {
                d.Eten();
            }

            RefreshUI();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Dier d in AllAnimals)
            {
                // Het keyword 'is' kijkt of het type dier een Aap is
                if (d is Aap)
                    d.Eten();
            }

            RefreshUI();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // De functie OfType<Leeuw> maakt eerst een subselectie van alle leeuwen
            foreach (Leeuw l in AllAnimals.OfType<Leeuw>())
            {
                l.Eten();
            }

            RefreshUI();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Olifanten voederen!

            foreach (Dier dier in AllAnimals)
            {
                if (dier is Olifant)
                {
                    // (Aap) is het casten van de variabele dier
                    Olifant ollie = (Olifant)dier;

                    ollie.Eten();
                }
            }

            RefreshUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Het object timer kan heeft een tick event
            var timer = new Timer();

            timer.Interval = 1000; // in milliseconden

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // als Energie < 0 dan verwijder uit verzameling
            // Tel van achteren naar voren!
            // Gebruik geen foreach(...) want dan mag je de verzameling niet aanpassen
            for (int i = AllAnimals.Count - 1; i >= 0; i--)
            {
                Dier d = AllAnimals[i];

                d.Leven();

                if (d.Energie < 0)
                    AllAnimals.Remove(d);
            }

            RefreshUI();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                // Dit is ook Inheritance. Control is de base class
                // TextBox, Button, ListBox etc zijn afgeleide classes
                // == Derived classes

                if (c is TextBox)
                    c.Text = "";
            }
        }
    }
}
