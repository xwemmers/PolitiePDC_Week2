using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;

namespace ExcelDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var app = new Microsoft.Office.Interop.Excel.Application();

            Workbook boek = app.Workbooks.Add();

            Worksheet sheet1 = boek.Worksheets.Add();
            Worksheet sheet2 = boek.Worksheets.Add();
            Worksheet sheet3 = boek.Worksheets.Add();

            sheet1.Name = "Januari";
            sheet2.Name = "Februari";
            sheet3.Name = "Maart";

            sheet1.Range["A1"].Value = "Xander";
            sheet1.Range["B1"].Value = "Wemmers";

            sheet1.Range["A3"].Value = 20;
            sheet1.Range["A4"].Value = 30;
            sheet1.Range["A5"].Value = "=SUM(A3:A4)";

            DateTime datum = new DateTime(2018, 7, 16);

            for (int i = 0; i < 14; i++)
            {
                sheet2.Range["A" + (datum.Day - 15)].Value = datum.ToString("dd-MM-yyyy");
                sheet2.Range["B" + (datum.Day - 15)].Value = "Warm en zonnig met een fris biertje er bij";
                datum = datum.AddDays(1);
            }

            //app.Visible = true;

            boek.SaveAs(@"c:\tmp\vakantieweer.xlsx");

            app.Quit();
        }
    }
}
