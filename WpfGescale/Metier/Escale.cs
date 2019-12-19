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
    public class Escale : Page
    {
        // Déclaration + Accesseurs 
        public DateTime DatedArrivee { set; get; }
        public DateTime HeuredArrivee { set; get; }
        public DateTime DatedeDepart { set; get; }
        public DateTime HeuredeDepart { set; get; }
        public double QuantiteFret { set; get; }
        public Boolean ConEscale { set; get; }
        public string CTypedeCargaison { set; get; }
        public string CodeAgent { set; get; }
        public string NumeLlo { set; get; }
        public string CodePavProv { set; get; }
        public string CodePorProv { set; get; }
        public string CodePavDest { set; get; }
        public string CodePorDest { set; get; }
        public string NumPiloteArrivee { set; get; }
        public string NumPiloteDepart { set; get; }

        //Constructeur 
        public Escale(DateTime UneDateArrivee, DateTime UneHeureArrivee, DateTime UneDateDepart, DateTime UneHeureDepart, double UneQteFre, Boolean UnConEsc, string unCTypeCar, string UnCodeAgent , string UnNumLlo, string UnCodPavProv, string UnCodPorProv, string UnCodePavDest, string UnCodPorDest, string UnNumPiloteArrivee, string UnNumPiloteDepart)
        {
            DatedArrivee = UneDateArrivee;
            HeuredArrivee = UneHeureArrivee;
            DatedeDepart = UneDateDepart;
            HeuredeDepart = UneHeureDepart;
            QuantiteFret = UneQteFre;
            ConEscale = UnConEsc;
            CTypedeCargaison = unCTypeCar;
            CodeAgent = UnCodeAgent;
            NumeLlo = UnNumLlo;
            CodePavProv = UnCodPavProv;
            CodePorProv = UnCodPorProv;
            CodePavDest = UnCodePavDest;
            CodePorDest = UnCodPorDest;
            NumPiloteArrivee = UnNumPiloteArrivee;
            NumPiloteDepart = UnNumPiloteDepart;
        }

        public Escale() { }
    
}
}
