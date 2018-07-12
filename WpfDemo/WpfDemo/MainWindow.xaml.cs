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

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit is XAML en WPF!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var p = new Persoon();
            p.Voornaam = "Xander";
            p.Achternaam = "Wemmers";

            sp.DataContext = p;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var p = (Persoon)sp.DataContext;

            MessageBox.Show(p.Voornaam + " " + p.Achternaam);
        }
    }
}
