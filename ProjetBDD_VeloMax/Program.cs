using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProjetBDD_VeloMax
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu : \n" +
                    "1) Creation\n" +
                    "2) Supression\n" +
                    "3) Mise a jour\n" +
                    "4) Module Stock\n" + 
                    "\n" +
                    "5) Module Statistique\n" +
                    "\n" +
                    "6) Module Demo\n" +
                    "\n" +
                    "Quel module souhaitez vous utiliser ?");
                int exo;
                exo = int.Parse(Console.ReadLine());

                switch (exo)
                {

                    case 1:
                        #region Module Creation
                        Console.WriteLine("\n ----------------------------------------------------------------------------\n" +
                         "Vous avez choisis le module Creation, voici les commandes à votre disposition : \n ");
                         strNouvtableau= MenuClass.Ajouter();


                        string choix = Console.ReadLine();
                        switch (choix)
                        {
                            case "A":

                                Console.WriteLine("Vous avez choisi d'ajouter un nouveau client");
                                Console.WriteLine("\n -----------------------------------\n");
                                

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi de supprimer un client");
                                Console.WriteLine("\n -----------------------------------\n");
                                

                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisi de modifier un client");
                                Console.WriteLine("\n -----------------------------------\n");
                                



                                break;

                            case "D":
                                Console.WriteLine("Vous avez choisi de d'afficher la liste des clients par ordre alphabétique");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("A partir de quel fichier Clients ?(Repertoire_Clients)");
                                string nomFichierClient_4 = Console.ReadLine() + ".txt";
                                Console.WriteLine("A partir de quel fichier Commandes ?(Repertoire_Commandes)");
                                string nomFichierCommandes_3 = Console.ReadLine() + ".txt";
                                Console.WriteLine("Voici la liste des Clients rangés par ordre alphabétique");
                                Console.WriteLine("\n -----------------------------------\n");
                                List<Client> liste = Client.Ordrealphabetique(nomFichierClient_4, nomFichierCommandes_3);
                                for (int i = 0; i < liste.Count; i++)
                                {
                                    Console.WriteLine(i + 1 + "." + liste[i].Nom + " " + liste[i].Prenom);
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
                                

                                
                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisis de supprimer une commande");
                                Console.WriteLine("\n -----------------------------------\n");
                                

                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisis de modifier une commande");
                                Console.WriteLine("\n -----------------------------------\n");
                                
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
                                
                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisis de supprimer un nouveau fournisseur");
                                Console.WriteLine("\n -----------------------------------\n");
                                
                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisis de modifier un nouveau fournisseur");
                                Console.WriteLine("\n -----------------------------------\n");
                              
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
                                Console.WriteLine("Le nombre de piece total est de:");//rajouter stock total de piece
                                Console.WriteLine("\n -----------------------------------\n" +
                               "Voici les commandes à votre disposition : ");
                                Console.WriteLine("\n 1.Par piece (CF3, G7,...) \n 2. Par type de piece (frein,cadre,...)  " +
                                    "\n "
                                  );

                                choixpiece = Convert.ToInt32(Console.ReadLine());
                                switch (choixpiece)
                                {
                                    case 1:
                                        Console.WriteLine("Voici le stock par piece: ");
                                        break;
                                    case 2:
                                        Console.WriteLine("Voici le stock par type de piece : ");
                                        break;

                                }


                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi d'examiner le stock de velo ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Le nombre de velo total est de:");//rajouter stock total de velo
                                Console.WriteLine("\n -----------------------------------\n" +
                               "Voici les commandes à votre disposition : ");
                                Console.WriteLine("\n 1.Par marque (killimanjaro,..) \n 2. Par grandeur \n3.Par ligne  " +
                                    "\n ");

                                choixVelo= Convert.ToInt32(Console.ReadLine());
                                switch (choixVelo)
                                {
                                    case 1:
                                        Console.WriteLine("Voici le stock de velo par marque: ");
                                        break;
                                    case 2:
                                        Console.WriteLine("Voici le stock velo par grandeur : ");
                                        break;
                                    case 3:
                                        Console.WriteLine("Voici le stock de velos par ligne : ");
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
                        //Ici, embaucher ou licencier un salarié revient à l'ajouter (ou le supprimer) de l'organigramme, c'est-à-dire de l'arbre n-aire
                        int choixPiece;
                        int choixVelo;
                        string choix3 = Console.ReadLine();
                        switch (choix3)
                        {
                            case "A":
                                Console.WriteLine("Vous avez choisi la gestion des Pieces ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Vous avez choisis la gestion des Velos, voici les commandes à votre disposition : ");
                                Console.WriteLine("\n A. Creer un Velo \n B. Supprimer un Velo \nC. Modifier un Velo ");

                                break;

                            case "B":
                                Console.WriteLine("Vous avez choisi la gestion des Velos ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("Vous avez choisis la gestion des Velos, voici les commandes à votre disposition : ");
                                Console.WriteLine("\n A. Creer un Velo \n B. Supprimer un Velo \nC. Modifier un Velo ");
                                break;

                                choixVelo = Convert.ToInt32(Console.ReadLine());

                                switch (choixPiece)
                                {
                                    case 1:
                                       
                                        break;

                                }



                        }
                        break;

                }
                #endregion
                Console.WriteLine("\nTapez Escape pour sortir ou Enter pour continuer");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            Console.ReadLine();






        }


        MenuClass menu = new MenuClass();
            menu.Menu();
            //bdd.Models;
        }
    }
}
