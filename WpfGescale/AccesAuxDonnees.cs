using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace WpfGescale
{
    public static class AccesAuxDonnees
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static List<Pavillon> ChargerPavillons()
        {
            List<Pavillon> LesPavillons = new List<Pavillon>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListePavillon = new SqlCommand("SELECT * FROM PAVILLON", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurPavillon = CommandeListePavillon.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurPavillon.Read())
            {
                // Ajout de la ligne dans la collection
                LesPavillons.Add(new Pavillon((string)LecteurPavillon["CodPav"], (string)LecteurPavillon["LibPav"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();

            return LesPavillons;
        }
        public static void SupprimerPavillon(Pavillon PavillonASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionPavillon = new SqlCommand("DELETE FROM PAVILLON WHERE CodPav=@PCodPav", ConnexionEscale);
            CommandeSuppressionPavillon.Parameters.Add("@PCodPav", System.Data.SqlDbType.NChar, 3).Value = PavillonASupprimer.Code;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionPavillon.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
        public static void ModifierPavillon(Pavillon PavillonAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajPavillon = new SqlCommand("UPDATE PAVILLON SET LibPav=@PLibPav WHERE CodPav=@PCodPav", ConnexionEscale);
            CommandeMajPavillon.Parameters.Add("@PCodPav", System.Data.SqlDbType.NChar, 3).Value = PavillonAModifier.Code;
            CommandeMajPavillon.Parameters.Add("@PLibPav", System.Data.SqlDbType.NChar, 30).Value = PavillonAModifier.Libelle;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajPavillon.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void AjouterPavillon(Pavillon PavillonAAjouter)
        {
            SqlCommand CommandeInsertionVisite = new SqlCommand("INSERT INTO PAVILLON(CodPav,LibPav) VALUES (@PCodPav,@PLibPav)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionVisite.Parameters.Add("@PCodPav", System.Data.SqlDbType.NChar).Value = PavillonAAjouter.Code;
            CommandeInsertionVisite.Parameters.AddWithValue("@PLibPav", System.Data.SqlDbType.NChar).Value = PavillonAAjouter.Libelle;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            //Exécution de la commande d'insertion
            CommandeInsertionVisite.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }  

        public static void AjouterEscale(Escale EScaleAAjouter)
        {
            // Insertion de l'enregistrement dans la BD
            SqlCommand CommandeInsertionEscale = new SqlCommand("INSERT INTO ESCALE (@datArr, @HeureArr, @datDep, @HeureDep, @qteFre, @conEsc, @cTyCar, @codAge, @numLlo, @CodPavProv, @CodPorProv, @CodPavDest, @CodPorDest)");
            // Ajout des paramètres
            CommandeInsertionEscale.Parameters.AddWithValue("@datArr", EScaleAAjouter.DatedArrivee);
            CommandeInsertionEscale.Parameters.AddWithValue("@HeureArr", EScaleAAjouter.HeuredArrivee);
            CommandeInsertionEscale.Parameters.AddWithValue("@datDep", EScaleAAjouter.DatedeDepart);
            CommandeInsertionEscale.Parameters.AddWithValue("@HeureDep", EScaleAAjouter.HeuredeDepart);
            CommandeInsertionEscale.Parameters.AddWithValue("@qteFre", EScaleAAjouter.QuantiteFret);
            CommandeInsertionEscale.Parameters.AddWithValue("@conEsc", EScaleAAjouter.ConEscale);
            CommandeInsertionEscale.Parameters.AddWithValue("@cTyCar", EScaleAAjouter.CTypedeCargaison);
            CommandeInsertionEscale.Parameters.AddWithValue("@codAge", EScaleAAjouter.CodeAgent);
            CommandeInsertionEscale.Parameters.AddWithValue("@numLlo", EScaleAAjouter.NumeLlo);
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPavProv", EScaleAAjouter.CodePavProv);
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPorProv", EScaleAAjouter.CodePorProv);
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPavDest", EScaleAAjouter.CodePavDest);
            CommandeInsertionEscale.Parameters.AddWithValue("@CodPorDest", EScaleAAjouter.CodePorDest);

            // Ouverture de la connexion
            ConnexionEscale.Open();

            //Exécution de la commande d'insertion
            CommandeInsertionEscale.ExecuteNonQuery();

            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

    }
}
