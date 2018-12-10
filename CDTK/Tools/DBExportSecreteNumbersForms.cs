using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTK.Tools
{
    public partial class DBExportSecreteNumbersForms : Form
    {
        public DBExportSecreteNumbersForms()
        {
            InitializeComponent();
            InitializeComponentEX();

            //bindingNavigatorMoveNextItem_Click(, new EventArgs());
            //DG_students.DataSource = BL.GetStudentListFromMasterTable(codeTextBox.Text);
        }
        void InitializeComponentEX()
        {
            CBX_CourseName.Items.AddRange(BL.GetCoursesList());
        }
        private void coursesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                // CTKDB_NMEntities ds = new CTKDB_NMEntities();
                string coursecode = BL.GetCourseCode(CBX_CourseName.Text);

                DataTable dt = (DataTable)DG_students.DataSource;
                BL.UpdateMasterTable_SecreteNumbers(dt, coursecode);
                this.Validate();
                this.coursesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.cTKDBDataSet);
                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex.Message);
            }

        }

        private void DBExportSecreteNumbersForms_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTKDBDataSet.Students' table. You can move, or remove it, as needed.
            //this.studentsTableAdapter.Fill(this.cTKDBDataSet.Students);
            //// TODO: This line of code loads data into the 'cTKDBDataSet.Courses' table. You can move, or remove it, as needed.
            //this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);
            //DG_students.DataSource = BL.GetStudentListFromMasterTable(codeTextBox.Text);
            
        }
        // validatenumeric startwith
        private void BTN_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                //Task: Consider to find a solution to the problem of nullable value check of SSID. This is not the case after applying the default value to all fields.
                if (!BL.IsNULLSSID(code))
                {
                    if (MessageBox.Show("يوجد بالفعل ارقام سرية لهذا المقرر. انت بصدد مسح هذه الارقام و استبدالها بأرقام أخرى. في هذه الحالة لا يمكن الرجوع مرة اخرى و لا يمكن ربط الارقام القديمة بكشوف رصد التحريري بشكل تلقائي. هل تريد الاستمرار؟ ", "إحذر", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MessageBox.Show("سيتم التغيير الان هل انت متأكد؟", "تحذير نهائي", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            throw new Exception("لم يحدث تغيير الارقام السرية");
                        }
                    }
                    else
                    {
                        throw new Exception("لم يحدث تغيير الارقام السرية");
                    }
                }
                if (!BL.IsNumeric(TB_Startingwith.Text))
                {
                    MessageBox.Show("الارقام السرية لابد الا تحتوي على حروف. لابد ان تكون ارقام فقط. من فضلك ادخل رقم صحيح للبدء به في عملية الترقيم.");
                    throw new Exception("No valid secrete number of empty placed secrete number is provided into the starting position");
                }
                int start = Convert.ToInt32(TB_Startingwith.Text);
                DataTable dt = (DataTable)DG_students.DataSource;
                int count = dt.Rows.Count;

                string[] buffer = EOB.Arrays.Processing.PsedoNumberGenerator(start, count);

                for (int i = 0; i < count; i++)
                {
                    DG_students["الرقم السري", i].Value = buffer[i];
                    //Data.CTKDBDataSet.StudentsRow r = dt[i];
                    //r.StudentSID = buffer[i];
                }

                BL.UpdateMasterTable_SecreteNumbers(dt, code);
            }
            catch (FormatException fe)
            {
                EOB.EOBLog.ReportError(null, "The secrete number starting number is a missing");
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
                MessageBox.Show(ex.Message);
            }
            //this.studentsBindingSource.EndEdit();
           // DataTable dd = (DataTable)cTKDBDataSet.Students;
           // EOB.Database.Processing.Merge(  ref dd,(DataTable) dt, "StudentID");
            
           //// cTKDBDataSet.Students.Merge(dt);
           // Data.CTKDBDataSetTableAdapters.StudentsTableAdapter sta = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
           // sta.Update(cTKDBDataSet);
           // this.tableAdapterManager.UpdateAll(this.cTKDBDataSet);
            

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            //long courseID = Convert.ToInt64(iDTextBox.Text);
            //Data.CTKDBDataSet.StudentsDataTable sdt = BL.GetStudentsByCourseCode(codeTextBox.Text);

            //DG_students.DataSource = sdt;
           // DG_students.DataSource = BL.GetStudentListFromMasterTable(codeTextBox.Text);
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Task: Adding course name to the export file
            if (!BL.ValidatePassKey())
            {
                MessageBox.Show("لابد من أدخال مفتاح تشغيل قبل تخزين الملفات");

            }
            else
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.xlsx)|*.XLSX";
                sfd.FileName = code + "-SecreteNumbers";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // DataTable dt = BL.MapMasterToBasicSecreteNumberTable((DataTable)DG_students.DataSource);
                    DataTable dt = (DataTable)DG_students.DataSource;
                    EOB.IO.ExcelFile.WriteDataTable_PP (sfd.FileName, dt);
                    if (MessageBox.Show("Do you want to protect the file using the passkey? ","Question", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        EOB.IO.ExcelFile.protect(sfd.FileName, "-", "-", Properties.Settings.Default.PassKey);
                        MessageBox.Show("Success");
                    }
                    
                    //EOB.IO.ExcelFile ff = new EOB.IO.ExcelFile(sfd.FileName);
                    ////ff.WriteTable(dt,);
                    //ff.Close();
                }
            }
            
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            //string code = BL.GetCourseCode(CBX_CourseName.Text);
            //DG_students.DataSource = BL.GetStudentListFromMasterTable(code);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            //string code = BL.GetCourseCode(CBX_CourseName.Text);
            //DG_students.DataSource = BL.GetStudentListFromMasterTable(code);
        }

        private void DG_students_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private string tempbuffer = string.Empty;
        private string tempbuffer3 = string.Empty;
        private void DG_students_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string code = BL.GetCourseCode(CBX_CourseName.Text);
            if (e.ColumnIndex == 0)
            {
                if (!BL.ApproveEditSecreteNumbers(code))
                {
                    tempbuffer = DG_students[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
                
            }

            if (e.ColumnIndex == 3)
            {
                tempbuffer3 = DG_students[e.ColumnIndex, e.RowIndex].Value.ToString();
                DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                c.Items.Add("ح");
                c.Items.Add("غ ع");
                c.Items.Add("غ");
               

                DG_students[e.ColumnIndex, e.RowIndex] = c;
            }
        }

        private void DG_students_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tempbuffer.Trim().Length > 0)
            {
                DG_students[e.ColumnIndex, e.RowIndex].Value = tempbuffer;
                tempbuffer = "";
            }
            if (e.ColumnIndex == 3)
            {
                string currentEntry = DG_students[e.ColumnIndex, e.RowIndex].Value.ToString();
               

            }

        }

        private void BTN_ManualEntry_Click(object sender, EventArgs e)
        {
            try
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                if (!BL.IsNULLSSID(code))
                {
                    if (MessageBox.Show("يوجد بالفعل ارقام سرية لهذا المقرر. انت بصدد مسح هذه الارقام و استبدالها بأرقام أخرى. في هذه الحالة لا يمكن الرجوع مرة اخرى و لا يمكن ربط الارقام القديمة بكشوف رصد التحريري بشكل تلقائي. هل تريد الاستمرار؟ ", "إحذر", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MessageBox.Show("سيتم التغيير الان هل انت متأكد؟", "تحذير نهائي", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            throw new Exception("لم يحدث تغيير الارقام السرية");
                        }
                    }
                    else
                    {
                        throw new Exception("لم يحدث تغيير الارقام السرية");
                    }
                }

                Dialogs.SecreteNumbersEntryDLG dl = new Dialogs.SecreteNumbersEntryDLG();
                if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   
                    CTK.Data.InternalDS.SecreteNumbersDTDataTable dt = dl.SecreteNumbersTable;
                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("لا يوجد ارقام سرية او حدث خطاء في توليد الارقام السرية");
                    }
                   
                    DataTable dtt = (DataTable)DG_students.DataSource;
                    int count = dtt.Rows.Count;

                    //string[] buffer = EOB.Arrays.Processing.PsedoNumberGenerator(start, count);

                    for (int i = 0; i < count; i++)
                    {
                        string StudentID = DG_students["رقم الجلوس", i].Value.ToString();
                        DataRow[] buff = dt.Select("STudentID = '"+StudentID+"'");
                        CTK.Data.InternalDS.SecreteNumbersDTRow dr =(CTK.Data.InternalDS.SecreteNumbersDTRow) buff[0];
                        DG_students["الرقم السري", i].Value = dr.SecreteNumber ;
                        //Data.CTKDBDataSet.StudentsRow r = dt[i];
                        //r.StudentSID = buffer[i];
                    }

                    BL.UpdateMasterTable_SecreteNumbers(dt, code);
                }
            }
            catch (Exception ex)
            {

                
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                // Announce delete
                if (MessageBox.Show("Course " + code + " will be removed from Database, do you want to continue?", "تنويه", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Find Course ID
                    string CourseID = code;
                    // Delete course by ID from Master Table
                    int res = BL.RemoveCourse(CourseID);
                    if (res == 0)
                    {
                        EOB.EOBLog.ReportInfo(this, "لا شئ تم حذفه من قاعدة البيانات للمادة " + CourseID);
                    }
                    // Delete course by ID from Course Table
                }
                this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);
                DG_students.DataSource = BL.GetStudentListFromMasterTable(code);

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_BarCodeExport_Click(object sender, EventArgs e)
        {
            try
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                Data.CTKDBDataSet.StudentsDataTable dt = BL.GetStudentsByCourseCode(code);
                EOB.Windows.Forms.ShowWaitDialog();
                int prcnt = 0;
                int idx = 0;
                foreach (Data.CTKDBDataSet.StudentsRow st in dt.Rows)
                {
                    prcnt = Convert.ToInt32(Convert.ToDouble(idx++ * 100) / Convert.ToDouble(dt.Rows.Count));
                    Data.CTKDBDataSet.MasterRow mr = BL.GetMasterRecord(code, st.StudentID);
                    //if (mr.SSID == null | mr.SSID.Trim().Length == 0)
                    //{
                        //mr.SSID = BL.GetNextBarCode();

                        mr.SSID = BL.GetNextBarCode(mr.CourseID, mr.StudentID);
                        mr.Status = "ح";
                        int n = BL.UpdateMasterTable(mr);
                        if (n == 0)
                        {
                            EOB.EOBLog.ReportError(this, "Failed to update the master table with new barcode for student = " + mr.StudentID + " and course = " + mr.CourseID);
                        }
                    //}
                    Application.DoEvents();
                    EOB.Windows.Forms.ReportProgress(prcnt);
                }
                int N = BL.UpdateBarCodeHasheTable();
                EOB.EOBLog.ReportInfo(this, N + " records are saved into BarCode Cache Table");
                // Refresh data bindings
                DG_students.DataSource = BL.GetStudentListFromMasterTable(code);
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
            EOB.Windows.Forms.ReportProgress(100);
        
        }

        private void BTN_ExportBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                BL.CourseCard CourseCardRecord = BL.GetCourseCard(BL.GetCourseCode(CBX_CourseName.Text));
                // For the course being active on display, it is required to export sheets for Barcode
                Dialogs.DLGPrintBarCode dlg = new Dialogs.DLGPrintBarCode();
                dlg.CourseName = CourseCardRecord.Name;
                dlg.CourseCode = CourseCardRecord.Code;
                
                dlg.ShowDialog();
                //BL.ExportBarCodeSheet(codeTextBox.Text.Trim());
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_DeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string code = BL.GetCourseCode(CBX_CourseName.Text);
                // Announce delete
                if (MessageBox.Show("Course " + code + " will be removed from Database, do you want to continue?", "تنويه", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Find Course ID
                    string CourseID = code;
                    // Delete course by ID from Master Table
                    int res = BL.RemoveCourse(CourseID);
                    if (res == 0)
                    {
                        EOB.EOBLog.ReportInfo(this, "لا شئ تم حذفه من قاعدة البيانات للمادة " + CourseID);
                    }
                    // Delete course by ID from Course Table
                }
                this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);
                CBX_CourseName.Items.Clear();
                CBX_CourseName.Items.AddRange(BL.GetCoursesList());
                DG_students.DataSource = BL.GetStudentListFromMasterTable(code);

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void CBX_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string courseCode = BL.GetCourseCode(CBX_CourseName.Text);
            DG_students.DataSource = BL.GetStudentListFromMasterTable(courseCode);

        }
    }
}
