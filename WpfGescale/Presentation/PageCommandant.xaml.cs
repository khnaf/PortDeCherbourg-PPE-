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
    /// Logique d'interaction pour PageCommandant.xaml
    /// </summary>
    public partial class PageCommandant : Page
    {
        Commandant LeCommandant = new Commandant();
        public PageCommandant()
        {
            InitializeComponent();
            this.DataContext = LeCommandant;    // le contexte de données correspond à un objet Commandant
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            AccesAuxDonneesCommandant.AjouterCommandant(LeCommandant);  // Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxCodeCommandant.Text = "";
            textBoxNomCommandant.Text = "";
            textBoxTelCommandant.Text = "";
            textBoxMelCommandant.Text = "";
        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxCodeCommandant.Text = "";
            textBoxNomCommandant.Text = "";
            textBoxTelCommandant.Text = "";
            textBoxMelCommandant.Text = "";
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }
    }
}