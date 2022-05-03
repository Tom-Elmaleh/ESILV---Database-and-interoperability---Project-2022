using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetBDD_VeloMax
{
    class MenuClass
    {
        public static DateTime ConversionDateTime(string date)
        {

            string[] tab = date.Split('/');

            DateTime convDate = new DateTime(Convert.ToInt32("20" + tab[2]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[0]));

            return convDate;
        }

        static void TestModele(MySqlConnection connection)
        {
            List<Modele> modeles = new List<Modele>();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from modele;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numM;
            string nomVelo;
            string grandeur;
            int prix;
            string ligne;
            DateTime date_intro;
            DateTime date_sortie;

            while (reader.Read())// parcours ligne par ligne
            {
                numM = reader.GetInt32(0);
                nomVelo = reader.GetString(1);
                grandeur = reader.GetString(2);
                prix = reader.GetInt32(3);
                ligne = reader.GetString(4);
                date_intro = ConversionDateTime(reader.GetString(5));
                date_sortie = ConversionDateTime(reader.GetString(6));
                modeles.Add(new Modele(numM, nomVelo, grandeur, prix, date_intro, date_sortie));
            }

            Console.WriteLine("\nListe des modèles\n");

            foreach (Modele element in modeles)
            {
                Console.WriteLine(element.ToString());
            }

            connection.Close();
        }

        static void Delete(MySqlConnection connection)
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
            switch(table)
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
            //Console.WriteLine("Indiquer les conditions de mise à jour sur les attributs souhaités à la manière d'une requête SQL (adapter selon les types des attributs) à mettre à jour ? ");
            //string condition = Console.ReadLine();
            //$"delete from {table} where condition;"

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from {table} where {key}={id};";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
        }

        static void Creer(MySqlConnection connection)
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
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {table} values ({valeurs});";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
        }

        static void MAJ(MySqlConnection connection)
        {
            Console.WriteLine("\nQue voulez vous mettre à jour :" +
               "\nFournisseur (fournisseur)" +
               "\nPièce(piece)" +
               "\nCommande(commande)"
               + "\nModèle (modele)"
               + "\nclient Individu (individu)" +
               "\nclient Entreprise (entreprise)");

            string table = Console.ReadLine();
            Console.WriteLine("\nIndiquer les valeurs pour chacun des attributs à modifier comme une requête SQL (adapter selon les types attributs à modifier) ? ");
            string maj = Console.ReadLine();
            Console.WriteLine("\nIndiquer les conditions de mise à jour sur les attributs souhaités à la manière d'une requête SQL (adapter selon les types des attributs) à mettre à jour ? ");
            string condition = Console.ReadLine();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"update {table} set {maj} where {condition};";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
        }

        public void Menu()
        {
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
            Console.WriteLine("VeloMax");
            //Creer(maConnexion);
            //TestModele(maConnexion);
            //MAJ(maConnexion);
            //TestModele(maConnexion);
            TestModele(maConnexion);

        }
    }
}
