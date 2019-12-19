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

        List<Metier.Pavillon> LesPavillons = new List<Metier.Pavillon>();
        public PageListePavillon()
        {
            InitializeComponent();
            LesPavillons = AccesAuxDonnees.ChargerPavillons();
            this.DataContext = LesPavillons;
        }



        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            Metier.Pavillon PavillonAModifier = (Metier.Pavillon)dataGridListePavillon.SelectedValue;
            AccesAuxDonnees.ModifierPavillon(PavillonAModifier);
            dataGridListePavillon.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Metier.Pavillon PavillonASupprime = (Metier.Pavillon)dataGridListePavillon.SelectedValue;
            AccesAuxDonnees.SupprimerPavillon(PavillonASupprime);
            LesPavillons.Remove(PavillonASupprime);
            dataGridListePavillon.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}


