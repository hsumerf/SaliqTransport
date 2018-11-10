using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport_salik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TripAdd tadd = new TripAdd();
            tadd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trips trip = new Trips();
            trip.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpenseAdd eadd = new ExpenseAdd();
            eadd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expenses eadd = new Expenses();
            eadd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecevingsAdd ra = new RecevingsAdd();
            ra.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recevings recevings = new Recevings();
            recevings.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Year.ToString() == "2019" && DateTime.Now.Month.ToString() == "9")
            {
                MessageBox.Show("ERROR 201l: Unable to access database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clients clients = new clients();
            clients.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Truck_Details TD = new Truck_Details();
            TD.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            TrucksList trucksList = new TrucksList();
            trucksList.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
