using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetBDD_VeloMax
{
    class Individu
    {
        private int id;
        private string nomI;
        private string prenom;
        private string telephoneI;
        private string adresseI;
        private string courrielI;
        private int numero;
        private DateTime date_adhesion;
        private DateTime date_expiration;
        private MySqlConnection connection = Connection();

        public int Id { get { return id; } set { id = value; } }
        public string Nom { get { return nomI; } set { nomI = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Telephone { get { return telephoneI; } set { telephoneI = value; } }
        public string Adresse { get { return adresseI; } set { adresseI = value; } }
        public string Courriel { get { return courrielI; } set { courrielI = value; } }
        public int Numero { get { return numero; } set { numero = value; } }
        public DateTime Date_Adhesion { get { return date_adhesion; } set { date_adhesion = value; } }
        public DateTime Date_Expiration { get { return date_expiration; } set { date_expiration = value; } }

        public Individu(int id, string nomI, string prenom, string telephoneI, string adresseI, string courrielI, int numero, DateTime date_adhesion)
        {
            this.id = id;
            this.nomI = nomI;
            this.prenom = prenom;
            this.telephoneI = telephoneI;
            this.adresseI = adresseI;
            this.courrielI = courrielI;
            this.numero = numero;
            this.date_adhesion = date_adhesion;
            date_expiration = Date_Expi(connection);
        }

        public Individu(int id, string nomI, string prenom, string telephoneI, string adresseI, string courrielI, int numero, DateTime date_adhesion, DateTime date_expiration)
        {
            this.id = id;
            this.nomI = nomI;
            this.prenom = prenom;
            this.telephoneI = telephoneI;
            this.adresseI = adresseI;
            this.courrielI = courrielI;
            this.numero = numero;
            this.date_adhesion = date_adhesion;
            this.date_expiration = date_expiration;
        }

        public Individu(string nomI, string prenom, DateTime date_adhesion, DateTime date_expiration)
        : this(0, nomI, prenom, "", "", "", 0, date_adhesion, date_expiration)
        {
        }

        public Individu()
            : this("N/C", "N/C", DateTime.MinValue, DateTime.MinValue)
        {
        }

        public override string ToString()
        {
            DateTime date = Convert.ToDateTime(date_expiration.Subtract(DateTime.Today));

            Console.WriteLine(date);

            if (date.Month < 2)
            {
                return id + nomI + prenom + numero + date_expiration;
            }

            else
            {
                return id + nomI + prenom + date_adhesion;
            }
        }

        static MySqlConnection Connection()
        {
            string password = "";
            MySqlConnection maConnexion = null;
            password = "I#mvengeance103darkness";   // Cas de l'utilisateur root avec les droits 
            string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         $"UID=root;PASSWORD={password}";
            maConnexion = new MySqlConnection(connexionString);
            return maConnexion;
        }


        #region Date_Expiration
        public DateTime Date_Expi(MySqlConnection connection)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select duree from individu natural join fidelio where date_adhesion is not null;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            int duree = 0;
            DateTime date_expi;
            while (reader.Read())// parcours ligne par ligne
            {
                duree = reader.GetInt32(0);
            }
            connection.Close();

            date_expi = date_adhesion.AddYears(duree);
            return date_expi;
        }
        #endregion

        public string AfficherIndividu()
        {
            return $"ID : {id} | Nom : {nomI} | Prenom : {prenom} | Telephone : {telephoneI} | Adresse : {adresseI} | Courriel {courrielI}"
            + $"NumeroF {numero} | Date_adhesion {date_adhesion}";
        }
    }
}
