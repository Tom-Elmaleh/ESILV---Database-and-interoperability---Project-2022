using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Commande
    {
        private int numC { get; set; }
        private DateTime dateC { get; set; }
        private DateTime dateLivraison { get; set; }
        private string adresseC { get; set; }
        private string nomE { get; set; }
        private int id { get; set; }

        public Commande(int numC, DateTime dateC, DateTime dateLivraison,string adresseC,string nomE,int id)
        {
            this.numC = numC;
            this.dateC = dateC;
            this.dateLivraison = dateLivraison;
            this.adresseC = adresseC;
            this.nomE = nomE;
            this.id = id;
        }
    }
}
