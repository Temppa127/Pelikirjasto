using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Pelikirjasto
{
    public class KonsoliPeli : Peli
    {
        public string Konsoli { get; set; }

        public override string HaePelityyppi()
        {
            return "Konsoli";
        }

        public KonsoliPeli() { }

        public KonsoliPeli(Pelikokoelma pk, string nimi, int julkaisuVuosi, string julkaisija, string kehittaja, string konsoli) 
            : base(pk, nimi, julkaisuVuosi, julkaisija, kehittaja) 
        {
            Konsoli = konsoli;
        }

        public override string KaikkiTiedot()
        {
            return base.KaikkiTiedot() + "\n" + $"Konsoli: {Konsoli}";
        }


    }


}
