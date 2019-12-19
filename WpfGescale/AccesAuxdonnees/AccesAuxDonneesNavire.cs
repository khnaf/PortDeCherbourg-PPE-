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
    public static class AccesAuxDonneesNavire
    {
        public static SqlConnection ConnexionEscale = new SqlConnection(Properties.Settings.Default.GEscaleConnectionString);

        public static void AjouterNavire(Navire NavireAAjouter)
        {
            //Recuperation du pavillon correspondant
            string codepavillon = "";
            ConnexionEscale.Open();
            SqlCommand CommandePav = new SqlCommand("SELECT CodPav FROM PORT WHERE CodPor=@CodPor", ConnexionEscale);
            CommandePav.Parameters.AddWithValue("@CodPor", NavireAAjouter.CodPor);
            SqlDataReader LecteurPavillon = CommandePav.ExecuteReader();
            while (LecteurPavillon.Read())
            {
                codepavillon = (string)LecteurPavillon["CodPav"];
            }
            ConnexionEscale.Close();


            //Insertion du navire
            SqlCommand CommandeInsertionNavire = new SqlCommand("INSERT INTO NAVIRE(NumLlo,NomNav,AnnCon,DatDre,LarNav,LongNav,TirEau,ProNav,CapNav,NumArm,CTyNav,CodPav,CodPor,NumCom) VALUES (@NumLlo,@NomNav,@AnnCon,@DatDre,@LarNav,@LongNav,@TirEau,@ProNav,@CapNav,@NumArm,@CTyNav,@CodPav,@CodPor,@NumCom)", ConnexionEscale);
            // Ajout des paramètres
            CommandeInsertionNavire.Parameters.AddWithValue("@NumLlo", NavireAAjouter.Llyods);
            CommandeInsertionNavire.Parameters.AddWithValue("@NomNav", NavireAAjouter.Nom);
            CommandeInsertionNavire.Parameters.AddWithValue("@AnnCon", NavireAAjouter.AnnCon);
            CommandeInsertionNavire.Parameters.AddWithValue("@DatDre", NavireAAjouter.DatDre.ToString());
            CommandeInsertionNavire.Parameters.AddWithValue("@LarNav", NavireAAjouter.Largeur);
            CommandeInsertionNavire.Parameters.AddWithValue("@LongNav", NavireAAjouter.Longueur);
            CommandeInsertionNavire.Parameters.AddWithValue("@TirEau", NavireAAjouter.Tirant);
            CommandeInsertionNavire.Parameters.AddWithValue("@ProNav", NavireAAjouter.Propulseur);
            CommandeInsertionNavire.Parameters.AddWithValue("@CapNav", NavireAAjouter.Capacite);
            CommandeInsertionNavire.Parameters.AddWithValue("@NumArm", NavireAAjouter.NumArm);
            CommandeInsertionNavire.Parameters.AddWithValue("@CTyNav", NavireAAjouter.CTyNav);
            CommandeInsertionNavire.Parameters.AddWithValue("@CodPav", codepavillon);
            CommandeInsertionNavire.Parameters.AddWithValue("@CodPor", NavireAAjouter.CodPor);
            CommandeInsertionNavire.Parameters.AddWithValue("@NumCom", NavireAAjouter.NumCom);

            // Ouverture de la connexion
            ConnexionEscale.Open();
            //Exécution de la commande d'insertion
            CommandeInsertionNavire.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static List<Navire> ChargerNavires()
        {
            List<Navire> LesNavires = new List<Navire>();
            //Ouverture de la connexion
            ConnexionEscale.Open();
            //Instanciation et définition de la commande
            SqlCommand CommandeListeNavire = new SqlCommand("SELECT * FROM NAVIRE", ConnexionEscale);
            //Exécution de la commande
            SqlDataReader LecteurNavire = CommandeListeNavire.ExecuteReader();
            //Itération du remplissage de la collection lignes
            while (LecteurNavire.Read())
            {
                // Ajout de la ligne dans la collection
                LesNavires.Add(new Navire((string)LecteurNavire["NumLlo"], (string)LecteurNavire["NomNav"], (Int16)LecteurNavire["AnnCon"], (DateTime)LecteurNavire["DatDre"], (decimal)LecteurNavire["LongNav"], (decimal)LecteurNavire["LarNav"], (decimal)LecteurNavire["TirEau"], (bool)LecteurNavire["ProNav"], (int)LecteurNavire["CapNav"], (int)LecteurNavire["NumArm"], (string)LecteurNavire["CTyNav"], (string)LecteurNavire["CodPav"], (string)LecteurNavire["CodPor"], (int)LecteurNavire["NumCom"]));
            }
            //Fermeture de la connexion
            ConnexionEscale.Close();
            return LesNavires;
        }

        public static void SupprimerNavire(Navire NavireASupprimer)
        {
            //Création de la commande de suppression
            SqlCommand CommandeSuppressionNavire = new SqlCommand("DELETE FROM NAVIRE WHERE NumLlo=@NumLlo", ConnexionEscale);
            CommandeSuppressionNavire.Parameters.Add("@NumLlo", System.Data.SqlDbType.NChar, 7).Value = NavireASupprimer.Llyods;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeSuppressionNavire.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }

        public static void ModifierNavire(Navire NavireAModifier)
        {
            //Création de la commande de Maj
            SqlCommand CommandeMajNavire = new SqlCommand("UPDATE NAVIRE SET NumLlo=@NumLlo,NomNav=@NomNav,AnnCon=@AnnCon,DatDre=@DatDre,LarNav=@LarNav,LongNav=@LongNav,TirEau=@TirEau,ProNav=@ProNav,CapNav=@CapNav,NumArm=@NumArm,CTyNav=@CTyNav,CodPav=@CodPav,CodPor=@CodPor WHERE CodPav=@CodPav", ConnexionEscale);
            CommandeMajNavire.Parameters.Add("@NumLlo", System.Data.SqlDbType.NChar, 7).Value = NavireAModifier.Llyods;
            CommandeMajNavire.Parameters.Add("@NomNav", System.Data.SqlDbType.NChar, 30).Value = NavireAModifier.Nom;
            CommandeMajNavire.Parameters.Add("@AnnCon", System.Data.SqlDbType.SmallInt).Value = NavireAModifier.AnnCon;
            CommandeMajNavire.Parameters.Add("@DatDre", System.Data.SqlDbType.Date).Value = NavireAModifier.DatDre;
            CommandeMajNavire.Parameters.Add("@LarNav", System.Data.SqlDbType.Decimal, 18).Value = NavireAModifier.Largeur;
            CommandeMajNavire.Parameters.Add("@LongNav", System.Data.SqlDbType.Decimal, 18).Value = NavireAModifier.Longueur;
            CommandeMajNavire.Parameters.Add("@TirEau", System.Data.SqlDbType.Decimal, 18).Value = NavireAModifier.Tirant;
            CommandeMajNavire.Parameters.Add("@ProNav", System.Data.SqlDbType.Bit).Value = NavireAModifier.Propulseur;
            CommandeMajNavire.Parameters.Add("@CapNav", System.Data.SqlDbType.Int).Value = NavireAModifier.Capacite;
            CommandeMajNavire.Parameters.Add("@NumArm", System.Data.SqlDbType.NChar, 5).Value = NavireAModifier.NumArm;
            CommandeMajNavire.Parameters.Add("@CTyNav", System.Data.SqlDbType.NChar, 2).Value = NavireAModifier.CTyNav;
            CommandeMajNavire.Parameters.Add("@CodPav", System.Data.SqlDbType.NChar, 3).Value = NavireAModifier.CodPav;
            CommandeMajNavire.Parameters.Add("@CodPor", System.Data.SqlDbType.NChar, 2).Value = NavireAModifier.CodPor;
            // Ouverture de la connexion
            ConnexionEscale.Open();
            // Exécution de la requete de suppression
            CommandeMajNavire.ExecuteNonQuery();
            // Fermeture de la connexion
            ConnexionEscale.Close();
        }
    }
}
