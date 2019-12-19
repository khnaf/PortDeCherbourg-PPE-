using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    public class Agent
    {
        public string Code { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }

        public Agent(string LeCode, string LePrenom, string LeNom, string LeTelephone, string LeMail)
        {
            Code = LeCode;
            Prenom = LePrenom;
            Nom = LeNom;
            Telephone = LeTelephone;
            Mail = LeMail;
        }

        public Agent() { }
    }
}
