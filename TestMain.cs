using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeineFussballmannschaft
{
    class TestMain
    {
        
       
        public static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            Kader kader = new Kader();
            kader.Init();
            //Spieler spieler = kader.SpielerListe[0];
            //Console.WriteLine(spieler.Name);
            foreach(Spieler spieler in kader.SpielerListe){
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
