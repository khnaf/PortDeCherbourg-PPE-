using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    class Pilote
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public Pilote(string LeCode, string LeNom, string LePrenom, string LeTelephone, string LeMail)
        {
            Code = LeCode;
            Nom = LeNom;
            Prenom = LePrenom;
            Telephone = LeTelephone;
            Mail = LeMail;
        }
        public Pilote()
        {
            
        }
    }
}
