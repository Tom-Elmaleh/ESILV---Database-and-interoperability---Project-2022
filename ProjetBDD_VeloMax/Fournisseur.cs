using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Fournisseur
    {
        private string siret;
        private string nomF;
        private string adresseF;
        private string contactF;
        private int libelle;
        private int stockF;

        public string SIRET { get { return siret; } set { siret = value; } }
        public string Nom { get { return nomF; } set { nomF = value; } }
        public int Stock { get { if (stockF < 10) return stockF; else return -1; } set { stockF = value; } }


        public Fournisseur(string siret,string nomF,string adresseF,string contactF,int libelle,int stockF)
        {
            this.siret = siret;
            this.nomF = nomF;
            this.adresseF = adresseF;
            this.contactF = contactF;
            this.libelle = libelle;
            this.stockF = stockF;
        }

        public Fournisseur(string siret, string nomF, int stockF)
           : this(siret,nomF,"","",-1, stockF)
        {
        }

        public Fournisseur()
            : this("N/C", "N/C", 0)
        {
        }

        public override string ToString()
        {
            return siret + nomF + stockF;
        }
    }
}
