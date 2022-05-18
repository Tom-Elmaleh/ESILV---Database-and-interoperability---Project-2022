using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    public class Commande
    {
        private int numC;
        private DateTime dateC;
        private DateTime dateLivraison;
        private string adresseC;
        private string nomE;
        private int id;

        public int NumC { get { return numC; } set { numC = value; } }
        public DateTime DateC { get { return dateC; } set { dateC = value; } }
        public DateTime DateL { get { return dateLivraison; } set { dateLivraison = value; } }
        public string Adresse { get { return adresseC; } set { adresseC = value; } }
        public string Nom { get { return nomE; } set { nomE = value; } }
        public int ID { get { return id; } set { id = value; } }

        public Commande(int numC, DateTime dateC, DateTime dateLivraison, string adresseC, string nomE)
        {
            this.numC = numC;
            this.dateC = dateC;
            this.dateLivraison = dateLivraison;
            this.adresseC = adresseC;
            this.nomE = nomE;
            id = -1;
        }

        public Commande(int numC, DateTime dateC, DateTime dateLivraison, string adresseC, int id)
        {
            this.numC = numC;
            this.dateC = dateC;
            this.dateLivraison = dateLivraison;
            this.adresseC = adresseC;
            this.id = id;
            nomE = "";
        }

        public override string ToString()
        {
            string resul = "";
            if (id == -1)
            {
                resul = $"numC : {numC} | date_Livraison : {AffichageDate(dateLivraison)} | adresseC : {adresseC} | nomE : {nomE}";
            }

            else
            {
                resul = $"numC : {numC} | dateLivraison : {AffichageDate(dateLivraison)} | adresseC : {adresseC} | id : {id}";
            }
            return resul;
        }

        public string AffichageDate(DateTime date)
        {
            return $"{Convert.ToString(date.Day)}/{Convert.ToString(date.Month)}/{Convert.ToString(date.Year)}";
        }
    }
}
