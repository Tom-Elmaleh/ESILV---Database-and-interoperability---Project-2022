﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProjetBDD_VeloMax
{
    class Program
    {
        public static  MySqlConnection Connection(string user)
        {
            string password = "";
            MySqlConnection maConnexion = null;
            try
            {
                if (user == "root")
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

        public static MySqlConnection ConnectionFinale(string user,string password)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=127.0.0.1;PORT=3306;" +
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

        static void Main(string[] args)
        {
            Console.WriteLine("Saisir nom utilisateur :");
            string user = Console.ReadLine();
            Console.WriteLine("Saisir mot de passe");
            string password = Console.ReadLine();
            MySqlConnection connexion = ConnectionFinale(user, password);
            Console.Clear();

            BddVelo bdd = new BddVelo(connexion);
            ConsoleKeyInfo cki;
            do
            {


                Console.WriteLine("Menu : \n" +
                    "1) Module Client\n" +
                    "2) Module Commande \n" +
                    "3) Module Fournisseur\n" +
                    "4) Module Stock\n" +

                    "5) Module Statistique\n" +


                    "6) Module Piece et Velo \n" +
                    "7) Module Demo\n" +
                    "\n" +
                    "Quel module souhaitez vous utiliser ?");
                int exo;
                exo = int.Parse(Console.ReadLine());


                switch (exo)
                {

                    case 1:
                        #region Module Client
                        Console.WriteLine("\n ----------------------------------------------------------------------------\n" +
                         "Vous avez choisis le module Client, voici les commandes à votre disposition : \n ");
                        Console.WriteLine("\n A. Créer un client \n B. Supprimer un client \n C. Modifier un client \n ");


                        string choix = Console.ReadLine();
                        switch (choix)
                        {
                            case "A":

                                Console.WriteLine("Vous avez choisi d'ajouter un nouveau client");
                                Console.WriteLine("\n -----------------------------------\n");

                                Console.WriteLine("S'agit-il d'un : \n 1.particulier \n2.entreprise ");
                                Console.WriteLine("\n -----------------------------------\n");

                                int typeclient = Convert.ToInt32(Console.ReadLine());
                                switch (typeclient)
                                {
                                    case 1:
                                        string[] tabValeurI = MenuClass.AjouterFinal("individu");
                                        bdd.Creer(connexion, "individu", tabValeurI);
                                        break;

                                    case 2:
                                        MenuClass.AjouterFinal("entreprise");
                                        string[] tabValeurE = MenuClass.AjouterFinal("entreprise");
                                        bdd.Creer(connexion, "entreprise", tabValeurE);

                                        break;
                                }

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi de supprimer un client");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("S'agit-il d'un : \n 1.particulier \n2.entreprise ");
                                Console.WriteLine("\n -----------------------------------\n");

                                int typeclient2 = Convert.ToInt32(Console.ReadLine());
                                switch (typeclient2)
                                {
                                    case 1:
                                        string[] tabValeurI = MenuClass.SupprimerFinal("individu");
                                        bdd.Delete(connexion, "individu", tabValeurI);
                                        break;

                                    case 2:
                                        MenuClass.SupprimerFinal("entreprise");
                                        string[] tabValeurE = MenuClass.AjouterFinal("entreprise");
                                        bdd.Delete(connexion, "entreprise", tabValeurE);

                                        break;
                                }



                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisi de modifier un client");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Vous avez choisi de supprimer un client");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("S'agit-il d'un : \n 1.particulier \n2.entreprise ");
                                Console.WriteLine("\n -----------------------------------\n");

                                int typeclient3 = Convert.ToInt32(Console.ReadLine());
                                switch (typeclient3)
                                {
                                    case 1:
                                        string[] tabValeurI = MenuClass.UpdateFinal("individu");
                                        bdd.MAJ(connexion, tabValeurI, "individu");
                                        break;

                                    case 2:
                                        MenuClass.UpdateFinal("entreprise");
                                        string[] tabValeurE = MenuClass.AjouterFinal("entreprise");
                                        bdd.MAJ(connexion, tabValeurE, "entreprise");

                                        break;
                                }


                                break;
                        }



                        break;
                    #endregion
                    case 2:
                        #region Module Commande
                        Console.WriteLine("\n -----------------------------------\n" +
                     "Vous avez choisis le module Commande, voici les commandes à votre disposition : ");
                        Console.WriteLine("\n A. Créer une commande \n B. Supprimer une commande \n C. Modifier une commande \n ");


                        choix = Console.ReadLine();
                        switch (choix)
                        {

                            case "A":
                                Console.WriteLine("Vous avez choisis d'ajouter une nouvelle commande");
                                Console.WriteLine("\n -----------------------------------\n");

                                string[] tabValeurC = MenuClass.AjouterFinal("commande");
                                bdd.Creer(connexion, "commande", tabValeurC);

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisis de supprimer une commande");
                                Console.WriteLine("\n -----------------------------------\n");
                                string[] tabValeur = MenuClass.SupprimerFinal("commande");
                                bdd.Delete(connexion, "commande", tabValeur);


                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisis de modifier une commande");
                                Console.WriteLine("\n -----------------------------------\n");
                                string[] tabValeur3 = MenuClass.UpdateFinal("commande");
                                bdd.MAJ(connexion, tabValeur3, "commande");

                                break;




                        }

                        break;
                    #endregion
                    case 3:
                        #region Fournisseur
                        Console.WriteLine("\n -----------------------------------\n" +
                     "Vous avez choisis le module Fournisseur, voici les commandes à votre disposition : ");
                        Console.WriteLine("\n A. Créer un fournisseur \n B. Suprrimer un fournisseur \n C. Modifier un fournisseur \n ");

                        choix = Console.ReadLine();
                        switch (choix)
                        {
                            case "A":
                                Console.WriteLine("Vous avez choisis d'ajouter un nouveau fournisseur");
                                Console.WriteLine("\n -----------------------------------\n");
                                //fonction qui demande les atributs et ajoute fournisseur
                                string[] tabValeur3 = MenuClass.AjouterFinal("fournisseur");
                                bdd.Creer(connexion, "fournisseur", tabValeur3);

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisis de supprimer un fournisseur");
                                Console.WriteLine("\n -----------------------------------\n");

                                string[] tabValeur = MenuClass.SupprimerFinal("fournisseur");
                                bdd.Delete(connexion, "fournisseur", tabValeur);

                                string nomfournisseur = Console.ReadLine();



                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisis de modifier un fournisseur");
                                Console.WriteLine("\n -----------------------------------\n");
                                //fonction afficage 
                                string[] tabValeur2 = MenuClass.UpdateFinal("fournisseur");
                                bdd.MAJ(connexion, tabValeur2, "fournisseur");

                                break;



                        }

                        break;

                    #endregion
                    case 4:
                        #region Stock
                        Console.WriteLine("\n -----------------------------------\n" +
                     "Vous avez choisis le module Stock, voici les commandes à votre disposition : ");
                        Console.WriteLine("\n A.Stock Piece \n B. Stock Velo \n "
                          );
                        string choix2 = Console.ReadLine();
                        int choixpiece;
                        int choixVelo;
                        switch (choix2)
                        {
                            case "A":
                                Console.WriteLine("Vous avez choisi d'examiner le stock de piece ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.Write("Le nombre de piece total est de:");

                                //rajouter stock total de piece
                                Console.WriteLine("\n -----------------------------------\n" +
                               "Voici les commandes à votre disposition : ");
                                Console.WriteLine("\n 1.Par piece (CF3, G7,...) \n 2. Par fournisseur  " +
                                    "\n "
                                  );

                                choixpiece = Convert.ToInt32(Console.ReadLine());
                                switch (choixpiece)
                                {
                                    case 1:
                                        Console.WriteLine("Voici le stock par piece: ");//Tom
                                        bdd.StockParPiece();

                                        break;
                                    case 2:
                                        Console.WriteLine("Voici le stock de piece par fournisseur : ");//tOM
                                        bdd.StockPieceParFournisseur();
                                        break;


                                }


                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi d'examiner le stock de velo ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Le nombre de velo total est de:");
                                //rajouter stock total de velo
                                Console.WriteLine("\n -----------------------------------\n" +
                               "Voici les commandes à votre disposition : ");
                                Console.WriteLine("\n 1.Par marque (killimanjaro,..) \n 2. Par grandeur \n3.Par ligne  " +
                                    "\n ");//tOM

                                choixVelo = Convert.ToInt32(Console.ReadLine());
                                switch (choixVelo)
                                {
                                    case 1:
                                        Console.WriteLine("Voici le stock de velo par marque: ");//TOM
                                        bdd.StockVeloParMarque();
                                        break;
                                    case 2:
                                        Console.WriteLine("Voici le stock velo par grandeur : ");//tom
                                        bdd.StockVeloParGrandeur();
                                        break;
                                    case 3:
                                        Console.WriteLine("Voici le stock de velos par ligne : ");//tOM
                                        bdd.StockVeloParLigne();
                                        break;

                                }


                                break;

                        }
                        break;

                    #endregion
                    case 5:
                        #region Pieces et Velo

                        Console.WriteLine("\n -----------------------------------\n" +
                     "Vous avez choisis le module Pieces et Velos, voici les commandes à votre disposition : ");
                        Console.WriteLine("\n A. Gestion Piece \n B. Gestion Velo \n ");


                        int choixVelo1;
                        string choix3 = Console.ReadLine();
                        switch (choix3)
                        {
                            case "A":
                                Console.WriteLine("Vous avez choisi la gestion des Pieces ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Vous avez choisis la gestion des Piece, voici les commandes à votre disposition : ");
                                Console.WriteLine("\n A. Creer un Piece \n B. Supprimer un Piece \nC. Modifier un Piece ");

                                int choix1 = Convert.ToInt32(Console.ReadLine());

                                switch (choix1)
                                {
                                    case 1:
                                        Console.WriteLine("Vous avez choisis d'ajouter une piece !");
                                        Console.WriteLine("S'agit-il d'une piece déja existante ? \n1.OUI \n2.NON ");

                                        int existe = Convert.ToInt32(Console.ReadLine());
                                        switch (existe)
                                        {
                                            case 1:
                                                Console.WriteLine("Quel est le numero de la pièce que vous voulez approvisionner");
                                                string numP = Console.ReadLine();
                                                Console.WriteLine("Quelle quantité ?");
                                                string quantite = Console.ReadLine();
                                                connexion.Open();
                                                MySqlCommand command = connexion.CreateCommand();
                                                command.CommandText = $"select stock from piece where numP={numP};";
                                                MySqlDataReader reader = command.ExecuteReader();
                                                string stock = reader.GetString(0);
                                                reader = command.ExecuteReader();
                                                string[] tab = new string[3] { numP, "stock", Convert.ToString(Convert.ToInt32(stock + quantite)) };
                                                connexion.Close();
                                                bdd.MAJ(connexion, tab, "piece");

                                                break;

                                            case 2:

                                                //fonction qui demande les atributs et ajoute fournisseur
                                                string[] tabValeur3 = MenuClass.AjouterFinal("piece");
                                                bdd.Creer(connexion, "piece", tabValeur3);

                                                break;
                                        }

                                        break;
                                    case 2:
                                        Console.WriteLine("Vous avez choisis de supprimer une piece");
                                        Console.WriteLine("\n -----------------------------------\n");

                                        string[] tabValeur = MenuClass.SupprimerFinal("piece");
                                        bdd.Delete(connexion, "piece", tabValeur);



                                        break;
                                    case 3:
                                        Console.WriteLine("Vous avez choisis de modifier une piece");
                                        Console.WriteLine("\n -----------------------------------\n");
                                        //fonction afficage 
                                        string[] tabValeur2 = MenuClass.UpdateFinal("piece");
                                        bdd.MAJ(connexion, tabValeur2, "piece");
                                        break;
                                }

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi la gestion des Velos ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Vous avez choisis la gestion des Velos, voici les commandes à votre disposition : ");
                                Console.WriteLine("\n A. Creer un Velo \n B. Supprimer un Velo \nC. Modifier un Velo ");


                                choixVelo1 = Convert.ToInt32(Console.ReadLine());

                                switch (choixVelo1)
                                {
                                    case 'A':
                                        Console.WriteLine("Est-ce un velo existant ou non ? ");
                                        int choixExiste = Convert.ToInt32(Console.ReadLine());

                                        Console.WriteLine("Vous avez choisis d'ajouter un velo !");
                                        Console.WriteLine("S'agit-il d'un velo déja existant ? \n1.OUI \n2.NON ");

                                        int existe = Convert.ToInt32(Console.ReadLine());
                                        switch (existe)
                                        {
                                            case 1:
                                                Console.WriteLine("Quel est le numero du velo que vous voulez approvisionner");
                                                string numM = Console.ReadLine();
                                                Console.WriteLine("Quelle quantité ?");
                                                string quantite = Console.ReadLine();
                                                connexion.Open();
                                                MySqlCommand command = connexion.CreateCommand();
                                                command.CommandText = $"select stock from modele where numP={numM};";
                                                MySqlDataReader reader = command.ExecuteReader();
                                                string stockM = reader.GetString(0);
                                                reader = command.ExecuteReader();
                                                string[] tab = new string[3] { numM, "stockM", Convert.ToString(Convert.ToInt32(stockM + quantite)) };
                                                connexion.Close();
                                                bdd.MAJ(connexion, tab, "modele");

                                                break;

                                            case 2:

                                                //fonction qui demande les atributs et ajoute modele
                                                string[] tabValeur3 = MenuClass.AjouterFinal("modele");
                                                bdd.Creer(connexion, "modele", tabValeur3);

                                                break;
                                        }
                                        break;



                                    case 'B':
                                        Console.WriteLine("Vous avez choisis de supprimer un velo");
                                        Console.WriteLine("\n -----------------------------------\n");

                                        string[] tabValeur = MenuClass.SupprimerFinal("modele");
                                        bdd.Delete(connexion, "modele", tabValeur);


                                        break;


                                    case 'C':
                                        Console.WriteLine("Vous avez choisis de modifier une modele");
                                        Console.WriteLine("\n -----------------------------------\n");
                                        //fonction afficage 
                                        string[] tabValeur2 = MenuClass.UpdateFinal("modele");
                                        bdd.MAJ(connexion, tabValeur2, "modele");

                                        break;


                                }
                                break;



                        }
                        break;
                    #endregion

                    case 7:
                        #region Demo
                        string choix4 = Console.ReadLine();
                        switch (choix4)
                        {
                            case "A":
                                Console.WriteLine("\n Voici la liste des produits ayant une quantité une  stock<=2");
                                bdd.ProduitStock2();
                                bdd.NombredeClients();

                                break;
                            case "B":
                                bdd.ProduitStock2();
                                break;
                            case "C":
                                bdd.NbproduitFournisseur(connexion);
                                break;
                            case "D"://eXPORT XML/JSON
                                break;
                        }

                        #endregion
                        break;

                }



                Console.WriteLine("\nTapez Escape pour sortir ou Enter pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.ReadLine();







            //

        }
        

    }
    }

