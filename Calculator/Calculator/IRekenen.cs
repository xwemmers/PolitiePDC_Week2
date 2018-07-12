using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface IRekenen
    {
        // Een interface legt alleen vast welke functies moeten bestaan
        // Dus niet hoe die functies geimplementeerd worden
        // De implementatie komt niet in de interface, maar in een class!

        int Optellen(int a, int b);

        int Aftrekken(int a, int b);

        int Vermenigvuldigen(int a, int b);

        int Delen(int a, int b);

        int Kwadraat(int a);

        // De asynchrone variant geeft een Task<int> terug
        Task<int> KwadraatAsync(int a);


    }
}
