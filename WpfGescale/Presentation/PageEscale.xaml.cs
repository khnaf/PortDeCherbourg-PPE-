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
    /// Logique d'interaction pour PageEscale.xaml
    /// </summary>
    public partial class PageEscale : Page
    {
        //Instanciation d'un object Escale
        Escale UnEscale = new Escale();


        // Déclaration des collections
        List<Navire> LesNavires = new List< Navire>();
        List<Agent> LesAgents = new List< Agent >();
        List<Port> LesPorts = new List<Port>();
        List<TypesDeCargaisons> LesTypesDeCargaisons = new List<TypesDeCargaisons>();
        List<Pilote> LesPilotes = new List<Pilote>();

        public PageEscale()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            LesPilotes = AccesAuxDonneesPilote.ChargerPilotes();
            ComboBoxPiloteArrivee.DataContext = LesPilotes;
            ComboBoxPiloteDepart.DataContext = LesPilotes;
            LesAgents = AccesAuxDonneesAgent.ChargerAgents();
            ComboBoxAgent.DataContext = LesAgents;
            LesNavires = AccesAuxDonneesNavire.ChargerNavires();
            ComboBoxNumLlyods.DataContext = LesNavires;
            LesPorts = AccesAuxDonneesPort.ChargerPorts();
            ComboBoxPorProv.DataContext = LesPorts;
            ComboBoxPorDest.DataContext = LesPorts;

            LesTypesDeCargaisons = AccesAuxDonneesTypesDeCargaisons.ChargerTypesDeCargaisons();
            ComboBoxTypeFret.DataContext = LesTypesDeCargaisons;
            
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            //Utilisation de la méthode "AjouterEscale" de la classe "AccesAuxDonneesEscale" en utilisant l'objet "UnEscale" en paramètre
           
            UnEscale.DatedArrivee = (DateTime)DatePickerDateArrivee.SelectedDate;
            UnEscale.DatedeDepart = (DateTime)DatePickerDateDepart.SelectedDate;
            UnEscale.HeuredArrivee = Convert.ToDateTime(HeureArrivee.Text);
            UnEscale.HeuredeDepart = Convert.ToDateTime(HeureDepart.Text);
            UnEscale.QuantiteFret = Convert.ToDouble(TonnageEscale.Text);
            UnEscale.ConEscale = LesTypesDeCargaisons[ComboBoxTypeFret.SelectedIndex].DanCar;
            UnEscale.CTypedeCargaison = LesTypesDeCargaisons[ComboBoxTypeFret.SelectedIndex].Code;
            UnEscale.CodeAgent = LesAgents[ComboBoxAgent.SelectedIndex].Code;
            UnEscale.NumeLlo = LesNavires[ComboBoxNumLlyods.SelectedIndex].Llyods;
            UnEscale.CodePavDest = LesPorts[ComboBoxPorDest.SelectedIndex].CodePav;
            UnEscale.CodePavProv = LesPorts[ComboBoxPorProv.SelectedIndex].CodePav;
            UnEscale.CodePorDest = LesPorts[ComboBoxPorDest.SelectedIndex].Code;
            UnEscale.CodePorProv = LesPorts[ComboBoxPorProv.SelectedIndex].Code;
            UnEscale.NumPiloteArrivee = LesPilotes[ComboBoxPiloteArrivee.SelectedIndex].Code;
            UnEscale.NumPiloteDepart = LesPilotes[ComboBoxPiloteDepart.SelectedIndex].Code;
            AccesAuxDonneesEscale.AjouterEscale(UnEscale);

            NomNavire.Text = "";
            LongueurNavire.Text = "";
            LargeurNavire.Text = "";
            TirantNavire.Text = "";
            ComboBoxPorDest.Text = "";
            ComboBoxPorProv.Text = "";
            DatePickerDateArrivee.Text = "";
            DatePickerDateDepart.Text = "";
            ComboBoxAgent.Text = "";
            HeureArrivee.Text = "";
            HeureDepart.Text = "";
            ComboBoxTypeFret.SelectedIndex = 0;
            TonnageEscale.Text = "";
            ComboBoxPiloteArrivee.Text = "";
            ComboBoxPiloteDepart.Text = "";

            MessageBox.Show("Escale ajouté à la base");
        }


        private void ComboBoxNumLlyods_SelectionChanged(object sender, SelectionChangedEventArgs e) // Changement de valeur dans la ComboBox
        {
            // Affectation aux TextBox des valeurs correspondant au Navire
            NomNavire.Text = LesNavires[ComboBoxNumLlyods.SelectedIndex].Nom;
            LongueurNavire.Text = Convert.ToString(LesNavires[ComboBoxNumLlyods.SelectedIndex].Longueur);
            LargeurNavire.Text = Convert.ToString(LesNavires[ComboBoxNumLlyods.SelectedIndex].Largeur);
            TirantNavire.Text = Convert.ToString(LesNavires[ComboBoxNumLlyods.SelectedIndex].Tirant);
            // RadioButton en fonction de la présence ou non de Propulseurs
            if (LesNavires[ComboBoxNumLlyods.SelectedIndex].Propulseur == true)
            {
                RadioButtonOuiPropulseur.IsChecked = true;
                RadioButtonNonPropulseur.IsChecked = false;
            }

            else
            {
                RadioButtonOuiPropulseur.IsChecked = false;
                RadioButtonNonPropulseur.IsChecked = true;
            }
        }

        private void ComboBoxTypeFret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LesTypesDeCargaisons[ComboBoxTypeFret.SelectedIndex].DanCar == true)
            {
                RadioButtonOuiDanger.IsChecked = true;
                RadioButtonNonDanger.IsChecked = false;
            }

            else
            {
                RadioButtonOuiDanger.IsChecked = false;
                RadioButtonNonDanger.IsChecked = true;
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
         
            NomNavire.Text = "";
            LongueurNavire.Text = "";
            LargeurNavire.Text = "";
            TirantNavire.Text = "";
            ComboBoxPorDest.Text = "";
            ComboBoxPorProv.Text = "";
            DatePickerDateArrivee.Text = "";
            DatePickerDateDepart.Text = "";
            ComboBoxAgent.Text = "";
            HeureArrivee.Text = "";
            HeureDepart.Text = "";
            ComboBoxTypeFret.SelectedIndex = 0;
            TonnageEscale.Text = "";
            ComboBoxPiloteArrivee.Text = "";
            ComboBoxPiloteDepart.Text = "";
        }


    }
}

