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
                    "1) Module Client\n" +
                    "2) Module Commande\n" +
                    "3) Module Fournisseur\n" +
                    "4) Module Stock\n" +
                    "5) Module Pieces et Velos\n" +
                    "\n" +
                    "6) Module Statistique\n" +
                    "\n" +
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
                        Console.WriteLine("\n A. Ajouter un client \n B. Supprimer un client \n C. Modifier un client \n " );


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
                                Console.WriteLine("Le nombre de velo total est de:");//rajouter stock total de piece
                                Console.WriteLine("\n -----------------------------------\n" +
                               "Voici les commandes à votre disposition : ");
                                Console.WriteLine("\n 1.Par marque (killimanjaro,..) \n 2. Par grandeur (frein,cadre,...)  " +
                                    "\n "
                                  );


                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisi de consulter le nombre de vente! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                Console.WriteLine("A partir de quel fichier Commandes souhaitez vous opérer ?(Repertoire_Commandes)");
                                nomFichierCommandes = Console.ReadLine() + ".txt";

                                Commande.Ventes(nomFichierCommandes);
                                break;

                            case "D":
                                Console.WriteLine("Vous avez choisi de licencier de manière totalement arbitraire...! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                NoeudOrg.LicenciementAleatoire();

                                break;


                        }


                        break;
                    #endregion
                    case 5:
                        #region Salarié
                        Console.WriteLine("\n -----------------------------------\n" +
                     "Vous avez choisis le module Salarié, voici les commandes à votre disposition : ");
                        Console.WriteLine("\n A. Afficher l'organigramme des salariés \n B. Embaucher un salarié \n C. Licencier un salarié ");
                        //Ici, embaucher ou licencier un salarié revient à l'ajouter (ou le supprimer) de l'organigramme, c'est-à-dire de l'arbre n-aire

                        string choix3 = Console.ReadLine();
                        switch (choix3)
                        {
                            case "A":
                                Console.WriteLine("Vous avez choisi d'afficher l'organigramme des salariés ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                NoeudOrg s0 = new NoeudOrg("Mr Dupont/Directeur général");
                                NoeudOrg s1 = new NoeudOrg("Mme Fiesta/Directrice commerciale");
                                NoeudOrg s2 = new NoeudOrg("Mr Fetard/Directeur des Opérations");
                                NoeudOrg s3 = new NoeudOrg("Mme Joyeuse/Directrice des RH");
                                NoeudOrg s4 = new NoeudOrg("Mr GripSous/Directeur Financier");
                                NoeudOrg s5 = new NoeudOrg("Mr Forge/Commercial");
                                NoeudOrg s6 = new NoeudOrg("Mme Fermi/Commerciale");
                                NoeudOrg s7 = new NoeudOrg("Mr Royal/Chef d'équipe");
                                NoeudOrg s8 = new NoeudOrg("Mr Romu/Chauffeur");
                                NoeudOrg s9 = new NoeudOrg("Mr Romi/Chauffeur");
                                NoeudOrg s10 = new NoeudOrg("Mr Roma/Chauffeur");
                                NoeudOrg s11 = new NoeudOrg("Mme Prince/Chef d'équipe");
                                NoeudOrg s12 = new NoeudOrg("Mme Rome/Chauffeur");
                                NoeudOrg s13 = new NoeudOrg("Mme Rimou/Chauffeur");
                                NoeudOrg s14 = new NoeudOrg("Mme Couleur/Formation");
                                NoeudOrg s15 = new NoeudOrg("Mme ToutleMonde/Contrats");
                                NoeudOrg s16 = new NoeudOrg("Mr Picsou/Direction Comptable");
                                NoeudOrg s17 = new NoeudOrg("Mme Fournier/Comptable");
                                NoeudOrg s18 = new NoeudOrg("Mme Gautier/Comptable");
                                NoeudOrg s19 = new NoeudOrg("Mr GrosSous/Controleur de Gestion");


                                s0.AjoutRgInf(s1);


                                s1.AjoutPareil(s2);

                                s1.AjoutPareil(s3);
                                s1.AjoutPareil(s4);
                                s1.AjoutRgInf(s6);
                                s1.AjoutRgInf(s5);
                                s2.AjoutRgInf(s7);
                                s2.AjoutRgInf(s5);
                                s5.AjoutPareil(s6);
                                s2.AjoutRgInf(s7);
                                s7.AjoutRgInf(s8);
                                s8.AjoutPareil(s9);
                                s9.AjoutPareil(s10);
                                s7.AjoutPareil(s11);
                                s11.AjoutRgInf(s12);
                                s12.AjoutPareil(s13);
                                s3.AjoutRgInf(s14);
                                s14.AjoutPareil(s15);
                                s4.AjoutRgInf(s16);
                                s16.AjoutRgInf(s17);
                                s16.AjoutRgInf(s18);
                                s18.AjoutPareil(s17);
                                s16.AjoutPareil(s19);

                                Arbre.AffichageArborescence(s0);

                                break;

                            case "B":
                                break;

                            case "C":
                                Console.WriteLine("Vous avez choisi de licencier un salarié ! ");
                                Console.WriteLine("\n -----------------------------------\n");
                                s0 = new NoeudOrg("Mr Dupont/Directeur général");
                                s1 = new NoeudOrg("Mme Fiesta/Directrice commerciale");
                                s2 = new NoeudOrg("Mr Fetard/Directeur des Opérations");
                                s3 = new NoeudOrg("Mme Joyeuse/Directrice des RH");
                                s4 = new NoeudOrg("Mr GripSous/Directeur Financier");
                                s5 = new NoeudOrg("Mr Forge/Commercial");
                                s6 = new NoeudOrg("Mme Fermi/Commerciale");
                                s7 = new NoeudOrg("Mr Royal/Chef d'équipe");
                                s8 = new NoeudOrg("Mr Romu/Chauffeur");
                                s9 = new NoeudOrg("Mr Romi/Chauffeur");
                                s10 = new NoeudOrg("Mr Roma/Chauffeur");
                                s11 = new NoeudOrg("Mme Prince/Chef d'équipe");
                                s12 = new NoeudOrg("Mme Rome/Chauffeur");
                                s13 = new NoeudOrg("Mme Rimou/Chauffeur");
                                s14 = new NoeudOrg("Mme Couleur/Formation");
                                s15 = new NoeudOrg("Mme ToutleMonde/Contrats");
                                s16 = new NoeudOrg("Mr Picsou/Direction Comptable");
                                s17 = new NoeudOrg("Mme Fournier/Comptable");
                                s18 = new NoeudOrg("Mme Gautier/Comptable");
                                s19 = new NoeudOrg("Mr GrosSous/Controleur de Gestion");


                                s0.AjoutRgInf(s1);
                                s1.AjoutPareil(s2);

                                s1.AjoutPareil(s3);
                                s1.AjoutPareil(s4);
                                s1.AjoutRgInf(s6);
                                s1.AjoutRgInf(s5);
                                s2.AjoutRgInf(s7);
                                s2.AjoutRgInf(s5);
                                s5.AjoutPareil(s6);
                                s2.AjoutRgInf(s7);
                                s7.AjoutRgInf(s8);
                                s8.AjoutPareil(s9);
                                s9.AjoutPareil(s10);
                                s7.AjoutPareil(s11);
                                s11.AjoutRgInf(s12);
                                s12.AjoutPareil(s13);
                                s3.AjoutRgInf(s14);
                                s14.AjoutPareil(s15);
                                s4.AjoutRgInf(s16);
                                s16.AjoutRgInf(s17);
                                s16.AjoutRgInf(s18);
                                s18.AjoutPareil(s17);
                                s16.AjoutPareil(s19);


                                Arbre.AffichageArborescence(s0);
                                Console.WriteLine("\nQui allez-vous virer ?");
                                string personneAsupp = Console.ReadLine();

                                NoeudOrg Recherche(string nom, NoeudOrg n)
                                {
                                    if (n != null)
                                    {
                                        if (nom == n.RgSup)
                                        {
                                            return n;
                                        }
                                        else
                                        {
                                            if (n.RgInf != null)
                                            {
                                                return Recherche(nom, n.RgInf);
                                            }
                                            else
                                            {
                                                return Recherche(nom, n.Pareil);
                                            }


                                        }
                                    }
                                    else { return null; }

                                }
                                Recherche(personneAsupp, s0).Licencie();


                                Arbre.AffichageArborescence(s0);



                                break;
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
