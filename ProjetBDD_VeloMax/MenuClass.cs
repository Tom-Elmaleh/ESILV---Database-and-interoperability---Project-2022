using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Serialization;


namespace ProjetBDD_VeloMax
{
    class MenuClass 
    {


        //    Console.WriteLine("\nListe des modèles\n");

        //    foreach (Modele element in modeles)
        //    {
        //        Console.WriteLine(element.ToString());
        //    }
        //    connection.Close();
        //    return modeles;
        //}

        public string [] Ajouter()
        {
            Console.WriteLine("\nQue voulez vous créer :" +
              "\nFournisseur (fournisseur)" +
              "\nPièce(piece)" +
              "\nCommande(commande)"
              + "\nModèle (modele)"
              + "\nclient Individu (individu)" +
              "\nclient Entreprise (entreprise)");
            string table = Console.ReadLine();
            Console.WriteLine("\nIndiquer les valeurs pour chacun des attributs à la manière d'une requête SQL (adapter selon les types) ? ");
            string valeurs = Console.ReadLine();
            string[] Tableau = new string[2] { table, valeurs };
            return Tableau;
        }

        public string [] Update()
        {
            Console.WriteLine("\nQue voulez vous mettre à jour :" +
            "\nFournisseur (fournisseur)" +
            "\nPièce(piece)" +
            "\nCommande(commande)" +
            "\nModèle (modele)"+
            "\nclient Individu (individu)" +
            "\nclient Entreprise (entreprise)");

            string table = Console.ReadLine();
            Console.WriteLine("\nIndiquer les valeurs pour chacun des attributs à modifier comme une requête SQL (adapter selon les types attributs à modifier) ? ");
            string maj = Console.ReadLine();
            Console.WriteLine("\nIndiquer les conditions de mise à jour sur les attributs souhaités à la manière d'une requête SQL (adapter selon les types des attributs) à mettre à jour ? ");
            string condition = Console.ReadLine();
            string[] Tableau = new string[3]  {table, maj,condition};
            return Tableau;

        }


        public string [] Supprimer()
        {
            Console.WriteLine("\nQue voulez vous supprimer :" +
               "\nFournisseur (fournisseur)" +
               "\nPièce(piece)" +
               "\nCommande(commande)"
               + "\nModèle (modele)"
               + "\nclient Individu (individu)" +
               "\nclient Entreprise (entreprise)");
            string table = Console.ReadLine();
            Console.WriteLine("\nIndiquer la valeur de l'identifiant(clé primaire) du tuple à supprimer ? ");
            string id = Console.ReadLine();
            string key = "";
            switch (table)
            {
                case "commande":
                    key = "numC";
                    break;
                case "entreprise":
                    key = "nomE";
                    break;
                case "fournisseur":
                    key = "siret";
                    break;
                case "individu":
                    key = "id";
                    break;
                case "modele":
                    key = "numM";
                    break;
                case "piece":
                    key = "numP";
                    break;
            }

            string[] Tableau = new string[3] { table, id,key };
            return Tableau;
        }


        public void Menu()
        {

            List<Modele> modeles = new List<Modele>();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=I#mvengeance103darkness";
                maConnexion = new MySqlConnection(connexionString);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

            BddVelo bdd = new BddVelo();
            bdd.ListeMembres(maConnexion);
            // bdd.Delete(maConnexion,)

            XmlSerializer xs = new XmlSerializer(typeof(Piece));
            StreamWriter wr = new StreamWriter("bdd.xml");

            //sérialisation de bdtheque
         //   xs.Serialize(wr,bdd);

            wr.Close();


        }
    }
}
