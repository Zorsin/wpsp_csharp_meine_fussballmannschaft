using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeineFussballmannschaft
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Kader kader = new Kader();
            kader.Init();

        }

        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxSpielerList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
