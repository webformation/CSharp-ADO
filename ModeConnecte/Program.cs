using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeConnecte
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connexion = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = demo; Integrated Security = True");
            SqlCommand commande = new SqlCommand("select * from annuaire", connexion);
            connexion.Open();
            SqlDataReader resultat = commande.ExecuteReader();
            while (resultat.Read())
            {
                Console.Write(resultat["nom"].ToString() + " ");
                Console.WriteLine(resultat["age"].ToString());
            }
            Console.WriteLine("----------------------");
            commande.CommandText = "select * from annuaire where nom='toto'";
            if (resultat != null) resultat.Close();
            resultat = commande.ExecuteReader();
            while (resultat.Read())
            {
                Console.Write(resultat["nom"].ToString() + " ");
                Console.WriteLine(resultat["age"].ToString());
            }
            Console.WriteLine("----------------------");
            commande.CommandText = "select * from annuaire where nom=@NomCherche";
            commande.Prepare();
            SqlParameter recherchenom = new SqlParameter("NomCherche", SqlDbType.VarChar,20);
            recherchenom.Value ="test";
            commande.Parameters.Add(recherchenom);
            if (resultat != null) resultat.Close();
            resultat = commande.ExecuteReader();
            while (resultat.Read())
            {
                Console.Write(resultat["nom"].ToString() + " ");
                Console.WriteLine(resultat["age"].ToString());
            }
            if (resultat != null) resultat.Close();
            if (connexion.State == ConnectionState.Open) connexion.Close();
        }
    }
}
