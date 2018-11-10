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
    public partial class ExpenseEdit : Form
    {
        public int recid;
        public ExpenseEdit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (recver.Text == "")
            {
                MessageBox.Show("Client name can not be empty");
                return;

            }

            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;
            //sq = new SQLiteCommand("select amount from Recevings where RecID= '" + recid + "'", scn);
            //int ammount = int.Parse(sq.ExecuteScalar().ToString());

            sq = new SQLiteCommand("delete from Expenses where payID = '" + recid + "'", scn);
            sq.ExecuteNonQuery();


            //if (recid != 0)
            //{
            sq = new SQLiteCommand(String.Format("insert into Expenses (payID,recver,decs,amount,date,tripno) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
              recid,
              recver.Text,
              descttxt.Text,
              amount.Text,
              dateTimePicker1.Text,
              tripnotextbox.Text), scn);

            //else
            //{
            //    sq = new SQLiteCommand(String.Format("insert into Recevings (Payer,Dec,Amount,Date) values ('{0}','{1}','{2}','{3}')",
            //    payer.Text,
            //    descttxt.Text,
            //    amount.Text,
            //    dateTimePicker1.Text), scn);
            //}
            sq.ExecuteNonQuery();
            MessageBox.Show("Data Saved successfully");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
