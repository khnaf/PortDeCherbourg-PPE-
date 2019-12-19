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
    /// Logique d'interaction pour PageAgent.xaml
    /// </summary>
    public partial class PageAgent : Page
    {
        public PageAgent()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonEnregistrer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRetour_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
