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
            Queres query = new Queres();
            query.CBox_Query(CompBox);
            Dictionary<int, string> pcs = new Dictionary<int, string>();
            for(int i = 0; i < CompBox.Items.Count; i++)
            {
                pcs.Add(i, CompBox.Items[i].ToString());
            }
            query.CBox_Status2(StatusBox);
            Dictionary<int, string> stts = new Dictionary<int, string>();
            for (int i = 0; i < StatusBox.Items.Count; i++)
            {
                stts.Add(i, StatusBox.Items[i].ToString());
            }
            query.CBox_TKom(TypesCBox);
            Dictionary<int, string> tps = new Dictionary<int, string>();
            for (int i = 0; i < TypesCBox.Items.Count; i++)
            {
                tps.Add(i, TypesCBox.Items[i].ToString());
            }
            if (selectedCompl != null)
            {
                _currentKomplektsh = selectedCompl;
                if (_currentKomplektsh.Technika1.name != null)
                    for (int i = 0; i < CompBox.Items.Count; i++)
                    {
                        if (pcs[i] == _currentKomplektsh.Technika1.name)
                            CompBox.SelectedIndex = i;
                        else CompBox.SelectedIndex = -1;
                    }
                if (_currentKomplektsh.Status1.status1 != null)
                {
                    for (int i = 0; i < StatusBox.Items.Count; i++)
                    {
                        if (stts[i] == _currentKomplektsh.Status1.status1)
                            StatusBox.SelectedIndex = i;
                        else StatusBox.SelectedIndex = -1;
                    }
                }
                if (_currentKomplektsh.Type_Komplekt1.name_type != null)
                {
                    for (int i = 0; i < TypesCBox.Items.Count; i++)
                    {
                        if (tps[i] == _currentKomplektsh.Type_Komplekt1.name_type)
                            TypesCBox.SelectedIndex = i;
                        else TypesCBox.SelectedIndex = -1;
                    }
                }

            }
            DataContext = _currentKomplektsh;
            

        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            Queres query = new Queres();
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentKomplektsh.name_komplekt))
            {
                errors.AppendLine("Введите название");
            }
            if (TypesCBox.SelectedIndex == -1)
            {
                errors.AppendLine("Выберите тмп комплектующего");
            }
            else _currentKomplektsh.type_komplekt = query.Add_TPKompl(TypesCBox);
            if (StatusBox.SelectedIndex == -1)
            {
                errors.AppendLine("Выберите статус");
            }
            else _currentKomplektsh.id_status = query.Add_Stats(StatusBox);
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            
            if (CompBox.SelectedIndex != -1)
            {
                _currentKomplektsh.id_pc = query.Add_TPC(CompBox);
            }
            if (_currentKomplektsh.id_kompl == 0)
                {
                    UchTechEntities.GetContext().Komplektsh.Add(_currentKomplektsh);
                }
           
            try
                {
                    UchTechEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    FrameNav.MF_EX.Navigate(new KomplektsPage());
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

