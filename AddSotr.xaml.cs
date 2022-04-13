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

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentSotrud.FIO))
            {
                errors.AppendLine("Введите ФИО");
            }
            if (string.IsNullOrWhiteSpace(_currentSotrud.dolzh))
            {
                errors.AppendLine("Введите должность");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentSotrud.id_sotr == 0)
            {
                UchTechEntities.GetContext().Sotrud.Add(_currentSotrud);
            }
            try
            {
                UchTechEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CansBut_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.GoBack();
        }
    }
}
