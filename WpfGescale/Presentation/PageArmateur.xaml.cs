using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfGescale
{
    /// <summary>
    /// Logique d'interaction pour NouveauArmateur.xaml
    /// </summary>
    public partial class PageArmateur : Page
    {
        // Déclaration de la collection
        Dictionary<string, Pavillon> LesPavillons = new Dictionary<string, Pavillon>();
        Armateur LeArmateur = new Armateur();
        public PageArmateur()
        {
            InitializeComponent();
            this.DataContext = LeArmateur;// le contexte de données correspond à un objet Armateur
        }
        private void PageArmateur_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxCodePavillon.DataContext = AccesAuxDonneesPavillon.ChargerPavillons();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la page Principale
            this.NavigationService.GoBack();
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            LeArmateur.CodePavillon = ComboBoxCodePavillon.Text;
            AccesAuxDonneesArmateur.AjouterArmateur(LeArmateur);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxNumArmateur.Text = "";
            textBoxNomArmateur.Text = "";
            textBoxAdreArmateur.Text = "";
            textBoxCodePostalArmateur.Text = "";
            textBoxVilleArmateur.Text = "";
            textBoxTelArmateur.Text = "";
            textBoxFaxArmateur.Text = "";
            textBoxEmailArmateur.Text = "";
            ComboBoxCodePavillon.Text = "";
        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxNumArmateur.Text = "";
            textBoxNomArmateur.Text = "";
            textBoxAdreArmateur.Text = "";
            textBoxCodePostalArmateur.Text = "";
            textBoxVilleArmateur.Text = "";
            textBoxTelArmateur.Text = "";
            textBoxFaxArmateur.Text = "";
            textBoxEmailArmateur.Text = "";
            ComboBoxCodePavillon.Text = "";

        }
    }
}
