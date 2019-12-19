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
    /// Logique d'interaction pour PageListeCommandant.xaml
    /// </summary>
    public partial class PageListeCommandant : Page

    {

        List<Commandant> LesCommandants = new List<Commandant>();
        public PageListeCommandant()
        {
            InitializeComponent();
            LesCommandants = AccesAuxDonneesCommandant.ChargerCommandants();
            this.DataContext = LesCommandants;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            Commandant CommandantAModifier = (Commandant)dataGridListeCommandant.SelectedValue;
            AccesAuxDonneesCommandant.ModifierCommandant(CommandantAModifier);
            dataGridListeCommandant.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Commandant CommandantASupprimer = (Commandant)dataGridListeCommandant.SelectedValue;
            AccesAuxDonneesCommandant.SupprimerCommandant(CommandantASupprimer);
            LesCommandants.Remove(CommandantASupprimer);
            dataGridListeCommandant.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}


