using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_VeloMax
{
    public class Piece
    {
        private string numP;
        private string descriptionP;
        private int num_catalogue;
        private int delai;
        private int stock;
        private int prixP;

        public string NumP { get { return numP; } set { numP = value; } }
        public string Description { get { return descriptionP; } set { descriptionP = value; } }
        public int Numcatalog { get { return num_catalogue; } set { num_catalogue = value; } }
        public int Delai { get { return delai; } set { delai = value; } }
        public int Stock { get { return stock; } set { stock = value; } }
        public int PrixP { get { return prixP; } set { prixP = value; } }


        public Piece(string numP, string descriptionP, int num_catalogue, int delai, int stock, int prixP)
        {
            this.numP = numP;
            this.descriptionP = descriptionP;
            this.num_catalogue = num_catalogue;
            this.delai = delai;
            this.stock = stock;
            this.prixP = prixP;
        }

        public override string ToString()
        {
            return $" numP : {numP} | descriptionP : {descriptionP} | num_catalogue : {num_catalogue} | delai : {delai} | " +
            $"stock : {stock} | prixP : {prixP}";
        }
    }
}
