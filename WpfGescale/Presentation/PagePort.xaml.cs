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

namespace WpfGescale
{
    /// <summary>
    /// Logique d'interaction pour PagePort.xaml
    /// </summary>
    public partial class PagePort : Page
    {
        Port LePort = new Port();
        Dictionary<string,Pavillon> LesPavillons = new Dictionary<string,Pavillon>();
        public PagePort()
        {
            InitializeComponent();
            this.DataContext = LePort;// le contexte de données correspond à un objet Port
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            LePort.CodePav = ComboBoxCodPav.Text;
            AccesAuxDonneesPort.AjouterPort(LePort);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxCodePort.Text = "";
            textBoxNomPort.Text = "";
            ComboBoxCodPav.Text = "";
        }


        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxCodePort.Text = "";
            textBoxNomPort.Text = "";
            ComboBoxCodPav.Text = "";

        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }


        private void PagePort_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxCodPav.DataContext = AccesAuxDonneesPavillon.ChargerPavillons();
        }
    }
}
