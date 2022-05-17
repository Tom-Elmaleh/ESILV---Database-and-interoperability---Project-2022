using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    public class Fournisseur
    {
        private string siret;
        private string nomF;
        private string adresseF;
        private string contactF;
        private int libelle;
        private int stockF;

        public string Siret { get { return siret; } set { siret = value; } } // xml
        public string Nom { get { return nomF; } set { nomF = value; } }     // xml
        public string Adresse { get { return adresseF; } set { adresseF = value; } }
        public string Contact { get { return contactF; } set { contactF = value; } }
        public int Libelle { get { return libelle; } set { libelle = value; } }
        public int Stock { get { if (stockF < 10) return stockF; else return -1; } set { stockF = value; } } // xml

        public Fournisseur(string siret, string nomF, string adresseF, string contactF, int libelle, int stockF)
        {
            this.siret = siret;
            this.nomF = nomF;
            this.adresseF = adresseF;
            this.contactF = contactF;
            this.libelle = libelle;
            this.stockF = stockF;
        }

        public Fournisseur(string siret, string nomF, int stockF)
           : this(siret, nomF, "", "", -1, stockF)
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

        public string Afficher()
        {
            return $"Siret {siret} | Nom {nomF} | Adresse {adresseF} | Contact {contactF} | Libelle {libelle} | Stock {stockF}";
        }
    }
}
