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
    public partial class Recevings : Form
    {
        public Recevings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = 0;
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            if (payer.Text == "-")
                sq = new SQLiteCommand("select * from Recevings where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", scn);
            else
            sq = new SQLiteCommand("select * from Recevings where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND Payer='" +payer.Text + "'", scn);

            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {

                listView1.Items.Add(new ListViewItem(new[] { dr["RecID"].ToString(),
                                                             dr["Payer"].ToString(),
                                                             dr["Date"].ToString(),
                                                             dr["Dec"].ToString(),
                                                             dr["Amount"].ToString()}));

                total += Convert.ToInt32(dr["amount"].ToString());
            }
            totaltext.Text = total.ToString();
        }

        private void Recevings_Load(object sender, EventArgs e)
        {
            payer.Items.Add("-");
            payer.Items.AddRange(Sqlite.LoadClients());
            payer.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
                scn.Open();
                SQLiteCommand sq;
                sq = new SQLiteCommand("delete from Recevings where RecID = '" + listView1.SelectedItems[0].Text + "'", scn);
                sq.ExecuteNonQuery();
                filterButton.PerformClick();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sqlite.ColumnSorter(e.Column, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(listView1);
        }

        private void payer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ReceiveEdit Redit = new ReceiveEdit();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select * from Recevings where RecID = '" + listView1.SelectedItems[0].Text + "'", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            //tadd.truckdetails.Items.Clear();
            
            while (dr.Read())
            {
                //tadd.isNew = false;
                //tadd.invoiceno.Text = listView1.SelectedItems[0].Text;
                //tadd.customername.Items.AddRange(Sqlite.LoadClients());
                // Redit.payerBox1.Text = dr["Payer"].ToString();
                Redit.recid = Convert.ToInt32(dr["RecID"]);
                Redit.dateTimePicker1.Text = dr["Date"].ToString();
                Redit.amount.Text = dr["Amount"].ToString();
                Redit.descttxt.Text = dr["Dec"].ToString();
                //tadd.from.Text = dr["Froom"].ToString();
                //tadd.to.Text = dr["Tao"].ToString();
                //tadd.comments.Text = dr["Comments"].ToString();
                //tadd.dateTimePicker1.Text = dr["Date"].ToString();
                //tadd.status = dr["Status"].ToString();
                //tadd.Qty.Text = dr["Qty"].ToString();
                //tadd.amount.Text = dr["Amount"].ToString();
                //tadd.typebox.Text = dr["Type"].ToString();
                //tadd.other.Text = dr["Other"].ToString();
            }

            //sq = new SQLiteCommand("select * from TripDetails where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);

            //dr = sq.ExecuteReader();
            //while (dr.Read())
            //{
            //    tadd.truckdetails.Items.Add(new ListViewItem(new[] { dr["Truckno"].ToString(),
            //                                                 dr["Weight"].ToString(),
            //                                                 dr["Location"].ToString(),
            //                                                 dr["Qty"].ToString(),
            //                                                 dr["Amount"].ToString()}));

            //}
            //tadd.ShowTrucksQty();
            Redit.Show();
        }
    }
}
