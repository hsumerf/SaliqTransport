namespace Transport_salik
{
    partial class TripAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripAdd));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.invoiceno = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comments = new System.Windows.Forms.TextBox();
            this.customername = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.amounttruck = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.qtybox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.truckno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.TextBox();
            this.Qty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.typebox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.other = new System.Windows.Forms.TextBox();
            this.total_items = new System.Windows.Forms.Label();
            this.truckdetails = new Transport_salik.editableListview();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(730, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // invoiceno
            // 
            this.invoiceno.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceno.Location = new System.Drawing.Point(18, 26);
            this.invoiceno.Name = "invoiceno";
            this.invoiceno.Size = new System.Drawing.Size(188, 25);
            this.invoiceno.TabIndex = 30;
            this.invoiceno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Note";
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(67, 322);
            this.comments.Multiline = true;
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(137, 31);
            this.comments.TabIndex = 6;
            // 
            // customername
            // 
            this.customername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customername.FormattingEnabled = true;
            this.customername.Location = new System.Drawing.Point(66, 68);
            this.customername.Name = "customername";
            this.customername.Size = new System.Drawing.Size(140, 21);
            this.customername.Sorted = true;
            this.customername.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.amounttruck);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.qtybox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.truckno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.location);
            this.groupBox1.Controls.Add(this.weight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(229, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Item";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(442, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Amount";
            // 
            // amounttruck
            // 
            this.amounttruck.AcceptsReturn = true;
            this.amounttruck.Location = new System.Drawing.Point(440, 46);
            this.amounttruck.Name = "amounttruck";
            this.amounttruck.Size = new System.Drawing.Size(97, 20);
            this.amounttruck.TabIndex = 11;
            this.amounttruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amounttruck_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Qty";
            // 
            // qtybox
            // 
            this.qtybox.Location = new System.Drawing.Point(351, 46);
            this.qtybox.Name = "qtybox";
            this.qtybox.Size = new System.Drawing.Size(83, 20);
            this.qtybox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(541, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // truckno
            // 
            this.truckno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.truckno.Location = new System.Drawing.Point(18, 46);
            this.truckno.Name = "truckno";
            this.truckno.Size = new System.Drawing.Size(116, 20);
            this.truckno.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Empty Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Weight";
            // 
            // location
            // 
            this.location.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.location.Location = new System.Drawing.Point(228, 46);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(116, 20);
            this.location.TabIndex = 9;
            // 
            // weight
            // 
            this.weight.Location = new System.Drawing.Point(142, 46);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(78, 20);
            this.weight.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Truck / Lifter / Labour";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(229, 358);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Date";
            // 
            // from
            // 
            this.from.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.from.Location = new System.Drawing.Point(67, 131);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(139, 20);
            this.from.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "From ";
            // 
            // to
            // 
            this.to.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.to.Location = new System.Drawing.Point(67, 162);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(139, 20);
            this.to.TabIndex = 3;
            // 
            // Qty
            // 
            this.Qty.Location = new System.Drawing.Point(66, 224);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(140, 20);
            this.Qty.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Unit Price";
            // 
            // typebox
            // 
            this.typebox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typebox.FormattingEnabled = true;
            this.typebox.Items.AddRange(new object[] {
            "20",
            "40",
            "Bulk"});
            this.typebox.Location = new System.Drawing.Point(67, 286);
            this.typebox.Name = "typebox";
            this.typebox.Size = new System.Drawing.Size(139, 21);
            this.typebox.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "To";
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(66, 193);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(140, 20);
            this.amount.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Qty";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 364);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.Text = "Show ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Other ";
            // 
            // other
            // 
            this.other.Location = new System.Drawing.Point(66, 255);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(140, 20);
            this.other.TabIndex = 49;
            // 
            // total_items
            // 
            this.total_items.AutoSize = true;
            this.total_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_items.Location = new System.Drawing.Point(537, 361);
            this.total_items.Name = "total_items";
            this.total_items.Size = new System.Drawing.Size(57, 16);
            this.total_items.TabIndex = 51;
            this.total_items.Text = "0 Items";
            // 
            // truckdetails
            // 
            this.truckdetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader1});
            this.truckdetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truckdetails.FullRowSelect = true;
            this.truckdetails.GridLines = true;
            this.truckdetails.Location = new System.Drawing.Point(229, 124);
            this.truckdetails.Name = "truckdetails";
            this.truckdetails.Size = new System.Drawing.Size(576, 220);
            this.truckdetails.TabIndex = 13;
            this.truckdetails.UseCompatibleStateImageBehavior = false;
            this.truckdetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Truck / Lifter";
            this.columnHeader4.Width = 156;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Weight";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Empty";
            this.columnHeader6.Width = 144;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Qty";
            this.columnHeader7.Width = 67;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Amount";
            this.columnHeader1.Width = 94;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(649, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 52;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // TripAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 393);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.total_items);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.other);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.typebox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.truckdetails);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.invoiceno);
            this.Controls.Add(this.comments);
            this.Controls.Add(this.customername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TripAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TripAdd";
            this.Load += new System.EventHandler(this.TripAdd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TripAdd_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label invoiceno;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox comments;
        public System.Windows.Forms.ComboBox customername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox truckno;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox from;
        public System.Windows.Forms.TextBox to;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        public editableListview truckdetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox qtybox;
        public System.Windows.Forms.TextBox Qty;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox typebox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox amounttruck;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox other;
        private System.Windows.Forms.Label total_items;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}