using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport_salik
{
    public static class Sqlite
    {
        public static string[] LoadClients()
        {
            List<string> namelist = new List<string>();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select Name from Clients", scn);
            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {

                namelist.Add(dr["Name"].ToString());
            }

            return namelist.ToArray();
        }

        public static int ClientBalance(string client)
        {
            int bal;
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;
           
            sq = new SQLiteCommand("select sum(Amount) from Recevings where Payer = '" + client + "'",scn);
            try
            {
                bal = int.Parse(sq.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                bal = 0;
            }
            sq = new SQLiteCommand("select sum((Amount*Qty)+Other) from Trips where Name='" + client + "' and Status='Paid'", scn);
            try
            {
                bal -= int.Parse(sq.ExecuteScalar().ToString());
                //System.Windows.Forms.MessageBox.Show(bal.ToString());
            }
            catch (Exception)
            {
            }
            return bal;

        }

        public static int TruckBalance(string truckno)
        {
            int bal;
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select sum(Amount) from TripDetails where Truckno = '" + truckno + "'", scn);
            try
            {
                bal = int.Parse(sq.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                bal = 0;
            }
            sq = new SQLiteCommand("select sum(amount) from Expenses where recver='" + truckno + "'", scn);
            try
            {
                bal -= int.Parse(sq.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
            }
            return bal;

        }

        public static void ColumnSorter(int index,System.Windows.Forms.ListView list)
        {
            sorter sorter = list.ListViewItemSorter as sorter;
            if (sorter == null)
            {
                sorter = new sorter(index);
                list.ListViewItemSorter = sorter;
            }
            else
            {
                sorter.Column = index;
            }
            list.Sort();
            list.ListViewItemSorter = null;
        }

        public static void ExportToExcel(ListView listsource)
        {
            StringBuilder CVS = new StringBuilder();
            for (int i = 0; i < listsource.Columns.Count; i++)
            {
                CVS.Append(listsource.Columns[i].Text + ",");
            }
            CVS.Append(Environment.NewLine);
            for (int i = 0; i < listsource.Items.Count; i++)
            {
                for (int j = 0; j < listsource.Columns.Count; j++)
                {
                    CVS.Append(listsource.Items[i].SubItems[j].Text + ",");
                }
                CVS.Append(Environment.NewLine);
            }
            System.IO.File.WriteAllText("Export.csv", CVS.ToString());
            Process.Start("Export.csv");
        }
    }
}
