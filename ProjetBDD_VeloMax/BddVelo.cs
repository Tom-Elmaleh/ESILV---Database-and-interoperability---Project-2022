using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProjetBDD_VeloMax
{
    class BddVelo
    {
        private MySqlConnection connexion = new MySqlConnection();
        private List<Modele> modeles = new List<Modele>();
        public List<Modele> Models { get { return modeles; } set { value = modeles; } }
        private List<Piece> pieces = new List<Piece>();
        public List<Piece> Pieces { get { return pieces; } set { value = pieces; } }
        private List<Individu> individus = new List<Individu>();
        public List<Individu> Individus { get { return individus; } set { value = individus; } }
        private List<Entreprise> entreprises = new List<Entreprise>();
        public List<Entreprise> Entreprises { get { return entreprises; } set { value = entreprises; } }
        private List<Commande> commandes = new List<Commande>();
        public List<Commande> Commandes { get { return commandes; } set { value = commandes; } }
        private List<Fournisseur> fournisseurs = new List<Fournisseur>();
        public List<Fournisseur> Fournisseurs { get { return fournisseurs; } set { value = fournisseurs; } }
        private List<Assemblage> assemblages = new List<Assemblage>();
        public List<Assemblage> Assemblages { get { return assemblages; } set { value = assemblages; } }
        private List<Contenu_Modele> contenus_M = new List<Contenu_Modele>();
        public List<Contenu_Modele> Contenu_Modeles { get { return contenus_M; } set { value = contenus_M; } }
        private List<Contenu_Piece> contenus_P = new List<Contenu_Piece>();
        public List<Contenu_Piece> Contenu_Pieces { get { return contenus_P; } set { value = contenus_P; } }
        private List<Fidelio> fidelios = new List<Fidelio>();
        public List<Fidelio> Fidelios { get { return fidelios; } set { value = fidelios; } }
        private List<Livraison> productions = new List<Livraison>();
        public List<Livraison> Productions { get { return productions; } set { value = productions; } }
        private List<Production> livraisons = new List<Production>();
        public List<Production> Livraisons { get { return livraisons; } set { value = livraisons; } }


        public BddVelo(MySqlConnection connexion)
        {
            this.connexion = connexion;
            LectureModele(connexion);
            //LectureCommande(connexion);
            LecturePiece(connexion);
            LectureEntreprises(connexion);
            LectureIndividu(connexion);
            LectureFournisseur(connexion);
            // LectureAssemblage(connexion);
            LectureContenu_M(connexion);
            LectureContenu_P(connexion);
            LectureFidelio(connexion);
            //LectureProduction(connexion);
            //LectureLivraison(connexion);
        }



        public BddVelo(List<Modele> m)
        {
            this.modeles = m;
        }

        /// <summary>
        /// Méthode qui retourne le nombre de clients de VeloMax
        /// </summary>
        #region NombreClients
        public void NombredeClients()
        {
            Console.WriteLine($"Il y a {individus.Count()} clients particuliers et {entreprises.Count()} clients entreprises");
        }
        #endregion

        /// <summary>
        /// Méthode qui retourne le nombre de pices dont le stock
        /// </summary>
        #region ProduitStock2
        public void ProduitStock2()
        {
            for (int i=0;i<=pieces.Count();i++)
            {
                if (pieces[i].Stock<=2)
                {
                    Console.WriteLine(pieces[i].ToString());
                }
            }

            for (int i = 0; i <= modeles.Count(); i++)
            {
                if (modeles[i].Stock <= 2)
                {
                    Console.WriteLine(modeles[i].ToString());
                }
            }
        }
        #endregion

        //2.Produire la liste des membres pour chaque programme d’adhésion.
        #region ListMembres
        public void ListeMembres(MySqlConnection connection)
        {

            //foreach (var groupe in individusGroupedByNumero)
            //{
            //    Console.WriteLine("Programme d'adhésion" + groupe.Key);
            //    foreach(var ind in groupe)
            //    {
            //        Console.WriteLine(ind.ToString());
            //    }
            //}

            List<Object> Members = new List<Object>();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select i.*,descriptionf,duree from individu i join fidelio f on f.numero=i.numero " +
            "group by i.id,descriptionf order by f.numero asc;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int id;
            string nomI;
            string prenom;
            string telephoneI;
            string adresseI;
            string courrielI;
            int numero;
            string descriptionf;
            string duree;

            while (reader.Read())// parcours ligne par ligne
            {
                id = reader.GetInt32(0);
                nomI = reader.GetString(1);
                prenom = reader.GetString(2);
                telephoneI = reader.GetString(3);
                adresseI = reader.GetString(4);
                courrielI = reader.GetString(5);
                numero = reader.GetInt32(6);
                descriptionf = reader.GetString(7);
                duree = $"{reader.GetString(8)} an";
                Console.WriteLine(" ");
               // Members.Add(new Object(id, nomI, prenom, telephoneI, adresseI, courrielI, numero, descriptionf));
            }
            connection.Close();
        }
        #endregion

        #region ConversionDateTime
        static DateTime ConversionDateTime(string date)
        {

            string[] tab = date.Split('/');

            DateTime convDate = new DateTime(Convert.ToInt32("20" + tab[2]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[0]));

            return convDate;
        }
        #endregion

        #region Delete
        public void Delete(MySqlConnection connection,string table,string key,string id)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from {table} where {key}={id};";
            connection.Close();
            Choose(connection, table);
        }
        #endregion

        #region Choose
        public void Choose(MySqlConnection connection,string table)
        {
            switch (table)
            {
                case "commande":
                    LectureCommande(connection);
                    LectureContenu_M(connection);
                    LectureContenu_P(connection);
                    break;
                case "entreprise":
                    LectureEntreprises(connection);
                    break;
                case "fournisseur":
                    LectureFournisseur(connection);
                    LectureProduction(connection);
                    LectureLivraison(connection);
                    break;
                case "individu":
                    LectureIndividu(connection);
                    break;
                case "modele":
                    LectureModele(connection);
                    LectureAssemblage(connection);
                    LectureContenu_M(connection);
                    break;
                case "piece":
                    LecturePiece(connection);
                    LectureAssemblage(connection);
                    LectureContenu_P(connection);
                    LectureProduction(connection);
                    LectureLivraison(connection);
                    break;
            }
        }
        #endregion

        #region Creer
        public void Creer(MySqlConnection connection, string table, string valeurs)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {table} values ({valeurs});";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            Choose(connection, table);
        }
        #endregion

        #region MAJ
        public void MAJ(MySqlConnection connection,string table,string maj,string condition)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"update {table} set {maj} where {condition};";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            Choose(connection,table);
        }
        #endregion

        /// <summary>
        /// Cette méthode recrée la liste de modèles via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureModele
        public void LectureModele(MySqlConnection connection)
        {
             modeles.Clear();
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
            int stockM=0;

            while (reader.Read())// parcours ligne par ligne
            {
                numM = reader.GetInt32(0);
                nomVelo = reader.GetString(1);
                grandeur = reader.GetString(2);
                prix = reader.GetInt32(3);
                ligne = reader.GetString(4);
                date_intro = ConversionDateTime(reader.GetString(5));
                date_sortie = ConversionDateTime(reader.GetString(6));
        //        stockM = reader.GetInt32(7);
                modeles.Add(new Modele(numM, nomVelo, grandeur, prix, date_intro, date_sortie,stockM));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des pièces via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LecturePiece
        public void LecturePiece(MySqlConnection connection)
        {
            modeles.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from piece;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string numP;
            string descriptionP;
            int num_catalogue;
            int delai;
            int stock;
            int prixP;

            while (reader.Read())// parcours ligne par ligne
            {
                numP = reader.GetString(0);
                descriptionP = reader.GetString(1);
                num_catalogue = reader.GetInt32(2);
                delai = reader.GetInt32(3);
                stock = reader.GetInt32(4);
                prixP = reader.GetInt32(5);
                pieces.Add(new Piece(numP,descriptionP,num_catalogue,delai,stock,prixP));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des clients individu via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureIndividu
        public void LectureIndividu(MySqlConnection connection)
        {
            individus.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from individu;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int id;
            string nomI;
            string prenom;
            string telephoneI;
            string adresseI;
            string courrielI;
            int numero;

            while (reader.Read())// parcours ligne par ligne
            {
                id = reader.GetInt32(0);
                nomI = reader.GetString(1);
                prenom = reader.GetString(2);
                telephoneI = reader.GetString(3);
                adresseI = reader.GetString(4);
                courrielI= reader.GetString(5);
                numero = reader.GetInt32(6);
                individus.Add(new Individu(id,nomI,prenom,telephoneI,adresseI,courrielI,numero));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des clients entreprises via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>
         #region LectureEntreprises
        public void LectureEntreprises(MySqlConnection connection)
        {
            entreprises.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from entreprise;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nomE;
            string telephoneE;
            string adresseE;
            string courrielE;
            string contactE;
            int volume_achat;
            float remise;

            while (reader.Read())// parcours ligne par ligne
            {
                nomE = reader.GetString(0);
                telephoneE = reader.GetString(1);
                adresseE = reader.GetString(2);
                courrielE = reader.GetString(3);
                contactE = reader.GetString(4);
                volume_achat = reader.GetInt32(5);
                remise = reader.GetFloat(5);
                entreprises.Add(new Entreprise(nomE,telephoneE,adresseE,courrielE,contactE,volume_achat,remise));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des commandes via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureCommande
        public void LectureCommande(MySqlConnection connection)
        {
            commandes.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from commande;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numC;
            DateTime dateC;
            DateTime dateLivraison;
            string adresseC; 
            string nomE; 
            int id;

            while (reader.Read())// parcours ligne par ligne
            {
                numC = reader.GetInt32(0);
                dateC = ConversionDateTime(reader.GetString(1));
                dateLivraison = ConversionDateTime(reader.GetString(2));
                adresseC = reader.GetString(3);
                nomE = reader.GetString(4);
                id = reader.GetInt32(5);
                commandes.Add(new Commande(numC,dateC,dateLivraison,adresseC,nomE,id));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des commandes via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>
        /// 
        #region LectureFournisseur
        public void LectureFournisseur(MySqlConnection connection)
        {
            fournisseurs.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from fournisseur;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string siret;
            string nomF;
            string adresseF;
            string contactF;
            int libelle;
            int stockF;

            while (reader.Read())// parcours ligne par ligne
            {
                siret=reader.GetString(0);
                nomF= reader.GetString(1);
                adresseF= reader.GetString(2);
                contactF= reader.GetString(3);
                libelle= reader.GetInt32(4);
                stockF = reader.GetInt32(5);
                fournisseurs.Add(new Fournisseur(siret,nomF,adresseF,contactF,libelle,stockF));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des commandes via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureAssemblage
        public void LectureAssemblage(MySqlConnection connection)
        {
            assemblages.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from assemblage;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numM;
            string numP;

            while (reader.Read())// parcours ligne par ligne
            {
                numM = reader.GetInt32(0);
                numP = reader.GetString(1);                
                assemblages.Add(new Assemblage(numM,numP));
            }
            connection.Close();
        }

        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des contenus_modèles via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureContenu_M

        public void LectureContenu_M(MySqlConnection connection)
        {
            contenus_M.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from contenu_modele;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int quantiteM;
            int numM;
            int numC;
            while (reader.Read())// parcours ligne par ligne
            {
                quantiteM = reader.GetInt32(0);
                numM= reader.GetInt32(1);
                numC = reader.GetInt32(2);
                contenus_M.Add(new Contenu_Modele(quantiteM, numM,numC));
            }
            connection.Close();
        }

        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des contenus_pièces via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureContenu_P

        public void LectureContenu_P(MySqlConnection connection)
        {
            contenus_P.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from contenu_piece;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int quantiteP;
            string numP;
            int numC;
            while (reader.Read())// parcours ligne par ligne
            {
                quantiteP = reader.GetInt32(0);
                numP = reader.GetString(1);
                numC = reader.GetInt32(2);
                contenus_P.Add(new Contenu_Piece(quantiteP, numP, numC));
            }
            connection.Close();
        }

        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des comptes fidelios via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureFidelio
        public void LectureFidelio(MySqlConnection connection)
        {
            fidelios.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from fidelio;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int numero;
            string description;
            int cout;
            int duree;
            int rabais;

            while (reader.Read())// parcours ligne par ligne
            {
                numero = reader.GetInt32(0);
                description = reader.GetString(1);
                cout = reader.GetInt32(2);
                duree = reader.GetInt32(3);
                rabais = reader.GetInt32(4);
                fidelios.Add(new Fidelio(numero,description,cout,duree,rabais));
            }
            connection.Close();
        }

        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des productions via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureProduction
        public void LectureProduction(MySqlConnection connection)
        {
            productions.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from production;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string numP;
            string siret;

            while (reader.Read())// parcours ligne par ligne
            {
                numP = reader.GetString(0);
                siret = reader.GetString(1);                
                productions.Add(new Livraison(numP,siret));
            }
            connection.Close();
        }
        #endregion
        //string numP,string siret,DateTime date_introP,DateTime date_sortieP
        /// <summary>
        /// Cette méthode recrée la liste des commandes via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureLivraison
        public void LectureLivraison(MySqlConnection connection)
        {
            livraisons.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from livraison;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string numP;
            string siret;
            DateTime date_introP;
            DateTime date_sortieP;

            while (reader.Read())// parcours ligne par ligne
            {
                date_introP = ConversionDateTime(reader.GetString(0));
                date_sortieP = ConversionDateTime(reader.GetString(1));
                numP = reader.GetString(2);
                siret = reader.GetString(3);
                livraisons.Add(new Production(date_introP,date_sortieP, numP, siret));
            }
            connection.Close();
        }
        #endregion
    }
}

