using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Individu
    {
        private int id;
        private string nomI;
        private string prenom;
        private string telephoneI;
        private string adresseI;
        private string courrielI;
        private int numero;
        private DateTime date_adhesion; 

        //Export des clients dont le programme de fidélité arrive à expiration dans moins de 2 mois avec historique 
        //des abonnements afin de les relancer en JSON

        public int ID { get { return id; } set { id = value; } }
        public string Nom { get { return nomI; } set { nomI = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public int Numero { get { return numero; } set { numero = value; } }

        public Individu(int id,string nomI,string prenom,string telephoneI,string adresseI,string courrielI,int numero/*,DateTime date_adhesion*/)
        {
            this.id = id;
            this.nomI = nomI;
            this.prenom = prenom;
            this.telephoneI = telephoneI;
            this.adresseI = adresseI;
            this.courrielI = courrielI;
            this.numero = numero;
            // this.date_adhesion=date_adhesion
        }

        public override string ToString()
        {
            return id + nomI + prenom + numero;

            // Il faut rajouter historique des abonnements si expiration < 2 mois
            
        }

        static DateTime ConversionDateTime(string date)
        {

            string[] tab = date.Split('/');

            DateTime convDate = new DateTime(Convert.ToInt32("20" + tab[2]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[0]));

            return convDate;
        }
    }
}
