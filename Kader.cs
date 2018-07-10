using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MeineFussballmannschaft
{
    public class Kader
    {
        public List<Spieler> SpielerListe { get; set; }

        public Kader()
        {
            
        }

        public void Init()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Kader));

            FileStream fileStream = new FileStream("C:/Users/zorsin/Source/Repos/MeineFussballmannschaft/MeineFussballmannschaft/VfB Stuttgart/SpielerData.xml", FileMode.Open);
            XmlReader xmlReader = XmlReader.Create(fileStream);

            Kader kader;

            kader = (Kader)xmlSerializer.Deserialize(xmlReader);

            Console.WriteLine("Anzahl an Spielern:" + kader.SpielerListe.Count);

            SpielerListe = kader.SpielerListe;

            //int count = 0;
            //foreach (Spieler spieler in SpielerListe)
            //{
            //    Console.WriteLine("--- Neuer Spieler ---");
            //    Console.WriteLine(spieler.Vorname + " " + spieler.Name);
            //    Console.WriteLine(spieler.Position);
            //    Console.WriteLine(spieler.Rueckennummer);
            //    Console.WriteLine(spieler.Seit);
            //    Console.WriteLine(spieler.GeburtsDatum);
            //    Console.WriteLine(spieler.GroesseInCm);
            //    Console.WriteLine(spieler.GewichtInKg);
            //    Console.WriteLine(spieler.SpieleInBundesliga);
            //    Console.WriteLine(spieler.ToreInBundesliga);
            //    Console.WriteLine(spieler.Nation);
            //    Console.WriteLine(spieler.Laenderspiele);
            //    Console.WriteLine("Count:"+count);
            //    count++;
            //}
        }
    }
}
