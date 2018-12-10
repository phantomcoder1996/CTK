namespace CTK.Tools
{
    partial class ExportToMIS
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codeLabel;
            this.coursesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTKDBDataSet = new CTK.Data.CTKDBDataSet();
            this.BTN_Export = new System.Windows.Forms.Button();
            this.MainHostingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CourseSelectionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CBX_Course = new System.Windows.Forms.ComboBox();
            this.UC_MISFile = new EOB.FileBrowserUC();
            this.UC_Screen = new EOB.AsynchLogScreen();
            this.RightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.helpButton1 = new EOB.Buttons.HelpButton();
            this.LB_CourseStatus = new System.Windows.Forms.CheckedListBox();
            this.coursesTableAdapter = new CTK.Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
            this.tableAdapterManager = new CTK.Data.CTKDBDataSetTableAdapters.TableAdapterManager();
            codeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).BeginInit();
            this.MainHostingPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.CourseSelectionPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codeLabel.Location = new System.Drawing.Point(712, 0);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(65, 24);
            codeLabel.TabIndex = 3;
            codeLabel.Text = "اسم المادة";
            // 
            // coursesBindingSource
            // 
            this.coursesBindingSource.DataMember = "Courses";
            this.coursesBindingSource.DataSource = this.cTKDBDataSet;
            // 
            // cTKDBDataSet
            // 
            this.cTKDBDataSet.DataSetName = "CTKDBDataSet";
            this.cTKDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BTN_Export
            // 
            this.BTN_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Export.Location = new System.Drawing.Point(3, 3);
            this.BTN_Export.Name = "BTN_Export";
            this.BTN_Export.Size = new System.Drawing.Size(141, 59);
            this.BTN_Export.TabIndex = 5;
            this.BTN_Export.Text = "اخراج";
            this.BTN_Export.UseVisualStyleBackColor = true;
            this.BTN_Export.Click += new System.EventHandler(this.BTN_Export_Click);
            // 
            // MainHostingPanel
            // 
            this.MainHostingPanel.ColumnCount = 2;
            this.MainHostingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.91534F));
            this.MainHostingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08466F));
            this.MainHostingPanel.Controls.Add(this.LeftPanel, 0, 0);
            this.MainHostingPanel.Controls.Add(this.RightPanel, 1, 0);
            this.MainHostingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainHostingPanel.Location = new System.Drawing.Point(0, 0);
            this.MainHostingPanel.Name = "MainHostingPanel";
            this.MainHostingPanel.RowCount = 1;
            this.MainHostingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainHostingPanel.Size = new System.Drawing.Size(945, 529);
            this.MainHostingPanel.TabIndex = 7;
            // 
            // LeftPanel
            // 
            this.LeftPanel.ColumnCount = 1;
            this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftPanel.Controls.Add(this.CourseSelectionPanel, 0, 0);
            this.LeftPanel.Controls.Add(this.UC_MISFile, 0, 1);
            this.LeftPanel.Controls.Add(this.UC_Screen, 0, 2);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(156, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.RowCount = 3;
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.24498F));
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.44578F));
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.51004F));
            this.LeftPanel.Size = new System.Drawing.Size(786, 523);
            this.LeftPanel.TabIndex = 0;
            // 
            // CourseSelectionPanel
            // 
            this.CourseSelectionPanel.ColumnCount = 2;
            this.CourseSelectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.23077F));
            this.CourseSelectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.76923F));
            this.CourseSelectionPanel.Controls.Add(codeLabel, 0, 0);
            this.CourseSelectionPanel.Controls.Add(this.CBX_Course, 1, 0);
            this.CourseSelectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseSelectionPanel.Location = new System.Drawing.Point(3, 3);
            this.CourseSelectionPanel.Name = "CourseSelectionPanel";
            this.CourseSelectionPanel.RowCount = 1;
            this.CourseSelectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CourseSelectionPanel.Size = new System.Drawing.Size(780, 52);
            this.CourseSelectionPanel.TabIndex = 0;
            // 
            // CBX_Course
            // 
            this.CBX_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Course.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBX_Course.FormattingEnabled = true;
            this.CBX_Course.Location = new System.Drawing.Point(3, 3);
            this.CBX_Course.Name = "CBX_Course";
            this.CBX_Course.Size = new System.Drawing.Size(585, 32);
            this.CBX_Course.Sorted = true;
            this.CBX_Course.TabIndex = 5;
            this.CBX_Course.SelectedIndexChanged += new System.EventHandler(this.CBX_Course_SelectedIndexChanged);
            // 
            // UC_MISFile
            // 
            this.UC_MISFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_MISFile.Filter = "Excel 2007 File (*.xlsx)|*.xlsx";
            this.UC_MISFile.Label = "MIS الملف من نظام ال";
            this.UC_MISFile.Location = new System.Drawing.Point(4, 62);
            this.UC_MISFile.Margin = new System.Windows.Forms.Padding(4);
            this.UC_MISFile.Name = "UC_MISFile";
            this.UC_MISFile.Size = new System.Drawing.Size(778, 51);
            this.UC_MISFile.TabIndex = 0;
            this.UC_MISFile.Visible = false;
            // 
            // UC_Screen
            // 
            this.UC_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Screen.Location = new System.Drawing.Point(4, 121);
            this.UC_Screen.Margin = new System.Windows.Forms.Padding(4);
            this.UC_Screen.MaximumThreads = 1;
            this.UC_Screen.Name = "UC_Screen";
            this.UC_Screen.Size = new System.Drawing.Size(778, 398);
            this.UC_Screen.TabIndex = 1;
            // 
            // RightPanel
            // 
            this.RightPanel.ColumnCount = 1;
            this.RightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightPanel.Controls.Add(this.BTN_Export, 0, 0);
            this.RightPanel.Controls.Add(this.helpButton1, 0, 7);
            this.RightPanel.Controls.Add(this.LB_CourseStatus, 0, 4);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(3, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.RowCount = 8;
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.RightPanel.Size = new System.Drawing.Size(147, 523);
            this.RightPanel.TabIndex = 1;
            // 
            // helpButton1
            // 
            this.helpButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpButton1.Location = new System.Drawing.Point(4, 459);
            this.helpButton1.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton1.Name = "helpButton1";
            this.helpButton1.Size = new System.Drawing.Size(139, 60);
            this.helpButton1.TabIndex = 6;
            // 
            // LB_CourseStatus
            // 
            this.LB_CourseStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_CourseStatus.Enabled = false;
            this.LB_CourseStatus.FormattingEnabled = true;
            this.LB_CourseStatus.Items.AddRange(new object[] {
            "أرقام سرية",
            "أدخال درجات"});
            this.LB_CourseStatus.Location = new System.Drawing.Point(2, 262);
            this.LB_CourseStatus.Margin = new System.Windows.Forms.Padding(2);
            this.LB_CourseStatus.Name = "LB_CourseStatus";
            this.LB_CourseStatus.Size = new System.Drawing.Size(143, 61);
            this.LB_CourseStatus.TabIndex = 7;
            // 
            // coursesTableAdapter
            // 
            this.coursesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BARCODETableAdapter = null;
            this.tableAdapterManager.CoursesTableAdapter = this.coursesTableAdapter;
            this.tableAdapterManager.INFOTableAdapter = null;
            this.tableAdapterManager.MasterTableAdapter = null;
            this.tableAdapterManager.StudentsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CTK.Data.CTKDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ExportToMIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(945, 529);
            this.Controls.Add(this.MainHostingPanel);
            this.Name = "ExportToMIS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Export to MIS";
            this.Load += new System.EventHandler(this.ExportToMIS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).EndInit();
            this.MainHostingPanel.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.CourseSelectionPanel.ResumeLayout(false);
            this.CourseSelectionPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EOB.FileBrowserUC UC_MISFile;
        private EOB.AsynchLogScreen UC_Screen;
        private Data.CTKDBDataSet cTKDBDataSet;
        private System.Windows.Forms.BindingSource coursesBindingSource;
        private Data.CTKDBDataSetTableAdapters.CoursesTableAdapter coursesTableAdapter;
        private Data.CTKDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button BTN_Export;
        private EOB.Buttons.HelpButton helpButton1;
        private System.Windows.Forms.TableLayoutPanel MainHostingPanel;
        private System.Windows.Forms.TableLayoutPanel LeftPanel;
        private System.Windows.Forms.TableLayoutPanel CourseSelectionPanel;
        private System.Windows.Forms.TableLayoutPanel RightPanel;
        private System.Windows.Forms.CheckedListBox LB_CourseStatus;
        private System.Windows.Forms.ComboBox CBX_Course;
    }
}