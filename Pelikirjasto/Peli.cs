using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelikirjasto
{
    public class Peli
    {
        private string _nimi = "";
        private int _julkaisuvuosi;
        private string _julkaisija = "";
        private string _kehittaja = "";
        private double _arvio;


        public string Nimi
        {
            get { return _nimi; }
            set {
                if (value != "") {
                    _nimi = value;
                }
                else {
                    Console.WriteLine("Nimi ei voi olla tyhjä merkkijono");
                }
            }
        }

        public int Julkaisuvuosi
        {
            get { return _julkaisuvuosi; }
            set { _julkaisuvuosi = value; }
        }

        public string Julkaisija
        {
            get { return _julkaisija; }
            set
            {
                if (value != "")
                {
                    _julkaisija = value;
                }
                else
                {
                    Console.WriteLine("Julkaisija ei voi olla tyhjä merkkijono");
                }
            }
        }

        public string Kehittaja
        {
            get { return _kehittaja; }
            set
            {
                if (value != "")
                {
                    _kehittaja = value;
                }
                else
                {
                    Console.WriteLine("Kehittäjä ei voi olla tyhjä merkkijono");
                }
            }
        }

        public double Arvio
        {
            get { return _arvio; }
            set {
                if (value >= 0 && value <= 5) {
                    _arvio = value;
                }
                else {
                    Console.WriteLine("Arvion täytyy olla väliltä 0-5");
                }
            }
        }

        public Peli(){ }

        public Peli(Pelikokoelma pk, string nimi, int julkaisuVuosi, string julkaisija, string kehittaja)
        {

            Nimi = nimi;
            Julkaisuvuosi = julkaisuVuosi;
            Julkaisija = julkaisija;
            Kehittaja = kehittaja;

            pk.LisaaPeli(this);
        }

        public string KaikkiTiedot()
        {
            string r1 = $"Peli: {Nimi}";
            string r2 = $"Julkaisuvuosi: {Julkaisuvuosi}";
            string r3 = $"Julkaisija: {Julkaisija}";
            string r4 = $"Kehittäjä: {Kehittaja}";
            string r5 = $"Arvio: {Arvio}/5";

            return r1 + "\n" + r2 + "\n" + r3 + "\n" + r4 + "\n" + r5;
        }

        public override string ToString()
        {
            if (Arvio == 0) 
            {
                return $"{Nimi} ({Julkaisuvuosi}) - Arvio: Ei vielä arvioitu";
            }
            else
            { 
                return $"{Nimi} ({Julkaisuvuosi}) - Arvio: {Arvio}/5"; 
            }
        }

    }
}
