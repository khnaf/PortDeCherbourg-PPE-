using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    public class Pavillon
    {
        public string Code {get; set;}
        public string Libelle{get;set;}
        
        public Pavillon(string LeCode, string LeLibelle)
        {
            Code = LeCode;
            Libelle = LeLibelle;
        }
        public Pavillon()
        {

        }
    }
}
