using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Fournisseur
    {
        private string siret { get; set; }
        private string nomF { get; set; }
        private string adresseF { get; set; }
        private string contactF { get; set; }
        private int libelle { get; set; }

        public Fournisseur(string siret,string nomF,string adresseF,string contactF,int libelle)
        {
            this.siret = siret;
            this.nomF = nomF;
            this.adresseF = adresseF;
            this.contactF = contactF;
            this.libelle = libelle;
        }
    }
}
