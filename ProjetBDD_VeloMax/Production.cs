using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Production
    {
        private DateTime date_introP;
        private DateTime date_sortieP;
        private string numP;
        private string siret;
        

        public Production(DateTime date_introP, DateTime date_sortieP,string numP,string siret)
        {
            this.date_introP = date_introP;
            this.date_sortieP = date_sortieP;
            this.numP = numP;
            this.siret = siret;
        }
    }
}
