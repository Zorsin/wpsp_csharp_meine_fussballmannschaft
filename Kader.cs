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

            Console.WriteLine("Anzahl an Spielern:" + kader.SpielerListe.Capacity);

            SpielerListe = kader.SpielerListe;
        }
    }
}
