using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGescale;
using System.Data.SqlClient;
using System.Windows;

namespace WpfGescale
{
    class AccesAuxDonneesArmateur
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static void AjouterArmateur(Armateur ArmateurAAjouter)
        {

            SqlCommand CommandeInsertionArmateur = new SqlCommand("INSERT INTO ARMATEUR ([NumArm],[NomArm],[AdrArm],[CPoArm],[VilArm],[TelArm],[FaxArm],[EmaArm],[CodPav]) VALUES (@PNumArma,@PNomArma,@PAdreArma,@PCPOArma,@PVilleArma,@PTelArma,@PFaxArma,@PEmailArma,@PCodePav)", ConnexionEscale);

            // Ajout des paramètres
            CommandeInsertionArmateur.Parameters.Add("@PNumArma", System.Data.SqlDbType.Int).Value = ArmateurAAjouter.Numero;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PNomArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Nom;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PAdreArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Adresse;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PCPOArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.CodePostal;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PVilleArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Ville;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PTelArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Telephone;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PFaxArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Fax;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PEmailArma", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.Email;
            CommandeInsertionArmateur.Parameters.AddWithValue("@PCodePav", System.Data.SqlDbType.NChar).Value = ArmateurAAjouter.CodePavillon;

            try
            {
                ConnexionEscale.Close();
                // Ouverture de la connexion
                ConnexionEscale.Open();
                //Exécution de la commande d'insertion
                CommandeInsertionArmateur.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Le numéro armateur est déja existant.");
                }
                else
                {
                    MessageBox.Show("Erreur inconnue.");
                }
            }


        }

        public static List<Armateur> ChargerArmateurs()
        {
            List<Armateur> LesArmateurs = new List<Armateur>();
            //Ouverture de la connexion
            ConnexionEscale.Close();
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeArmateur = new SqlCommand("SELECT * FROM ARMATEUR", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurArmateur = CommandeListeArmateur.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurArmateur.Read())
            {
                // Ajout de la ligne dans la collection
                LesArmateurs.Add(new Armateur((int)LecteurArmateur["NumArm"], (string)LecteurArmateur["NomArm"], (string)LecteurArmateur["AdrArm"], (string)LecteurArmateur["CPoArm"], (string)LecteurArmateur["VilArm"], (string)LecteurArmateur["TelArm"], (string)LecteurArmateur["FaxArm"], (string)LecteurArmateur["EmaArm"], (string)LecteurArmateur["CodPav"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();
            return LesArmateurs;
        }

        public static void ModifierArmateur(Armateur ArmateurAModifier)
        {
            try
            {
                //Création de la commande de Maj
                SqlCommand CommandeMajArmateur = new SqlCommand("UPDATE ARMATEUR SET NomArm=@PNomArma, AdrArm=@PAdreArma, CPoArm=@PCPOArma, VilArm=@PVilleArma, TelArm=@PTelArma, FaxArm=@PFaxArma, EmaArm=@PEmailArma WHERE NumArm=@PNumArma", ConnexionEscale);
                CommandeMajArmateur.Parameters.Add("@PNumArma", System.Data.SqlDbType.Int).Value = ArmateurAModifier.Numero;
                CommandeMajArmateur.Parameters.Add("@PNomArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Nom;
                CommandeMajArmateur.Parameters.Add("@PAdreArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Adresse;
                CommandeMajArmateur.Parameters.Add("@PCPOArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.CodePostal;
                CommandeMajArmateur.Parameters.Add("@PVilleArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Ville;
                CommandeMajArmateur.Parameters.Add("@PTelArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Telephone;
                CommandeMajArmateur.Parameters.Add("@PFaxArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Fax;
                CommandeMajArmateur.Parameters.Add("@PEmailArma", System.Data.SqlDbType.NChar).Value = ArmateurAModifier.Email;

                ConnexionEscale.Close();
                // Ouverture de la connexion
                ConnexionEscale.Open();
                // Exécution de la requete de suppression
                CommandeMajArmateur.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Veuillez modifier un armateur.");
            }
        }

        public static void SupprimerArmateur(Armateur ArmateurASupprimer)
        {
            try
            {
                //Création de la commande de suppression
                SqlCommand CommandeSuppressionArmateur = new SqlCommand("DELETE FROM ARMATEUR WHERE NumArm=@PNumArma", ConnexionEscale);
                CommandeSuppressionArmateur.Parameters.Add("@PNumArma", System.Data.SqlDbType.Int).Value = ArmateurASupprimer.Numero;
                ConnexionEscale.Close();
                // Ouverture de la connexion
                ConnexionEscale.Open();
                // Exécution de la requete de suppression
                CommandeSuppressionArmateur.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Veuillez sélectionner un armateur pour pouvoir le supprimer.");
            }
        }

    }
}
