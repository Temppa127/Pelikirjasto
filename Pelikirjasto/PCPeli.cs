using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelikirjasto
{
    public class PCPeli : Peli
    {

        public string KauppaAlusta { get; set; }

        public override string HaePelityyppi()
        {
            return "PC";
        }

        public PCPeli() { }

        public PCPeli(Pelikokoelma pk, string nimi, int julkaisuVuosi, string julkaisija, string kehittaja, string kauppaAlusta)
            : base(pk, nimi, julkaisuVuosi, julkaisija, kehittaja)
        {
            KauppaAlusta = kauppaAlusta;
        }

        public override string KaikkiTiedot()
        {
            return base.KaikkiTiedot() + "\n" + $"Kauppa-alusta: {KauppaAlusta}";
        }

    }
}
