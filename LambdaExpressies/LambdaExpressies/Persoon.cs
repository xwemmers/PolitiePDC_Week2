using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressies
{
    class Persoon
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public string VolledigeNaam
        {
            get
            {
                return Voornaam + " " + Achternaam;
            }
        }

        // Hetzelfde, maar dan met een Lambda expressie
        // Kortere notatie:
        public string VolledigeNaam2 => Voornaam + " " + Achternaam;

    }
}
