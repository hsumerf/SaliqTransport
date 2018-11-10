using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport_salik
{
    public partial class TrucksList : Form
    {
        public TrucksList()
        {
            InitializeComponent();
        }

        private void TrucksList_Load(object sender, EventArgs e)
        {
            
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filter_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;
            sq = new SQLiteCommand("select distinct TripDetails.Truckno from TripDetails inner join Trips on TripDetails.Tripno = Trips.TripNo "+
             "WHERE Trips.Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", scn);


            SQLiteDataReader dr = sq.ExecuteReader();
        
            while (dr.Read())
            {

                var item = new ListViewItem();
                item.Text = dr["Truckno"].ToString();
                item.SubItems.Add(Sqlite.TruckBalance(dr["Truckno"].ToString()).ToString());
                if (item.SubItems[1].Text != "0")
                {
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[1].BackColor = Color.LightPink;
                 
                }
                //listView1.Items.Add(new ListViewItem(new[] { dr["Truckno"].ToString(),
                //                                             Sqlite.TruckBalance( dr["Truckno"].ToString()).ToString()}));
                listView1.Items.Add(item);
               
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpenseAdd expenseAdd = new ExpenseAdd();
            expenseAdd.recver.Text = listView1.SelectedItems[0].Text;
            expenseAdd.amount.Text = listView1.SelectedItems[0].SubItems[1].Text;
            expenseAdd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sum += int.Parse(listView1.Items[i].SubItems[1].Text);
            }
            MessageBox.Show(sum.ToString());
        }
    }
}
