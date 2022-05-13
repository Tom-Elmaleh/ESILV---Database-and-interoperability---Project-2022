using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Entreprise
    {
        private string nomE;
        private string telephoneE;
        private string adresseE;
        private string courrielE;
        private string contactE;
        private int volume_achat;
        private float remise;

        public Entreprise(string nomE,string telephoneE, string adresseE, string courrielE, string contactE, int volume_achat, float remise)
        {
            this.nomE = nomE;
            this.telephoneE = telephoneE;
            this.adresseE = adresseE;
            this.courrielE = courrielE;
            this.contactE = contactE;
            this.volume_achat = volume_achat;
            this.remise = remise;
        }
    }
}
