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

        //public int NUMC { get { return numC; } set { numC = value; } }
        //public DateTime DATEC { get { return dateC; } set { dateC = value; } }
        //public DateTime DATE_L { get { return dateLivraison; } set { dateLivraison = value; } }
        //public string Adresse { get { return adresseC; } set { adresseC = value; } }
        //private string Nom { get { return nomE; } set { nomE = value; } }
        //public int ID { get { return id; } set { id = value; } }

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

        //    public Commandexml()
        //    {
        //        public Commande(int numC, DateTime dateC, DateTime dateLivraison, string adresseC, string nomE, int id)
        //: this(numC, -1)

        //        {
        //        }
        //    }

        //public Commande()
        //        : this(null, null, null, "N/C", "N/C", null); // N/C : Non Communiqué
        //{
        //}
    }
}
