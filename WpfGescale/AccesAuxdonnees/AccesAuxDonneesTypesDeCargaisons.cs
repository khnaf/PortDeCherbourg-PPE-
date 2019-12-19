using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Xml;

namespace WpfGescale
{
    class AccesAuxDonneesTypesDeCargaisons
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static void AjouterTypesDeCargaisons(TypesDeCargaisons TypesDeCargaisonsAAjouter)
        {
            SqlCommand CommandeInsertionVisite = new SqlCommand("INSERT INTO [TYPE-CARGAISON](CTyCar, LibCar, DanCar) VALUES (@PCTyCar,@PLibCar,@PDanCar)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionVisite.Parameters.Add("@PCTyCar", System.Data.SqlDbType.NChar).Value = TypesDeCargaisonsAAjouter.Code;
            CommandeInsertionVisite.Parameters.AddWithValue("@PLibCar", System.Data.SqlDbType.NChar).Value = TypesDeCargaisonsAAjouter.Libelle;
            CommandeInsertionVisite.Parameters.AddWithValue("@PDanCar", System.Data.SqlDbType.Bit).Value = TypesDeCargaisonsAAjouter.DanCar;
            // Ouverture de la connexion 
            ConnexionEscale.Open();
            //Exécution de la commande d'insertion 
            CommandeInsertionVisite.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void SupprimerTypesDeCargaisons(TypesDeCargaisons TypesDeCargaisonsASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionTypesDeCargaisons = new SqlCommand("DELETE FROM [TYPE-CARGAISON] WHERE [TYPE-CARGAISON].CTyCar=@PCTyCar ", ConnexionEscale);
            CommandeSuppressionTypesDeCargaisons.Parameters.Add("@PCTyCar", System.Data.SqlDbType.NChar, 2).Value = TypesDeCargaisonsASupprimer.Code;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionTypesDeCargaisons.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void ModifierTypesDeCargaisons(TypesDeCargaisons TypesDeCargaisonsAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajTypesDeCargaisons = new SqlCommand("UPDATE [TYPE-CARGAISON] SET LibCar=@PLibCar WHERE CTyCar=@CTyCar", ConnexionEscale);
            CommandeMajTypesDeCargaisons.Parameters.Add("@CTyCar", System.Data.SqlDbType.NChar, 3).Value = TypesDeCargaisonsAModifier.Code;
            CommandeMajTypesDeCargaisons.Parameters.Add("@PLibCar", System.Data.SqlDbType.NChar, 30).Value = TypesDeCargaisonsAModifier.Libelle;
            CommandeMajTypesDeCargaisons.Parameters.Add("@PDanCar", System.Data.SqlDbType.NChar, 30).Value = TypesDeCargaisonsAModifier.Libelle;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajTypesDeCargaisons.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static List<TypesDeCargaisons> ChargerTypesDeCargaisons()
        {
            List<TypesDeCargaisons> LesTypesDeCargaisons = new List<TypesDeCargaisons>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeTypesDeCargaisons = new SqlCommand("SELECT * FROM [TYPE-CARGAISON]", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurTypesDeCargaisons = CommandeListeTypesDeCargaisons.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurTypesDeCargaisons.Read())
            {
                // Ajout de la ligne dans la collection
                LesTypesDeCargaisons.Add(new TypesDeCargaisons((string)LecteurTypesDeCargaisons["CTyCar"], (string)LecteurTypesDeCargaisons["LibCar"], (bool)LecteurTypesDeCargaisons["DanCar"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();
            return LesTypesDeCargaisons;
        }


    }

}