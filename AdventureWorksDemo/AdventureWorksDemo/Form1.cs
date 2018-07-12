using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataLayer;

namespace AdventureWorksDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Change tracking
        // Form1 niveau bestaat het db object
        // Dus daardoor ook beschikbaar in alle functies binnen Form1
        AdventureWorksEntities db = new AdventureWorksEntities();

        private void button1_Click(object sender, EventArgs e)
        {

            var query = from p in db.Products
                        where p.Name.Contains("bike")
                        || p.ProductCategory.Name.Contains("bike")
                        select p;

            // Laat de SQL zien
            //MessageBox.Show(query.ToString());

            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // De 20 duurste producten (ListPrice)

            var query = from p in db.Products
                        orderby p.ListPrice descending
                        select new
                        {
                            p.Name,
                            p.ListPrice,
                            p.Color,
                            p.ProductNumber,
                            p.ModifiedDate,
                            CategoryName = p.ProductCategory.Name
                        };

            // Pak de eerste twintig met de Take functie!
            var results = query.Take(20).ToList();

            // Het keyword var bepaalt zelf automatisch het juiste type!
            
            // In dit geval is results van het type List <anonymous type>



            // Laat de SQL zien
            MessageBox.Show(query.ToString());

            dataGridView1.DataSource = results;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sla de wijzigingen op die gebruiker gemaakt heeft:
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var nieuw = new ProductCategory();

            nieuw.Name = "Xander's fietsen";
            nieuw.ModifiedDate = DateTime.Now;
            nieuw.rowguid = Guid.NewGuid();
            // etc

            db.ProductCategories.Add(nieuw);
            db.SaveChanges();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ProductCategories.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var dbc = new DatabaseComponent();

            dataGridView1.DataSource = dbc.GetExpensiveProducts();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var dbc = new DataModule();
            DataRow row = dbc.GetProductById(1036);

            // Toon de naam en de listprice!
            MessageBox.Show(string.Format("De prijs van {0} is $ {1}.", row["Name"], row["ListPrice"]));

            // Zonder Entity Framework is alles weakly typed.
            // Er is geen intellisense dus veldnamen moet je zelf weten
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dit is het toppunt van SQL Injection!
            // Don't try this at home
            var dbc = new DataModule();
            dataGridView1.DataSource = dbc.GetData(textBox1.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var dbc = new DatabaseComponent();

            // Verhoog in prijs
            int aantal = dbc.Execute("update SalesLT.Product set ListPrice = ListPrice + 1 where ProductID = 1036");

            // Haal de data opnieuw op
            dataGridView1.DataSource = dbc.GetExpensiveProducts();
        }
    }
}
