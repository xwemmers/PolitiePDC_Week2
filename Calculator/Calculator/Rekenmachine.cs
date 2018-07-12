using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Rekenmachine : IRekenen
    {
        public int Aftrekken(int a, int b)
        {
            return a - b;
        }

        public int Delen(int a, int b)
        {
            // Dit wil je niet!
            //if (b == 0)
            //    return 5;

            return a / b;
        }

        public int Kwadraat(int a)
        {
            System.Threading.Thread.Sleep(a * 1000);
            return a * a;
        }

        public Task<int> KwadraatAsync(int a)
        {
            // Deze functie roept ook Kwadraat aan, maar dan verpakt in een Task
            // zodat hij in de achtergrond gaat draaien
            var t = new Task<int>(() => Kwadraat(a));
            t.Start();
            return t;
        }

        public int Optellen(int a, int b)
        {
            checked
            {
                return a + b;
            }
        }

        public int Vermenigvuldigen(int a, int b)
        {
            // checked: als je binnen dat blok over de grenzen
            // van een integer heen gaat dan OverflowException
            checked
            {
                return a * b;
            }
        }
    }
}
