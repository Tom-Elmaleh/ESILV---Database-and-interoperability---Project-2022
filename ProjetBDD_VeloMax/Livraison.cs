using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Livraison
    {
        private string numP { get; set; }
        private string siret { get; set; }
        private DateTime date_introP { get; set; }
        private DateTime date_sortieP { get; set; }

        public Livraison(DateTime date_introP, DateTime date_sortieP,string numP,string siret)
        {
            this.numP = numP;
            this.siret = siret;
            this.date_sortieP = date_sortieP;
            this.date_introP = date_introP;
        }
    }
}
