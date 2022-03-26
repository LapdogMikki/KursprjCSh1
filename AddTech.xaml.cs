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
    /// Логика взаимодействия для AddTech.xaml
    /// </summary>
    public partial class AddTech : Page
    {
        private Technika _currentTechnika = new Technika();
        public AddTech(Technika selectedTech)
        {
            if (selectedTech != null)
                _currentTechnika= selectedTech;
            DataContext = _currentTechnika;
            InitializeComponent();
            Queres quere = new Queres();
            quere.CBox_Status(StatusBox);
            quere.CBox_TTech(TypesCBox);
            quere.CBox_Usvers(UserBox);
        }
    }
}
