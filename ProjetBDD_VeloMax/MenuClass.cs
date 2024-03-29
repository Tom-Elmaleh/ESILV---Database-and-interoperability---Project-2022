﻿using System;
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
        #region Ajouter
        public string [] Ajouter()
        {
            Console.WriteLine("\nQue voulez vous créer :" +
              "\nA. Fournisseur (fournisseur)" +
              "\nB. Pièce(piece)" +
              "\nC. Commande(commande)"
              + "\nD. Modèle (modele)"
              + "\nE. client Individu (individu)" +
              "\nF. client Entreprise (entreprise)");
            string table = Console.ReadLine();
            Console.WriteLine("\nIndiquer les valeurs pour chacun des attributs à la manière d'une requête SQL (adapter selon les types) ? ");
            string valeurs = Console.ReadLine();
            string[] Tableau = new string[2] { table, valeurs };
            return Tableau;
        }
        #endregion

        #region AjouterFinal
        public static string AjouterFinal(string nomTable)
        {
            string valeurs="";

            string choix = nomTable.ToLower();
            switch (choix)
            {
                case "individu":
                    Console.WriteLine("Quel est l'identifiant du client ?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est le nom du client ?");
                    string nomI = Console.ReadLine();
                    Console.WriteLine("Quel est le prenom du client ?");
                    string prenom = Console.ReadLine();
                    Console.WriteLine("Quel est le numero de telephone du client ?");
                    string telephoneI = Console.ReadLine();
                    Console.WriteLine("Quel est l'addresse du client ?");
                    string adresseI =Console.ReadLine();
                    Console.WriteLine("Quel est son courriel ?");
                    string courrielI = Console.ReadLine();
                    Console.WriteLine("Quel est le numero du programme fidelio auquel est souscrit ce client ? ");
                    Console.WriteLine("\n 0.  Pas d'abonnement \n1.Fideio \n2.Fidelio Or \n3.Fidelio Platine \n4.Fidelio Max");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    DateTime date_adhesion = DateTime.MinValue;
                    if (numero != 0)
                    {

                        date_adhesion = DateTime.Today;
                    }


                    valeurs = valeurs = $"{id},'{nomI}','{prenom}','{telephoneI}','{adresseI}','{courrielI}',{numero},'{ Convert.ToString(date_adhesion.Day)}/{Convert.ToString(date_adhesion.Month)}/{Convert.ToString(date_adhesion.Year)}'";

                    break;

                case "fournisseur":
                    Console.WriteLine("Quel est le numero Siret du fournisseur ?");
                    string siret = Console.ReadLine();
                    Console.WriteLine("Quel est le nom du fornisseur ?");
                    string nomF = Console.ReadLine();
                    Console.WriteLine("Quel est l'addresse du fournisseur ?");
                    string addresseF = Console.ReadLine();
                    Console.WriteLine("Quel est le contact du fournisseur?");
                    string contactF = Console.ReadLine();
                    Console.WriteLine("Quel est le libelle du fournisseur ?");
                    int libelle  = Convert.ToInt32(Console.ReadLine());

                    valeurs =  $"'{siret}','{nomF}','{addresseF}','{contactF}',{libelle}";

                    break;
                case "entreprise":
                    Console.WriteLine("Quel est le nom de l'entreprise?");
                    string nomE = Console.ReadLine();
                    Console.WriteLine("Quel est le numero de telephone de l'entreprise ?");
                    string telephoneE = Console.ReadLine();
                    Console.WriteLine("Quel est l'addresse de l'entreprise ?");
                    string addresseE = Console.ReadLine();
                    Console.WriteLine("Quel est le contact de l'entreprise ?");
                    string contactE = Console.ReadLine();
                    Console.WriteLine("Quel est le courriel de l'entreprise ?");
                    string courriel = Console.ReadLine();
                    int volume_achat = 0;
                    int remise =0 ;

                    valeurs = $"'{nomE}','{telephoneE}','{addresseE}','{contactE}','{courriel}',{volume_achat},{remise}";

                    break;
                case "piece":
                    Console.WriteLine("Quel est le numero de la piece ?");
                    string numP = Console.ReadLine();
                    Console.WriteLine( "De quelle type de piece s'agit-il ? (frein,guidons,..)");
                    string descriptionf = Console.ReadLine();
                    Console.WriteLine("Quel est son numero dans le catalogue ?");
                    int num_catalogue = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est son delai de livraison ?");
                    int delai = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Combien voulez vous en rajouter ?");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est son prix unitaire ?");
                    int prixP = Convert.ToInt32(Console.ReadLine());


                    valeurs = $"'{numP}','{descriptionf}',{num_catalogue},{delai},{stock},{prixP}";

                    break;
                case "modele":
                    Console.WriteLine("Quel est le numero unique du modèle  ?");
                    int numM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est le nom du velo ?");
                    string nomVelo = Console.ReadLine();
                    Console.WriteLine("Quel est la grandeur du velo ?");
                    string grandeur = Console.ReadLine();
                    Console.WriteLine("Quel est la ligne du velo ?");
                    string ligne = Console.ReadLine();
                    Console.WriteLine("Quel est le prix du velo ?");
                    int prix = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est la date d'introduction du velo ? (DD/MM/YY)");
                    string date_intro =Console.ReadLine();
                    Console.WriteLine("Quel est la date de sortie de vente du  velo ? (DD/MM/YY)");
                    string date_sortie =Console.ReadLine();
                    Console.WriteLine("Quelle quantité voulez-vous ajouter ?");
                    int  stockM = Convert.ToInt32(Console.ReadLine());
                    valeurs = $"'{numM}','{nomVelo}','{grandeur}',{prix},'{ligne}','{date_intro}','{date_sortie}',{stockM}";
                    break;
                case "commande":
                    Console.WriteLine("Quel est le numero de commande ?");
                    int numC = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est la commande ?(DD/MM/YY)");
                    string dateC = Console.ReadLine();
                    Console.WriteLine("Quel est la date à laquelle on livre ?(DD/MM/YY) ");
                    string dateLivraison = Console.ReadLine();
                    Console.WriteLine("Quel est l'addresse de Livraison ?");
                    string addresseC = Console.ReadLine();
                    Console.WriteLine("Quel est le nom de l'entreprise ? ('Na'si particulier) )");
                    string nomEn = Console.ReadLine();
                    Console.WriteLine("Quel est l'identifiant du particulier ? (0 si entreprise)");
                    int ide = Convert.ToInt32(Console.ReadLine());

                    valeurs = $"{numC},'{dateC}','{dateLivraison}','{addresseC}','{nomEn}',{ide}";
                    break;
            }

            Console.WriteLine("");
            
            return valeurs;
        }
        #endregion

        #region Update
        public static  string [] Update()
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
            #endregion
        }
        #region Update Final
        public static string UpdateFinal(string nomTable)
        {
            string tab = "";

            string choix = nomTable.ToLower();
            switch (choix)
            {
                case "individu":
                    Console.WriteLine("Quel est l'identifiant de l'individu que vous voulez modifier ?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attribut = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string maj= Console.ReadLine();

                    tab = $"{id},{attribut},{maj},id";
                    break;

                case "fournisseur":
                    Console.WriteLine("Quel est le siret du fournisseur que vous voulez modifier ?");
                    string siret = Console.ReadLine();
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attributF = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string majF= Console.ReadLine();

                    tab = $"'{siret}',{attributF},{majF}"+",NomF";
                    break;
                case "entreprise":
                    Console.WriteLine("Quel est le nom de l'entreprise que vous voulez modifier");
                    string nomE = Console.ReadLine();
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attributE = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string majE = Console.ReadLine();

                    tab = $"'{nomE}',{attributE},{majE}" + ",NomE";

                    break;
                case "piece":
                    Console.WriteLine("Quel est le numero de la piece que vous voulez modifier ?");
                    string numP = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attributP = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string majP = Console.ReadLine();
                    tab = $"'{numP}',{attributP},{majP}" + ",NumP";

                    break;
                case "modele":
                    Console.WriteLine("Quel est le numero du modele que vous voulez modifier ?");
                    int numM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attributM = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string majM = Console.ReadLine();

                    tab = $"{numM},{attributM},{majM}"+",NomM";

                    break;

                case "commande":
                    Console.WriteLine("Quel est le numero de commande que vous voulez modifier ?");
                    int numC = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quel est l'attribut que vous voulez modifier ?");
                    string attributC = Console.ReadLine();
                    Console.WriteLine("Quel est la nouvelle valeur ?");
                    string majC = Console.ReadLine();

                    tab = $"'{numC}',{attributC},{majC}" + ",NumC";

                    break;
            }

            return tab;

        }
        #endregion

        #region Supprimer
        public static  string [] Supprimer()
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
        #endregion

        #region SupprimerFinal
        public static string SupprimerFinal(string nomTable)
        {

            string ASupprimer = "";

            string choix = nomTable.ToLower();
            switch (choix)
            {
                case "individu":
                    Console.WriteLine("Quel est l'identifiant de l'individu que vous voulez supprimer ?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ASupprimer = $"{id}"+",id";



                    break;

                case "fournisseur":
                    Console.WriteLine("Quel est le siret du fournisseur que vous voulez supprimer ?");
                    string siret = Console.ReadLine();
                    
                    ASupprimer = $"'{siret}'" + ",siret"; 


                    break;
                case "entreprise":
                    Console.WriteLine("Quel est le nom de l'entreprise que vous voulez supprimer ?");
                    string nomE =Console.ReadLine();
                    ASupprimer = $"'{nomE}'" + ",nomE";


                    break;
                case "piece":
                    Console.WriteLine("Quel est le numero de la piece que vous voulez supprimer");
                    string numP = Convert.ToString(Console.ReadLine());
                    ASupprimer = $"'{numP}'" + ",numP";



                    break;
                case "modele":
                    Console.WriteLine("Quel est le numero du modele que vous voulez supprimer ?");
                    int numM = Convert.ToInt32(Console.ReadLine());

                    ASupprimer = $"{numM}" + ",numP";

                    break;

                case "commande":
                    Console.WriteLine("Quel est le numero du modele que vous voulez supprimer ?");
                    int numC = Convert.ToInt32(Console.ReadLine());

                    ASupprimer = $"{numC}" + ",numC";


                    break;

            }

            return ASupprimer;
        }
        #endregion
        public  MySqlConnection Connection(string user)
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
