using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursprj2
{
    class Queres
    {

        public void CBox_Query(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Technika
                          where techs.id_techn == 2
                          select techs.name;
                var kgm = pcs.ToList();
                    CBox.ItemsSource= kgm;
            }
        }

        public void CBox_Status1(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Status
                          select techs.status1;
                var kgm = pcs.ToList();
                    CBox.ItemsSource=kgm;
      
            }
        }
        public void CBox_Status2(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Status
                          select techs.status1;
                var kgm = pcs.ToList();
                CBox.ItemsSource = kgm;

            }
        }
        public void CBox_TTech(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Type_Techn
                          select techs.name_type;
                var kgm = pcs.ToList();
                CBox.ItemsSource=kgm;
            }
        }
        public void CBox_Usvers(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Sotrud
                          select techs.FIO;
                var kgm = pcs.ToList();
                CBox.ItemsSource = kgm;

            }
        }

        public void CBox_TKom(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var pcs = from techs in context.Type_Komplekt

                          select techs.name_type;
                var kgm = pcs.ToList();
                CBox.ItemsSource = kgm;

            }
        }

        public void Table_Query(string txquery, DataGrid TQue)
        {
            using (var context = new UchTechEntities())
            {
                var txt = from pcs in context.Technika
                          where pcs.name == txquery
                          select pcs;
                var ids = txt.ToList();
                var quere = from que in context.Komplektsh
                            from kvs in ids
                            where que.id_pc == kvs.id_techn
                            select new { que.name_komplekt};
                var qds = quere.ToList();
                TQue.ItemsSource = qds;

            }
        }
           
    }
}
