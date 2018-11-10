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
    public partial class Activation : Form
    {
        public Activation()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.StartsWith(Convert.ToChar(int.Parse(DateTime.Now.Month.ToString()) - 1 + 'A').ToString()) && textBox3.Text.EndsWith(DateTime.Now.Day.ToString()))
            {
                Properties.Settings.Default.active = true;
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            else
                MessageBox.Show("Wrong Code!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            //MessageBox.Show((Convert.ToChar(int.Parse(DateTime.Now.Month.ToString())-1+'A').ToString()) + (DateTime.Now.Day.ToString()));
        }

        private void Activation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
