using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataModule
    {
        public DataRow GetProductById(int blub)
        {
            var param = new SqlParameter("id", blub);

            // SQL injection
            DataTable dt = GetData("select * from SalesLT.Product where ProductID = @id", param);
            return dt.Rows[0];
        }

        public DataTable GetExpensiveProducts()
        {
            return GetData("select * from SalesLT.Product where ListPrice > 1000");
        }

        public DataTable GetData(string sql, SqlParameter p = null)
        {
            // Queries zonder Entity Framework
            // ADO.NET

            // Maak een connectie object met de connection string
            // De connectionstring bevat alle informatie om de connectie te openen

            var connectie = new SqlConnection("Data Source=dbserverxw.database.windows.net; Initial Catalog=AdventureWorks; User Id=SqlAdmin; Pwd=Pa$$w0rd");

            // In de praktijk (in productie) wordt meestal Integrated Security gebruikt:
            //var connectie = new SqlConnection("Data Source=dbserverxw.database.windows.net; Initial Catalog=AdventureWorks; Integrated Security=True");

            // Definieer de query
            //string sql = "select * from SalesLT.Product where ListPrice > 1000";
            //string sql = "GetProducts";

            // Maak een Command object dat de query kan gaan uitvoeren
            var cmd = new SqlCommand(sql, connectie);

            if (p != null)
                cmd.Parameters.Add(p);
            // Geef eventueel aan dat de string sql een Stored Procedure naam is:
            //cmd.CommandType = CommandType.StoredProcedure;

            // Een DataTable om het eindresultaat in op te slaan
            var dt = new DataTable();

            // Een Adapter om de DataTable te vullen (op basis van het Command)
            var adapter = new SqlDataAdapter(cmd);

            // Voer de query uit!
            connectie.Open();
            adapter.Fill(dt);
            connectie.Close();

            return dt;
        }


        public int Execute(string sql)
        {
            var connectie = new SqlConnection("Data Source=dbserverxw.database.windows.net; Initial Catalog=AdventureWorks; User Id=SqlAdmin; Pwd=Pa$$w0rd");
            var cmd = new SqlCommand(sql, connectie);

            // Als de sql een insert/update/delete bevat dat heb 
            // je ExecuteNonQuery() nodig!
            int aantal = cmd.ExecuteNonQuery();

            return aantal;
        }
    }
}
