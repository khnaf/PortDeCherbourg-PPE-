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
    class AccesAuxDonneesAgent
    {

        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);
        public static List<Agent> ChargerAgents()
        {
            List<Agent> LesAgents = new List<Agent>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeAgent = new SqlCommand("SELECT * FROM AGENT", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurAgent = CommandeListeAgent.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurAgent.Read())
            {
                // Ajout de la ligne dans la collection
                LesAgents.Add(new Agent((string)LecteurAgent["CodAge"], (string)LecteurAgent["PrenAge"], (string)LecteurAgent["NomAge"], (string)LecteurAgent["TelAge"], (string)LecteurAgent["EMaAgent"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();

            return LesAgents;
        }
        /*
        public static void SupprimerAgent(Pavillon AgentASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionAgent = new SqlCommand("DELETE FROM AGENT WHERE CodAge=@PCodAge", ConnexionEscale);
            CommandeSuppressionAgent.Parameters.Add("@PCodAge", System.Data.SqlDbType.NChar, 3).Value = AgentASupprimer.Code;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionAgent.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
        public static void ModifierAgent(Pavillon AgentAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajAgent = new SqlCommand("UPDATE AGENT SET PrenAge=@PPrenAge, NomAge=@PNomAge, TelAge@PTelAge, EMaAge=@PEMaAge WHERE CodPav=@PCodPav", ConnexionEscale);
            CommandeMajAgent.Parameters.Add("@PCodAge", System.Data.SqlDbType.NChar, 3).Value = AgentAModifier.Code;
            CommandeMajAgent.Parameters.Add("@PPrenAge", System.Data.SqlDbType.NChar, 30).Value = AgentAModifier.Prenom;
            CommandeMajAgent.Parameters.Add("@PNomAge", System.Data.SqlDbType.NChar, 30).Value = AgentAModifier.nom;
            CommandeMajAgent.Parameters.Add("@PTelAge", System.Data.SqlDbType.NChar, 30).Value = AgentAModifier.Telephone;
            CommandeMajAgent.Parameters.Add("@PEmaAge", System.Data.SqlDbType.NChar, 30).Value = AgentAModifier.Email;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajAgent.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void AjouterPavillon(Pavillon PavillonAAjouter)
        {
            SqlCommand CommandeInsertionAgent = new SqlCommand("INSERT INTO PAVILLON(CodPav,LibPav) VALUES (@PCodPav,@PLibPav)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionAgent.Parameters.Add("@PCodAge", System.Data.SqlDbType.NChar, 3).Value = PavillonAAjouter.Code;
            CommandeInsertionAgent.Parameters.AddWithValue("@PPrenAge", System.Data.SqlDbType.NChar, 30).Value = PavillonAAjouter.Prenom;
            CommandeInsertionAgent.Parameters.AddWithValue("@PNomAge", System.Data.SqlDbType.NChar, 30).Value = PavillonAAjouter.nom;
            CommandeInsertionAgent.Parameters.AddWithValue("@PTelAge", System.Data.SqlDbType.NChar, 30).Value = PavillonAAjouter.Telephone;
            CommandeInsertionAgent.Parameters.AddWithValue("@PEmaAge", System.Data.SqlDbType.NChar, 30).Value = PavillonAAjouter.Email;

            // Ouverture de la connexion
            ConnexionEscale.Open();
            //Exécution de la commande d'insertion
            CommandeInsertionAgent.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
        */
    }
}
