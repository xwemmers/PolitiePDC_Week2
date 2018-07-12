using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin
{
    class Olifant : Dier
    {
        public override void Leven()
        {
            Energie -= 10;
        }
    }
}
