using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Modele
    {
        private int numM;
        private string nomVelo;
        private string grandeur;
        private int prix;
        private string ligne;
        private DateTime date_introV;
        private DateTime date_sortieV;
        private int stockM;

        public int Stock { get { return stockM; } set { stockM = value; } }

        public Modele(int numM,string nomVelo,string grandeur,int prix,DateTime date_introV, DateTime date_sortieV,int stockM)
        {
            this.numM = numM;
            this.nomVelo = nomVelo;
            this.grandeur = grandeur;
            this.prix = prix;
            this.date_introV = date_introV;
            this.date_sortieV = date_sortieV;
            this.stockM = stockM;
        }

        public override string ToString()
        {
            string resultat = $"{numM}|{nomVelo}|{grandeur}|{prix}|{date_introV}|{date_sortieV}|{stockM}";
            return resultat;
        }
    }
}
