using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlasWater
{
    class Glas
    {
        private int _temperatuur;

        public int Temperatuur
        {
            get { return _temperatuur; }
            set
            {
                _temperatuur = value;
                // Nu kunnen we de event raisen (fires)
                // De delegate EventHandler dwingt ons om twee argumenten mee te geven
                // object sender en EventArgs e

                // Check altijd op null want het kan zijn dat er geen Listeners zijn
                // voor deze event
                if (TemperatuurChanged != null)
                    TemperatuurChanged(DateTime.Now);

                if (Temperatuur >= 100 && Koken != null)
                    Koken(this, EventArgs.Empty);

                if (Temperatuur <= 0 && Bevriezen != null)
                    Bevriezen(this, EventArgs.Empty);

                if (Temperatuur > 0 && Temperatuur < 100 && Normaal != null)
                    Normaal(this, EventArgs.Empty);
            }
        }

        // Nu mijn eigen delegate
        // Nu met alleen een tijdstip!
        public delegate void TemperatuurChangedEventHandler(DateTime tijdstip);

        // De delegate is in dit geval de standaard EventHandler
        // Deze delegate schrijft voor dat straks een functie nodig is met
        // twee parameters object sender en EventArgs e
        public event TemperatuurChangedEventHandler TemperatuurChanged;
        public event EventHandler Koken;
        public event EventHandler Bevriezen;
        public event EventHandler Normaal;


        // Ook een event voor Koken > 100 graden
        // Ook een event voor Bevriezen < 0 graden
        

        public Glas()
        {
            Temperatuur = 20;
        }
    }
}
