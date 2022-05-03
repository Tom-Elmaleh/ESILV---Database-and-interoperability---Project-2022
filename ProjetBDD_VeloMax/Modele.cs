using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Modele
    {
        private int numM { get; set; }
        private string nomVelo { get; set; }
        private string grandeur { get; set; }
        private int prix { get; set; }
        private string ligne { get; set; }
        private DateTime date_introV { get; set; }
        private DateTime date_sortieV { get; set; }

        public Modele()
        {

        }

        public Modele(int numM,string nomVelo,string grandeur,int prix,DateTime date_introV, DateTime date_sortieV)
        {
            this.numM = numM;
            this.nomVelo = nomVelo;
            this.grandeur = grandeur;
            this.prix = prix;
            this.date_introV = date_introV;
            this.date_sortieV = date_sortieV;
        }

        public override string ToString()
        {
            string resultat = $"{numM}|{nomVelo}|{grandeur}|{prix}|{date_introV}|{date_sortieV}";
            return resultat;
        }
    }
}
