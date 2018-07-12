using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // Het keyword partial zorgt er voor dat de class Persoon op meerdere plekken (files)
    // kan worden gedefinieerd.
    // Wordt met name gebruikt als een deel van de code wordt gegenereerd door VS of EF (Entity Framework)
    partial class Persoon
    {
        //public int Salaris { get; set; }

        private string _voornaam;

        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                if (value.Length >= 2)
                    _voornaam = value;
                else
                    throw new ArgumentException("De naam is te kort!");
            }
        }

        public string Achternaam { get; set; }

        #region Salaris Property

        private int _salaris;

        public int Salaris
        {
            get
            {
                return _salaris;
            }
            set
            {
                if (value >= 0)
                    _salaris = value;
                else
                    throw new ArgumentException("Het salaris is te laag!");
            }
        }
        #endregion
    }


    partial class Persoon
    {

    }
}
