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

namespace Kursprj2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            FrameNav.MF_EX = MainFrame;
            FrameNav.MF_EX.Navigate(new TechPage());
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new TechPage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new SotrPage());
        }
    }
}
