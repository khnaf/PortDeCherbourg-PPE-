using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGescale;

using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfGescale
{
    class AccesAuxDonneesTypeNavire
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);

        public static List<TypeNavire> ChargerTypeNavire()
        {
            List<TypeNavire> LesTypesNavire = new List<TypeNavire>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeTypeNavire = new SqlCommand("SELECT * FROM [TYPE-NAVIRE]", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurTypeNavire = CommandeListeTypeNavire.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurTypeNavire.Read())
            {
                // Ajout de la ligne dans la collection
                LesTypesNavire.Add(new TypeNavire((string)LecteurTypeNavire["CTyNav"], (string)LecteurTypeNavire["LibTyp"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();
            return LesTypesNavire;
        }

        public static void SupprimerTypeNavire(TypeNavire TypeNavireASupprimer)
        {
            try
            {
                //Création de la commande de suppression
                SqlCommand CommandeSuppressionTypeNavire = new SqlCommand("DELETE FROM [TYPE-NAVIRE] WHERE CTyNav=@PCTyNavv", ConnexionEscale);
            CommandeSuppressionTypeNavire.Parameters.Add("@PCTyNavv", System.Data.SqlDbType.NChar, 2).Value = TypeNavireASupprimer.CodeTypeNavire;

            
                // Ouverture de la connexion
                ConnexionEscale.Open();
                // Exécution de la requete de suppression
                CommandeSuppressionTypeNavire.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("veuillez selectionner un type-navie dans la liste");
            }
            }

        public static void ModifierTypeNavire(TypeNavire TypeNavireAModifier)
        {
            try
            {
                //Création de la commande de Maj
                SqlCommand CommandeMajTypeNavire = new SqlCommand("UPDATE [TYPE-NAVIRE] SET LibTyp=@PLibTyp, CTyNav = @CTyNavv  WHERE CTyNav=@CTyNavv", ConnexionEscale);
            CommandeMajTypeNavire.Parameters.Add("@CTyNavv", System.Data.SqlDbType.NChar, 2).Value = TypeNavireAModifier.CodeTypeNavire;
            CommandeMajTypeNavire.Parameters.Add("@PLibTyp", System.Data.SqlDbType.NChar, 30).Value = TypeNavireAModifier.LibelleTypeNavire;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajTypeNavire.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("veuillez modifier un type-navire pour enregistrer une modification ");
            }
        }

        public static void AjouterTypeNavire(TypeNavire TypeNavireAAjouter)
        {
            SqlCommand CommandeInsertionTypeNavire = new SqlCommand("INSERT INTO [TYPE-NAVIRE](CTyNav,LibTyp) VALUES (@CTyNavv,@PLibTyp)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionTypeNavire.Parameters.Add("@CTyNavv", System.Data.SqlDbType.NChar).Value = TypeNavireAAjouter.CodeTypeNavire;
            CommandeInsertionTypeNavire.Parameters.AddWithValue("@PLibTyp", System.Data.SqlDbType.NChar).Value = TypeNavireAAjouter.LibelleTypeNavire;

            try
            {
                // Ouverture de la connexion
                ConnexionEscale.Open();
                //Exécution de la commande d'insertion
                CommandeInsertionTypeNavire.ExecuteNonQuery();
                // Fermeture de la connexion
                ConnexionEscale.Close();
            } catch(SqlException ex)
            {
                if(ex.Number == 2627)
                {
                    MessageBox.Show("création du type-navire impossible : ce code correspond déjà à un type de navire.");
                }
                else
                {
                    MessageBox.Show("erreur inconnue");
                }
            }
        }
    }
}
