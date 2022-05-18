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


        public int NumM { get { return numM; } set { numM = value; } }
        public string NomVelo { get { return nomVelo; } set { nomVelo = value; } }
        public string Grandeur { get { return grandeur; } set { grandeur = value; } }
        public int Prix { get { return prix; } set { prix = value; } }
        public string Ligne { get { return ligne; } set { ligne = value; } }
        public DateTime Date_Intro { get { return date_introV; } set { date_introV = value; } }
        public DateTime Date_Sortie { get { return date_sortieV; } set { date_sortieV = value; } }
        public int Stock { get { return stockM; } set { stockM = value; } }

        public Modele(int numM, string nomVelo, string grandeur, string ligne, int prix, DateTime date_introV, DateTime date_sortieV, int stockM)
        {
            this.numM = numM;
            this.nomVelo = nomVelo;
            this.grandeur = grandeur;
            this.ligne = ligne;
            this.prix = prix;
            this.date_introV = date_introV;
            this.date_sortieV = date_sortieV;
            this.stockM = stockM;
        }

        public override string ToString()
        {
            return $"numM : {numM} | nomVelo : {nomVelo} | grandeur : {grandeur} | prix : {prix}|" +
            $"ligne : {ligne} | date_introV : {AffichageDate(date_introV)} | date_sortieV : {AffichageDate(date_sortieV)} | stockM : {stockM}";
        }

        public string AffichageDate(DateTime date)
        {
            return $"{Convert.ToString(date.Day)}/{Convert.ToString(date.Month)}/{Convert.ToString(date.Year)}";
        }
    }
}
