using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelikirjasto
{
    public class MobiiliPeli : Peli
    {
        public string SovellusKauppa { get; set; }

        public override string HaePelityyppi()
        {
            return "Mobiili";
        }

        public MobiiliPeli() { }

        public MobiiliPeli(Pelikokoelma pk, string nimi, int julkaisuVuosi, string julkaisija, string kehittaja, string sovKauppa)
            : base(pk, nimi, julkaisuVuosi, julkaisija, kehittaja)
        {
            SovellusKauppa = sovKauppa;
        }

        public override string KaikkiTiedot()
        {
            return base.KaikkiTiedot() + "\n" + $"Sovelluskauppa: {SovellusKauppa}";
        }
    }
}
