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
            LectureCommande(connexion);
            LecturePiece(connexion);
            LectureEntreprises(connexion);
            LectureIndividu(connexion);
            LectureFournisseur(connexion);
            LectureAssemblage(connexion);
            LectureContenu_M(connexion);
            LectureContenu_P(connexion);
            LectureFidelio(connexion);
            LectureProduction(connexion);
            LectureLivraison(connexion);
        }

        public BddVelo(List<Modele> m)
        {
            this.modeles = m;
        }

        #region Affichage Modele
        public void AffichageModele()
        {
            foreach (Modele modele in modeles)
            {
                Console.WriteLine(modele.ToString());
            }
        }
        #endregion

        #region AffichagePiece
        public void AffichagePiece()
        {
            foreach (Piece piece in pieces)
            {
                Console.WriteLine(piece.ToString());
            }
        }
        #endregion

        #region AffichageFournisseur
        public void AffichageFournisseur()
        {
            foreach (Fournisseur fournisseur in fournisseurs)
            {
                Console.WriteLine(fournisseur.Afficher());
            }
        }
        #endregion

        #region AffichageCommande
        public void AffichageCommande()
        {
            foreach (Commande commande in commandes)
            {
                Console.WriteLine(commande.ToString());
            }
        }
        #endregion

        #region AffichageEntreprise
        public void AffichageEntreprise()
        {
            foreach (Entreprise entreprise in entreprises)
            {
                Console.WriteLine(entreprise.ToString());
            }
        }
        #endregion

        #region AffichageIndividu
        public void AffichageIndividu()
        {
            foreach (Individu individu in individus)
            {
                Console.WriteLine(individu.AfficherIndividu());
            }
        }
        #endregion

        #region StockPiece
        public void StockParPiece()
        {
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select numP,sum(stock) from piece group by numP;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string numP;
            int stock;

            while (reader.Read())// parcours ligne par ligne
            {
                numP = reader.GetString(0);
                stock = reader.GetInt32(1);
                Console.WriteLine($"Numéro de la pièce : {numP} | Stock par pièce : {stock}");
            }
            connexion.Close();
        }
        #endregion

        #region StockPieceParFournisseur
        public void StockPieceParFournisseur()
        {
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select siret,stockF from fournisseur;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string siret;
            int stockF;

            while (reader.Read())// parcours ligne par ligne
            {
                siret = reader.GetString(0);
                stockF = reader.GetInt32(1);
                Console.WriteLine($"Numéro de Siret du fournisseur : {siret} | Stock de pièces par fournisseur {stockF}");
            }
            connexion.Close();
        }
        #endregion

        #region StockVeloParLigne
        public void StockVeloParLigne()
        {
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select ligne,sum(stockM) from modele group by ligne;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string ligne;
            int stockM;

            while (reader.Read())// parcours ligne par ligne
            {
                ligne = reader.GetString(0);
                stockM = reader.GetInt32(1);
                Console.WriteLine($"Ligne de vélo : {ligne} | Stock par ligne : {stockM}");
            }
            connexion.Close();
        }
        #endregion

        #region StockVeloParMarque
        public void StockVeloParMarque()
        {
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select nomVelo,sum(stockM) from modele group by nomVelo;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string nomVelo;
            int stockM;

            while (reader.Read())// parcours ligne par ligne
            {
                nomVelo = reader.GetString(0);
                stockM = reader.GetInt32(1);
                Console.WriteLine($"Marque de vélo : {nomVelo} | Stock par marque : {stockM}");
            }
            connexion.Close();
        }
        #endregion

        #region StockVeloParGrandeur
        public void StockVeloParGrandeur()
        {
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select grandeur,sum(stockM) from modele group by grandeur;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string grandeur;
            int stockM;

            while (reader.Read())// parcours ligne par ligne
            {
                grandeur = reader.GetString(0);
                stockM = reader.GetInt32(1);
                Console.WriteLine($"Grandeur de Vélo : {grandeur} | Stock par grandeur : {stockM}");
            }
            connexion.Close();
        }
        #endregion

        #region MeilleurClient
        /// <summary>
        /// Retrouvez-le (ou les) meilleur client en fonction des quantités vendues en nombre de  pièces vendues ou en cumul en euros 
        /// </summary>
        public void MeilleurClient(MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select nomE, volume_achat from entreprise order by volume_achat desc;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nomE;
            int volumeachat;
            int volcopy = 0;
            bool stop = false;
            int count = 0;
            Console.WriteLine("\nMeilleur client Entreprise");
            while (reader.Read() && stop == false)// parcours ligne par ligne
            {
                nomE = reader.GetString(0);
                volumeachat = reader.GetInt32(1);

                if (volcopy <= volumeachat || count == 0)
                {
                    volcopy = volumeachat;
                }

                else if (volcopy > volumeachat)
                {
                    stop = true;
                }

                if (stop == false)
                {
                    Console.WriteLine($"nom Entreprise : {nomE} | volume d'achat :{volumeachat}");
                }
                count += 1;
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select nomI,prenom,sum(quantiteP*prixP) " +
            "from individu natural join commande " +
            "natural join contenu_piece " +
            "natural join piece group by id order by sum(quantiteP * prixP) desc; ";

            reader = command.ExecuteReader();
            string nomI;
            string prenom;
            int cumul = 0;
            stop = false;
            int copy = 0;
            count = 0;
            Console.WriteLine("\nMeilleur client Individu en cumul euros pour les pièces");
            while (reader.Read() && stop == false)// parcours ligne par ligne
            {
                nomI = reader.GetString(0);
                prenom = reader.GetString(1);
                cumul = reader.GetInt32(2);

                if (copy <= cumul || count == 0)
                {
                    copy = cumul;
                }

                else if (copy > cumul)
                {
                    stop = true;
                }

                if (stop == false)
                {
                    Console.WriteLine($"Nom : {nomI} | Prenom : {prenom} | cumul de pièces :{cumul} euros");
                }
                count += 1;
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select nomI,prenom,sum(quantiteM * prix) " +
            "from individu natural join commande " +
            "natural join contenu_modele " +
            "natural join modele group by id " +
            "order by sum(quantiteM * prix) desc;";

            reader = command.ExecuteReader();


            stop = false;
            copy = 0;
            count = 0;
            Console.WriteLine("\nMeilleur client Individu en cumul euros pour les modèles");
            while (reader.Read() && stop == false)// parcours ligne par ligne
            {
                nomI = reader.GetString(0);
                prenom = reader.GetString(1);
                cumul = reader.GetInt32(2);

                if (copy <= cumul || count == 0)
                {
                    copy = cumul;
                }

                else if (copy > cumul)
                {
                    stop = true;
                }

                if (stop == false)
                {
                    Console.WriteLine($"Nom : {nomI} | Prenom : {prenom} | cumul de modèles :{cumul} euros");
                }
                count += 1;
            }
            connection.Close();
        }
        #endregion

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
        /// Méthode qui retourne le nombre de pieces et de modèles dont le stock est inférieur ou égale à 2
        /// </summary>
        #region ProduitStock2
        public void ProduitStock2()
        {
            for (int i = 0; i < pieces.Count(); i++)
            {
                if (pieces[i].Stock <= 2)
                {
                    Console.WriteLine(pieces[i].ToString());
                }

            }
            Console.WriteLine("\n");
            for (int i = 0; i < modeles.Count(); i++)
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
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select id,nomI,prenom,descriptionf from individu i join fidelio f on " +
            "f.numero=i.numero order by descriptionf;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int id;
            string nomI;
            string prenom;
            string descriptionf;

            while (reader.Read())// parcours ligne par ligne
            {
                id = reader.GetInt32(0);
                nomI = reader.GetString(1);
                prenom = reader.GetString(2);
                descriptionf = reader.GetString(3);
                Console.WriteLine($"Id :{id} | nomI : {nomI} | prenom :{prenom} | description : {descriptionf}");
            }
            connection.Close();
        }
        #endregion


        #region Pièces/Vélos par Fournisseur
        public void NbproduitFournisseur(MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select nomF,count(*),siret from livraison natural join fournisseur group by siret;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string nomF;
            int nbpieces;
            string siret;
            Console.WriteLine("\nNombres de pièces et/ou vélos fournis par fournisseur.");
            while (reader.Read())// parcours ligne par ligne
            {
                nomF = reader.GetString(0);
                nbpieces = reader.GetInt32(1);
                siret = reader.GetString(2);
                Console.WriteLine($"Nom fournisseur :{nomF} | Nombre de pièces : {nbpieces} | siret :{siret}");
            }
            connection.Close();
        }
        #endregion

        #region RapportStat
        public void RapportStat(MySqlConnection connection)
        {
            var liste_Modele_Vendus = new List<Tuple<Modele, int>>();
            var liste_Piece_Vendues = new List<Tuple<Piece, int>>();

            int nbModele = 0;
            int nbPiece = 0;

            connection.Open();
            MySqlCommand commandModele = connection.CreateCommand();
            commandModele.CommandText = "select modele.*, sum(quantiteM) from contenu_modele natural join modele group by  numM;";
            MySqlDataReader readerModele;
            readerModele = commandModele.ExecuteReader();

            int numM;
            string nomVelo;
            string grandeur;
            int prix;
            string ligne;
            DateTime date_intro;
            DateTime date_sortie;
            int stockM = 0;

            string numP;
            string descriptionP;
            int num_catalogue;
            int delai;
            int stock;
            int prixP;

            while (readerModele.Read())// parcours ligne par ligne
            {
                numM = readerModele.GetInt32(0);
                nomVelo = readerModele.GetString(1);
                grandeur = readerModele.GetString(2);
                prix = readerModele.GetInt32(3);
                ligne = readerModele.GetString(4);
                date_intro = ConversionDateTime(readerModele.GetString(5));
                date_sortie = ConversionDateTime(readerModele.GetString(6));
                nbModele = readerModele.GetInt32(7);
                stockM = readerModele.GetInt32(7);

                Modele modele0 = new Modele(numM, nomVelo, grandeur,ligne,prix, date_intro, date_sortie, stockM);
                var monTupleModele = Tuple.Create(modele0, nbModele);
                liste_Modele_Vendus.Add(monTupleModele);
            }


            MySqlCommand commandPiece = connection.CreateCommand();
            commandPiece.CommandText = "select  piece.* ,sum(quantiteP)from contenu_piece  natural join piece  group by  numP;";
            MySqlDataReader readerPiece;
            readerPiece = commandPiece.ExecuteReader();

            while (readerPiece.Read())// parcours ligne par ligne
            {
                numP = readerPiece.GetString(0);
                descriptionP = readerPiece.GetString(1);
                num_catalogue = readerPiece.GetInt32(2);
                delai = readerPiece.GetInt32(3);
                stock = readerPiece.GetInt32(4);
                prixP = readerPiece.GetInt32(5);
                nbPiece = readerPiece.GetInt32(6);

                //  stock = reader.GetInt32(6);
                Piece piece0 = new Piece(numP, descriptionP, num_catalogue, delai, stock, prixP);
                var monTuplePiece = Tuple.Create(piece0, nbPiece);
                liste_Piece_Vendues.Add(monTuplePiece);
            }
            connection.Close();

  //List<Tuple<object, int>>[] res = [liste_Modele_Vendus, liste_Piece_Vendues];


        }
        #endregion

        #region Date_Expiration
        public List<Tuple<Individu, DateTime>> Date_Expiration(MySqlConnection connection)
        {
            var liste_date_expi = new List<Tuple<Individu, DateTime>>();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select individu.*,date_adhesion, duree from individu natural join fidelio where date_adhesion is not null;";
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
            DateTime date_adhesion;
            int duree;
            DateTime date_expiration;


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
                date_adhesion = ConversionDateTime(reader.GetString(8));
                duree = reader.GetInt32(9);
                

                date_expiration = date_adhesion.AddYears(duree);
                Individu indiv = new Individu(id, nomI, prenom, telephoneI, adresseI, courrielI, numero,date_adhesion,date_expiration);
                var monTuple = Tuple.Create(indiv, date_expiration);
                liste_date_expi.Add(monTuple);
            }


            connection.Close();

            return liste_date_expi;
        }
        #endregion

        #region Date_Expiration
        public DateTime Date_Expi(int id,MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select duree,date_adhesion from individu i natural join fidelio where i.id="+id+";";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int duree = 0;
            DateTime date_adhesion=new DateTime();
            DateTime date_expi;
            while (reader.Read())// parcours ligne par ligne
            {
                duree = reader.GetInt32(0);
                date_adhesion = ConversionDateTime(reader.GetString(1));
            }
            connection.Close();
            date_expi = date_adhesion.AddYears(duree);
            return date_expi;
        }
        #endregion

        #region Moyennes
        public int Moyenne_Montant(MySqlConnection connection)
        {



            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select PrixP*quantiteP from commande natural join contenu_piece natural join piece;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int moyPrixPieceParCommande = 0;
            int cptPiece = 0;
            int nbPrixPieceParCommande;

            while (reader.Read())// parcours ligne par ligne
            {
                nbPrixPieceParCommande = reader.GetInt32(0);
                moyPrixPieceParCommande += nbPrixPieceParCommande;
                cptPiece++;

            }

            int moyModele = 0;
            int cptModele = 0;

            MySqlCommand commandModele = connection.CreateCommand();
//command.CommandText = "select sum(PrixP) from commande natural join contenu_modele natural join modele natural join piece natural join assemblage group by numC;";
            command.CommandText = "select prix*quantiteM from commande natural join contenu_modele natural join modele;";
            MySqlDataReader readerModele;
            readerModele = commandModele.ExecuteReader();

            int nbPrixModeleParCommande = 0;

            while (reader.Read())// parcours ligne par ligne
            {
                nbPrixModeleParCommande = reader.GetInt32(0);
                moyModele += nbPrixModeleParCommande;
                cptModele++;
            }

            int moyenneTotale = (moyPrixPieceParCommande + moyModele) / (cptModele + cptPiece);


            connexion.Close();

            return moyenneTotale;
        }
        public int Moyenne_Piece(MySqlConnection connection)
        {
            int moy = 0;
            int cpt = 0;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select sum(quantiteP) from piece natural join contenu_piece natural join commande group by NumC;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int nbPieceParCommande;

            while (reader.Read())// parcours ligne par ligne
            {
                nbPieceParCommande = reader.GetInt32(0);
                moy += nbPieceParCommande;
                cpt += 1;
            }
            connection.Close();
            moy = moy / cpt;

            return moy;
        }

        public int Moyenne_Modele(MySqlConnection connection)
        {
            int moy = 0;
            int cpt = 0;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select sum(quantiteM) from modele natural join contenu_modele natural join commande group by NumC;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int nbModeleParCommande;

            while (reader.Read())// parcours ligne par ligne
            {
                nbModeleParCommande = reader.GetInt32(0);
                moy += nbModeleParCommande;
                cpt += 1;
            }
            connection.Close();
            moy = moy / cpt;

            return moy;



        }
        #endregion

        #region ConversionDateTime
        public  static DateTime ConversionDateTime(string date)
        {

            string[] tab = date.Split('/');

            DateTime convDate = new DateTime(Convert.ToInt32("20" + tab[2]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[0]));

            return convDate;
        }
        #endregion

        #region Delete
        public  void Delete(MySqlConnection connection,string table,string tab)
        {
            string[] tab1 = tab.Split(',');
            string key = tab1[1];
            string id = tab1[0];
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from {table} where {key}={id};";
            connection.Close();
            Choose(connection, table);
        }
        #endregion

        #region Choose
        public  void Choose(MySqlConnection connection,string table)
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
        public  void Creer(MySqlConnection connection, string nomtable, string valeurs)
        {
        //    string valeurSql = "";
        //    for(int i =0; i < valeurs.Length-1; i++)
        //    {
        //        valeurSql = valeurSql + valeurs[i] + ",";
        //    }
        //    valeurSql = valeurSql + valeurs[valeurs.Length - 1];

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into {nomtable} values ({valeurs});";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            Choose(connection, nomtable);
        }
        #endregion       

        #region MAJ
        public void MAJ(MySqlConnection connection,string tab, string nomtable)
        {
            string[] tab1 = tab.Split(',');
            int n;
            if(Int32.TryParse(tab1[2],out n) == false)
            {
                tab1[2] = $"'{tab1[2]}";
            }

            string maj = tab1[2];
            string attribut = tab1[1];
            string cle = tab1[0];

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"update {nomtable} set {attribut = maj} where {attribut =cle};";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            connection.Close();
            Choose(connection,nomtable);
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
            int stockM;

            while (reader.Read())// parcours ligne par ligne
            {
                numM = reader.GetInt32(0);
                nomVelo = reader.GetString(1);
                grandeur = reader.GetString(2);
                prix = reader.GetInt32(3);
                ligne = reader.GetString(4);
                date_intro = ConversionDateTime(reader.GetString(5));
                date_sortie = ConversionDateTime(reader.GetString(6));
                stockM = reader.GetInt32(7);
                modeles.Add(new Modele(numM, nomVelo, grandeur, ligne, prix, date_intro, date_sortie, stockM));
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
            pieces.Clear();
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
                pieces.Add(new Piece(numP, descriptionP, num_catalogue, delai, stock, prixP));
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
            DateTime date_adhesion;
            DateTime date_expiration;
            while (reader.Read())// parcours ligne par ligne
            {
                id = reader.GetInt32(0);
                nomI = reader.GetString(1);
                prenom = reader.GetString(2);
                telephoneI = reader.GetString(3);
                adresseI = reader.GetString(4);
                courrielI = reader.GetString(5);
                numero = reader.GetInt32(6);
                date_adhesion = ConversionDateTime(reader.GetString(7));
                
                individus.Add(new Individu(id, nomI, prenom, telephoneI, adresseI, courrielI, numero, date_adhesion));
            }
            connection.Close();
            for(int i = 0; i < individus.Count();i++)
            {
                date_expiration = Date_Expi(individus[i].Id, connection);
                individus[i].Date_Expiration = date_expiration;
            }

            
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
                entreprises.Add(new Entreprise(nomE, telephoneE, adresseE, courrielE, contactE, volume_achat, remise));
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

                if (!reader.IsDBNull(4))
                {
                    nomE = reader.GetString(4);
                    commandes.Add(new Commande(numC, dateC, dateLivraison, adresseC, nomE));
                }

                else
                {
                    id = reader.GetInt32(5);
                    commandes.Add(new Commande(numC, dateC, dateLivraison, adresseC, id));
                }
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
                siret = reader.GetString(0);
                nomF = reader.GetString(1);
                adresseF = reader.GetString(2);
                contactF = reader.GetString(3);
                libelle = reader.GetInt32(4);
                stockF = reader.GetInt32(5);
                fournisseurs.Add(new Fournisseur(siret, nomF, adresseF, contactF, libelle, stockF));
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
                assemblages.Add(new Assemblage(numM, numP));
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
                numM = reader.GetInt32(1);
                numC = reader.GetInt32(2);
                contenus_M.Add(new Contenu_Modele(quantiteM, numM, numC));
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
                fidelios.Add(new Fidelio(numero, description, cout, duree, rabais));
            }
            connection.Close();
        }

        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des productions via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureProduction
        public void LectureLivraison(MySqlConnection connection)
        {
            productions.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from livraison;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string numP;
            string siret;

            while (reader.Read())// parcours ligne par ligne
            {
                numP = reader.GetString(0);
                siret = reader.GetString(1);
                productions.Add(new Livraison(numP, siret));
            }
            connection.Close();
        }
        #endregion
        /// <summary>
        /// Cette méthode recrée la liste des commandes via une requête SQL. Elle est utilisé lorsqu'on modifie la liste
        /// </summary>
        /// <param name="connection"></param>

        #region LectureLivraison
        public void LectureProduction(MySqlConnection connection)
        {
            livraisons.Clear();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from production;";
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
                livraisons.Add(new Production(date_introP, date_sortieP, numP, siret));
            }
            connection.Close();
        }
        #endregion
    }
}

