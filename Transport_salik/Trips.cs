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
    public partial class Trips : Form
    {
        public Trips()
        {
            InitializeComponent();
        }

        private void Trips_Load(object sender, EventArgs e)
        {
            clientname.Items.AddRange(Sqlite.LoadClients());
            clientname.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            if (clientname.Text == "-")
               sq = new SQLiteCommand("select * from Trips where Date BETWEEN '" + dateTimePicker1.Text + "' and '"+ dateTimePicker2.Text+"'", scn);
            else
               sq = new SQLiteCommand("select * from Trips where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND Name='" + clientname.Text + "'", scn);
            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {
                int total=0;
                var command = new SQLiteCommand("select sum(Amount) from TripDetails where Tripno = '" + dr["TripNo"].ToString() + "'", scn);
                try
                {
                    total -= int.Parse(command.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                }

                command = new SQLiteCommand("select sum(amount) from Expenses where tripno = '" + dr["TripNo"].ToString() + "'", scn);             
                try
                {
                    total -= int.Parse(command.ExecuteScalar().ToString());
                }
                catch (Exception)
                {
                }        

                if (dr["Status"].ToString() == "Paid")
                {
                    total += (int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString()) + int.Parse(dr["Other"].ToString()));
                }
                listView1.Items.Add(new ListViewItem(new[]
                {
                 dr["TripNo"].ToString(),
                  dr["Name"].ToString(),
                  dr["Date"].ToString(),
                  dr["Qty"].ToString(),
                  dr["Froom"].ToString(),
                  dr["Tao"].ToString(),
                  (int.Parse(dr["Amount"].ToString())*int.Parse(dr["Qty"].ToString())+int.Parse(dr["Other"].ToString())).ToString(),
                  dr["Status"].ToString(),
                  total.ToString(),
                dr["Type"].ToString()
                }));
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TripAdd tadd = new TripAdd();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select * from Trips where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            tadd.truckdetails.Items.Clear();
            while (dr.Read())
            {
                tadd.isNew = false;
                tadd.invoiceno.Text = listView1.SelectedItems[0].Text;
                tadd.customername.Items.AddRange(Sqlite.LoadClients());
                tadd.customername.Text = dr["Name"].ToString();
                tadd.from.Text = dr["Froom"].ToString();
                tadd.to.Text = dr["Tao"].ToString();
                tadd.comments.Text = dr["Comments"].ToString();
                tadd.dateTimePicker1.Text = dr["Date"].ToString();
                tadd.status = dr["Status"].ToString();
                tadd.Qty.Text = dr["Qty"].ToString();
                tadd.amount.Text = dr["Amount"].ToString();
                tadd.typebox.Text = dr["Type"].ToString();
                tadd.other.Text = dr["Other"].ToString();
            }
           
            sq = new SQLiteCommand("select * from TripDetails where Tripno = '" + listView1.SelectedItems[0].Text +"'", scn);
            
            dr = sq.ExecuteReader();
            while (dr.Read())
            {
                tadd.truckdetails.Items.Add(new ListViewItem(new[] { dr["Truckno"].ToString(),
                                                             dr["Weight"].ToString(),
                                                             dr["Location"].ToString(),
                                                             dr["Qty"].ToString(),
                                                             dr["Amount"].ToString()}));

            }
            tadd.ShowTrucksQty();
            tadd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(listView1.SelectedItems[0].SubItems[6].Text) > Sqlite.ClientBalance(listView1.SelectedItems[0].SubItems[1].Text))
            {
                MessageBox.Show("Not enough balance");
                return;
            }
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;
            sq = new SQLiteCommand("update Trips set Status='Paid' where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);
            sq.ExecuteNonQuery();
            filter.PerformClick();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Sqlite.ClientBalance(clientname.Text).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
                scn.Open();
                SQLiteCommand sq;
                sq = new SQLiteCommand("delete from Trips where TripNo = '" + listView1.SelectedItems[0].Text + "'", scn);
                sq.ExecuteNonQuery();
                sq = new SQLiteCommand("delete from TripDetails where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);
                sq.ExecuteNonQuery();
                filter.PerformClick();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sqlite.ColumnSorter(e.Column, listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum=0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sum += int.Parse(listView1.Items[i].SubItems[8].Text);
            }
            MessageBox.Show(sum.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(listView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sum += int.Parse(listView1.Items[i].SubItems[6].Text);
            }
            MessageBox.Show(sum.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;
            sq = new SQLiteCommand("update Trips set Status='Unpaid' where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);
            sq.ExecuteNonQuery();
            filter.PerformClick();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
