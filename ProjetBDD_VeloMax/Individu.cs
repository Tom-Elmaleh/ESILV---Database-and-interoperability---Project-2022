using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Individu
    {
        private int id { get; set; }
        private string nomI { get; set; }
        private string prenom { get; set; }
        private string telephoneI { get; set; }
        private string adresseI { get; set; }
        private string courrielI { get; set; }
        private int numero { get; set; }

        public int Numero { get; set; }


        public Individu(int id,string nomI,string prenom,string telephoneI,string adresseI,string courrielI,int numero)
        {
            this.id = id;
            this.nomI = nomI;
            this.prenom = prenom;
            this.telephoneI = telephoneI;
            this.adresseI = adresseI;
            this.courrielI = courrielI;
            this.numero = numero;
        }

        public override string ToString()
        {
            return $" {id} {nomI} {prenom} {telephoneI} {adresseI} {courrielI} ";
        }
    }
}
