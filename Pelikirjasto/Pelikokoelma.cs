using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace Pelikirjasto
{
     public class Pelikokoelma
    {
        public List<Peli> Pelit { get; set; } = new List<Peli>();

        public Pelikokoelma(){}

        public Peli? EtsiPeli(string nimi)
        {
            List<Peli> mahdPelit = new List<Peli>();
            foreach (Peli peli in Pelit)
            {
                if (peli.Nimi.ToLower() == nimi.ToLower())
                {
                    return peli;
                }
                else if (peli.Nimi.ToLower().Contains(nimi.ToLower()))
                {
                    mahdPelit.Add(peli);
                }
            }

            int maara = mahdPelit.Count;
            if (maara == 0) { return null; }
            if (maara == 1) { return mahdPelit[0]; }

            Console.WriteLine("Valitse peli (numero)");
            for (int i = 0; i < maara; i++) { Console.WriteLine($"[{i + 1}]: " + mahdPelit[i].Nimi); }

            int valinta = -1;
            bool succ = Int32.TryParse(Console.ReadLine(), out valinta);
            if (!succ || maara < valinta || valinta < 1) { return null; }
            return mahdPelit[valinta - 1]; 
        }

        public void LisaaPeli(Peli peli)
        {
            Pelit.Add(peli);
        }

        public void PoistaPeli(string nimi)
        {
            Peli? p = EtsiPeli(nimi);
            if (p != null)
            {
                Pelit.Remove(p);
            }
        }

        public void TulostaPelit()
        {
            foreach(Peli p in Pelit)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public void TallennaXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pelikokoelma));
            FileStream fileStream = new FileStream("pelikokoelma.xml", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                xmlSerializer.Serialize(fileStream, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virhe tallentaessa: " + ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public void LataaXML()
        {
            if (!File.Exists("pelikokoelma.xml"))
            {
                return;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pelikokoelma));
            FileStream fileStream = new FileStream("pelikokoelma.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                Pelikokoelma? ladattu = xmlSerializer.Deserialize(fileStream) as Pelikokoelma;

                if (ladattu != null)
                {
                    this.Pelit = ladattu.Pelit;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virhe ladatessa: " + ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
