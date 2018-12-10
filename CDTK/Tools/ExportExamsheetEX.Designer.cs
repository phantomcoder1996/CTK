namespace CTK.Tools
{
    partial class ExportExamsheetEX
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UC_Tool = new EOB.UserControls.ToolsTypicals.BulkFileProcessorStandardTool();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_RecallCourseLimits = new System.Windows.Forms.Button();
            this.CHK_ProtectFiles = new System.Windows.Forms.CheckBox();
            this.RB_FullDetails = new System.Windows.Forms.RadioButton();
            this.RB_ExamSheetStandard = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.UC_Tool, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.253732F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.74627F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 670);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UC_Tool
            // 
            this.UC_Tool.Condition1_Checked = false;
            this.UC_Tool.Condition1_Text = "checkBox1";
            this.UC_Tool.Condition1_Visible = false;
            this.UC_Tool.Condition2_Checked = false;
            this.UC_Tool.Condition2_Text = "checkBox2";
            this.UC_Tool.Condition2_Visible = false;
            this.UC_Tool.Condition3_Checked = false;
            this.UC_Tool.Condition3_Text = "checkBox3";
            this.UC_Tool.Condition3_Visible = false;
            this.UC_Tool.Condition4_Checked = false;
            this.UC_Tool.Condition4_Text = "checkBox4";
            this.UC_Tool.Condition4_Visible = false;
            this.UC_Tool.Condition5_Checked = false;
            this.UC_Tool.Condition5_Text = "checkBox5";
            this.UC_Tool.Condition5_Visible = false;
            this.UC_Tool.DataBindings.Add(new System.Windows.Forms.Binding("UC_RootFolder", global::CTK.Properties.Settings.Default, "WorkingFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UC_Tool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Tool.Location = new System.Drawing.Point(2, 64);
            this.UC_Tool.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UC_Tool.Name = "UC_Tool";
            this.UC_Tool.Size = new System.Drawing.Size(863, 604);
            this.UC_Tool.TabIndex = 0;
            this.UC_Tool.UC_Button1Text = "خروج";
            this.UC_Tool.UC_Button2Text = "button2";
            this.UC_Tool.UC_Button3Text = "button3";
            this.UC_Tool.UC_EnableBooleanIndicators = false;
            this.UC_Tool.UC_EnableButton1 = true;
            this.UC_Tool.UC_EnableButton2 = false;
            this.UC_Tool.UC_EnableButton3 = false;
            this.UC_Tool.UC_EnableSidePRogress = false;
            this.UC_Tool.UC_Filter = "*.TXT";
            this.UC_Tool.UC_Indicator1 = false;
            this.UC_Tool.UC_Indicator1_Text = null;
            this.UC_Tool.UC_Indicator2 = false;
            this.UC_Tool.UC_Indicator2_Text = null;
            this.UC_Tool.UC_Indicator3 = false;
            this.UC_Tool.UC_Indicator3_Text = null;
            this.UC_Tool.UC_Indicator4 = false;
            this.UC_Tool.UC_Indicator4_Text = null;
            this.UC_Tool.UC_RootFolder = global::CTK.Properties.Settings.Default.WorkingFolder;
            this.UC_Tool.UC_Button1Click += new System.EventHandler(this.bulkFileProcessorStandardTool1_UC_Button1Click);
            this.UC_Tool.UC_FileCallbackFunction += new EOB.EnumFileEventHandler(this.bulkFileProcessorStandardTool1_UC_FileCallbackFunction);
            this.UC_Tool.UC_Complete += new System.EventHandler(this.bulkFileProcessorStandardTool1_UC_Complete);
            this.UC_Tool.UC_Initialize += new System.EventHandler(this.bulkFileProcessorStandardTool1_UC_Initialize);
            this.UC_Tool.UC_SavePathClicked += new System.EventHandler(this.bulkFileProcessorStandardTool1_UC_SavePathClicked);
            this.UC_Tool.UC_TopFolderChanged += new System.EventHandler(this.bulkFileProcessorStandardTool1_UC_TopFolderChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BTN_RecallCourseLimits, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CHK_ProtectFiles, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RB_FullDetails, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.RB_ExamSheetStandard, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(861, 56);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BTN_RecallCourseLimits
            // 
            this.BTN_RecallCourseLimits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_RecallCourseLimits.Location = new System.Drawing.Point(692, 3);
            this.BTN_RecallCourseLimits.Name = "BTN_RecallCourseLimits";
            this.BTN_RecallCourseLimits.Size = new System.Drawing.Size(166, 22);
            this.BTN_RecallCourseLimits.TabIndex = 0;
            this.BTN_RecallCourseLimits.Text = "ادخال الدرجة النهائية ";
            this.BTN_RecallCourseLimits.UseVisualStyleBackColor = true;
            this.BTN_RecallCourseLimits.Click += new System.EventHandler(this.BTN_RecallCourseLimits_Click);
            // 
            // CHK_ProtectFiles
            // 
            this.CHK_ProtectFiles.AutoSize = true;
            this.CHK_ProtectFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CHK_ProtectFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_ProtectFiles.ForeColor = System.Drawing.Color.Red;
            this.CHK_ProtectFiles.Location = new System.Drawing.Point(520, 3);
            this.CHK_ProtectFiles.Name = "CHK_ProtectFiles";
            this.CHK_ProtectFiles.Size = new System.Drawing.Size(166, 22);
            this.CHK_ProtectFiles.TabIndex = 1;
            this.CHK_ProtectFiles.Text = "تأمين الملفات";
            this.CHK_ProtectFiles.UseVisualStyleBackColor = true;
            // 
            // RB_FullDetails
            // 
            this.RB_FullDetails.AutoSize = true;
            this.RB_FullDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RB_FullDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_FullDetails.ForeColor = System.Drawing.Color.Blue;
            this.RB_FullDetails.Location = new System.Drawing.Point(348, 3);
            this.RB_FullDetails.Name = "RB_FullDetails";
            this.RB_FullDetails.Size = new System.Drawing.Size(166, 22);
            this.RB_FullDetails.TabIndex = 2;
            this.RB_FullDetails.Text = "كشوف ادارة";
            this.RB_FullDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_FullDetails.UseVisualStyleBackColor = true;
            // 
            // RB_ExamSheetStandard
            // 
            this.RB_ExamSheetStandard.AutoSize = true;
            this.RB_ExamSheetStandard.Checked = true;
            this.RB_ExamSheetStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RB_ExamSheetStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_ExamSheetStandard.ForeColor = System.Drawing.Color.Blue;
            this.RB_ExamSheetStandard.Location = new System.Drawing.Point(348, 31);
            this.RB_ExamSheetStandard.Name = "RB_ExamSheetStandard";
            this.RB_ExamSheetStandard.Size = new System.Drawing.Size(166, 22);
            this.RB_ExamSheetStandard.TabIndex = 3;
            this.RB_ExamSheetStandard.TabStop = true;
            this.RB_ExamSheetStandard.Text = "نتيجة معلنة";
            this.RB_ExamSheetStandard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RB_ExamSheetStandard.UseVisualStyleBackColor = true;
            // 
            // ExportExamsheetEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 670);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExportExamsheetEX";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ExportExamsheetEX";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EOB.UserControls.ToolsTypicals.BulkFileProcessorStandardTool UC_Tool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BTN_RecallCourseLimits;
        private System.Windows.Forms.CheckBox CHK_ProtectFiles;
        private System.Windows.Forms.RadioButton RB_FullDetails;
        private System.Windows.Forms.RadioButton RB_ExamSheetStandard;
    }
}