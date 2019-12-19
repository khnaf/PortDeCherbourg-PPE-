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
    /// Logique d'interaction pour PageListePilote.xaml
    /// </summary>
    public partial class PageListePilote : Page
    {
        List<Pilote> LesPilotes = new List<Pilote>();
        public PageListePilote()
        {
            InitializeComponent();
            LesPilotes = AccesAuxDonneesPilote.ChargerPilotes();
            this.DataContext = LesPilotes;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            Pilote PiloteAModifier = (Pilote)dataGridListePilote.SelectedValue;
            AccesAuxDonneesPilote.ModifierPilote(PiloteAModifier);
            dataGridListePilote.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Pilote PiloteASupprime = (Pilote)dataGridListePilote.SelectedValue;
            AccesAuxDonneesPilote.SupprimerPilote(PiloteASupprime);
            LesPilotes.Remove(PiloteASupprime);
            dataGridListePilote.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
