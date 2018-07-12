using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin
{
    class Leeuw : Dier
    {
        public override void Leven()
        {
            Energie -= 5;
        }
    }
}
