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

namespace WpfGescale.Presentation
{
    /// <summary>
    /// Logique d'interaction pour PageListeTypeNavire.xaml
    /// </summary>
    public partial class PageListeTypeNavire : Page
    {



        List<TypeNavire> LesTypesNavire = new List<TypeNavire>();
        public PageListeTypeNavire()
        {
            InitializeComponent();
            LesTypesNavire = AccesAuxDonneesTypeNavire.ChargerTypeNavire();
            this.DataContext = LesTypesNavire;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            TypeNavire TypeNavireAModifier = (TypeNavire)dataGridListeTypeNavire.SelectedValue;
            AccesAuxDonneesTypeNavire.ModifierTypeNavire(TypeNavireAModifier);
            dataGridListeTypeNavire.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            TypeNavire TypeNavireASupprimer = (TypeNavire)dataGridListeTypeNavire.SelectedValue;
            AccesAuxDonneesTypeNavire.SupprimerTypeNavire(TypeNavireASupprimer);
            LesTypesNavire.Remove(TypeNavireASupprimer);
            dataGridListeTypeNavire.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }



    }
}
