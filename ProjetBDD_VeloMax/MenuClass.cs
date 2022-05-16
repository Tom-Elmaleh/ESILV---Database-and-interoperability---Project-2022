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
using Newtonsoft.Json;



namespace ProjetBDD_VeloMax
{
    class MenuClass 
    {

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

        public MySqlConnection Connection(string user)
        {
            string password = "";
            MySqlConnection maConnexion = null;
            try
            {
                if(user=="root")
                {
                    password = "I#mvengeance103darkness";   // Cas de l'utilisateur root avec les droits 
                }

                else
                {
                    password = "user";    // Cas de l'utilisateur ayant uniquement les accès en lecture
                }

                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         $"UID={user};PASSWORD={password}";
                maConnexion = new MySqlConnection(connexionString);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
            }

            return maConnexion;
        }

        public void ModuleStats(BddVelo bdd)
        {
            /* 1. Produire un rapport statistique présentant les quantités vendues de chaque item qui se
                trouve dans l’inventaire de VéloMax
             * 
             * 2. Produire la liste des membres pour chaque programme d’adhésion. 
            
             * 
             * 
             * 
             * 
             * 
             */


            
        }

       


        public void Menu()
        {
            // Export des stocks faibles avec fournisseurs pour command en XML 
            Console.WriteLine("\n Définir le nom du user ?"); // root ou bozo 
            string user = Console.ReadLine();
            MySqlConnection maConnexion = Connection(user);
            BddVelo bdd = new BddVelo(maConnexion);


            //bdd.ListeMembres(maConnexion);

            // Export des stocks faibles avec fournisseurs pour command en XML

            //Instanciation des objets			
            List<Fournisseur> liste = bdd.Fournisseurs;
            XmlSerializer xs = new XmlSerializer(typeof(List<Fournisseur>));
            StreamWriter wr = new StreamWriter("bdd.liste.xml");

            //sérialisation de bdtheque
            xs.Serialize(wr, liste);

            wr.Close();
            Console.WriteLine("Export des stock faibles avec fournisseurs en XML terminée");


            //Export des clients dont le programme de fidélité arrive à expiration dans moins de 2 mois avec historique
            //des abonnements afin de les relancer en JSON

            ////fichier destinataire de la sérialisation
            string fileToWrite = "Clients.json";

            ////instanciation des objets <Individus>
            List<Individu> inds = bdd.Individus;


            ////instanciation des flux d'écriture(writer)
            StreamWriter fileWriter = new StreamWriter(fileToWrite);
            JsonTextWriter jsonWriter = new JsonTextWriter(fileWriter);

            //// sérialisation des objets vers le flux d'écriture fichier
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, inds);

            ////fermeture des flux (writer)
            jsonWriter.Close();
            fileWriter.Close();
        }
    }
}
