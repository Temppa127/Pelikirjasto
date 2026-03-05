using System.Globalization;

namespace Pelikirjasto
{
    internal class Program
    {

        static string KysyNimi(string tieto)
        {
            if(tieto == "julkaisuvuosi") { Console.WriteLine($"Anna julkaisuvuosi"); }
            else if(tieto == "peliEtsi") { Console.WriteLine($"Anna pelin nimi (tai osa nimestä)"); }
            else { Console.WriteLine($"Anna {tieto}n nimi"); }
            
            string? inp = Console.ReadLine();

            if (inp == null)
            {
                Console.WriteLine("Virhe tiedon annossa");
                return "";
            }
            else
            {
                return inp;
            }
        }




        static void Main(string[] args)
        {
            Pelikokoelma pk = new Pelikokoelma();

            // ESIMERKKIPELI: VOI POISTAA
            Peli p1 = new KonsoliPeli(pk, "Makkaramaakarit Deluxe", 2004, "Atria", "Rovio", "Xbox");
            p1.Arvio = 5;
            
            pk.LataaXML();



            while (true)
            {

                Console.WriteLine("\r\n1 = Lisää peli\r\n2 = Poista peli\r\n3 = Arvioi peli\r\n4 = Listaa kaikki pelit\r\n5 = Näytä pelin tiedot\r\n6 = Tarkista arvosana\r\n7 = Tallenna\r\n0 = Lopeta\r\n");

                string? inp = Console.ReadLine();
                if(inp == null) { continue; }

                switch (inp[0] - '0') {

                    case 1:
                        {
                            string nimi = KysyNimi("peli");
                            if(nimi == "") {continue;}
                            int jv = -1;
                            bool succ = Int32.TryParse(KysyNimi("julkaisuvuosi"), out jv);
                            if (!succ) { continue; }
                            string jul = KysyNimi("julkaisija");
                            if (jul == "") { continue; }
                            string keh = KysyNimi("kehittäjä");
                            if (keh == "") { continue; }

                            Console.WriteLine("Alusta:\n[1]: PC\n[2]: Konsoli\n[3}: Mobiili\n");
                            int vl = -1;
                            bool succ2 = Int32.TryParse(Console.ReadLine(), out vl);
                            if (!succ2) { continue; }

                            switch (vl)
                            {
                                case 1:
                                    {
                                        string kau = KysyNimi("kauppa-alusta");
                                        if (kau == "") { continue; }

                                        new PCPeli(pk, nimi, jv, jul, keh, kau);
                                        continue;
                                    }

                                case 2:
                                    {
                                        string kon = KysyNimi("konsoli");
                                        if (kon == "") { continue; }

                                        new KonsoliPeli(pk, nimi, jv, jul, keh, kon);

                                        continue;
                                    }

                                case 3:
                                    {
                                        string sov = KysyNimi("sovelluskaupa"); // kyllä, tahalteen väärin kirjoitettu
                                        if (sov == "") { continue; }

                                        new MobiiliPeli(pk, nimi, jv, jul, keh, sov);

                                        continue;
                                    }

                            }

                            continue;

                        }

                    case 2:
                        {
                            string nimi = KysyNimi("peliEtsi");
                            if (nimi == "") { continue; }
                            pk.PoistaPeli(nimi);
                            continue;
                        }

                    case 3:
                        {
                            string nimi = KysyNimi("peliEtsi");
                            if (nimi == "") { continue; }
                            Peli? p = pk.EtsiPeli(nimi);
                            if (p == null) { Console.WriteLine("Peliä ei löytynyt"); continue; }


                            Console.WriteLine("Anna arvosana (0-5)");
                            bool succ = double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double arv);
                            if (!succ) { continue; }

                            p.Arvio = arv;
                            continue;
                        }

                    case 4: 
                        {
                            pk.TulostaPelit();
                            continue;
                        }

                    case 5:
                        {
                            string nimi = KysyNimi("peliEtsi");
                            if (nimi == "") { continue; }
                            Peli? p = pk.EtsiPeli(nimi);
                            if (p == null) { Console.WriteLine("Peliä ei löytynyt"); continue; }
                            Console.WriteLine(p.KaikkiTiedot());
                            continue;
                        }

                    case 6:
                        {
                            string nimi = KysyNimi("peliEtsi");
                            if (nimi == "") { continue; }
                            Peli? p = pk.EtsiPeli(nimi);
                            if (p == null) { Console.WriteLine("Peliä ei löytynyt"); continue; }
                            Console.WriteLine(p.ArvioYhteenveto());
                            continue;
                        }

                    case 7: pk.TallennaXML(); continue;

                    case 0: return;

                }

            }

        }
    }

}
