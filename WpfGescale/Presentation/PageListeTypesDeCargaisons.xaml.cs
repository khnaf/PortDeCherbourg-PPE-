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
    /// Logique d'interaction pour PageListeTypesDeCargaisons.xaml
    /// </summary>
    public partial class PageListeTypesDeCargaisons : Page

    {
        List<TypesDeCargaisons> LesTypesDeCargaisons = new List<TypesDeCargaisons>();
        public PageListeTypesDeCargaisons()
        {
            InitializeComponent();
            LesTypesDeCargaisons = AccesAuxDonneesTypesDeCargaisons.ChargerTypesDeCargaisons();
            this.DataContext = LesTypesDeCargaisons;
        }



        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            TypesDeCargaisons CargaisonsAModifier = (TypesDeCargaisons)dataGridListeTypesdeCargaisons.SelectedValue;
            AccesAuxDonneesTypesDeCargaisons.ModifierTypesDeCargaisons(CargaisonsAModifier);
            dataGridListeTypesdeCargaisons.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            TypesDeCargaisons CargaisonsASupprime = (TypesDeCargaisons)dataGridListeTypesdeCargaisons.SelectedValue;
            AccesAuxDonneesTypesDeCargaisons.SupprimerTypesDeCargaisons(CargaisonsASupprime);
            LesTypesDeCargaisons.Remove(CargaisonsASupprime);
            dataGridListeTypesdeCargaisons.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}


