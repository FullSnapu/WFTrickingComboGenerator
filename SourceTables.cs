using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;

namespace WFTrickingComboGenerator
{
    public static class SourceTables
    {
        public static DataTable TrickTable1 { get; set; }

        static SourceTables()
        {
            TrickTable1 = new DataTable();
            CreateTrickTable();
        }

        private static void CreateTrickTable() //probably create new class
        {
            DataTable dt1 = new DataTable();

            DataColumn dc1 = new DataColumn("Name");
            DataColumn dc2 = new DataColumn("DisplayName");
            DataColumn dc3 = new DataColumn("OneFootTakeOff");
            DataColumn dc4 = new DataColumn("InStances");
            DataColumn dc5 = new DataColumn("OutStances");
            DataColumn dc6 = new DataColumn("InStance");
            DataColumn dc7 = new DataColumn("OutStance");
            DataColumn dc8 = new DataColumn("Category");
            DataColumn dc9 = new DataColumn("Variation");

            dt1.Columns.Add(dc1);
            dt1.Columns.Add(dc2);
            dt1.Columns.Add(dc3);
            dt1.Columns.Add(dc4);
            dt1.Columns.Add(dc5);
            dt1.Columns.Add(dc6);
            dt1.Columns.Add(dc7);
            dt1.Columns.Add(dc8);
            dt1.Columns.Add(dc9);

            Trick t;

            for (int i = 0; i < TrickLibrary.TrickData.Count; i++)
            {
                t = TrickLibrary.TrickData[i];

                dt1.Rows.Add(t.Name, t.DisplayName, t.OneFootTakeOff, t.InStances, t.OutStances, t.InStance, t.OutStance, t.Category, t.Variation);
            }
        }



        public static void AssociateDataTableToComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = dt
        }

        private static BindingList<Trick> cbTrickList1 = new BindingList<Trick>();
        private static BindingSource bs1 = new BindingSource();

        private void PopulateTrickComboBox(Transition prevTran, Transition nextTran, ComboBox comboBox)
        {
            //list of applicable tricks based on prev and next tran
            List<Trick> applicableTricks = TrickLibrary.GetSuitableTrickList(prevTran, nextTran, false);

            if (cbTrickList1.Count > 0) { cbTrickList1.Clear(); }
            //loop thru list and add names to list
            for (int i = 0; i < applicableTricks.Count; i++)
            {
                Trick trick = applicableTricks[i];
                if (TrickNotInList(trick, cbTrickList1)) //ignore favorability - by removing duplicates
                {
                    cbTrickList1.Add(trick);
                }
            }

        }
    }
}
