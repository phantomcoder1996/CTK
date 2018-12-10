namespace CTK.Tools
{
    partial class BarCodeReaderForm
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
            this.barcodeTextBox1 = new DDCL.Forms.BarcodeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_StudentName = new System.Windows.Forms.Label();
            this.LBL_CourseName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // barcodeTextBox1
            // 
            this.barcodeTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.barcodeTextBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.barcodeTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.barcodeTextBox1.LastBarCode = null;
            this.barcodeTextBox1.Location = new System.Drawing.Point(239, 28);
            this.barcodeTextBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.barcodeTextBox1.Name = "barcodeTextBox1";
            this.barcodeTextBox1.Size = new System.Drawing.Size(164, 45);
            this.barcodeTextBox1.TabIndex = 0;
            this.barcodeTextBox1.OnNewBarcodeRecived += new DDCL.Forms.OnNewBarCode(this.barcodeTextBox1_OnNewBarcodeRecived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "اسم الطالب";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "اسم المادة";
            // 
            // LBL_StudentName
            // 
            this.LBL_StudentName.AutoSize = true;
            this.LBL_StudentName.ForeColor = System.Drawing.Color.Blue;
            this.LBL_StudentName.Location = new System.Drawing.Point(413, 166);
            this.LBL_StudentName.Name = "LBL_StudentName";
            this.LBL_StudentName.Size = new System.Drawing.Size(0, 24);
            this.LBL_StudentName.TabIndex = 3;
            // 
            // LBL_CourseName
            // 
            this.LBL_CourseName.AutoSize = true;
            this.LBL_CourseName.ForeColor = System.Drawing.Color.Blue;
            this.LBL_CourseName.Location = new System.Drawing.Point(413, 231);
            this.LBL_CourseName.Name = "LBL_CourseName";
            this.LBL_CourseName.Size = new System.Drawing.Size(0, 24);
            this.LBL_CourseName.TabIndex = 4;
            // 
            // BarCodeReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 566);
            this.Controls.Add(this.LBL_CourseName);
            this.Controls.Add(this.LBL_StudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barcodeTextBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarCodeReaderForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الكشف عن الباركود";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DDCL.Forms.BarcodeTextBox barcodeTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBL_StudentName;
        private System.Windows.Forms.Label LBL_CourseName;
    }
}