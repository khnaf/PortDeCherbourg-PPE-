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
    /// Logique d'interaction pour PagePrincipale.xaml
    /// </summary>
    public partial class PagePrincipale : Page
    {
        public PagePrincipale MaPagePrincipale;
        public PagePrincipale()
        {
           InitializeComponent();
            MaPagePrincipale = this;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PageNavire PageNouveauNavire = new PageNavire();
            this.NavigationService.Navigate(PageNouveauNavire);
        }

        private void ItemNouveauArmateur_Click(object sender, RoutedEventArgs e)
        {
            PageArmateur PageNouveauArmateur = new PageArmateur();
            this.NavigationService.Navigate(PageNouveauArmateur);
        }
        private void ItemListeArmateur_Click(object sender, RoutedEventArgs e)
        {
            PageListeArmateur PageListeArmateur = new PageListeArmateur();
            this.NavigationService.Navigate(PageListeArmateur);
        }
        private void itemNouveauPavillon_Click(object sender, RoutedEventArgs e)
        {
            PagePavillon PageNouveauPavillon = new PagePavillon();
            this.NavigationService.Navigate(PageNouveauPavillon);
        }

        private void itemListeNavire_Click(object sender, RoutedEventArgs e)
        {
            PageListeNavire PageListeNavire = new PageListeNavire();
            this.NavigationService.Navigate(PageListeNavire);
        }

        private void itemNouvelleEscale_Click(object sender, RoutedEventArgs e)
        {
            PageEscale PageNouvelleEscale = new PageEscale();
            this.NavigationService.Navigate(PageNouvelleEscale);
        }

        private void itemListePavillon_Click(object sender, RoutedEventArgs e)
        {
            PageListePavillon PageListePavillon = new PageListePavillon();
            this.NavigationService.Navigate(PageListePavillon);
        }
        private void itemNouveauCommandant_Click(object sender, RoutedEventArgs e)
        {
            PageCommandant PageNouveauCommandant = new PageCommandant();
            this.NavigationService.Navigate(PageNouveauCommandant);
        }
        private void itemNouveauTypeNavire_Click(object sender, RoutedEventArgs e)
        {
            PageTypeNavire PageNouveauTypeNavire = new PageTypeNavire();
            this.NavigationService.Navigate(PageNouveauTypeNavire);
        }

        private void itemNouveauPort_Click(object sender, RoutedEventArgs e)
        {
            PagePort PageNouveauPort = new PagePort();
            this.NavigationService.Navigate(PageNouveauPort);
        }
        private void itemListePort_Click(object sender, RoutedEventArgs e)
        {
            PageListePort PageListePort = new PageListePort();
            this.NavigationService.Navigate(PageListePort);
        }


        private void itemListeCommandant_Click(object sender, RoutedEventArgs e)
        {
            PageListeCommandant PageListeCommandant = new PageListeCommandant();
            this.NavigationService.Navigate(PageListeCommandant);
        }

        private void itemNouveauPilote_Click(object sender, RoutedEventArgs e)
        {
            PagePilote PageNouveauPilote = new PagePilote();
            this.NavigationService.Navigate(PageNouveauPilote);
        }

        private void itemListePilote_Click(object sender, RoutedEventArgs e)
        {
            PageListePilote PageListePilote = new PageListePilote();
            this.NavigationService.Navigate(PageListePilote);
        }

        private void itemListeTypeNavire_Click(object sender, RoutedEventArgs e)
        {
            Presentation.PageListeTypeNavire PageListeTypeNavire = new Presentation.PageListeTypeNavire();
            this.NavigationService.Navigate(PageListeTypeNavire);
        }

        private void itemNouveauTypeDeCargaison_Click(object sender, RoutedEventArgs e)
        {
            PageTypesDeCargaisons PageNouveauTypeDeCargaison = new PageTypesDeCargaisons();
            this.NavigationService.Navigate(PageNouveauTypeDeCargaison);
        }

        private void itemListeTypesDeCargaisons_Click(object sender, RoutedEventArgs e)
        {
            PageListeTypesDeCargaisons PageListeTypesDeCargaisons = new PageListeTypesDeCargaisons();
            this.NavigationService.Navigate(PageListeTypesDeCargaisons);
        }

        private void itemNouveauAgent_Click(object sender, RoutedEventArgs e)
        {
            PageAgent PageNouveauAgent = new PageAgent();
            this.NavigationService.Navigate(PageNouveauAgent);
        }

        private void itemListeAgent_Click(object sender, RoutedEventArgs e)
        {
            WpfGescale.Presentation.PageListeAgent PageListeAgent = new WpfGescale.Presentation.PageListeAgent();
            this.NavigationService.Navigate(PageListeAgent);
        }
    }
}
