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

        public string NomE { get { return nomE; } set { nomE = value; } }
        public string Telephone { get { return telephoneE; } set { telephoneE = value; } }
        public string Adresse { get { return adresseE; } set { adresseE = value; } }
        public string CourrielE { get { return courrielE; } set { courrielE = value; } }
        public string ContactE { get { return contactE; } set { courrielE = value; } }
        public int Volume_A { get { return volume_achat; } set { volume_achat = value; } }
        public float Remise { get { return remise; } set { remise = value; } }

        public Entreprise(string nomE, string telephoneE, string adresseE, string courrielE, string contactE, int volume_achat, float remise)
        {
            this.nomE = nomE;
            this.telephoneE = telephoneE;
            this.adresseE = adresseE;
            this.courrielE = courrielE;
            this.contactE = contactE;
            this.volume_achat = volume_achat;
            this.remise = remise;
        }

        public override string ToString()
        {
            return $"nomE : {nomE} | contactE : {contactE} | volume_Achat : {volume_achat} | remise :{remise} ";
        }
    }
}
