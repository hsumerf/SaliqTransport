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
    public partial class ExpenseAdd : Form
    {
        public int payid;
        public ExpenseAdd()
        {
            InitializeComponent();
        }

        private void ExpenseAdd_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (recver.Text == "")
            {
                MessageBox.Show("Recever filed can not be empty");
                return;

            }

            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("delete from Expenses where payID = '" + payid.ToString() + "'", scn);
            sq.ExecuteNonQuery();

            if (payid != 0)
            {
                sq = new SQLiteCommand(String.Format("insert into Expenses (payID,recver,decs,amount,date,tripno) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                  payid,
                  recver.Text,
                  descttxt.Text,
                  amount.Text,
                  dateTimePicker1.Text,
                  tripnotextbox.Text), scn);
            }
            else
            {
                sq = new SQLiteCommand(String.Format("insert into Expenses (recver,decs,amount,date,tripno) values ('{0}','{1}','{2}','{3}','{4}')",
                recver.Text,
                descttxt.Text,
                amount.Text,
                dateTimePicker1.Text,
                tripnotextbox.Text), scn);
            }
            sq.ExecuteNonQuery();

            MessageBox.Show("Data Saved successfully");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
