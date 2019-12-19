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
    /// Logique d'interaction pour PageListePort.xaml
    /// </summary>
    public partial class PageListePort : Page
    {
        List<Port> LesPorts = new List<Port>();
        public PageListePort()
        {
            InitializeComponent();
            LesPorts = AccesAuxDonneesPort.ChargerPorts();
            this.DataContext = LesPorts;
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            Port PortAModifier = (Port)dataGridListePort.SelectedValue;
            AccesAuxDonneesPort.ModifierPort(PortAModifier);
            dataGridListePort.Items.Refresh();

        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Port PortASupprimer = (Port)dataGridListePort.SelectedValue;
            AccesAuxDonneesPort.SupprimerPort(PortASupprimer);
            LesPorts.Remove(PortASupprimer);
            dataGridListePort.Items.Refresh();
        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    
    }
}
