using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    public class Port
    {
        public string Code { get; set; }
        public string Nom { get; set; }

        public string CodePav { get; set; }

        public Port(string LeCode, string LeNom, string LeCodePav)
        {
            Code = LeCode;
            Nom = LeNom;
            CodePav = LeCodePav;
        }
        public Port()
        {

        }
    }
}
