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
    /// Логика взаимодействия для TechPage.xaml
    /// </summary>
    public partial class TechPage : Page
    {
        public TechPage()
        {
            InitializeComponent();
            TechGrid.ItemsSource = UchTechEntities.GetContext().Technika.ToList();
            QueryButton.Visibility = Visibility.Hidden;
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            var cl1 = TechGrid.SelectedCells[1];
            string tp = cl1.Column.GetCellContent(cl1.Item).ToString();
            FrameNav.MF_EX.Navigate(new KomplQueryPage(tp));
        }

        private void TechGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cl1 = TechGrid.SelectedCells[1];
            string tp = cl1.Column.GetCellContent(cl1.Item).ToString();
            if (tp == "Компьютер")
                QueryButton.Visibility = Visibility.Visible;
            else QueryButton.Visibility = Visibility.Hidden;
            
        }

        private void AddButtTech_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddTech(null));
        }
        private void EditButtTech_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.Navigate(new AddTech((sender as Button).DataContext as Technika));
        }

        private void DelButtTech_Click(object sender, RoutedEventArgs e)
        {
            var RemoveK = TechGrid.SelectedItems.Cast<Technika>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {RemoveK.Count()}записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UchTechEntities.GetContext().Technika.RemoveRange(RemoveK);
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
