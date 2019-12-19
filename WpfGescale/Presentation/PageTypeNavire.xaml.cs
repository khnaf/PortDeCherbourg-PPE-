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
    /// Logique d'interaction pour PageTypeNavire.xaml
    /// </summary>
    public partial class PageTypeNavire : Page
    {
         TypeNavire LeTypeNavire = new TypeNavire();

        public PageTypeNavire()
        {
            InitializeComponent();
            this.DataContext = LeTypeNavire;// le contexte de données correspond à un objet Pavillon
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {

            WpfGescale.AccesAuxDonneesTypeNavire.AjouterTypeNavire(LeTypeNavire);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxTypeNavire.Text = "";
            textBoxTypeNavire.Text = "";

        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxTypeNavire.Text = "";
            textBoxTypeNavire.Text = "";
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }
 }


}

