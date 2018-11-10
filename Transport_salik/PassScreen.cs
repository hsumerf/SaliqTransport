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
    public partial class PassScreen : Form
    {
        public PassScreen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == Properties.Settings.Default.password)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password is wrong!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PassScreen_Load(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.active ==false)
            {
                Activation form = new Activation();
                this.Hide();
                form.ShowDialog();
            }
        }
    }
}
