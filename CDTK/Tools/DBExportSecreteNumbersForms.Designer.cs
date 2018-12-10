namespace CTK.Tools
{
    partial class DBExportSecreteNumbersForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBExportSecreteNumbersForms));
            this.cTKDBDataSet = new CTK.Data.CTKDBDataSet();
            this.coursesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coursesTableAdapter = new CTK.Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
            this.tableAdapterManager = new CTK.Data.CTKDBDataSetTableAdapters.TableAdapterManager();
            this.studentsTableAdapter = new CTK.Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
            this.coursesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.coursesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TB_Startingwith = new System.Windows.Forms.TextBox();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DG_students = new System.Windows.Forms.DataGridView();
            this.BTN_ManualEntry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_BarCodeExport = new System.Windows.Forms.Button();
            this.BTN_ExportBarCode = new System.Windows.Forms.Button();
            this.BTN_DeleteCourse = new System.Windows.Forms.Button();
            this.CBX_CourseName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingNavigator)).BeginInit();
            this.coursesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_students)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cTKDBDataSet
            // 
            this.cTKDBDataSet.DataSetName = "CTKDBDataSet";
            this.cTKDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // coursesBindingSource
            // 
            this.coursesBindingSource.DataMember = "Courses";
            this.coursesBindingSource.DataSource = this.cTKDBDataSet;
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
            this.tableAdapterManager.StudentsTableAdapter = this.studentsTableAdapter;
            this.tableAdapterManager.UpdateOrder = CTK.Data.CTKDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // coursesBindingNavigator
            // 
            this.coursesBindingNavigator.AddNewItem = null;
            this.coursesBindingNavigator.BindingSource = this.coursesBindingSource;
            this.coursesBindingNavigator.CountItem = null;
            this.coursesBindingNavigator.DeleteItem = null;
            this.coursesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorSeparator2,
            this.coursesBindingNavigatorSaveItem});
            this.coursesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.coursesBindingNavigator.MoveFirstItem = null;
            this.coursesBindingNavigator.MoveLastItem = null;
            this.coursesBindingNavigator.MoveNextItem = null;
            this.coursesBindingNavigator.MovePreviousItem = null;
            this.coursesBindingNavigator.Name = "coursesBindingNavigator";
            this.coursesBindingNavigator.PositionItem = null;
            this.coursesBindingNavigator.Size = new System.Drawing.Size(872, 25);
            this.coursesBindingNavigator.TabIndex = 0;
            this.coursesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // coursesBindingNavigatorSaveItem
            // 
            this.coursesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.coursesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("coursesBindingNavigatorSaveItem.Image")));
            this.coursesBindingNavigatorSaveItem.Name = "coursesBindingNavigatorSaveItem";
            this.coursesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.coursesBindingNavigatorSaveItem.Text = "Save Data";
            this.coursesBindingNavigatorSaveItem.Click += new System.EventHandler(this.coursesBindingNavigatorSaveItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start with";
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.cTKDBDataSet;
            // 
            // TB_Startingwith
            // 
            this.TB_Startingwith.Location = new System.Drawing.Point(66, 20);
            this.TB_Startingwith.Name = "TB_Startingwith";
            this.TB_Startingwith.Size = new System.Drawing.Size(150, 20);
            this.TB_Startingwith.TabIndex = 5;
            // 
            // BTN_Update
            // 
            this.BTN_Update.Location = new System.Drawing.Point(12, 46);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(204, 35);
            this.BTN_Update.TabIndex = 6;
            this.BTN_Update.Text = "تحديث الارقام السرية تلقائيا";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(736, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 56);
            this.button2.TabIndex = 7;
            this.button2.Text = "حفظ في اكسيل";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DG_students
            // 
            this.DG_students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_students.Location = new System.Drawing.Point(28, 196);
            this.DG_students.Name = "DG_students";
            this.DG_students.RowTemplate.Height = 24;
            this.DG_students.Size = new System.Drawing.Size(682, 211);
            this.DG_students.TabIndex = 8;
            this.DG_students.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DG_students_CellBeginEdit);
            this.DG_students.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_students_CellContentClick);
            this.DG_students.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_students_CellEndEdit);
            // 
            // BTN_ManualEntry
            // 
            this.BTN_ManualEntry.Location = new System.Drawing.Point(242, 145);
            this.BTN_ManualEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BTN_ManualEntry.Name = "BTN_ManualEntry";
            this.BTN_ManualEntry.Size = new System.Drawing.Size(204, 35);
            this.BTN_ManualEntry.TabIndex = 12;
            this.BTN_ManualEntry.Text = "ادخال يدوي";
            this.BTN_ManualEntry.UseVisualStyleBackColor = true;
            this.BTN_ManualEntry.Visible = false;
            this.BTN_ManualEntry.Click += new System.EventHandler(this.BTN_ManualEntry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_Startingwith);
            this.groupBox1.Controls.Add(this.BTN_Update);
            this.groupBox1.Location = new System.Drawing.Point(452, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(255, 91);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ادخال تلقائي";
            this.groupBox1.Visible = false;
            // 
            // BTN_BarCodeExport
            // 
            this.BTN_BarCodeExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_BarCodeExport.Location = new System.Drawing.Point(736, 137);
            this.BTN_BarCodeExport.Name = "BTN_BarCodeExport";
            this.BTN_BarCodeExport.Size = new System.Drawing.Size(124, 56);
            this.BTN_BarCodeExport.TabIndex = 14;
            this.BTN_BarCodeExport.Text = "تصنيع باركود";
            this.BTN_BarCodeExport.UseVisualStyleBackColor = true;
            this.BTN_BarCodeExport.Click += new System.EventHandler(this.BTN_BarCodeExport_Click);
            // 
            // BTN_ExportBarCode
            // 
            this.BTN_ExportBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ExportBarCode.Location = new System.Drawing.Point(736, 280);
            this.BTN_ExportBarCode.Name = "BTN_ExportBarCode";
            this.BTN_ExportBarCode.Size = new System.Drawing.Size(124, 56);
            this.BTN_ExportBarCode.TabIndex = 15;
            this.BTN_ExportBarCode.Text = "طباعة الباركود";
            this.BTN_ExportBarCode.UseVisualStyleBackColor = true;
            this.BTN_ExportBarCode.Click += new System.EventHandler(this.BTN_ExportBarCode_Click);
            // 
            // BTN_DeleteCourse
            // 
            this.BTN_DeleteCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DeleteCourse.Location = new System.Drawing.Point(736, 67);
            this.BTN_DeleteCourse.Name = "BTN_DeleteCourse";
            this.BTN_DeleteCourse.Size = new System.Drawing.Size(124, 56);
            this.BTN_DeleteCourse.TabIndex = 16;
            this.BTN_DeleteCourse.Text = "حذف المادة";
            this.BTN_DeleteCourse.UseVisualStyleBackColor = true;
            this.BTN_DeleteCourse.Click += new System.EventHandler(this.BTN_DeleteCourse_Click);
            // 
            // CBX_CourseName
            // 
            this.CBX_CourseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_CourseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBX_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBX_CourseName.FormattingEnabled = true;
            this.CBX_CourseName.Location = new System.Drawing.Point(175, 51);
            this.CBX_CourseName.Name = "CBX_CourseName";
            this.CBX_CourseName.Size = new System.Drawing.Size(510, 32);
            this.CBX_CourseName.Sorted = true;
            this.CBX_CourseName.TabIndex = 17;
            this.CBX_CourseName.SelectedIndexChanged += new System.EventHandler(this.CBX_CourseName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "اختيار المادة من القائمة";
            // 
            // DBExportSecreteNumbersForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(872, 467);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBX_CourseName);
            this.Controls.Add(this.BTN_DeleteCourse);
            this.Controls.Add(this.BTN_ExportBarCode);
            this.Controls.Add(this.BTN_BarCodeExport);
            this.Controls.Add(this.BTN_ManualEntry);
            this.Controls.Add(this.DG_students);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.coursesBindingNavigator);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DBExportSecreteNumbersForms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "اخراج الباركود للمواد";
            this.Load += new System.EventHandler(this.DBExportSecreteNumbersForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cTKDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coursesBindingNavigator)).EndInit();
            this.coursesBindingNavigator.ResumeLayout(false);
            this.coursesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_students)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Data.CTKDBDataSet cTKDBDataSet;
        private System.Windows.Forms.BindingSource coursesBindingSource;
        private Data.CTKDBDataSetTableAdapters.CoursesTableAdapter coursesTableAdapter;
        private Data.CTKDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator coursesBindingNavigator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton coursesBindingNavigatorSaveItem;
        private Data.CTKDBDataSetTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private System.Windows.Forms.TextBox TB_Startingwith;
        private System.Windows.Forms.Button BTN_Update;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DG_students;
        private System.Windows.Forms.Button BTN_ManualEntry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_BarCodeExport;
        private System.Windows.Forms.Button BTN_ExportBarCode;
        private System.Windows.Forms.Button BTN_DeleteCourse;
        private System.Windows.Forms.ComboBox CBX_CourseName;
        private System.Windows.Forms.Label label2;
    }
}