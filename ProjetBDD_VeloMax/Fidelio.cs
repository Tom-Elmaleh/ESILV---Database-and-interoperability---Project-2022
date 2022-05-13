using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Fidelio
    {
        private int numero;
        private string description;
        private int cout;
        private int duree;
        private int rabais;

     //   public int NumeroF { get; set; }

        public Fidelio(int numero,string description,int cout,int duree,int rabais)
        {
            this.numero = numero;
            this.description = description;
            this.cout = cout;
            this.duree = duree;
            this.rabais = rabais;
        }
    }
}
