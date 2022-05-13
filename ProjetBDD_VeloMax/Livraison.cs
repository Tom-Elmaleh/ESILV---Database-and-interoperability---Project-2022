using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Livraison
    {
        private string numP;
        private string siret;

        public Livraison(string numP,string siret)
        {
            this.numP = numP;
            this.siret = siret;
        }
    }
}
