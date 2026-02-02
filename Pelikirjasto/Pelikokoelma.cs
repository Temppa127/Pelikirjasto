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
            foreach (Peli peli in Pelit)
            {
                if (peli.Nimi == nimi)
                {
                    return peli;
                }
            }
            return null;
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
                Console.WriteLine("Error in saving: " + ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
