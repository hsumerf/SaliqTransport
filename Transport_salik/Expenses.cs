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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            int total=0;
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            if (textBox1.Text == "")
                sq = new SQLiteCommand("select * from Expenses where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", scn);
            else
            sq = new SQLiteCommand("select * from Expenses where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND recver='" + textBox1.Text + "'", scn);

            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {

                listView1.Items.Add(new ListViewItem(new[] { dr["payID"].ToString(),
                                                             dr["recver"].ToString(),
                                                             dr["date"].ToString(),
                                                             dr["tripno"].ToString(),
                                                             dr["decs"].ToString(),
                                                             dr["amount"].ToString()}));

                total += Convert.ToInt32(dr["amount"].ToString());
            }
            totaltext.Text = total.ToString();

        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // listView1.LabelEdit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
                scn.Open();
                SQLiteCommand sq;
                sq = new SQLiteCommand("delete from Expenses where PayID = '" + listView1.SelectedItems[0].Text + "'", scn);
                sq.ExecuteNonQuery();
                filter.PerformClick();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sqlite.ColumnSorter(e.Column, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(listView1);
        }

        private void listView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            ExpenseEdit Eedit = new ExpenseEdit();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select * from Expenses where payID = '" + listView1.SelectedItems[0].Text + "'", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            //tadd.truckdetails.Items.Clear();

            while (dr.Read())
            {
                //tadd.isNew = false;
                //tadd.invoiceno.Text = listView1.SelectedItems[0].Text;
                //tadd.customername.Items.AddRange(Sqlite.LoadClients());
                // Redit.payerBox1.Text = dr["Payer"].ToString();
                Eedit.recid = Convert.ToInt32(dr["payID"]);
                Eedit.recver.Text = dr["recver"].ToString();
                Eedit.dateTimePicker1.Text = dr["date"].ToString();
                Eedit.amount.Text = dr["Amount"].ToString();

                Eedit.tripnotextbox.Text = dr["tripno"].ToString();
                Eedit.descttxt.Text = dr["Decs"].ToString();
               
            }

            Eedit.Show();
        }
    
    }
}
