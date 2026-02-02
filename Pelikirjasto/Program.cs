using System.Globalization;

namespace Pelikirjasto
{
    internal class Program
    {

        static string KysyNimi(string tieto)
        {
            if(tieto == "julkaisuvuosi") { Console.WriteLine($"Anna julkaisuvuosi"); }
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
            Peli p1 = new Peli(pk, "Makkaramaakarit Deluxe", 2004, "Atria", "Rovio");
            p1.Arvio = 5;
            
            pk.LataaXML();



            while (true)
            {

                Console.WriteLine("\r\n1 = Lisää peli\r\n2 = Poista peli\r\n3 = Arvioi peli\r\n4 = Listaa kaikki pelit\r\n5 = Näytä pelin tiedot\r\n6 = Tallenna\r\n0 = Lopeta\r\n");

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

                            new Peli(pk, nimi, jv, jul, keh);
                            continue;

                        }

                    case 2:
                        {
                            string nimi = KysyNimi("peli");
                            if (nimi == "") { continue; }
                            pk.PoistaPeli(nimi);
                            continue;
                        }

                    case 3:
                        {
                            string nimi = KysyNimi("peli");
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
                            string nimi = KysyNimi("peli");
                            if (nimi == "") { continue; }
                            Peli? p = pk.EtsiPeli(nimi);
                            if (p == null) { Console.WriteLine("Peliä ei löytynyt"); continue; }
                            Console.WriteLine(p.KaikkiTiedot());
                            continue;
                        }

                    case 6: pk.TallennaXML(); continue;

                    case 0: return;

                }

            }

        }
    }

}
