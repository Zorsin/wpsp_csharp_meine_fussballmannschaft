using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

namespace MeineFussballmannschaft
{
    class TestMain
    {
        
       
        public static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            Kader kader = new Kader();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Kader));
            string currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string currentAssemblyParentPath = Path.GetDirectoryName(currentAssemblyPath);
            String path = String.Format("{0}/{1}", Path.GetDirectoryName(currentAssemblyParentPath), "VfB Stuttgart/SpielerData.xml");

            FileStream fileStream = new FileStream(path, FileMode.Open);
            XmlReader xmlReader = XmlReader.Create(fileStream);


            kader = (Kader)xmlSerializer.Deserialize(xmlReader);

            Console.WriteLine("Anzahl an Spielern:" + kader.SpielerListe.Count);
            //Spieler spieler = kader.SpielerListe[0];
            //Console.WriteLine(spieler.Name);
            foreach (Spieler spieler in kader.SpielerListe){
                Console.WriteLine("--- Neuer Spieler ---");
                Console.WriteLine(spieler.Vorname + " " + spieler.Name);
                Console.WriteLine(spieler.Position);
                Console.WriteLine(spieler.Rueckennummer);
                Console.WriteLine(spieler.Seit);
                Console.WriteLine(spieler.GeburtsDatum);
                Console.WriteLine(spieler.GroesseInCm);
                Console.WriteLine(spieler.GewichtInKg);
                Console.WriteLine(spieler.SpieleInBundesliga);
                Console.WriteLine(spieler.ToreInBundesliga);
                Console.WriteLine(spieler.Nation);
                Console.WriteLine(spieler.Laenderspiele);
            }
        }
    }
}
