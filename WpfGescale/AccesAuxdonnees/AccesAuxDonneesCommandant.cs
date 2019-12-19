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
    public static class AccesAuxDonneesCommandant
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);

        public static void AjouterCommandant(Commandant CommandantAAjouter)
        {
            //teuz
            SqlCommand CommandeInsertionCommandant = new SqlCommand("INSERT INTO COMMANDANT(NumCom,NomCom,TelCom,MelCom) VALUES (@NumCom,@NomCom,@TelCom,@MelCom)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionCommandant.Parameters.AddWithValue("@NumCom", System.Data.SqlDbType.Int).Value = CommandantAAjouter.Code;
            CommandeInsertionCommandant.Parameters.AddWithValue("@NomCom", System.Data.SqlDbType.NChar).Value = CommandantAAjouter.Nom;
            CommandeInsertionCommandant.Parameters.AddWithValue("@TelCom", System.Data.SqlDbType.NChar).Value = CommandantAAjouter.Tel;
            CommandeInsertionCommandant.Parameters.AddWithValue("@MelCom", System.Data.SqlDbType.NChar).Value = CommandantAAjouter.Mel;

            try
            {
                // Ouverture de la connexion
                ConnexionEscale.Close();
                ConnexionEscale.Open();
                //Exécution de la commande d'insertion
                CommandeInsertionCommandant.ExecuteNonQuery();
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

        public static List<Commandant> ChargerCommandants()
        {
            List<Commandant> LesCommandants = new List<Commandant>();
            //Ouverture de la connexion
            ConnexionEscale.Close();
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeCommandant = new SqlCommand("SELECT * FROM COMMANDANT", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurCommandant = CommandeListeCommandant.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurCommandant.Read())
            {
                // Ajout de la ligne dans la collection
                LesCommandants.Add(new Commandant((int)LecteurCommandant["NumCom"], (string)LecteurCommandant["NomCom"], (string)LecteurCommandant["TelCom"], (string)LecteurCommandant["MelCom"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();
            return LesCommandants;
        }

        public static void SupprimerCommandant(Commandant CommandantASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionCommandant = new SqlCommand("DELETE FROM COMMANDANT WHERE NumCom=@PNumCom", ConnexionEscale);
            CommandeSuppressionCommandant.Parameters.Add("@PNumCom", System.Data.SqlDbType.Int).Value = CommandantASupprimer.Code;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionCommandant.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void ModifierCommandant(Commandant CommandantAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajCommandant = new SqlCommand("UPDATE COMMANDANT SET NumCom=@PNumCom, NomCom=@PNomCom, TelCom=@PTelCom, MelCom=@PMelCom WHERE NumCom=@PNumCom", ConnexionEscale);
            CommandeMajCommandant.Parameters.Add("@PNumCom", System.Data.SqlDbType.Int).Value = CommandantAModifier.Code;
            CommandeMajCommandant.Parameters.Add("@PNomCom", System.Data.SqlDbType.NChar, 35).Value = CommandantAModifier.Nom;
            CommandeMajCommandant.Parameters.Add("@PTelCom", System.Data.SqlDbType.NChar, 10).Value = CommandantAModifier.Tel;
            CommandeMajCommandant.Parameters.Add("@PMelCom", System.Data.SqlDbType.NChar, 35).Value = CommandantAModifier.Mel;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajCommandant.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
    }
}
