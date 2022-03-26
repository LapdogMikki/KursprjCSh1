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
    /// Логика взаимодействия для AddKompl.xaml
    /// </summary>
    public partial class AddKompl : Page
    {
        private Komplektsh _currentKomplektsh = new Komplektsh();
        public AddKompl(Komplektsh selectedCompl)
        {
            InitializeComponent();
            if (selectedCompl != null)
                _currentKomplektsh = selectedCompl;
            DataContext = _currentKomplektsh;
            Queres query = new Queres();
            query.CBox_Query(CompBox);
            query.CBox_Status2(StatusBox);
            query.CBox_TKom(TypesCBox);

        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentKomplektsh.name_komplekt)){
                errors.AppendLine("Введите название");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentKomplektsh.id_kompl == 0)
                {
                    UchTechEntities.GetContext().Komplektsh.Add(_currentKomplektsh);
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

