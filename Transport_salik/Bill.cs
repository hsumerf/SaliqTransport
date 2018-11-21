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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select * from Trips where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND Name='" + clientname.Text + "' AND Status='Unpaid' ORDER BY Date", scn);
            SQLiteDataReader dr = sq.ExecuteReader();
            int ttl=0;
            while (dr.Read())
            {

                ttl += int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString()) + int.Parse(dr["Other"].ToString());
                listView1.Items.Add(new ListViewItem(new[]
                { dr["TripNo"].ToString(),
                  dr["Date"].ToString(),              
                  dr["Froom"] +" - " + dr["Tao"],
                   dr["Type"].ToString(),
                  dr["Qty"].ToString(),
                  dr["Amount"].ToString(),
                  dr["Other"].ToString(),
                  (int.Parse(dr["Amount"].ToString())*int.Parse(dr["Qty"].ToString())+int.Parse(dr["Other"].ToString())).ToString()}));
            }
            // Previous Balance
            int previosReceive = 0;
            sq = new SQLiteCommand("select * from Recevings where Date < '" + dateTimePicker1.Text + "' AND Payer='" + clientname.Text + "' ORDER BY Date", scn);
            dr = sq.ExecuteReader();
            while (dr.Read())
            {

                previosReceive += int.Parse(dr["Amount"].ToString());

            }
            int previosBalance = 0;
            sq = new SQLiteCommand("select * from Trips where Date < '" + dateTimePicker1.Text + "' AND Name='" + clientname.Text + "' ORDER BY Date", scn);
            dr = sq.ExecuteReader();
            while (dr.Read())
            {

                previosBalance += int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString()) + int.Parse(dr["Other"].ToString());


            }
            int previousNet = previosBalance - previosReceive;
            
            Previous.Text = previousNet.ToString();
            //Previous End
            total.Text = ttl.ToString();
            int receivedAmount = 0;
            sq = new SQLiteCommand("select * from Recevings where Date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' AND Payer='" + clientname.Text + "' ORDER BY Date", scn);
            dr = sq.ExecuteReader();
            while (dr.Read())
            {
                receivedAmount += int.Parse(dr["Amount"].ToString());
            }
            // balance.Text = Sqlite.ClientBalance(clientname.Text).ToString();
            balance.Text = receivedAmount.ToString();
            net.Text = ((ttl - receivedAmount) + previousNet).ToString();
            // CODE FOR TOTAL
            int wholeTotal = 0;
            sq = new SQLiteCommand("select * from Trips where Name='" + clientname.Text + "' ORDER BY Date", scn);
            dr = sq.ExecuteReader();
            while (dr.Read())
            {
                wholeTotal += int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString()) + int.Parse(dr["Other"].ToString());
            }
            WholeTotal.Text = wholeTotal.ToString();
            int wholeReceive = 0;
            sq = new SQLiteCommand("select * from Recevings where Payer='" + clientname.Text + "' ORDER BY Date", scn);
            dr = sq.ExecuteReader();
            while (dr.Read())
            {
                wholeReceive += int.Parse(dr["Amount"].ToString());

            }
            WholeReceive.Text = wholeReceive.ToString();
            WholeNet.Text = (wholeTotal - wholeReceive).ToString();
            //sq = new SQLiteCommand("select * from Trips where Name='" + clientname.Text + "' AND Status='Unpaid' ORDER BY Date", scn);
            //dr = sq.ExecuteReader();
            //int TotalAmount=0;
            //while (dr.Read())
            //{

            //    TotalAmount += int.Parse(dr["Amount"].ToString()) * int.Parse(dr["Qty"].ToString()) + int.Parse(dr["Other"].ToString());
            //    //Console.WriteLine(TotalAmount);

            //}
            //TotalBalance.Text = TotalAmount.ToString();
            //sq = new SQLiteCommand("select * from Recevings where Payer='" + clientname.Text + "' ORDER BY Date", scn);
            //dr = sq.ExecuteReader();
            //int totalRec = 0;
            //while (dr.Read())
            //{

            //    totalRec += int.Parse(dr["Amount"].ToString());
            //    //Console.WriteLine(totalRec);

            //}
            //TotalRec.Text = totalRec.ToString();
            //TotalNet.Text = (TotalAmount - totalRec).ToString();

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            clientname.Items.AddRange(Sqlite.LoadClients());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            itemperpage = totalitem = 0;
            currentpage = 1;
            printPreviewDialog1.Document = printDocument1;
            //    printDocument1.DefaultPageSettings.PaperSize = pages;
            printPreviewDialog1.ShowDialog();
        }
        int itemperpage = 0;
        int[] weight = new int[] { 30, 0, -20, 50, 25, 0, -10,20 };
        int totalitem = 0;
        int currentpage = 1;

        Rectangle RectangleOffset(int x,int y,Rectangle r)
        {
            return new Rectangle(r.X+x, r.Y + y, r.Width, r.Height);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int heingh = 170;
            StringFormat sf = new StringFormat();
        //    sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Font fbold = new Font("Arial", 8.75f, FontStyle.Bold);
            Font body = new Font("Arial", 8.75f, FontStyle.Regular);

            e.Graphics.DrawImage(Properties.Resources._88, 308, 15, 45,45);
            e.Graphics.DrawString("         Transport Company", new Font("Arial", 14, FontStyle.Bold), Brushes.Black,RectangleOffset(0,30,e.PageBounds),sf);
            e.Graphics.DrawString("Kishan Nivas Building, Room No 1, Punjabi Club, Kharadar, Karachi.", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, RectangleOffset(0,61, e.PageBounds), sf);
            e.Graphics.DrawString("Muhammad Saliq : 0342-2990100", new Font("Arial", 8, FontStyle.Regular), Brushes.Black,RectangleOffset(0,77, e.PageBounds), sf);


            e.Graphics.DrawString(DateTime.Now.ToLongDateString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 30, 45);
            e.Graphics.DrawString(DateTime.Now.ToLongTimeString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 30, 62);
            e.Graphics.DrawString("Page: " + currentpage.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 750, 45);

            e.Graphics.DrawString(clientname.Text, new Font("Arial", 9.5f, FontStyle.Bold), Brushes.Black, 30, 105);
            e.Graphics.DrawString(dateTimePicker1.Text + " - " + dateTimePicker2.Text , body, Brushes.Black, RectangleOffset(0,105, e.PageBounds), sf);
            //    e.Graphics.DrawString("Previous Balance:  " + prevBal.Text.ToString(), body, Brushes.Black, 635, 105);
            e.Graphics.DrawLine(Pens.Black, 30, 125, 795, 125);

            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                e.Graphics.DrawString(listView1.Columns[i].Text, fbold, Brushes.Black, weight[i] + (i * 100), 145);
                //     e.Graphics.DrawLine(Pens.Black, 40 + (i * 100), 35, 40 + (i * 100), 1000);
            }
            while (totalitem < listView1.Items.Count)
            {

                for (int j = 0; j < listView1.Columns.Count; j++)
                {
                    e.Graphics.DrawString(listView1.Items[totalitem].SubItems[j].Text, body, Brushes.Black, weight[j] + (j * 100), heingh);

                }
                totalitem++;
                heingh += 18;

                if (itemperpage <= 45) // check whether  the number of item(per page) is more than 20 or not
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
            e.Graphics.DrawString("Previous Balance ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 10);
            e.Graphics.DrawString(Previous.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 10);
            e.Graphics.DrawString("Total ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 26);
            e.Graphics.DrawString(total.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 26);
            e.Graphics.DrawString("Receive ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 45);
            e.Graphics.DrawString(balance.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 45);
            e.Graphics.DrawString("Net ", new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 600, heingh + 64);
            e.Graphics.DrawString(net.Text, new Font("Arial", 9f, FontStyle.Bold), Brushes.Black, 720, heingh + 64);
            Pen pen = new Pen(Color.Black, 1);
        //    pen.Alignment = PenAlignment.Inset; //<-- this
         //   e.Graphics.DrawRectangle(pen, 695, heingh + 2, 95, 20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            itemperpage = totalitem = 0;
            currentpage = 1;
            printDocument1.Print();
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlite.ExportToExcel(listView1);
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

            sq = new SQLiteCommand("select * from TripDetails where Tripno = '" + listView1.SelectedItems[0].Text + "'", scn);

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TotalBalance_Click(object sender, EventArgs e)
        {

        }

        private void TotalRec_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void balance_Click(object sender, EventArgs e)
        {

        }

        private void clientname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Previous_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void net_Click(object sender, EventArgs e)
        {

        }
    }
}
