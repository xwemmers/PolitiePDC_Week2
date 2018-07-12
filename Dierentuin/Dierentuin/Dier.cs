using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin
{
    abstract class Dier
    {
        // Constructor
        public Dier()
        {
            // Deze functie wordt altijd als eerste aangeroepen.
            // Dus zeer geschikt voor initialisatie van elk nieuw dier
            Energie = 20;
        }

        public string Naam { get; set; }
        public int Energie { get; set; }

        public virtual void Eten()
        {
            // virtual: je 'mag' deze functie overschrijven in een subclass
            Energie += 25;
        }

        // abstract: je 'moet' deze functie overschrijven in een subclass
        // Dus er is ook geen default implementatie
        public abstract void Leven();

        public override string ToString()
        {
            // override is het overschrijven van een bestaande functie
            return string.Format(GetType().Name + " {0} ({1})", Naam, Energie);
        }
    }
}
