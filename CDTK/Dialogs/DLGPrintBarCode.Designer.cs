namespace CTK.Dialogs
{
    partial class DLGPrintBarCode
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
            this.BTN_Print = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBL_CourseName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_CourseCode = new System.Windows.Forms.Label();
            this.BTN_PrintPreview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Print
            // 
            this.BTN_Print.Location = new System.Drawing.Point(897, 223);
            this.BTN_Print.Name = "BTN_Print";
            this.BTN_Print.Size = new System.Drawing.Size(142, 97);
            this.BTN_Print.TabIndex = 0;
            this.BTN_Print.Text = "طباعة";
            this.BTN_Print.UseVisualStyleBackColor = true;
            this.BTN_Print.Click += new System.EventHandler(this.BTN_Print_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(405, 260);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(356, 30);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(212, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "تاريخ الامتحان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(212, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "اسم المادة";
            // 
            // LBL_CourseName
            // 
            this.LBL_CourseName.AutoSize = true;
            this.LBL_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CourseName.ForeColor = System.Drawing.Color.Blue;
            this.LBL_CourseName.Location = new System.Drawing.Point(400, 146);
            this.LBL_CourseName.Name = "LBL_CourseName";
            this.LBL_CourseName.Size = new System.Drawing.Size(0, 25);
            this.LBL_CourseName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(212, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "كود المادة";
            // 
            // LBL_CourseCode
            // 
            this.LBL_CourseCode.AutoSize = true;
            this.LBL_CourseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CourseCode.ForeColor = System.Drawing.Color.Blue;
            this.LBL_CourseCode.Location = new System.Drawing.Point(400, 194);
            this.LBL_CourseCode.Name = "LBL_CourseCode";
            this.LBL_CourseCode.Size = new System.Drawing.Size(74, 25);
            this.LBL_CourseCode.TabIndex = 7;
            this.LBL_CourseCode.Text = "كود المادة";
            // 
            // BTN_PrintPreview
            // 
            this.BTN_PrintPreview.Location = new System.Drawing.Point(897, 58);
            this.BTN_PrintPreview.Name = "BTN_PrintPreview";
            this.BTN_PrintPreview.Size = new System.Drawing.Size(142, 77);
            this.BTN_PrintPreview.TabIndex = 8;
            this.BTN_PrintPreview.Text = "عرض طباعة";
            this.BTN_PrintPreview.UseVisualStyleBackColor = true;
            this.BTN_PrintPreview.Click += new System.EventHandler(this.BTN_PrintPreview_Click);
            // 
            // DLGPrintBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 526);
            this.Controls.Add(this.BTN_PrintPreview);
            this.Controls.Add(this.LBL_CourseCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_CourseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BTN_Print);
            this.Name = "DLGPrintBarCode";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "طباعة الباركود";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Print;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBL_CourseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_CourseCode;
        private System.Windows.Forms.Button BTN_PrintPreview;
    }
}