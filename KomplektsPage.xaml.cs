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
    /// Логика взаимодействия для KomplektsPage.xaml
    /// </summary>
    public partial class KomplektsPage : Page
    {
        public KomplektsPage()
        {
            InitializeComponent();
            KomplektGrid.ItemsSource = UchTechEntities.GetContext().Komplektsh.ToList();
        }

      

        private void AddButtComp_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddKompl(null));
        }

        private void EditButtComp_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddKompl((sender as Button).DataContext as Komplektsh));
        }

        private void DelButtKomp_Click(object sender, RoutedEventArgs e)
        {
            var RemoveK = KomplektGrid.SelectedItems.Cast<Komplektsh>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {RemoveK.Count()}записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { try
                {
                    UchTechEntities.GetContext().Komplektsh.RemoveRange(RemoveK);
                    UchTechEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                   }
        }
    }
}
