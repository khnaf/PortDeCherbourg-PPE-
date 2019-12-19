using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    class Armateur
    {
        private int _Numero;
        private string _Nom;
        private string _Adresse;
        private string _CodePostal;
        private string _Ville;
        private string _Telepone;
        private string _Fax;
        private string _Email;
        private string _CodePavillon;

        public int Numero { get { return _Numero; } set { _Numero = value; } }

        public string Nom { get { return _Nom; } set { _Nom = value; } }

        public string Adresse { get { return _Adresse; } set { _Adresse = value; } }

        public string CodePostal { get { return _CodePostal; } set { _CodePostal = value; } }

        public string Ville { get { return _Ville; } set { _Ville = value; } }

        public string Telephone { get { return _Telepone; } set { _Telepone = value; } }

        public string Fax { get { return _Fax; } set { _Fax = value; } }

        public string Email { get { return _Email; } set { _Email = value; } }

        public string CodePavillon { get { return _CodePavillon; } set { _CodePavillon = value; } }

        public Armateur(int LeNumero, string LeNom,string LaAdresse, string LeCodePostal, string LaVille, string LeTelephone, string LeFax, string LeEmail, string LeCodePavillon)
        {
            Numero = LeNumero;
            Nom = LeNom;
            Adresse = LaAdresse;
            CodePostal = LeCodePostal;
            Ville = LaVille;
            Telephone = LeTelephone;
            Fax = LeFax;
            Email = LeEmail;
            CodePavillon = LeCodePavillon;
        }

        public Armateur()
        {

        }
    }
}
