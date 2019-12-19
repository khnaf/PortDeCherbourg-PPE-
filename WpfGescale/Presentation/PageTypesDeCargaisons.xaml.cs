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
    /// Logique d'interaction pour PageTypesdeCargaisons.xaml
    /// </summary>
    public partial class PageTypesDeCargaisons : Page
    {
        TypesDeCargaisons LeTypesDeCargaisons = new TypesDeCargaisons();
        public PageTypesDeCargaisons()
        {
            InitializeComponent();
            this.DataContext = LeTypesDeCargaisons;// le contexte de données correspond à un objet TypesDeCargaisons
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonOuiDanger.IsChecked == true)
            {
                LeTypesDeCargaisons.DanCar = true;
            }

            else
            {
                LeTypesDeCargaisons.DanCar = false; 

            }
            // Metier.TypesDeCargaisons LeTypesDeCargaisons = new Metier.TypesDeCargaisons(textBoxCodeTypeCargaison.Text, textBoxNomCargaison.text);
            AccesAuxDonneesTypesDeCargaisons.AjouterTypesDeCargaisons(LeTypesDeCargaisons);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxCodeTypeCargaison.Text = "";
            textBoxNomCargaison.Text = "";

        }

  

            private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxCodeTypeCargaison.Text = "";
            textBoxNomCargaison.Text = "";
        }



        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }

        private void RadioButtonOuiDanger_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

