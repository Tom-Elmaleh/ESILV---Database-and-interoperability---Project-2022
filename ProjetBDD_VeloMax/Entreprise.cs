using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Entreprise
    {
        private string nomE { get; set; }
        private string telephoneE { get; set; }
        private string adresseE { get; set; }
        private string courrielE { get; set; }
        private string contactE { get; set; }
        private int volume_achat { get; set; }
        private float remise { get; set; }

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
