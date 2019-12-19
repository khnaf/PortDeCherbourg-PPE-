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
    /// Logique d'interaction pour PagePilote.xaml
    /// </summary>
    public partial class PagePilote : Page
    {
        Pilote LePilote = new Pilote();
        public PagePilote()
        {
            
            InitializeComponent();
            this.DataContext =  LePilote;// le contexte de données correspond à un objet Pilote
        }
        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            AccesAuxDonneesPilote.AjouterPilote(LePilote);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxNumPilote.Text = "";
            textBoxNomPilote.Text = "";
            textBoxPrenomPilote.Text = "";
            textBoxTelephonePilote.Text = "";
            textBoxMailPilote.Text = "";

            // Insertion de l'enregistrement dans la BD
            SqlCommand CommandeInsertionEscale = new SqlCommand("INSERT INTO PILOTE (@numPil,@nomPil, @prePil, @telPil, @melPil)");
        }
        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxNumPilote.Text = "";
            textBoxNomPilote.Text = "";
            textBoxPrenomPilote.Text = "";
            textBoxTelephonePilote.Text = "";
            textBoxMailPilote.Text = "";
        }
        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la page Principale
            this.NavigationService.GoBack();
        }
    }
}
