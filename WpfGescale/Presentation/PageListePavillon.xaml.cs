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
    /// Logique d'interaction pour PageListePavillon.xaml
    /// </summary>
    public partial class PageListePavillon : Page
    {
        List< Pavillon> LesPavillons = new List< Pavillon>();
        public PageListePavillon()
        {
            InitializeComponent();
            LesPavillons = AccesAuxDonneesPavillon.ChargerPavillons();
            this.DataContext = LesPavillons;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
             Pavillon PavillonAModifier = ( Pavillon)dataGridListePavillon.SelectedValue;
            AccesAuxDonneesPavillon.ModifierPavillon(PavillonAModifier);
            dataGridListePavillon.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
             Pavillon PavillonASupprime = ( Pavillon)dataGridListePavillon.SelectedValue;
            AccesAuxDonneesPavillon.SupprimerPavillon(PavillonASupprime);
            LesPavillons.Remove(PavillonASupprime);
            dataGridListePavillon.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}


