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
using System.Collections.ObjectModel;

namespace WpfGescale
{
    /// <summary>
    /// Logique d'interaction pour PageListeNavire.xaml
    /// </summary>
    public partial class PageListeNavire : Page
    {
        List<Navire> LesNavires = new List<Navire>();
        public PageListeNavire()
        {
            InitializeComponent();
            LesNavires = AccesAuxDonneesNavire.ChargerNavires();
            this.DataContext = LesNavires;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            Navire NavireAModifier = (Navire)dataGridListeNavire.SelectedValue;
            AccesAuxDonneesNavire.ModifierNavire(NavireAModifier);
            dataGridListeNavire.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Navire NavireASupprime = (Navire)dataGridListeNavire.SelectedValue;
            AccesAuxDonneesNavire.SupprimerNavire(NavireASupprime);
            LesNavires.Remove(NavireASupprime);
            dataGridListeNavire.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }
    }
}
