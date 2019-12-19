using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    public class Navire
    {
        // liste pavillon = exemple à suivre

        // Lloyds = numéro 
        public string Llyods { get; set; }

        public string Nom { get; set; }

        public decimal Longueur { get; set; }

        public int AnnCon { get; set; }

        public DateTime DatDre { get; set; }

        public decimal Largeur { get; set; }

        public decimal Tirant { get; set; }

        public bool Propulseur { get; set; }

        public int Capacite { get; set; }

        public int NumArm { get; set; }

        public string CTyNav { get; set; }

        public string CodPav { get; set; }

        public string CodPor { get; set; }

        public int NumCom { get; set; }



        public Navire(string LeLlyods, string LeNom, int LeAnnCon, DateTime LaDatDre, decimal LaLongueur, decimal LaLargeur, decimal LeTirant, bool LePropulseur, int LaCapacite, int LeNumArm, string LeCTyNav, string LeCodPav, string LeCodPor, int LeNumCom)
        {
            Llyods = LeLlyods;
            Nom = LeNom;
            AnnCon = LeAnnCon;
            DatDre = LaDatDre;
            Longueur = LaLongueur;
            Largeur = LaLargeur;
            Tirant = LeTirant;
            Propulseur = LePropulseur;
            Capacite = LaCapacite;
            NumArm = LeNumArm;
            CTyNav = LeCTyNav;
            CodPav = LeCodPav;
            CodPor = LeCodPor;
            NumCom = LeNumCom;

        }

        public Navire()
        {

        }
    }
}
