﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Contenu_Piece
    {
        private int quantiteP { get; set; }
        private string numP { get; set; }
        private int numC { get; set; }

        public Contenu_Piece(int quantiteP,string numP,int numC)
        {
            this.quantiteP = quantiteP;
            this.numP = numP;
            this.numC = numC;
        }
    }
}
