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
    /// Логика взаимодействия для SotrPage.xaml
    /// </summary>
    public partial class SotrPage : Page
    {
        public SotrPage()
        {
            InitializeComponent();
            SotrGrid.ItemsSource = UchTechEntities.GetContext().Sotrud.ToList();
        }

        private void AddButtSotr_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddSotr(null));
        }
        private void EditButtSotr_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddSotr((sender as Button).DataContext as Sotrud));
        }

        private void DelButtSotr_Click(object sender, RoutedEventArgs e)
        {
            var RemoveK = SotrGrid.SelectedItems.Cast<Sotrud>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {RemoveK.Count()}записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UchTechEntities.GetContext().Sotrud.RemoveRange(RemoveK);
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
