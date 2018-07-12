using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin
{
    class Aap : Dier
    {
        public Aap()
        {
            // Dit is initializatie voor elke nieuwe aap
            Energie = 30;
        }

        public override void Eten()
        {
            // Dit is een override van de default 
            // zoals die is gedefinieerd in class Dier
            Energie += 10;
        }

        public override void Leven()
        {
            Energie -= 20;
        }

    }
}
