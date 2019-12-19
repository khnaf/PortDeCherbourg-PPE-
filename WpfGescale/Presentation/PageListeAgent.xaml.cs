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
    /// Logique d'interaction pour PageListeAgent.xaml
    /// </summary>
    public partial class PageListeAgent : Page
    {
        List<Agent> lesAgents = new List<Agent>();
        public PageListeAgent()
        {
            InitializeComponent();
            //lesAgents = AccesAuxDonneesAgent.ChargerAgents();
            //this.DataContext = lesAgents;
        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //Agent AgentASupprime = (Agent)dataGridListeAgent.SelectedValue;
            //AccesAuxDonneesAgent.SupprimerAgent(AgentASupprime);
            //lesAgents.Remove(AgentASupprime);
            //dataGridListeAgent.Items.Refresh();
        }

        private void buttonMaj_Click(object sender, RoutedEventArgs e)
        {
            //Agent AgentAModifier = (Agent)dataGridListeAgent.SelectedValue;
            //AccesAuxDonneesAgent.ModifierAgent(AgentAModifier);
            //dataGridListeAgent.Items.Refresh();
        }
        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DataGridListeAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
