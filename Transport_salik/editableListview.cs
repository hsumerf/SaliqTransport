using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport_salik
{
    public class editableListview : ListView
    {
        [Description("Occurs when cell is updated"), Category("Event")]
        public event EventHandler DataUpdated;
        protected virtual void onDataUpdated(EventArgs e)
        {
         //   EventHandler handler = DataUpdated;
            if (DataUpdated != null)
            {
                DataUpdated(this, e);
            }
        }

        TextBox tb = new TextBox();
        int row;
        int col;
        ListViewHitTestInfo info;
        string value;
        public editableListview()
        {
            View = View.Details;
            FullRowSelect = true;
            GridLines = true;
            tb.Location = new System.Drawing.Point(0, 0);
            tb.Visible = false;
            this.Controls.Add(tb);
            tb.Leave += new EventHandler(textboxleave);
            tb.KeyDown += new KeyEventHandler(textboxkeypressed);
            this.MouseWheel += new MouseEventHandler(scroll);
        }

        


        private void scroll(object sender, MouseEventArgs e)
        {

            tb.Visible = false;
            Focus();
        }

        protected virtual void OnScroll(ScrollEventArgs e)
        {

            tb.Visible = false;
            Focus();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x115 || m.Msg == 0x0114)
            {
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), 0));
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
           
            info = HitTest(e.X, e.Y);
            row = info.Item.Index;
            col = info.Item.SubItems.IndexOf(info.SubItem);
            value = info.Item.SubItems[col].Text;

            tb.Location = new Point(info.Item.SubItems[col].Bounds.Location.X , info.Item.SubItems[col].Bounds.Location.Y );
            tb.Width = this.Columns[col].Width;
            tb.Visible = true;
            tb.Text = value;
            tb.Focus();
            base.OnMouseDoubleClick(e);       

        }

        private void textboxkeypressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Items[row].SubItems[col].Text = tb.Text;
                tb.Visible = false;
                this.Focus();
                onDataUpdated(EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tb.Visible = false;
            }
        }

        private void textboxleave(object sender, EventArgs e)
        {
            tb.Visible = false;
        }
    }
}
