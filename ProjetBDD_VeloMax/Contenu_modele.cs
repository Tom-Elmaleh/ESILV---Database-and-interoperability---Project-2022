using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Contenu_Modele
    {
        private int quantiteM;
        private int numM;
        private int numC;

        public Contenu_Modele(int quantiteM,int numM,int numC)
        {
            this.quantiteM = quantiteM;
            this.numM = numM;
            this.numC = numC;
        }
    }
}
