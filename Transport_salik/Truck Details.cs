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
    public partial class Truck_Details : Form
    {
        public Truck_Details()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            truckdetails.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("SELECT Trips.TripNo,Trips.Date,Trips.Froom,Trips.Tao,TripDetails.Truckno,TripDetails.Weight,TripDetails.Location,TripDetails.Qty,TripDetails.Amount " +
                                   "FROM TripDetails INNER JOIN Trips ON TripDetails.Tripno = Trips.TripNo " +
                                   "WHERE Trips.Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND TripDetails.Truckno='" + textBox1.Text + "' ORDER BY Trips.Date", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            int ttl = 0;
            int total_Trips = 0;
            while (dr.Read())
            {
                total_Trips++;
                ttl += int.Parse(dr["Amount"].ToString());
                truckdetails.Items.Add(new ListViewItem(new[]
                { dr["TripNo"].ToString(),
                  dr["Date"].ToString(),
                  dr["Froom"].ToString() +" - "+dr["Tao"].ToString(),
                  dr["Weight"].ToString(),
                  dr["Location"].ToString(),
                  dr["Qty"].ToString(),
                  dr["Amount"].ToString() }));
            }
            total.Text = ttl.ToString();
            //  balance.Text = Sqlite.TruckBalance(textBox1.Text).ToString();
            //  net.Text = ttl + int.Parse(balance.Text) + "";
            net.Text = Sqlite.TruckBalance(textBox1.Text).ToString();
            Total_Trips.Text = total_Trips.ToString();

        }

        private void Truck_Details_Load(object sender, EventArgs e)
        {
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select DISTINCT Truckno from TripDetails", scn);
            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {

                textBox1.Items.Add(dr["Truckno"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpenseAdd expenseAdd = new ExpenseAdd();
            expenseAdd.recver.Text = textBox1.Text;
            expenseAdd.amount.Text = net.Text;
            expenseAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            itemperpage = totalitem = 0;
            currentpage = 1;
            printDocument1.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemperpage = totalitem = 0;
            currentpage = 1;
            printPreviewDialog1.Document = printDocument1;
            //    printDocument1.DefaultPageSettings.PaperSize = pages;
            printPreviewDialog1.ShowDialog();
        }

        Rectangle RectangleOffset(int x, int y, Rectangle r)
        {
            return new Rectangle(r.X + x, r.Y + y, r.Width, r.Height);
        }

        int itemperpage = 0;
        int[] weight = new int[] { 30, 10, 10, 80, 100, 100, 120 };
        int totalitem = 0;
        int currentpage = 1;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int heingh = 170;
            StringFormat sf = new StringFormat();
            //    sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font fbold = new Font("Arial", 8.75f, FontStyle.Bold);
            Font body = new Font("Arial", 8.75f, FontStyle.Regular);

            e.Graphics.DrawImage(Properties.Resources._88, 308, 15, 45, 45);
            e.Graphics.DrawString("         Transport Company", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, RectangleOffset(0, 30, e.PageBounds), sf);
            e.Graphics.DrawString("Kishan Nivas Building, Room No 1, Punjabi Club, Kharadar, Karachi.", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, RectangleOffset(0, 61, e.PageBounds), sf);
            e.Graphics.DrawString("Muhammad Saliq : 0342-2990100", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, RectangleOffset(0, 77, e.PageBounds), sf);

            e.Graphics.DrawString(DateTime.Now.ToLongDateString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 30, 45);
            e.Graphics.DrawString(DateTime.Now.ToLongTimeString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 30, 62);
            e.Graphics.DrawString("Page: " + currentpage.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 750, 45);

            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 9.5f, FontStyle.Bold), Brushes.Black, 30, 105);
            e.Graphics.DrawString(dateTimePicker1.Text + " - " + dateTimePicker2.Text, body, Brushes.Black, RectangleOffset(0, 105, e.PageBounds), sf);
            //    e.Graphics.DrawString("Previous Balance:  " + prevBal.Text.ToString(), body, Brushes.Black, 635, 105);
            e.Graphics.DrawLine(Pens.Black, 30, 125, 795, 125);

            for (int i = 0; i < truckdetails.Columns.Count; i++)
            {
                e.Graphics.DrawString(truckdetails.Columns[i].Text, fbold, Brushes.Black, weight[i] + (i * 100), 145);
                //     e.Graphics.DrawLine(Pens.Black, 40 + (i * 100), 35, 40 + (i * 100), 1000);
            }
            while (totalitem < truckdetails.Items.Count)
            {

                for (int j = 0; j < truckdetails.Columns.Count; j++)
                {
                    e.Graphics.DrawString(truckdetails.Items[totalitem].SubItems[j].Text, body, Brushes.Black, weight[j] + (j * 100), heingh);

                }
                totalitem++;
                heingh += 18;

                if (itemperpage <= 48) // check whether  the number of item(per page) is more than 20 or not
                {
                    itemperpage += 1; // increment itemperpage by 1
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added

                }
                else // if the number of item(per page) is more than 20 then add one page
                {
                    itemperpage = 0; //initiate itemperpage to 0 .
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    currentpage++;
                    return;//It will call PrintPage event again
                }
            }
            sf.Alignment = StringAlignment.Far;
            e.Graphics.DrawString("Total ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 6);
            e.Graphics.DrawString(total.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 6);
            //e.Graphics.DrawString("Net ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 25);
            //e.Graphics.DrawString(net.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 25);
            Pen pen = new Pen(Color.Black, 1);
            //    pen.Alignment = PenAlignment.Inset; //<-- this
            //   e.Graphics.DrawRectangle(pen, 695, heingh + 2, 95, 20);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(truckdetails);
        }

        private void Truck_Details_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void truckdetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TripAdd tadd = new TripAdd();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select * from Trips where Tripno = '" + truckdetails.SelectedItems[0].Text + "'", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            tadd.truckdetails.Items.Clear();
            while (dr.Read())
            {
                tadd.isNew = false;
                tadd.invoiceno.Text = truckdetails.SelectedItems[0].Text;
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

            sq = new SQLiteCommand("select * from TripDetails where Tripno = '" + truckdetails.SelectedItems[0].Text + "'", scn);

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
    }
}
