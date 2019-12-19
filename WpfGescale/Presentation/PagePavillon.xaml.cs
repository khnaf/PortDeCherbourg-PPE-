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
using WpfGescale;


namespace WpfGescale
{
    /// <summary>
    /// Logique d'interaction pour PagePavillon.xaml
    /// </summary>
    public partial class PagePavillon : Page
    {
        Pavillon LePavillon = new Pavillon();
        public PagePavillon()
        {
            InitializeComponent();
            this.DataContext = LePavillon;// le contexte de données correspond à un objet Pavillon
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
           AccesAuxDonneesPavillon.AjouterPavillon(LePavillon);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxCodePavillon.Text = "";
            textBoxNomPavillon.Text = "";
        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxCodePavillon.Text = "";
            textBoxNomPavillon.Text = "";
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }

    }


}

