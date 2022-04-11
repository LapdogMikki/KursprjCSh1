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
                          where techs.id_type_techn == 1
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
        public int Add_Stats(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var selid = from stats in context.Status
                            where stats.status1 == CBox.SelectedItem.ToString()
                            select stats.id_status;
                var id_s = selid.ToArray();
                return id_s[0];
             }
        }
        public int Add_TPKompl(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var selid = from tkomp in context.Type_Komplekt
                            where tkomp.name_type == CBox.SelectedItem.ToString()
                            select tkomp.id_type_komplekt;
                var id_s = selid.ToArray();
                return id_s[0];
            }
        }
        public int Add_TPC(ComboBox CBox)
        {
            using (var context = new UchTechEntities())
            {
                var selid = from tpc in context.Technika
                            where tpc.name == CBox.SelectedItem.ToString()
                            select tpc.id_techn;
                var id_s = selid.ToArray();
                return id_s[0];
            }
        }
        
           
    }
}
