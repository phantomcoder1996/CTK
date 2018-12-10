namespace CTK.Tools
{
    partial class DBExamImportUsingBarCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBExamImportUsingBarCode));
            this.CBX_CourseName = new System.Windows.Forms.ComboBox();
            this.LBL_CaptionCourseName = new System.Windows.Forms.Label();
            this.DG_CourseSheet = new System.Windows.Forms.DataGridView();
            this.markEntryTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.internalDS = new CTK.Data.InternalDS();
            this.TB_Mark = new System.Windows.Forms.TextBox();
            this.LBL_CaptionMark = new System.Windows.Forms.Label();
            this.LBL_CaptionStudentName = new System.Windows.Forms.Label();
            this.LBL_StudentName = new System.Windows.Forms.Label();
            this.BTN_SaveTempFile = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.GB_Mode = new System.Windows.Forms.GroupBox();
            this.RB_RegAttendnace = new System.Windows.Forms.RadioButton();
            this.RB_REG_Second = new System.Windows.Forms.RadioButton();
            this.RB_REG_First = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BTN_LoadTempfile = new System.Windows.Forms.Button();
            this.TB_TempFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SideDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.helpButton1 = new EOB.Buttons.HelpButton();
            this.BTN_FinalReview = new System.Windows.Forms.Button();
            this.CHB_EnableEditing = new System.Windows.Forms.CheckBox();
            this.MainDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.LogScreen = new EOB.AsynchLogScreen();
            this.PNL_BarCodeEntry = new System.Windows.Forms.Panel();
            this.GB_ReportMark = new System.Windows.Forms.GroupBox();
            this.GB_ReportStatus = new System.Windows.Forms.GroupBox();
            this.RB_Attended = new System.Windows.Forms.RadioButton();
            this.Ok = new System.Windows.Forms.Button();
            this.RB_Absent = new System.Windows.Forms.RadioButton();
            this.RB_Execused = new System.Windows.Forms.RadioButton();
            this.UC_BarCodeControl = new DDCL.Forms.BarcodeTextBox();
            this.PNL_InfoEntry = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Review = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.firstEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DG_CourseSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markEntryTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalDS)).BeginInit();
            this.GB_Mode.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SideDisplay.SuspendLayout();
            this.MainDisplay.SuspendLayout();
            this.PNL_BarCodeEntry.SuspendLayout();
            this.GB_ReportMark.SuspendLayout();
            this.GB_ReportStatus.SuspendLayout();
            this.PNL_InfoEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBX_CourseName
            // 
            this.CBX_CourseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBX_CourseName.FormattingEnabled = true;
            this.CBX_CourseName.Location = new System.Drawing.Point(363, 10);
            this.CBX_CourseName.Name = "CBX_CourseName";
            this.CBX_CourseName.Size = new System.Drawing.Size(481, 32);
            this.CBX_CourseName.Sorted = true;
            this.CBX_CourseName.TabIndex = 3;
            this.CBX_CourseName.SelectedIndexChanged += new System.EventHandler(this.CBX_CourseName_SelectedIndexChanged);
            // 
            // LBL_CaptionCourseName
            // 
            this.LBL_CaptionCourseName.AutoSize = true;
            this.LBL_CaptionCourseName.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LBL_CaptionCourseName.Location = new System.Drawing.Point(850, 13);
            this.LBL_CaptionCourseName.Name = "LBL_CaptionCourseName";
            this.LBL_CaptionCourseName.Size = new System.Drawing.Size(65, 21);
            this.LBL_CaptionCourseName.TabIndex = 4;
            this.LBL_CaptionCourseName.Text = "اسم المادة";
            // 
            // DG_CourseSheet
            // 
            this.DG_CourseSheet.AllowUserToAddRows = false;
            this.DG_CourseSheet.AllowUserToDeleteRows = false;
            this.DG_CourseSheet.AutoGenerateColumns = false;
            this.DG_CourseSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_CourseSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Review,
            this.studentIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.Status,
            this.firstEntryDataGridViewTextBoxColumn,
            this.secondEntryDataGridViewTextBoxColumn});
            this.DG_CourseSheet.DataSource = this.markEntryTableBindingSource;
            this.DG_CourseSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_CourseSheet.Location = new System.Drawing.Point(3, 151);
            this.DG_CourseSheet.Name = "DG_CourseSheet";
            this.DG_CourseSheet.RowTemplate.Height = 40;
            this.DG_CourseSheet.Size = new System.Drawing.Size(921, 182);
            this.DG_CourseSheet.TabIndex = 5;
            this.DG_CourseSheet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CourseSheet_CellClick);
            this.DG_CourseSheet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CourseSheet_CellContentClick);
            this.DG_CourseSheet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CourseSheet_CellValueChanged);
            // 
            // markEntryTableBindingSource
            // 
            this.markEntryTableBindingSource.DataMember = "MarkEntryTable";
            this.markEntryTableBindingSource.DataSource = this.internalDS;
            // 
            // internalDS
            // 
            this.internalDS.DataSetName = "InternalDS";
            this.internalDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TB_Mark
            // 
            this.TB_Mark.Font = new System.Drawing.Font("Tahoma", 14F);
            this.TB_Mark.Location = new System.Drawing.Point(17, 12);
            this.TB_Mark.Name = "TB_Mark";
            this.TB_Mark.Size = new System.Drawing.Size(100, 30);
            this.TB_Mark.TabIndex = 6;
            this.TB_Mark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Mark_KeyPress);
            this.TB_Mark.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Mark_KeyUp);
            // 
            // LBL_CaptionMark
            // 
            this.LBL_CaptionMark.AutoSize = true;
            this.LBL_CaptionMark.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LBL_CaptionMark.Location = new System.Drawing.Point(123, 17);
            this.LBL_CaptionMark.Name = "LBL_CaptionMark";
            this.LBL_CaptionMark.Size = new System.Drawing.Size(50, 21);
            this.LBL_CaptionMark.TabIndex = 7;
            this.LBL_CaptionMark.Text = "الدرجة";
            // 
            // LBL_CaptionStudentName
            // 
            this.LBL_CaptionStudentName.AutoSize = true;
            this.LBL_CaptionStudentName.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.LBL_CaptionStudentName.Location = new System.Drawing.Point(729, 22);
            this.LBL_CaptionStudentName.Name = "LBL_CaptionStudentName";
            this.LBL_CaptionStudentName.Size = new System.Drawing.Size(76, 21);
            this.LBL_CaptionStudentName.TabIndex = 8;
            this.LBL_CaptionStudentName.Text = "اسم الطالب";
            // 
            // LBL_StudentName
            // 
            this.LBL_StudentName.AutoSize = true;
            this.LBL_StudentName.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_StudentName.ForeColor = System.Drawing.Color.DarkRed;
            this.LBL_StudentName.Location = new System.Drawing.Point(408, 22);
            this.LBL_StudentName.Name = "LBL_StudentName";
            this.LBL_StudentName.Size = new System.Drawing.Size(184, 19);
            this.LBL_StudentName.TabIndex = 9;
            this.LBL_StudentName.Text = "-----------------------------------";
            // 
            // BTN_SaveTempFile
            // 
            this.BTN_SaveTempFile.Location = new System.Drawing.Point(12, 8);
            this.BTN_SaveTempFile.Name = "BTN_SaveTempFile";
            this.BTN_SaveTempFile.Size = new System.Drawing.Size(152, 23);
            this.BTN_SaveTempFile.TabIndex = 10;
            this.BTN_SaveTempFile.Text = "<<حفظ ملف الرصد";
            this.BTN_SaveTempFile.UseVisualStyleBackColor = true;
            this.BTN_SaveTempFile.Click += new System.EventHandler(this.BTN_SaveTempFile_Click);
            // 
            // BTN_OK
            // 
            this.BTN_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_OK.Location = new System.Drawing.Point(3, 3);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(138, 43);
            this.BTN_OK.TabIndex = 11;
            this.BTN_OK.Text = "انهاء";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // GB_Mode
            // 
            this.GB_Mode.BackColor = System.Drawing.Color.LemonChiffon;
            this.GB_Mode.Controls.Add(this.RB_RegAttendnace);
            this.GB_Mode.Controls.Add(this.RB_REG_Second);
            this.GB_Mode.Controls.Add(this.RB_REG_First);
            this.GB_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Mode.Font = new System.Drawing.Font("Tahoma", 14F);
            this.GB_Mode.Location = new System.Drawing.Point(3, 52);
            this.GB_Mode.Name = "GB_Mode";
            this.GB_Mode.Size = new System.Drawing.Size(138, 162);
            this.GB_Mode.TabIndex = 13;
            this.GB_Mode.TabStop = false;
            this.GB_Mode.Text = "الحالة";
            // 
            // RB_RegAttendnace
            // 
            this.RB_RegAttendnace.AutoSize = true;
            this.RB_RegAttendnace.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.RB_RegAttendnace.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RB_RegAttendnace.Location = new System.Drawing.Point(6, 70);
            this.RB_RegAttendnace.Name = "RB_RegAttendnace";
            this.RB_RegAttendnace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RB_RegAttendnace.Size = new System.Drawing.Size(94, 26);
            this.RB_RegAttendnace.TabIndex = 2;
            this.RB_RegAttendnace.TabStop = true;
            this.RB_RegAttendnace.Text = "رصد غياب";
            this.RB_RegAttendnace.UseVisualStyleBackColor = true;
            this.RB_RegAttendnace.CheckedChanged += new System.EventHandler(this.RB_RegAttendnace_CheckedChanged);
            // 
            // RB_REG_Second
            // 
            this.RB_REG_Second.AutoSize = true;
            this.RB_REG_Second.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.RB_REG_Second.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RB_REG_Second.Location = new System.Drawing.Point(6, 44);
            this.RB_REG_Second.Name = "RB_REG_Second";
            this.RB_REG_Second.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RB_REG_Second.Size = new System.Drawing.Size(88, 26);
            this.RB_REG_Second.TabIndex = 1;
            this.RB_REG_Second.TabStop = true;
            this.RB_REG_Second.Text = "رصد ثاني";
            this.RB_REG_Second.UseVisualStyleBackColor = true;
            this.RB_REG_Second.CheckedChanged += new System.EventHandler(this.RB_REG_Second_CheckedChanged);
            // 
            // RB_REG_First
            // 
            this.RB_REG_First.AutoSize = true;
            this.RB_REG_First.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.RB_REG_First.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RB_REG_First.Location = new System.Drawing.Point(6, 18);
            this.RB_REG_First.Name = "RB_REG_First";
            this.RB_REG_First.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RB_REG_First.Size = new System.Drawing.Size(85, 26);
            this.RB_REG_First.TabIndex = 0;
            this.RB_REG_First.TabStop = true;
            this.RB_REG_First.Text = "رصد أول";
            this.RB_REG_First.UseVisualStyleBackColor = true;
            this.RB_REG_First.CheckedChanged += new System.EventHandler(this.RB_REG_First_CheckedChanged);
            // 
            // BTN_LoadTempfile
            // 
            this.BTN_LoadTempfile.Location = new System.Drawing.Point(12, 32);
            this.BTN_LoadTempfile.Name = "BTN_LoadTempfile";
            this.BTN_LoadTempfile.Size = new System.Drawing.Size(152, 23);
            this.BTN_LoadTempfile.TabIndex = 16;
            this.BTN_LoadTempfile.Text = "تحميل ملف رصد>>";
            this.BTN_LoadTempfile.UseVisualStyleBackColor = true;
            this.BTN_LoadTempfile.Click += new System.EventHandler(this.BTN_LoadTempfile_Click);
            // 
            // TB_TempFileName
            // 
            this.TB_TempFileName.Enabled = false;
            this.TB_TempFileName.Location = new System.Drawing.Point(264, 10);
            this.TB_TempFileName.Name = "TB_TempFileName";
            this.TB_TempFileName.Size = new System.Drawing.Size(93, 20);
            this.TB_TempFileName.TabIndex = 17;
            this.TB_TempFileName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label1.Location = new System.Drawing.Point(166, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "اسم الملف المؤقت";
            this.label1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.24192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.75808F));
            this.tableLayoutPanel1.Controls.Add(this.SideDisplay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MainDisplay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 549);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // SideDisplay
            // 
            this.SideDisplay.ColumnCount = 1;
            this.SideDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SideDisplay.Controls.Add(this.helpButton1, 0, 4);
            this.SideDisplay.Controls.Add(this.GB_Mode, 0, 1);
            this.SideDisplay.Controls.Add(this.BTN_OK, 0, 0);
            this.SideDisplay.Controls.Add(this.BTN_FinalReview, 0, 2);
            this.SideDisplay.Controls.Add(this.CHB_EnableEditing, 0, 3);
            this.SideDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideDisplay.Location = new System.Drawing.Point(3, 3);
            this.SideDisplay.Name = "SideDisplay";
            this.SideDisplay.RowCount = 5;
            this.SideDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.041096F));
            this.SideDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.9589F));
            this.SideDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.SideDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.SideDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.SideDisplay.Size = new System.Drawing.Size(144, 543);
            this.SideDisplay.TabIndex = 0;
            // 
            // helpButton1
            // 
            this.helpButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpButton1.Location = new System.Drawing.Point(4, 437);
            this.helpButton1.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton1.Name = "helpButton1";
            this.helpButton1.Size = new System.Drawing.Size(136, 102);
            this.helpButton1.TabIndex = 19;
            // 
            // BTN_FinalReview
            // 
            this.BTN_FinalReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_FinalReview.Image = global::CTK.Properties.Resources.view_32;
            this.BTN_FinalReview.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.BTN_FinalReview.Location = new System.Drawing.Point(3, 220);
            this.BTN_FinalReview.Name = "BTN_FinalReview";
            this.BTN_FinalReview.Size = new System.Drawing.Size(138, 102);
            this.BTN_FinalReview.TabIndex = 20;
            this.BTN_FinalReview.Text = "مراجعة شاملة";
            this.BTN_FinalReview.UseVisualStyleBackColor = true;
            this.BTN_FinalReview.Click += new System.EventHandler(this.BTN_FinalReview_Click);
            // 
            // CHB_EnableEditing
            // 
            this.CHB_EnableEditing.AutoSize = true;
            this.CHB_EnableEditing.Location = new System.Drawing.Point(64, 327);
            this.CHB_EnableEditing.Margin = new System.Windows.Forms.Padding(2);
            this.CHB_EnableEditing.Name = "CHB_EnableEditing";
            this.CHB_EnableEditing.Size = new System.Drawing.Size(78, 17);
            this.CHB_EnableEditing.TabIndex = 21;
            this.CHB_EnableEditing.Text = "فتح الجدول";
            this.CHB_EnableEditing.UseVisualStyleBackColor = true;
            this.CHB_EnableEditing.CheckedChanged += new System.EventHandler(this.CHB_EnableEditing_CheckedChanged);
            // 
            // MainDisplay
            // 
            this.MainDisplay.ColumnCount = 1;
            this.MainDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainDisplay.Controls.Add(this.LogScreen, 0, 3);
            this.MainDisplay.Controls.Add(this.DG_CourseSheet, 0, 2);
            this.MainDisplay.Controls.Add(this.PNL_BarCodeEntry, 0, 1);
            this.MainDisplay.Controls.Add(this.PNL_InfoEntry, 0, 0);
            this.MainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDisplay.Location = new System.Drawing.Point(153, 3);
            this.MainDisplay.Name = "MainDisplay";
            this.MainDisplay.RowCount = 4;
            this.MainDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.01814F));
            this.MainDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.64626F));
            this.MainDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.92064F));
            this.MainDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.86848F));
            this.MainDisplay.Size = new System.Drawing.Size(927, 543);
            this.MainDisplay.TabIndex = 1;
            // 
            // LogScreen
            // 
            this.LogScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogScreen.Location = new System.Drawing.Point(4, 340);
            this.LogScreen.Margin = new System.Windows.Forms.Padding(4);
            this.LogScreen.MaximumThreads = 1;
            this.LogScreen.Name = "LogScreen";
            this.LogScreen.Size = new System.Drawing.Size(919, 199);
            this.LogScreen.TabIndex = 21;
            // 
            // PNL_BarCodeEntry
            // 
            this.PNL_BarCodeEntry.Controls.Add(this.GB_ReportMark);
            this.PNL_BarCodeEntry.Controls.Add(this.GB_ReportStatus);
            this.PNL_BarCodeEntry.Controls.Add(this.UC_BarCodeControl);
            this.PNL_BarCodeEntry.Controls.Add(this.LBL_CaptionStudentName);
            this.PNL_BarCodeEntry.Controls.Add(this.LBL_StudentName);
            this.PNL_BarCodeEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_BarCodeEntry.Location = new System.Drawing.Point(3, 67);
            this.PNL_BarCodeEntry.Name = "PNL_BarCodeEntry";
            this.PNL_BarCodeEntry.Size = new System.Drawing.Size(921, 78);
            this.PNL_BarCodeEntry.TabIndex = 22;
            // 
            // GB_ReportMark
            // 
            this.GB_ReportMark.Controls.Add(this.LBL_CaptionMark);
            this.GB_ReportMark.Controls.Add(this.TB_Mark);
            this.GB_ReportMark.Location = new System.Drawing.Point(22, 5);
            this.GB_ReportMark.Name = "GB_ReportMark";
            this.GB_ReportMark.Size = new System.Drawing.Size(325, 52);
            this.GB_ReportMark.TabIndex = 11;
            this.GB_ReportMark.TabStop = false;
            // 
            // GB_ReportStatus
            // 
            this.GB_ReportStatus.Controls.Add(this.RB_Attended);
            this.GB_ReportStatus.Controls.Add(this.Ok);
            this.GB_ReportStatus.Controls.Add(this.RB_Absent);
            this.GB_ReportStatus.Controls.Add(this.RB_Execused);
            this.GB_ReportStatus.Location = new System.Drawing.Point(22, 3);
            this.GB_ReportStatus.Name = "GB_ReportStatus";
            this.GB_ReportStatus.Size = new System.Drawing.Size(325, 52);
            this.GB_ReportStatus.TabIndex = 10;
            this.GB_ReportStatus.TabStop = false;
            // 
            // RB_Attended
            // 
            this.RB_Attended.AutoSize = true;
            this.RB_Attended.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.RB_Attended.Location = new System.Drawing.Point(220, 24);
            this.RB_Attended.Name = "RB_Attended";
            this.RB_Attended.Size = new System.Drawing.Size(36, 23);
            this.RB_Attended.TabIndex = 3;
            this.RB_Attended.TabStop = true;
            this.RB_Attended.Text = "ح";
            this.RB_Attended.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(17, 23);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "موافق";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // RB_Absent
            // 
            this.RB_Absent.AutoSize = true;
            this.RB_Absent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.RB_Absent.Location = new System.Drawing.Point(98, 24);
            this.RB_Absent.Name = "RB_Absent";
            this.RB_Absent.Size = new System.Drawing.Size(36, 23);
            this.RB_Absent.TabIndex = 1;
            this.RB_Absent.TabStop = true;
            this.RB_Absent.Text = "غ";
            this.RB_Absent.UseVisualStyleBackColor = true;
            // 
            // RB_Execused
            // 
            this.RB_Execused.AutoSize = true;
            this.RB_Execused.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.RB_Execused.Location = new System.Drawing.Point(153, 24);
            this.RB_Execused.Name = "RB_Execused";
            this.RB_Execused.Size = new System.Drawing.Size(49, 23);
            this.RB_Execused.TabIndex = 0;
            this.RB_Execused.TabStop = true;
            this.RB_Execused.Text = "غ ع";
            this.RB_Execused.UseVisualStyleBackColor = true;
            // 
            // UC_BarCodeControl
            // 
            this.UC_BarCodeControl.BackColor = System.Drawing.SystemColors.Control;
            this.UC_BarCodeControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.UC_BarCodeControl.ForeColor = System.Drawing.Color.Blue;
            this.UC_BarCodeControl.LastBarCode = null;
            this.UC_BarCodeControl.Location = new System.Drawing.Point(812, 16);
            this.UC_BarCodeControl.Margin = new System.Windows.Forms.Padding(4);
            this.UC_BarCodeControl.Name = "UC_BarCodeControl";
            this.UC_BarCodeControl.Size = new System.Drawing.Size(99, 31);
            this.UC_BarCodeControl.TabIndex = 0;
            this.UC_BarCodeControl.OnNewBarcodeRecived += new DDCL.Forms.OnNewBarCode(this.barcodeTextBox1_OnNewBarcodeRecived);
            // 
            // PNL_InfoEntry
            // 
            this.PNL_InfoEntry.Controls.Add(this.LBL_CaptionCourseName);
            this.PNL_InfoEntry.Controls.Add(this.BTN_LoadTempfile);
            this.PNL_InfoEntry.Controls.Add(this.label1);
            this.PNL_InfoEntry.Controls.Add(this.TB_TempFileName);
            this.PNL_InfoEntry.Controls.Add(this.CBX_CourseName);
            this.PNL_InfoEntry.Controls.Add(this.BTN_SaveTempFile);
            this.PNL_InfoEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_InfoEntry.Location = new System.Drawing.Point(3, 3);
            this.PNL_InfoEntry.Name = "PNL_InfoEntry";
            this.PNL_InfoEntry.Size = new System.Drawing.Size(921, 58);
            this.PNL_InfoEntry.TabIndex = 23;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Review
            // 
            this.Review.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Review.DataPropertyName = "Review";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Review.DefaultCellStyle = dataGridViewCellStyle1;
            this.Review.HeaderText = "#";
            this.Review.Name = "Review";
            this.Review.Width = 39;
            // 
            // studentIDDataGridViewTextBoxColumn
            // 
            this.studentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.studentIDDataGridViewTextBoxColumn.DataPropertyName = "StudentID";
            this.studentIDDataGridViewTextBoxColumn.HeaderText = "رقم الجلوس";
            this.studentIDDataGridViewTextBoxColumn.Name = "studentIDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "اسم الطالب";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 80;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "الحالة";
            this.Status.Items.AddRange(new object[] {
            "ح",
            "غ",
            "غ ع"});
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // firstEntryDataGridViewTextBoxColumn
            // 
            this.firstEntryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.firstEntryDataGridViewTextBoxColumn.DataPropertyName = "FirstEntry";
            this.firstEntryDataGridViewTextBoxColumn.HeaderText = "رصد أول";
            this.firstEntryDataGridViewTextBoxColumn.Name = "firstEntryDataGridViewTextBoxColumn";
            // 
            // secondEntryDataGridViewTextBoxColumn
            // 
            this.secondEntryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.secondEntryDataGridViewTextBoxColumn.DataPropertyName = "SecondEntry";
            this.secondEntryDataGridViewTextBoxColumn.HeaderText = "رصد ثاني";
            this.secondEntryDataGridViewTextBoxColumn.Name = "secondEntryDataGridViewTextBoxColumn";
            // 
            // DBExamImportUsingBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DBExamImportUsingBarCode";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ادخال الدرجات بالباركود";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DG_CourseSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markEntryTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalDS)).EndInit();
            this.GB_Mode.ResumeLayout(false);
            this.GB_Mode.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SideDisplay.ResumeLayout(false);
            this.SideDisplay.PerformLayout();
            this.MainDisplay.ResumeLayout(false);
            this.PNL_BarCodeEntry.ResumeLayout(false);
            this.PNL_BarCodeEntry.PerformLayout();
            this.GB_ReportMark.ResumeLayout(false);
            this.GB_ReportMark.PerformLayout();
            this.GB_ReportStatus.ResumeLayout(false);
            this.GB_ReportStatus.PerformLayout();
            this.PNL_InfoEntry.ResumeLayout(false);
            this.PNL_InfoEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DDCL.Forms.BarcodeTextBox UC_BarCodeControl;
        private System.Windows.Forms.ComboBox CBX_CourseName;
        private System.Windows.Forms.Label LBL_CaptionCourseName;
        private System.Windows.Forms.DataGridView DG_CourseSheet;
        private System.Windows.Forms.TextBox TB_Mark;
        private System.Windows.Forms.Label LBL_CaptionMark;
        private System.Windows.Forms.Label LBL_CaptionStudentName;
        private System.Windows.Forms.Label LBL_StudentName;
        private System.Windows.Forms.Button BTN_SaveTempFile;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.GroupBox GB_Mode;
        private System.Windows.Forms.RadioButton RB_RegAttendnace;
        private System.Windows.Forms.RadioButton RB_REG_Second;
        private System.Windows.Forms.RadioButton RB_REG_First;
        private System.Windows.Forms.BindingSource markEntryTableBindingSource;
        private Data.InternalDS internalDS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BTN_LoadTempfile;
        private System.Windows.Forms.TextBox TB_TempFileName;
        private System.Windows.Forms.Label label1;
        private EOB.Buttons.HelpButton helpButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel SideDisplay;
        private System.Windows.Forms.TableLayoutPanel MainDisplay;
        private EOB.AsynchLogScreen LogScreen;
        private System.Windows.Forms.Panel PNL_BarCodeEntry;
        private System.Windows.Forms.Panel PNL_InfoEntry;
        private System.Windows.Forms.GroupBox GB_ReportMark;
        private System.Windows.Forms.GroupBox GB_ReportStatus;
        private System.Windows.Forms.RadioButton RB_Absent;
        private System.Windows.Forms.RadioButton RB_Execused;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.RadioButton RB_Attended;
        private System.Windows.Forms.Button BTN_FinalReview;
        private System.Windows.Forms.CheckBox CHB_EnableEditing;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Review;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstEntryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondEntryDataGridViewTextBoxColumn;
    }
}