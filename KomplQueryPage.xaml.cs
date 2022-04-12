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
    /// Логика взаимодействия для KomplQueryPage.xaml
    /// </summary>
    public partial class KomplQueryPage : Page
    {
        private Komplektsh _queryKomplektsh = new Komplektsh();
        public KomplQueryPage(int qt)
        {
            InitializeComponent();
            var qrt = UchTechEntities.GetContext().Komplektsh.Where(p => p.id_pc == qt);
            KomplektQueryGrid.ItemsSource = qrt.ToList();      
        }

        private void ButBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.GoBack();

        }
    }
}
