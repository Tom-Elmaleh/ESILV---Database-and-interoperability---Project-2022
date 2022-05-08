using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    class Piece
    {
        private string numP { get; set; }
        private string descriptionP { get; set; }
        private int num_catalogue { get; set; }
        private int delai { get; set; }
        private int stock { get; set; }
        private int prixP { get; set; }

        public Piece(string numP,string descriptionP,int num_catalogue,int delai,int stock,int prixP)
        {
            this.numP = numP;
            this.descriptionP = descriptionP;
            this.num_catalogue = num_catalogue;
            this.delai = delai;
            this.stock = stock;
            this.prixP = prixP;
        }
    }
}
