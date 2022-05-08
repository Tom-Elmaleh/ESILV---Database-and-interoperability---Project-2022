using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProjetBDD_VeloMax
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MenuClass menu = new MenuClass();
            menu.Menu();

            BddVelo bdd = new BddVelo();
            //bdd.Models;
        }
    }
}
