namespace CTK.Dialogs
{
    partial class SecreteNumbersEntryDLG
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DG_FirstEntry = new System.Windows.Forms.DataGridView();
            this.sTudentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secreteNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secreteNumbersDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.internalDS = new CTK.Data.InternalDS();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DG_SecondEntry = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB_CourseCode = new System.Windows.Forms.ComboBox();
            this.coursesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTKDBDataSet = new CTK.Data.CTKDBDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Match = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.coursesTableAdapter = new CTK.Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DG_MismatchReport = new System.Windows.Forms.DataGridView();
            this.mismatchTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BTN_Correct = new System.Windows.Forms.Button();
            this.studentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_FirstEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secreteNumbersDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalDS)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_SecondEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_MismatchReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mismatchTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(83, 128);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(538, 321);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DG_FirstEntry);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(530, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "الرصد الاول";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DG_FirstEntry
            // 
            this.DG_FirstEntry.AllowUserToAddRows = false;
            this.DG_FirstEntry.AllowUserToDeleteRows = false;
            this.DG_FirstEntry.AutoGenerateColumns = false;
            this.DG_FirstEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_FirstEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sTudentIDDataGridViewTextBoxColumn,
            this.secreteNumberDataGridViewTextBoxColumn});
            this.DG_FirstEntry.DataSource = this.secreteNumbersDTBindingSource;
            this.DG_FirstEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_FirstEntry.Location = new System.Drawing.Point(2, 2);
            this.DG_FirstEntry.Margin = new System.Windows.Forms.Padding(2);
            this.DG_FirstEntry.Name = "DG_FirstEntry";
            this.DG_FirstEntry.RowTemplate.Height = 24;
            this.DG_FirstEntry.Size = new System.Drawing.Size(526, 291);
            this.DG_FirstEntry.TabIndex = 0;
            // 
            // sTudentIDDataGridViewTextBoxColumn
            // 
            this.sTudentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sTudentIDDataGridViewTextBoxColumn.DataPropertyName = "STudentID";
            this.sTudentIDDataGridViewTextBoxColumn.HeaderText = "رقم الجلوس";
            this.sTudentIDDataGridViewTextBoxColumn.Name = "sTudentIDDataGridViewTextBoxColumn";
            this.sTudentIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secreteNumberDataGridViewTextBoxColumn
            // 
            this.secreteNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.secreteNumberDataGridViewTextBoxColumn.DataPropertyName = "SecreteNumber";
            this.secreteNumberDataGridViewTextBoxColumn.HeaderText = "الرقم السري";
            this.secreteNumberDataGridViewTextBoxColumn.Name = "secreteNumberDataGridViewTextBoxColumn";
            // 
            // secreteNumbersDTBindingSource
            // 
            this.secreteNumbersDTBindingSource.DataMember = "SecreteNumbersDT";
            this.secreteNumbersDTBindingSource.DataSource = this.internalDS;
            // 
            // internalDS
            // 
            this.internalDS.DataSetName = "InternalDS";
            this.internalDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DG_SecondEntry);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(530, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "الرصد الثاني";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DG_SecondEntry
            // 
            this.DG_SecondEntry.AllowUserToAddRows = false;
            this.DG_SecondEntry.AllowUserToDeleteRows = false;
            this.DG_SecondEntry.AutoGenerateColumns = false;
            this.DG_SecondEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_SecondEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DG_SecondEntry.DataSource = this.secreteNumbersDTBindingSource;
            this.DG_SecondEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_SecondEntry.Location = new System.Drawing.Point(2, 2);
            this.DG_SecondEntry.Margin = new System.Windows.Forms.Padding(2);
            this.DG_SecondEntry.Name = "DG_SecondEntry";
            this.DG_SecondEntry.RowTemplate.Height = 24;
            this.DG_SecondEntry.Size = new System.Drawing.Size(526, 291);
            this.DG_SecondEntry.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STudentID";
            this.dataGridViewTextBoxColumn1.HeaderText = "رقم الجلوس";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SecreteNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "الرقم السري";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // CB_CourseCode
            // 
            this.CB_CourseCode.DataSource = this.coursesBindingSource;
            this.CB_CourseCode.DisplayMember = "Code";
            this.CB_CourseCode.FormattingEnabled = true;
            this.CB_CourseCode.Location = new System.Drawing.Point(175, 64);
            this.CB_CourseCode.Margin = new System.Windows.Forms.Padding(2);
            this.CB_CourseCode.Name = "CB_CourseCode";
            this.CB_CourseCode.Size = new System.Drawing.Size(366, 21);
            this.CB_CourseCode.TabIndex = 1;
            this.CB_CourseCode.ValueMember = "Code";
            this.CB_CourseCode.SelectedIndexChanged += new System.EventHandler(this.CB_CourseCode_SelectedIndexChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "المادة";
            // 
            // BTN_Match
            // 
            this.BTN_Match.Location = new System.Drawing.Point(324, 453);
            this.BTN_Match.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Match.Name = "BTN_Match";
            this.BTN_Match.Size = new System.Drawing.Size(74, 43);
            this.BTN_Match.TabIndex = 3;
            this.BTN_Match.Text = "مطابقة";
            this.BTN_Match.UseVisualStyleBackColor = true;
            this.BTN_Match.Click += new System.EventHandler(this.BTN_Match_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(649, 65);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "موافق";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(649, 128);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "الغاء";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // coursesTableAdapter
            // 
            this.coursesTableAdapter.ClearBeforeFill = true;
            // 
            // BTN_Update
            // 
            this.BTN_Update.Location = new System.Drawing.Point(283, 89);
            this.BTN_Update.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(56, 39);
            this.BTN_Update.TabIndex = 6;
            this.BTN_Update.Text = "تحميل";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DG_MismatchReport);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(530, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "نتيجة المطابقة";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DG_MismatchReport
            // 
            this.DG_MismatchReport.AllowUserToAddRows = false;
            this.DG_MismatchReport.AllowUserToDeleteRows = false;
            this.DG_MismatchReport.AutoGenerateColumns = false;
            this.DG_MismatchReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_MismatchReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentIDDataGridViewTextBoxColumn1,
            this.firstEntryDataGridViewTextBoxColumn,
            this.secondEntryDataGridViewTextBoxColumn});
            this.DG_MismatchReport.DataSource = this.mismatchTableBindingSource;
            this.DG_MismatchReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_MismatchReport.Location = new System.Drawing.Point(3, 3);
            this.DG_MismatchReport.Margin = new System.Windows.Forms.Padding(2);
            this.DG_MismatchReport.Name = "DG_MismatchReport";
            this.DG_MismatchReport.RowTemplate.Height = 24;
            this.DG_MismatchReport.Size = new System.Drawing.Size(524, 289);
            this.DG_MismatchReport.TabIndex = 1;
            // 
            // mismatchTableBindingSource
            // 
            this.mismatchTableBindingSource.DataMember = "MismatchTable";
            this.mismatchTableBindingSource.DataSource = this.internalDS;
            // 
            // BTN_Correct
            // 
            this.BTN_Correct.Location = new System.Drawing.Point(431, 453);
            this.BTN_Correct.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Correct.Name = "BTN_Correct";
            this.BTN_Correct.Size = new System.Drawing.Size(74, 43);
            this.BTN_Correct.TabIndex = 7;
            this.BTN_Correct.Text = "تصحيح";
            this.BTN_Correct.UseVisualStyleBackColor = true;
            this.BTN_Correct.Click += new System.EventHandler(this.BTN_Correct_Click);
            // 
            // studentIDDataGridViewTextBoxColumn1
            // 
            this.studentIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.studentIDDataGridViewTextBoxColumn1.DataPropertyName = "StudentID";
            this.studentIDDataGridViewTextBoxColumn1.HeaderText = "رقم الجلوس";
            this.studentIDDataGridViewTextBoxColumn1.Name = "studentIDDataGridViewTextBoxColumn1";
            this.studentIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // firstEntryDataGridViewTextBoxColumn
            // 
            this.firstEntryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.firstEntryDataGridViewTextBoxColumn.DataPropertyName = "FirstEntry";
            this.firstEntryDataGridViewTextBoxColumn.HeaderText = "الرصد الاول";
            this.firstEntryDataGridViewTextBoxColumn.Name = "firstEntryDataGridViewTextBoxColumn";
            // 
            // secondEntryDataGridViewTextBoxColumn
            // 
            this.secondEntryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.secondEntryDataGridViewTextBoxColumn.DataPropertyName = "SecondEntry";
            this.secondEntryDataGridViewTextBoxColumn.HeaderText = "الرصد الثاني";
            this.secondEntryDataGridViewTextBoxColumn.Name = "secondEntryDataGridViewTextBoxColumn";
            // 
            // SecreteNumbersEntryDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 560);
            this.Controls.Add(this.BTN_Correct);
            this.Controls.Add(this.BTN_Update);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BTN_Match);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_CourseCode);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SecreteNumbersEntryDLG";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "رصد الارقام السرية";
            this.Load += new System.EventHandler(this.SecreteNumbersEntryDLG_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_FirstEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secreteNumbersDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalDS)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_SecondEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_MismatchReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mismatchTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox CB_CourseCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Match;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView DG_FirstEntry;
        private System.Windows.Forms.BindingSource secreteNumbersDTBindingSource;
        private Data.InternalDS internalDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTudentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secreteNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView DG_SecondEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Data.CTKDBDataSet cTKDBDataSet;
        private System.Windows.Forms.BindingSource coursesBindingSource;
        private Data.CTKDBDataSetTableAdapters.CoursesTableAdapter coursesTableAdapter;
        private System.Windows.Forms.Button BTN_Update;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView DG_MismatchReport;
        private System.Windows.Forms.BindingSource mismatchTableBindingSource;
        private System.Windows.Forms.Button BTN_Correct;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstEntryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondEntryDataGridViewTextBoxColumn;
    }
}