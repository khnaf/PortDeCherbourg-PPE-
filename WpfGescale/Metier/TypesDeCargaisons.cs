using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGescale
{
    class TypesDeCargaisons
    {
        public string Code { get; set; }
        public string Libelle { get; set; }

        public bool DanCar { get; set; }

        public TypesDeCargaisons(string LeCode, string LeLibelle, bool LeDanCar)
        {
            Code = LeCode;
            Libelle = LeLibelle;
            DanCar = LeDanCar;
        }

        //Surcharge
        public TypesDeCargaisons()
        {

        }

    }

}

