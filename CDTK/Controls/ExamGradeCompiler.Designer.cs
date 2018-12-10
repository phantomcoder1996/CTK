namespace CTK.Controls
{
    partial class ExamGradeCompiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamGradeCompiler));
            this.TLP_Contrl = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_ExportFinalSheets = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.BTN_ImportExamSheet = new System.Windows.Forms.Button();
            this.BTN_ImportActivitySheet = new System.Windows.Forms.Button();
            this.PIC_Status = new System.Windows.Forms.PictureBox();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_INFO = new System.Windows.Forms.TableLayoutPanel();
            this.LBL_Departmenet = new System.Windows.Forms.Label();
            this.LBL_AcademicClass = new System.Windows.Forms.Label();
            this.LBL_AcademicYear = new System.Windows.Forms.Label();
            this.TLP_HeaderContainer = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_Input = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TLP_Contrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Status)).BeginInit();
            this.TLP_Main.SuspendLayout();
            this.TLP_INFO.SuspendLayout();
            this.TLP_HeaderContainer.SuspendLayout();
            this.TLP_Input.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_Contrl
            // 
            this.TLP_Contrl.ColumnCount = 2;
            this.TLP_Contrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Contrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Contrl.Controls.Add(this.BTN_ExportFinalSheets, 1, 1);
            this.TLP_Contrl.Controls.Add(this.BTN_ImportExamSheet, 0, 0);
            this.TLP_Contrl.Controls.Add(this.BTN_ImportActivitySheet, 1, 0);
            this.TLP_Contrl.Controls.Add(this.PIC_Status, 0, 1);
            this.TLP_Contrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Contrl.Location = new System.Drawing.Point(3, 149);
            this.TLP_Contrl.Name = "TLP_Contrl";
            this.TLP_Contrl.RowCount = 2;
            this.TLP_Contrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Contrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Contrl.Size = new System.Drawing.Size(737, 140);
            this.TLP_Contrl.TabIndex = 0;
            // 
            // BTN_ExportFinalSheets
            // 
            this.BTN_ExportFinalSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_ExportFinalSheets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_ExportFinalSheets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_ExportFinalSheets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ExportFinalSheets.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.BTN_ExportFinalSheets.ImageIndex = 4;
            this.BTN_ExportFinalSheets.ImageList = this.imageList1;
            this.BTN_ExportFinalSheets.Location = new System.Drawing.Point(3, 73);
            this.BTN_ExportFinalSheets.Name = "BTN_ExportFinalSheets";
            this.BTN_ExportFinalSheets.Size = new System.Drawing.Size(363, 64);
            this.BTN_ExportFinalSheets.TabIndex = 3;
            this.BTN_ExportFinalSheets.Text = "حفظ";
            this.BTN_ExportFinalSheets.UseVisualStyleBackColor = true;
            this.BTN_ExportFinalSheets.Click += new System.EventHandler(this.BTN_ExportFinalSheets_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OK");
            this.imageList1.Images.SetKeyName(1, "WARN");
            this.imageList1.Images.SetKeyName(2, "NO");
            this.imageList1.Images.SetKeyName(3, "FINAL");
            this.imageList1.Images.SetKeyName(4, "SAVE");
            // 
            // BTN_ImportExamSheet
            // 
            this.BTN_ImportExamSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_ImportExamSheet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_ImportExamSheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_ImportExamSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ImportExamSheet.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.BTN_ImportExamSheet.ImageIndex = 3;
            this.BTN_ImportExamSheet.ImageList = this.imageList1;
            this.BTN_ImportExamSheet.Location = new System.Drawing.Point(372, 3);
            this.BTN_ImportExamSheet.Name = "BTN_ImportExamSheet";
            this.BTN_ImportExamSheet.Size = new System.Drawing.Size(362, 64);
            this.BTN_ImportExamSheet.TabIndex = 1;
            this.BTN_ImportExamSheet.Text = "الامتحان";
            this.BTN_ImportExamSheet.UseVisualStyleBackColor = true;
            this.BTN_ImportExamSheet.Click += new System.EventHandler(this.BTN_ImportExamSheet_Click);
            // 
            // BTN_ImportActivitySheet
            // 
            this.BTN_ImportActivitySheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_ImportActivitySheet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTN_ImportActivitySheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BTN_ImportActivitySheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ImportActivitySheet.Location = new System.Drawing.Point(3, 3);
            this.BTN_ImportActivitySheet.Name = "BTN_ImportActivitySheet";
            this.BTN_ImportActivitySheet.Size = new System.Drawing.Size(363, 64);
            this.BTN_ImportActivitySheet.TabIndex = 0;
            this.BTN_ImportActivitySheet.Text = "اعمال السنة";
            this.BTN_ImportActivitySheet.UseVisualStyleBackColor = true;
            this.BTN_ImportActivitySheet.Click += new System.EventHandler(this.BTN_ImportActivitySheet_Click);
            // 
            // PIC_Status
            // 
            this.PIC_Status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PIC_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PIC_Status.Image = global::CTK.Properties.Resources.LeftLogo31;
            this.PIC_Status.Location = new System.Drawing.Point(372, 73);
            this.PIC_Status.Name = "PIC_Status";
            this.PIC_Status.Size = new System.Drawing.Size(362, 64);
            this.PIC_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PIC_Status.TabIndex = 2;
            this.PIC_Status.TabStop = false;
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Controls.Add(this.TLP_Contrl, 0, 1);
            this.TLP_Main.Controls.Add(this.TLP_HeaderContainer, 0, 0);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 2;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Main.Size = new System.Drawing.Size(743, 292);
            this.TLP_Main.TabIndex = 1;
            // 
            // TLP_INFO
            // 
            this.TLP_INFO.ColumnCount = 1;
            this.TLP_INFO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_INFO.Controls.Add(this.LBL_Departmenet, 0, 2);
            this.TLP_INFO.Controls.Add(this.LBL_AcademicClass, 0, 1);
            this.TLP_INFO.Controls.Add(this.LBL_AcademicYear, 0, 0);
            this.TLP_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_INFO.Location = new System.Drawing.Point(3, 3);
            this.TLP_INFO.Name = "TLP_INFO";
            this.TLP_INFO.RowCount = 3;
            this.TLP_INFO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_INFO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_INFO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLP_INFO.Size = new System.Drawing.Size(363, 134);
            this.TLP_INFO.TabIndex = 1;
            // 
            // LBL_Departmenet
            // 
            this.LBL_Departmenet.AutoSize = true;
            this.LBL_Departmenet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Departmenet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_Departmenet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Departmenet.ForeColor = System.Drawing.Color.Black;
            this.LBL_Departmenet.Location = new System.Drawing.Point(3, 88);
            this.LBL_Departmenet.Name = "LBL_Departmenet";
            this.LBL_Departmenet.Size = new System.Drawing.Size(357, 46);
            this.LBL_Departmenet.TabIndex = 2;
            this.LBL_Departmenet.Text = "label3";
            this.LBL_Departmenet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_AcademicClass
            // 
            this.LBL_AcademicClass.AutoSize = true;
            this.LBL_AcademicClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_AcademicClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_AcademicClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_AcademicClass.ForeColor = System.Drawing.Color.Red;
            this.LBL_AcademicClass.Location = new System.Drawing.Point(3, 44);
            this.LBL_AcademicClass.Name = "LBL_AcademicClass";
            this.LBL_AcademicClass.Size = new System.Drawing.Size(357, 44);
            this.LBL_AcademicClass.TabIndex = 1;
            this.LBL_AcademicClass.Text = "label2";
            this.LBL_AcademicClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_AcademicYear
            // 
            this.LBL_AcademicYear.AutoSize = true;
            this.LBL_AcademicYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_AcademicYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_AcademicYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_AcademicYear.ForeColor = System.Drawing.Color.White;
            this.LBL_AcademicYear.Location = new System.Drawing.Point(3, 0);
            this.LBL_AcademicYear.Name = "LBL_AcademicYear";
            this.LBL_AcademicYear.Size = new System.Drawing.Size(357, 44);
            this.LBL_AcademicYear.TabIndex = 0;
            this.LBL_AcademicYear.Text = "label1";
            this.LBL_AcademicYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLP_HeaderContainer
            // 
            this.TLP_HeaderContainer.ColumnCount = 2;
            this.TLP_HeaderContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_HeaderContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_HeaderContainer.Controls.Add(this.TLP_INFO, 1, 0);
            this.TLP_HeaderContainer.Controls.Add(this.TLP_Input, 0, 0);
            this.TLP_HeaderContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_HeaderContainer.Location = new System.Drawing.Point(3, 3);
            this.TLP_HeaderContainer.Name = "TLP_HeaderContainer";
            this.TLP_HeaderContainer.RowCount = 1;
            this.TLP_HeaderContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_HeaderContainer.Size = new System.Drawing.Size(737, 140);
            this.TLP_HeaderContainer.TabIndex = 2;
            // 
            // TLP_Input
            // 
            this.TLP_Input.ColumnCount = 2;
            this.TLP_Input.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Input.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Input.Controls.Add(this.textBox2, 1, 1);
            this.TLP_Input.Controls.Add(this.label1, 0, 0);
            this.TLP_Input.Controls.Add(this.label2, 0, 1);
            this.TLP_Input.Controls.Add(this.textBox1, 1, 0);
            this.TLP_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Input.Location = new System.Drawing.Point(372, 3);
            this.TLP_Input.Name = "TLP_Input";
            this.TLP_Input.RowCount = 2;
            this.TLP_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Input.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP_Input.Size = new System.Drawing.Size(362, 134);
            this.TLP_Input.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "الدرجة العظمى للتحريري";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 67);
            this.label2.TabIndex = 1;
            this.label2.Text = "الدرجة العظمى لاعمال السنة";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 38);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(3, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 38);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "0";
            // 
            // ExamGradeCompiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_Main);
            this.Name = "ExamGradeCompiler";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(743, 292);
            this.TLP_Contrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PIC_Status)).EndInit();
            this.TLP_Main.ResumeLayout(false);
            this.TLP_INFO.ResumeLayout(false);
            this.TLP_INFO.PerformLayout();
            this.TLP_HeaderContainer.ResumeLayout(false);
            this.TLP_Input.ResumeLayout(false);
            this.TLP_Input.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Contrl;
        private System.Windows.Forms.Button BTN_ImportExamSheet;
        private System.Windows.Forms.Button BTN_ImportActivitySheet;
        private System.Windows.Forms.PictureBox PIC_Status;
        private System.Windows.Forms.Button BTN_ExportFinalSheets;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.TableLayoutPanel TLP_INFO;
        private System.Windows.Forms.Label LBL_Departmenet;
        private System.Windows.Forms.Label LBL_AcademicClass;
        private System.Windows.Forms.Label LBL_AcademicYear;
        private System.Windows.Forms.TableLayoutPanel TLP_HeaderContainer;
        private System.Windows.Forms.TableLayoutPanel TLP_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
