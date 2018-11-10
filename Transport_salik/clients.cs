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
    public partial class clients : Form
    {
        public clients()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

             sq = new SQLiteCommand(String.Format("insert into Clients (Name) values ('{0}')",
                  clientname.Text),scn);
          
            sq.ExecuteNonQuery();
            refreshlist();

        }

        private void refreshlist()
        {
            listView1.Items.Clear();
            SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
            scn.Open();
            SQLiteCommand sq;

            sq = new SQLiteCommand("select Name from Clients", scn);
            SQLiteDataReader dr = sq.ExecuteReader();

            while (dr.Read())
            {

                listView1.Items.Add(new ListViewItem(new[] { dr["Name"].ToString()}));
            }       
        }

        private void clients_Load(object sender, EventArgs e)
        {
            refreshlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this client?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLiteConnection scn = new SQLiteConnection(@"data source = main.db");
                scn.Open();
                SQLiteCommand sq;
                sq = new SQLiteCommand("delete from Clients where Name = '" + listView1.SelectedItems[0].Text + "'", scn);
                sq.ExecuteNonQuery();
                refreshlist();
            }
        }
    }
}
