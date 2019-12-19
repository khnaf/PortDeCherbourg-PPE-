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

namespace WpfGescale
{
    /// <summary>
    /// Logique d'interaction pour PageListeArmateur.xaml
    /// </summary>


    public partial class PageListeArmateur : Page
    {
        List<Armateur> LesArmateurs = new List<Armateur>();
        public PageListeArmateur()
        {
            InitializeComponent();
            LesArmateurs = AccesAuxDonneesArmateur.ChargerArmateurs();
            this.DataContext = LesArmateurs;
        }
        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la page Principale
            this.NavigationService.GoBack();
        }
        private void ButtonEnregistrer_Click_1(object sender, RoutedEventArgs e)
        {
            Armateur ArmateurAModifier = (Armateur)dataGridListeArmateur.SelectedValue;
            AccesAuxDonneesArmateur.ModifierArmateur(ArmateurAModifier);
            dataGridListeArmateur.Items.Refresh();
        }

        private void ButtonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Armateur ArmateurASupprimer = (Armateur)dataGridListeArmateur.SelectedValue;
            AccesAuxDonneesArmateur.SupprimerArmateur(ArmateurASupprimer);
            LesArmateurs.Remove(ArmateurASupprimer);
            dataGridListeArmateur.Items.Refresh();
        }

        private void buttonRetour_Click_1(object sender, RoutedEventArgs e)
        {
            // Retour à la page Principale
            this.NavigationService.GoBack();

        }

        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Armateur ArmateurAModifier = (Armateur)dataGridListeArmateur.SelectedValue;
            AccesAuxDonneesArmateur.ModifierArmateur(ArmateurAModifier);
            dataGridListeArmateur.Items.Refresh();
        }

        private void ButtonRetour_Click_1(object sender, RoutedEventArgs e)
        {
            // Retour à la page Principale
            this.NavigationService.GoBack();
        }
    }
}
