using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using WpfGescale;
using System.Windows.Forms;

namespace WpfGescale
{
    class AccesAuxDonneesPilote
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);

        public static void AjouterPilote(Pilote PiloteAAjouter)
        {
            SqlCommand CommandeInsertionPilote = new SqlCommand("INSERT INTO PILOTE(NumPil,NomPil,PrenPil,TelPil,MelPil) VALUES (@NumPil,@NomPil,@PrenPil,@TelPil,@MelPil)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionPilote.Parameters.AddWithValue("@NumPil", System.Data.SqlDbType.Int).Value = PiloteAAjouter.Code;
            CommandeInsertionPilote.Parameters.AddWithValue("@NomPil", System.Data.SqlDbType.NChar).Value = PiloteAAjouter.Nom;
            CommandeInsertionPilote.Parameters.AddWithValue("@PrenPil", System.Data.SqlDbType.NChar).Value = PiloteAAjouter.Prenom;
            CommandeInsertionPilote.Parameters.AddWithValue("@TelPil", System.Data.SqlDbType.NChar).Value = PiloteAAjouter.Telephone;
            CommandeInsertionPilote.Parameters.AddWithValue("@MelPil", System.Data.SqlDbType.NChar).Value = PiloteAAjouter.Mail;
            try
            {
                // Ouverture de la connexion
                ConnexionEscale.Close();
                ConnexionEscale.Open();
                //Exécution de la commande d'insertion
                CommandeInsertionPilote.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Ce numéro existe déjà !");
                }
            }
        }
        public static void ModifierPilote(Pilote PiloteAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajPilote = new SqlCommand("UPDATE PILOTE SET NomPil=@NomPil,PrenPil=@PrenPil,TelPil=@TelPil,MelPil=@MelPil WHERE NumPil=@NumPil", ConnexionEscale);
            CommandeMajPilote.Parameters.AddWithValue("@NumPil", System.Data.SqlDbType.Int).Value = PiloteAModifier.Code;
            CommandeMajPilote.Parameters.AddWithValue("@NomPil", System.Data.SqlDbType.NChar).Value = PiloteAModifier.Nom;
            CommandeMajPilote.Parameters.AddWithValue("@PrenPil", System.Data.SqlDbType.NChar).Value = PiloteAModifier.Prenom;
            CommandeMajPilote.Parameters.AddWithValue("@TelPil", System.Data.SqlDbType.NChar).Value = PiloteAModifier.Telephone;
            CommandeMajPilote.Parameters.AddWithValue("@MelPil", System.Data.SqlDbType.NChar).Value = PiloteAModifier.Mail;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajPilote.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
        public static void SupprimerPilote(Pilote PiloteASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionPilote = new SqlCommand("DELETE FROM PILOTE WHERE NumPil=@NumPil", ConnexionEscale);
            CommandeSuppressionPilote.Parameters.Add("@NumPil", System.Data.SqlDbType.Int).Value = PiloteASupprimer.Code;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionPilote.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
        public static List<Pilote> ChargerPilotes()
        {
            List<Pilote> LesPilotes = new List<Pilote>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListePilote = new SqlCommand("SELECT * FROM PILOTE", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurPilote = CommandeListePilote.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurPilote.Read())
            {
                // Ajout de la ligne dans la collection
                LesPilotes.Add(new Pilote((string)LecteurPilote["NumPil"], (string)LecteurPilote["NomPil"], (string)LecteurPilote["PrenPil"], (string)LecteurPilote["TelPil"], (string)LecteurPilote["MelPil"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();

            return LesPilotes;
        }
    }
}
