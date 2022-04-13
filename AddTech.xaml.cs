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
            InitializeComponent();
            Queres quere = new Queres();
            quere.CBox_Status2(StatusBox);
            Dictionary<int, string> stts = new Dictionary<int, string>();
            for (int i = 0; i < StatusBox.Items.Count; i++)
            {
                stts.Add(i, StatusBox.Items[i].ToString());
            }
            quere.CBox_TTech(TypesCBox);
            Dictionary<int, string> tps = new Dictionary<int, string>();
            for (int i = 0; i < TypesCBox.Items.Count; i++)
            {
                tps.Add(i, TypesCBox.Items[i].ToString());
            }
            quere.CBox_Usvers(UserBox);
            Dictionary<int, string> ccs = new Dictionary<int, string>();
            for (int i = 0; i < UserBox.Items.Count; i++)
            {
                ccs.Add(i, UserBox.Items[i].ToString());
            }
            if (selectedTech != null) { 
                _currentTechnika= selectedTech;
                if (_currentTechnika.Sotrud1.FIO != null)
                for (int i = 0; i < UserBox.Items.Count; i++)
                {
                    if (ccs[i] == _currentTechnika.Sotrud1.FIO)
                        UserBox.SelectedIndex = i;
                    
                    }
                if (_currentTechnika.Status1.status1 != null)
                {
                    for (int i = 0; i < StatusBox.Items.Count; i++)
                    {
                        if (stts[i] == _currentTechnika.Status1.status1)
                            StatusBox.SelectedIndex = i;
                        
                    }
                }
                if (_currentTechnika.Type_Techn.name_type != null)
                {
                    for (int i = 0; i < TypesCBox.Items.Count; i++)
                    {
                        if (tps[i] == _currentTechnika.Type_Techn.name_type)
                            TypesCBox.SelectedIndex = i;
                        
                    }
                }
            }
            DataContext = _currentTechnika;
            
            

        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            Queres query = new Queres();
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentTechnika.name))
            {
                errors.AppendLine("Введите название");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (TypesCBox.SelectedIndex == -1)
            {
                errors.AppendLine("Выберите тмп комплектующего");
            }
            else _currentTechnika.id_type_techn = query.Add_TPTechn(TypesCBox);
            if (StatusBox.SelectedIndex == -1)
            {
                errors.AppendLine("Выберите статус");
            }
            else _currentTechnika.id_status = query.Add_Stats(StatusBox);
            if (UserBox.SelectedIndex != -1)
            {
                _currentTechnika.id_sotrud = query.Add_TPUser(UserBox);
            }
            if (_currentTechnika.id_techn == 0)
            {
                UchTechEntities.GetContext().Technika.Add(_currentTechnika);
            }
            try
            {
                UchTechEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameNav.MF_EX.Navigate(new TechPage());
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
