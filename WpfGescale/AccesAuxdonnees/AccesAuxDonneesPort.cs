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
    public static class AccesAuxDonneesPort
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static void AjouterPort(Port PortAAjouter)
        {
            SqlCommand CommandeInsertionPort = new SqlCommand("INSERT INTO Port(CodPor,NomPor,CodPav) VALUES (@CodPor,@NomPor,@CodPav)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionPort.Parameters.AddWithValue("@CodPor", System.Data.SqlDbType.NChar).Value = PortAAjouter.Code;
            CommandeInsertionPort.Parameters.AddWithValue("@NomPor", System.Data.SqlDbType.NChar).Value = PortAAjouter.Nom;
            CommandeInsertionPort.Parameters.AddWithValue("@CodPav", System.Data.SqlDbType.NChar).Value = PortAAjouter.CodePav;
            try
            {
                // Ouverture de la connexion
                ConnexionEscale.Close();
                ConnexionEscale.Open();
                //Exécution de la commande d'insertion
                CommandeInsertionPort.ExecuteNonQuery();
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

        public static List<Port> ChargerPorts()
        {
        List<Port> LesPorts = new List<Port>();
            //Ouverture de la connexion
            ConnexionEscale.Close();
            ConnexionEscale.Open();
        //Instanciation et définition de la commande
        SqlCommand CommandeListePort = new SqlCommand("SELECT * FROM PORT", ConnexionEscale);
        //Exécution de la commande
        SqlDataReader LecteurPort = CommandeListePort.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurPort.Read())
            {
                // Ajout de la ligne dans la collection
                LesPorts.Add(new Port((string)LecteurPort["CodPor"], (string)LecteurPort["NomPor"], (string)LecteurPort["CodPav"]));
            }
                //Fermeture de la connexion
                ConnexionEscale.Close();
        return LesPorts;
        }


        public static void SupprimerPort(Port PortASupprimer)
        {
            try
            {
                 //Création de la commande de suppression
                            SqlCommand CommandeSuppressionPort = new SqlCommand("DELETE FROM Port WHERE CodPor=@CodPor", ConnexionEscale);
                            CommandeSuppressionPort.Parameters.Add("@CodPor", System.Data.SqlDbType.NChar, 7).Value = PortASupprimer.Code;
                            // Ouverture de la connexion
                            ConnexionEscale.Open();
                            // Exécution de la requete de suppression
                            CommandeSuppressionPort.ExecuteNonQuery();
                            // Fermeture de la connexion
                            ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Aucun port n'a été selectionné !");
            }

        }

        public static void ModifierPort(Port PortAModifier)
        {
            try
            {
                 //Création de la commande de Maj
                            SqlCommand CommandeMajPort = new SqlCommand("UPDATE PORT SET NomPor=@NomPor WHERE CodPor=@CodPor", ConnexionEscale);          
                            CommandeMajPort.Parameters.Add("@CodPor", System.Data.SqlDbType.NChar).Value = PortAModifier.Code;
                            CommandeMajPort.Parameters.Add("@NomPor", System.Data.SqlDbType.NChar).Value = PortAModifier.Nom;
                            // Ouverture de la connexion
                            ConnexionEscale.Open();
                            // Exécution de la requete de suppression
                            CommandeMajPort.ExecuteNonQuery();
                            // Fermeture de la connexion
                            ConnexionEscale.Close();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Aucun port n'a été selectionné !");
            }

        }
    }

}            