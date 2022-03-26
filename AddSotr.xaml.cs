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
    /// Логика взаимодействия для AddSotr.xaml
    /// </summary>
    public partial class AddSotr : Page
    {
        private Sotrud _currentSotrud = new Sotrud();
        public AddSotr(Sotrud selectedSotr)
        {
            if (selectedSotr != null)
                _currentSotrud = selectedSotr;
            DataContext = _currentSotrud;
            InitializeComponent();
        }
    }
}
