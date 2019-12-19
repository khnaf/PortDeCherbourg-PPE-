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
    /// Logique d'interaction pour PageNavire.xaml
    /// </summary>
    public partial class PageNavire : Page
    {
        Navire LeNavire = new Navire();
        Dictionary<string, Armateur> LesArmateurs = new Dictionary<string, Armateur>();
        Dictionary<string, TypeNavire> LesTypeNavires = new Dictionary<string, TypeNavire>();
        Dictionary<string, Port> LesPorts = new Dictionary<string, Port>();
        Dictionary<string,Pavillon> LesPavillons = new Dictionary<string,Pavillon>();
        Dictionary<string, Commandant> LesCommandants = new Dictionary<string,Commandant>();

        public PageNavire()
        {
            InitializeComponent();
            this.DataContext = LeNavire;// le contexte de données correspond à un objet Commandant
        }

        private void PageNavire_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxNumCom.DataContext = AccesAuxDonneesCommandant.ChargerCommandants();
            ComboBoxCodPor.DataContext = AccesAuxDonneesPort.ChargerPorts();
            ComboBoxCTyNav.DataContext = AccesAuxDonneesTypeNavire.ChargerTypeNavire();
            ComboBoxNumArm.DataContext = AccesAuxDonneesArmateur.ChargerArmateurs();
        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            LeNavire.NumCom = Convert.ToInt32(ComboBoxNumCom.Text);
            LeNavire.CodPor = ComboBoxCodPor.Text;
            LeNavire.CTyNav = ComboBoxCTyNav.Text;
            LeNavire.NumArm = Convert.ToInt32(ComboBoxNumArm.Text);
            LeNavire.DatDre = (DateTime)DatePickerDatDre.SelectedDate;
            AccesAuxDonneesNavire.AjouterNavire(LeNavire);// Insertion de l'objet dans le BD

            // Raz des TextBox
            textBoxNumLlo.Text = "";
            textBoxNomNav.Text = "";
            textBoxAnnCon.Text = "";
            DatePickerDatDre.Text = "";
            textBoxLarNav.Text = "";
            textBoxLongNav.Text = "";
            textBoxTirEau.Text = "";
            textBoxProNav.Text = "";
            textBoxCapNav.Text = "";
            ComboBoxNumCom.Text = "";
            ComboBoxNumArm.Text = "";
            ComboBoxCTyNav.Text = "";
            ComboBoxCodPor.Text = "";
        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Raz des TextBox
            textBoxNumLlo.Text = "";
            textBoxNomNav.Text = "";
            textBoxAnnCon.Text = "";
            DatePickerDatDre.Text = "";
            textBoxLarNav.Text = "";
            textBoxLongNav.Text = "";
            textBoxTirEau.Text = "";
            textBoxProNav.Text = "";
            textBoxCapNav.Text = "";
            ComboBoxNumCom.Text = "";
            ComboBoxNumArm.Text = "";
            ComboBoxCTyNav.Text = "";
            ComboBoxCodPor.Text = "";
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            //  Retour à la page Principale
            this.NavigationService.GoBack();
        }

    }
}
