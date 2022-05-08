using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Assemblage
    {
        private int numM { get; set; }
        private string numP { get; set; }

        public Assemblage(int numM,string numP)
        {
            this.numM = numM;
            this.numP = numP;
        }
    }

}
