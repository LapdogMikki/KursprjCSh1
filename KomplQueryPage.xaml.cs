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
        public KomplQueryPage(string dateq)
        {
            InitializeComponent();
            Queres query = new Queres();
            query.Table_Query(dateq, KomplektQueryGrid);
            
        }

        private void ButBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.GoBack();

        }
    }
}
