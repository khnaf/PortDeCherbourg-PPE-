using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale

{
    public class TypeNavire
    {  

        public string CodeTypeNavire { get; set; }

        public string LibelleTypeNavire { get ; set;  }

        public TypeNavire(string PCodeTypeNavire, string PLibelleTypeNavire)
        {
            CodeTypeNavire = PCodeTypeNavire;
            LibelleTypeNavire = PLibelleTypeNavire;
        }
        public TypeNavire(){}
    }
}