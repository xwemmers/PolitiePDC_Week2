using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace Landen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // System.Net.Http is een NuGet package maar helaas installeert die niet in 
            // Visual Studio in de versie van de cursusinstallatie. 

            // Data ophalen! Web api voor alle landen van de wereld

            HttpClient client = new HttpClient();
            

            // Dit is een asynchrone functie, zodat de aanroep niet de UI zal doen bevriezen
            // Met await kun je deze functie het makkelijkste aanroepen
            string jsondata = await client.GetStringAsync("https://restcountries.eu/rest/v2");

            // JSON parsen: van string naar Country
            // Gebruik daarvoor NewtonSoft.Json package in NuGet

            List<Country> allelanden = JsonConvert.DeserializeObject<List<Country>>(jsondata);

            var query = from l in allelanden
                        //where l.Region == "Europe"
                        orderby l.Population descending
                        select l;

            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.GetAsync("http://nu.nl"); // Dit haalt HTML op
        }
    }
}
