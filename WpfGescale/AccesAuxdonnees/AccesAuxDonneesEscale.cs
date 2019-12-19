using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using WpfGescale;

namespace WpfGescale
{
    class AccesAuxDonneesEscale
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static void AjouterEscale(Escale EScaleAAjouter)
        {
            ConnexionEscale.Close();
            // Insertion de l'enregistrement dans la BD
            SqlCommand CommandeInsertionEscale = new SqlCommand("INSERT INTO ESCALE (DatArr, HeureArr, DatDep, HeureDep, QteFre, ConEsc, CTyCar, CodAge, NumLlo, CodPavProv, CodPorProv, CodPavDest, CodPorDest, NumPilEntree, NumPilSortie) VALUES(@datArr, @HeureArr, @datDep, @HeureDep, @qteFre, @conEsc, @cTyCar, @codAge, @numLlo, @CodPavProv, @CodPorProv, @CodPavDest, @CodPorDest, @NumPilArrivee, @NumPilDepart)", ConnexionEscale);

            // Ajout des paramètres
            
            CommandeInsertionEscale.Parameters.AddWithValue("@datArr", System.Data.SqlDbType.Date).Value = EScaleAAjouter.DatedArrivee.ToString();
            CommandeInsertionEscale.Parameters.AddWithValue("@HeureArr", System.Data.SqlDbType.Time).Value = EScaleAAjouter.HeuredArrivee.ToShortTimeString();
            CommandeInsertionEscale.Parameters.AddWithValue("@datDep", System.Data.SqlDbType.Date).Value = EScaleAAjouter.DatedeDepart.ToString();
            CommandeInsertionEscale.Parameters.AddWithValue("@HeureDep", System.Data.SqlDbType.Time).Value = EScaleAAjouter.HeuredeDepart.ToShortTimeString();
            CommandeInsertionEscale.Parameters.AddWithValue("@qteFre", System.Data.SqlDbType.Decimal).Value = EScaleAAjouter.QuantiteFret;
            CommandeInsertionEscale.Parameters.AddWithValue("@conEsc", System.Data.SqlDbType.Binary).Value = EScaleAAjouter.ConEscale.ToString();
            CommandeInsertionEscale.Parameters.AddWithValue("@cTyCar", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CTypedeCargaison;
            CommandeInsertionEscale.Parameters.AddWithValue("@codAge", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CodeAgent;
            CommandeInsertionEscale.Parameters.AddWithValue("@numLlo", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.NumeLlo;
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPavProv", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CodePavProv;
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPorProv", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CodePorProv;
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPavDest", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CodePavDest;
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPorDest", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.CodePorDest;
            CommandeInsertionEscale.Parameters.AddWithValue("@NumPilArrivee", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.NumPiloteArrivee;
            CommandeInsertionEscale.Parameters.AddWithValue("@NumPilDepart", System.Data.SqlDbType.NChar).Value = EScaleAAjouter.NumPiloteDepart;

            // Ouverture de la connexion
            ConnexionEscale.Open();

            //Exécution de la commande d'insertion
            CommandeInsertionEscale.ExecuteNonQuery();

            // Fermeture de la connexion
            ConnexionEscale.Close();

        }
    }
}
