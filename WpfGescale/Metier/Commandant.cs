using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    public class Commandant
    {
        public int Code { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Mel { get; set; }


        public Commandant(int LeCode, string LeNom, string LeTel, string LeMel)
        {
            Code = LeCode;
            Nom = LeNom;
            Tel = LeTel;
            Mel = LeMel;
        }
        public Commandant()
        {

        }
    }
}
