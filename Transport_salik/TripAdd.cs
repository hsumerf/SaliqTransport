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
    public partial class TripAdd : Form
    {
        public bool isNew = true;
        public string status = "Unpaid";
        public TripAdd()
        {
            InitializeComponent();
        }

        public void ShowTrucksQty()
        {
            total_items.Text = truckdetails.Items.Count + " items";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (truckno.Text == "")
                return;

            ListViewItem itm = new ListViewItem();
            itm.Text =truckno.Text;
            itm.SubItems.Add(weight.Text);
            itm.SubItems.Add(location.Text);
            itm.SubItems.Add(qtybox.Text);
            itm.SubItems.Add(amounttruck.Text);
            truckdetails.Items.Add(itm);
           

            truckno.Text = "";
            weight.Text = "";
            location.Text = "";
            qtybox.Text = "";
            amounttruck.Text = "";

            truckno.Focus();
            ShowTrucksQty();
        }

        //public void

        private void TripAdd_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.showcontent;
            if (checkBox1.Checked)
            {
                amount.PasswordChar = '\0';
                other.PasswordChar = '\0';
            }
            else
            {
                amount.PasswordChar = '*';
                other.PasswordChar = '*';
            }

            if (!isNew)
               return;

            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            customername.Items.AddRange(Sqlite.LoadClients());
            scn.Open();
            SQLiteCommand sq;
            sq = new SQLiteCommand("select seq from sqlite_sequence where name='Trips'", scn);
            int lastid = Convert.ToInt32(sq.ExecuteScalar());
            invoiceno.Text = (lastid + 1).ToString();
            scn.Close();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            truckdetails.Items.Remove(truckdetails.SelectedItems[0]);
            ShowTrucksQty();
        }
        string trucks="";
        private void button2_Click(object sender, EventArgs e)
        {
            if (customername.Text == "")
            {
                MessageBox.Show("Client name can not be empty");
                return;
                   
            }

            for (int i = 0; i < truckdetails.Items.Count; i++)
            {
                trucks += truckdetails.Items[i].Text + " ";
            }
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();

            SQLiteCommand sq;

            sq = new SQLiteCommand("delete from Trips where TripNo = '" + invoiceno.Text + "'", scn);
            sq.ExecuteNonQuery();
            sq = new SQLiteCommand("delete from TripDetails where Tripno = '" + invoiceno.Text + "'", scn);
            sq.ExecuteNonQuery();



            for (int i = 0; i < truckdetails.Items.Count; i++)
            {
                sq = new SQLiteCommand(String.Format("insert into tripdetails (Tripno,truckno,Weight,Location,Qty,Amount) values ('{0}','{1}','{2}','{3}','{4}','{5}')", invoiceno.Text,
                   truckdetails.Items[i].SubItems[0].Text,
                   truckdetails.Items[i].SubItems[1].Text,
                   truckdetails.Items[i].SubItems[2].Text,
                   truckdetails.Items[i].SubItems[3].Text,
                    truckdetails.Items[i].SubItems[4].Text), scn);
                sq.ExecuteNonQuery();
            }

            sq = new SQLiteCommand(String.Format("insert into trips (TripNo,Date,Name,Froom,Tao,Comments,Trucks,Amount,Type,Status,Qty,Other) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                  invoiceno.Text,
                  dateTimePicker1.Text,
                  customername.Text,
                  from.Text,
                  to.Text,
                  comments.Text,
                  trucks,
                  amount.Text,
                  typebox.Text,
                  status,
                  Qty.Text,
                  other.Text), scn);
            sq.ExecuteNonQuery();

            MessageBox.Show("Data Saved Succsefully");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showcontent = checkBox1.Checked;
            Properties.Settings.Default.Save();
            if (checkBox1.Checked)
            {
                amount.PasswordChar = '\0';
                other.PasswordChar = '\0';
            }
            else
            {
                amount.PasswordChar = '*';
                other.PasswordChar = '*';
            }
        }

        private void TripAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                truckno.Focus();
            }
        }

        private void amounttruck_KeyDown(object sender, KeyEventArgs e)
        {
            if      (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
               
            }
        }
        Rectangle RectangleOffset(int x, int y, Rectangle r)
        {
            return new Rectangle(r.X + x, r.Y + y, r.Width, r.Height);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
     
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int offset = -100;
            StringFormat sf= new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawImage(Properties.Resources._88, 308, 15, 45, 45);
            e.Graphics.DrawString("         Transport Company", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, RectangleOffset(0, 30, e.PageBounds), sf);
            e.Graphics.DrawString("Kishan Nivas Building, Room No 1, Punjabi Club, Kharadar, Karachi.", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, RectangleOffset(0, 61, e.PageBounds), sf);
            e.Graphics.DrawString("Muhammad Saliq : 0342-2990100", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, RectangleOffset(0, 77, e.PageBounds), sf);
            sf.Alignment = StringAlignment.Near;

            e.Graphics.DrawString("Name:", new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(75, 229 + offset, 46, 18), sf);
            e.Graphics.DrawString(customername.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(186, 229 + offset, 200, 18), sf);
            e.Graphics.DrawString("Date:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(496, 229 + offset, 40, 18), sf);
            e.Graphics.DrawString(dateTimePicker1.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(611, 229 + offset, 200, 18), sf);
            e.Graphics.DrawString("From:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(75, 269 + offset, 44, 18), sf);
            e.Graphics.DrawString(from.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(186, 269 + offset, 200, 18), sf);
            e.Graphics.DrawString("To:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(496, 269 + offset, 27, 18), sf);
            e.Graphics.DrawString(to.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(611, 269 + offset, 200, 18), sf);
            e.Graphics.DrawString("Unit Price:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(75, 305 + offset, 82, 18), sf);
            e.Graphics.DrawString(amount.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(186, 305 + offset, 200, 18), sf);
            e.Graphics.DrawString("Quantity:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(496, 305 + offset, 66, 18), sf);
            e.Graphics.DrawString(Qty.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(611, 305 + offset, 200, 18), sf);
            e.Graphics.DrawString("Other:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(75, 345 + offset, 47, 18), sf);
            e.Graphics.DrawString(other.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(186, 345 + offset, 200, 18), sf);
            e.Graphics.DrawString("Type:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(496, 345 + offset, 42, 18), sf);
            e.Graphics.DrawString(typebox.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(611, 345 + offset, 200, 18), sf);
            e.Graphics.DrawString("Truck/ Lifter/ Labour", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(74, 455 + offset, 139, 18), sf);
            e.Graphics.DrawString("Weight", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(278, 455 + offset, 51, 18), sf);
            e.Graphics.DrawString("Empty Location", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(396, 455 + offset, 108, 18), sf);
            e.Graphics.DrawString("Qty", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(566, 455 + offset, 28, 18), sf);
            e.Graphics.DrawString("Amount", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(644, 455 + offset, 57, 18), sf);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), 63, 491+offset, 763, 491+offset);
            e.Graphics.DrawString("Note:", new Font("Arial", 9.6f, FontStyle.Bold), new SolidBrush(Color.Black), new Rectangle(74, 383 + offset, 41, 18), sf);
            e.Graphics.DrawString(comments.Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(186, 383 + offset, 200, 18), sf);
            for (int i = 0; i < truckdetails.Items.Count; i++)
            {
                e.Graphics.DrawString(truckdetails.Items[i].SubItems[0].Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(74, 513 + offset, 250, 18), sf);
                e.Graphics.DrawString(truckdetails.Items[i].SubItems[1].Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(278, 513 + offset, 250, 18), sf);
                e.Graphics.DrawString(truckdetails.Items[i].SubItems[2].Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(396, 513 + offset, 250, 18), sf);
                e.Graphics.DrawString(truckdetails.Items[i].SubItems[3].Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(566, 513 + offset, 250, 18), sf);
                e.Graphics.DrawString(truckdetails.Items[i].SubItems[4].Text, new Font("Arial", 9.6f, FontStyle.Regular), new SolidBrush(Color.Black), new Rectangle(644, 513 + offset, 250, 18), sf);
                offset += 25;
            }

        }
    }
}
