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

        static void Test(MySqlConnection connection)
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

            foreach (Modele element in modeles)
            {
                Console.WriteLine(element.ToString());
            }

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

            Test(maConnexion);
        }
    }
}
