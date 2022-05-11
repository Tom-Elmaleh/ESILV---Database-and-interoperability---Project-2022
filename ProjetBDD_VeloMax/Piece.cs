using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    public class Piece
    {
        private string numP { get; set; }
        private string descriptionP { get; set; }
        private int num_catalogue { get; set; }
        private int delai { get; set; }
        private int stock { get; set; }
        private int prixP { get; set; }

        public Piece(string numP, string descriptionP, int num_catalogue, int delai, int stock, int prixP)
        {
            this.numP = numP;
            this.descriptionP = descriptionP;
            this.num_catalogue = num_catalogue;
            this.delai = delai;
            this.stock = stock;
            this.prixP = prixP;
        }

        public Piece(string numP, string descriptionP, int num_catalogue, int stock)
             : this(numP, descriptionP, num_catalogue,-1,stock,-1)
        {
        }

        public Piece()
            : this("N/C", "N/C", 0, 0)
        {
        }



}
}
