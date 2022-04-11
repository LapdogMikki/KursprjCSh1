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
            using (var context = new UchTechEntities())
            {
                var txt = from pcs in context.Technika
                          where pcs.name == dateq
                          select pcs;
                var ids = txt.ToList();
                var quere = from que in context.Komplektsh
                            from kvs in ids
                            where que.id_pc == kvs.id_techn
                            select new { que.name_komplekt, que.Type_Komplekt1.name_type, que.Status1.status1, que.Technika1.name };
                var qds = quere.ToList();
                

            }
        }

        private void ButBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.MF_EX.GoBack();

        }
    }
}
