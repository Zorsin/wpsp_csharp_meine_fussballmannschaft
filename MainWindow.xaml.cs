using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace MeineFussballmannschaft
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Kader kader = new Kader();
        private int minSelectedItem;
        private int maxSelectedItem;
        private String folderOfPlayerData = "VfB Stuttgart";

        public MainWindow()
        {
            InitializeComponent();
            
            Init();

            foreach(Spieler spieler in kader.SpielerListe)
            {
                comboBoxSpielerList.Items.Add(String.Format("{0} {1}", spieler.Vorname, spieler.Name));
            }
            comboBoxSpielerList.SelectedIndex = 0;
            minSelectedItem = 0;
            maxSelectedItem = kader.SpielerListe.Count - 1;

            buttonPrev.IsEnabled = false;
            buttonFirst.IsEnabled = false;

            buttonNext.IsEnabled = true;
            buttonLast.IsEnabled = true;

        }

        public void Init()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Kader));
            string currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string currentAssemblyParentPath = Path.GetDirectoryName(currentAssemblyPath);
            String path = String.Format("{0}/{1}/{2}", Path.GetDirectoryName(currentAssemblyParentPath), folderOfPlayerData ,"SpielerData.xml");

            FileStream fileStream = new FileStream(path, FileMode.Open);
            XmlReader xmlReader = XmlReader.Create(fileStream);
                     

            kader = (Kader)xmlSerializer.Deserialize(xmlReader);

            Console.WriteLine("Anzahl an Spielern in der XML:" + kader.SpielerListe.Count);
                        
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

        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSpielerList.SelectedIndex = 0;

            buttonPrev.IsEnabled = false;
            buttonFirst.IsEnabled = false;

            buttonNext.IsEnabled = true;
            buttonLast.IsEnabled = true;
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSpielerList.SelectedIndex = comboBoxSpielerList.SelectedIndex - 1;

            if(comboBoxSpielerList.SelectedIndex == minSelectedItem)
            {
                buttonPrev.IsEnabled = false;
                buttonFirst.IsEnabled = false;
            }

            if(comboBoxSpielerList.SelectedIndex < maxSelectedItem)
            {
                buttonNext.IsEnabled = true;
                buttonLast.IsEnabled = true;
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSpielerList.SelectedIndex = comboBoxSpielerList.SelectedIndex + 1;
            if(comboBoxSpielerList.SelectedIndex > minSelectedItem)
            {
                buttonPrev.IsEnabled = true;
                buttonFirst.IsEnabled = true;
            }

            if (comboBoxSpielerList.SelectedIndex == maxSelectedItem)
            {
                buttonNext.IsEnabled = false;
                buttonLast.IsEnabled = false;
            }
        }

        private void buttonLast_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSpielerList.SelectedIndex = maxSelectedItem;
            
            buttonPrev.IsEnabled = true;
            buttonFirst.IsEnabled = true;

            buttonNext.IsEnabled = false;
            buttonLast.IsEnabled = false;
            
        }
        
        private void comboBoxSpielerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("ComboBoxValue has changed! Index:"+comboBoxSpielerList.SelectedIndex);

            Spieler spieler = kader.SpielerListe[comboBoxSpielerList.SelectedIndex];

            //Console.WriteLine("--- Neuer Spieler ---");
            //Console.WriteLine(spieler.Vorname + " " + spieler.Name);
            //Console.WriteLine(spieler.Position);
            //Console.WriteLine(spieler.Rueckennummer);
            //Console.WriteLine(spieler.Seit);
            //Console.WriteLine(spieler.GeburtsDatum);
            //Console.WriteLine(spieler.GroesseInCm);
            //Console.WriteLine(spieler.GewichtInKg);
            //Console.WriteLine(spieler.SpieleInBundesliga);
            //Console.WriteLine(spieler.ToreInBundesliga);
            //Console.WriteLine(spieler.Nation);
            //Console.WriteLine(spieler.Laenderspiele);

            MapSpielerTextBox();

            if (comboBoxSpielerList.SelectedIndex == minSelectedItem)
            {
                buttonPrev.IsEnabled = false;
                buttonFirst.IsEnabled = false;
            }
            else
            {
                buttonPrev.IsEnabled = true;
                buttonFirst.IsEnabled = true;
            }

            if (comboBoxSpielerList.SelectedIndex < maxSelectedItem)
            {
                buttonNext.IsEnabled = true;
                buttonLast.IsEnabled = true;
            }
            else
            {
                buttonNext.IsEnabled = false;
                buttonLast.IsEnabled = false;
            }
        }

        private void MapSpielerTextBox()
        {
            Spieler spieler = kader.SpielerListe[comboBoxSpielerList.SelectedIndex];

            textBoxName.Text = spieler.Name;
            textBoxVorname.Text = spieler.Vorname;
            textBoxPosition.Text = spieler.Position;
            textBoxRueckennummer.Text = String.Format("{0}", spieler.Rueckennummer);
            textBoxSeit.Text = String.Format("{0}", spieler.Seit);
            textBoxGeburtsdatum.Text = spieler.GeburtsDatum;
            textBoxGroesseInCm.Text = String.Format("{0}", spieler.GroesseInCm);
            textBoxGewichtInKg.Text = String.Format("{0}", spieler.GewichtInKg);
            textBoxSpieleTore.Text = String.Format("{0} / {1}", spieler.SpieleInBundesliga, spieler.ToreInBundesliga);
            textBoxNation.Text = spieler.Nation;
            textBoxLänderspiele.Text = String.Format("{0}", spieler.Laenderspiele);

            String playerFullName = String.Format("{1} {0}", spieler.Vorname, spieler.Name);

            string currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string currentAssemblyParentPath = Path.GetDirectoryName(currentAssemblyPath);
            String path = String.Format("{0}/{1}/{2}.jpg", Path.GetDirectoryName(currentAssemblyParentPath), folderOfPlayerData, playerFullName);
            
            Uri uri = new Uri(path);
            try
            {
                imageSpieler.Source = null;
                var bitmap = new BitmapImage(uri);
                imageSpieler.Source = bitmap;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Fehler beim Abfragen des Bildes:" + exception.Message);
            }
            
        }
    }
}
