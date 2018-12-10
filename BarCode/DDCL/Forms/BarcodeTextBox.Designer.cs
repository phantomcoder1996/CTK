namespace DDCL.Forms
{
    partial class BarcodeTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TB_Barcode = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Barcode
            // 
            this.TB_Barcode.BackColor = System.Drawing.Color.Green;
            this.TB_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Barcode.Font = new System.Drawing.Font("Tahoma", 1F, System.Drawing.FontStyle.Bold);
            this.TB_Barcode.Location = new System.Drawing.Point(3, 61);
            this.TB_Barcode.Name = "TB_Barcode";
            this.TB_Barcode.Size = new System.Drawing.Size(17, 2);
            this.TB_Barcode.TabIndex = 0;
            this.TB_Barcode.TextChanged += new System.EventHandler(this.TB_Barcode_TextChanged);
            this.TB_Barcode.Enter += new System.EventHandler(this.TB_Barcode_Enter);
            this.TB_Barcode.Leave += new System.EventHandler(this.TB_Barcode_Leave);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.87302F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.12698F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BTN_Start, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(99, 31);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.TB_Barcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(9, 25);
            this.panel1.TabIndex = 3;
            this.panel1.Leave += new System.EventHandler(this.panel1_Leave);
            // 
            // BTN_Start
            // 
            this.BTN_Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Start.Image = global::DDCL.Properties.Resources.Stop;
            this.BTN_Start.Location = new System.Drawing.Point(18, 3);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(78, 25);
            this.BTN_Start.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BTN_Start, "Click to start/stop barcode reader");
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.button1_Click);
            this.BTN_Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BTN_Start_KeyPress);
            // 
            // BarcodeTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarcodeTextBox";
            this.Size = new System.Drawing.Size(99, 31);
            this.Load += new System.EventHandler(this.BarcodeTextBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Barcode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
