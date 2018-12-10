using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
using CTK;
namespace CTK.Tools
{
    public partial class DBExamImportUsingBarCode : Form
    {
        public enum OperationMode
        {
            FirstEntry,
            SecondEntry,
            AttendanceEntry
        }

        private bool m_bAttendanceRegistred;
        private bool m_bNoMissingentries;
        private bool m_bNoMismatch;
        private OperationMode m_nMode;
        private CTK.Data.CTKDBDataSet.MasterDataTable m_objMasterTable;
        public readonly CTK.MessageBoxWrapper MessageBox1;

        public DBExamImportUsingBarCode()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        void  InitializeComponentEX()
        {
            try
            {
                EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
                m_nMode = new OperationMode();
                SetMode(OperationMode.FirstEntry);
                CBX_CourseName.Items.AddRange(BL.GetCoursesList());
                m_objMasterTable = BL.GetMasterTable();
                UpdateGUI();

            }
            catch (Exception ex)
            {

                LogScreen.Print(ex.Message);
            }
        }
        

        void UpdateGUI()
        {
            this.DG_CourseSheet.DefaultCellStyle.Font = new Font("Tahoma", 15);

        }
        void SetMode(OperationMode mode )
        {
            try
            {
                m_nMode = mode;

                switch(m_nMode )
                {

                    case OperationMode.AttendanceEntry:

                        RB_RegAttendnace.Checked = true;
                        LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد الغياب");
                        break;

                    case OperationMode.FirstEntry:

                        RB_REG_First.Checked = true;
                        LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد أول");
                        break;

                    case OperationMode.SecondEntry:
                        RB_REG_Second.Checked = true;
                        LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد ثاني");
                        break;
                }
               
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                LogScreen.Print(Message);
            }
            catch (Exception ex)
            {

                LogScreen.Print(ex.Message);
            }
        }
        /// <summary>
        /// Gets or sets the filename of the File to store the final excel sheet.
        /// </summary>
        public string FileName
        {
            get
            {
                //Task: construct the file name from the course code as it was in the previous version
                //هنص103مبادئ الإدارة دفعة  اولى_Final
                string CourseCode = CBX_CourseName.Text.Trim().Split(':')[0];
                BL.CourseCard cc = BL.GetCourseCard(CourseCode);
                string file =cc.Code+ cc.Name + "_Final";
                return file;
            }
           
        }

        /// <summary>
        /// Gets the datatable which contain the final marks
        /// </summary>
        public DataTable Data
        {
            get
            {
                DataTable dt = new DataTable();
                try
                {
                    dt.Columns.Add("رقم الجلوس");
                    dt.Columns.Add("الرقم السري");
                    dt.Columns.Add("إسم الطالب");
                    dt.Columns.Add("الدرجة");
                    dt.Columns.Add("الحالة");

                    for (int i = 0; i < DG_CourseSheet.Rows.Count; i++)
                    {
                        DataRow r = dt.NewRow();
                        r["رقم الجلوس"] = DG_CourseSheet[1, i].Value;
                        r["الرقم السري"] = "";
                        r["إسم الطالب"] = DG_CourseSheet[2, i].Value;
                        r["الدرجة"] = DG_CourseSheet[5, i].Value;
                        r["الحالة"] = DG_CourseSheet[3, i].Value;
                        dt.Rows.Add(r);
                    }

                  

                }
                catch (Exception ex)
                {

                    LOG.ReportError(this, ex.Message);
                }
                return dt;
               
            }
           
        }

        /// <summary>
        /// Gets status of the database. True in case of no mismatch and all attendance are registered
        /// </summary>
        public bool DataStatus
        {
            get
            {
                if (m_bAttendanceRegistred && m_bNoMismatch && m_bNoMissingentries)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        private void barcodeTextBox1_OnNewBarcodeRecived(object Sender, string BarCode)
        {

            try
            {
               
                Data.CTKDBDataSet.MasterRow r = BL.GetMasterRowBySSID(m_objMasterTable, BarCode.Substring(0, 11));
                BL.CourseCard cc = BL.GetCourseCard(r.CourseID);
                TB_TempFileName.Tag = cc;
                BL.StudentCard sc = BL.GetStudentCard(r.StudentID);
                //Check if the received Barcode belongs to the currently active course
                string CourseCode = CBX_CourseName.Text.Trim().Split(':')[0];
                string CourseName = CBX_CourseName.Text.Trim().Split(':')[1];
                if (CourseCode == cc.Code)
                {

                    LBL_StudentName.Tag = sc;

                    LBL_StudentName.Text = sc.Name;
                    TB_Mark.Focus();
                    this.Invalidate();
                }
                else
                {
                    MessageBox.Show("هذا الباركود لاينتمي الى المادة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("هذا الباركود لاينتمي الى المادة " + CourseName);
                }
                

            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
            
        }

        private void TB_Mark_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        bool ValidateMark(int Mark)
        {
            bool res = true;
            //Task: Check mark value
            return res;
        }
       /// <summary>
       /// When user enters barcode 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void TB_Mark_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                
                if (TB_Mark.Text.Trim().Length > 3)
                {
                    TB_Mark.Text = string.Empty;
                    MessageBox.Show("لم يتم ادخال الرصد. رجاء  ادخال الدرجة و الضغط على زر ادخال قبل ادخال درجة جديدة","إحذر", MessageBoxButtons.OK);
                    TB_Mark.Focus();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    BL.StudentCard sc = (BL.StudentCard)LBL_StudentName.Tag;
                    DataRow[] buf = internalDS.MarkEntryTable.Select("StudentID = " + sc.StudentID);
                    if (m_nMode == OperationMode.FirstEntry || m_nMode == OperationMode.SecondEntry)
                    {
                        int mark = Convert.ToInt32(TB_Mark.Text);
                        if (ValidateMark(mark))
                        {
                            // Mark is validated


                            if (buf.Length == 1)
                            {
                                CTK.Data.InternalDS.MarkEntryTableRow r = (CTK.Data.InternalDS.MarkEntryTableRow)buf[0];
                                switch (m_nMode)
                                {
                                    case OperationMode.FirstEntry:
                                        r.FirstEntry = mark;
                                        break;
                                    case OperationMode.SecondEntry:

                                        try
                                        {
                                            int temp = r.FirstEntry;
                                        }
                                        catch (StrongTypingException exx)
                                        {
                                            MessageBox.Show("لابد من عمل الادخال الأول قبل الادخال الثاني");
                                            SetMode(OperationMode.FirstEntry);
                                            break;
                                        }
                                       
                                        if (r.FirstEntry != mark)
                                        {
                                            MessageBox.Show("يوجد عدم تطابق مع الادخال الاول. لابد من ادخال هذه الدرجة مرة اخرى. من فضلك نحي هذه الكراسة جانبا لادخالها مرة اخرى لاحقا ادخال اول و ثاني");
                                            //MessageBox.Show("")
                                           
                                            //r.SecondEntry =  r.FirstEntry = -1;
                                            r.Review = 3;

                                            DG_CourseSheet.Invalidate();
                                            
                                        }
                                        else
                                        {
                                            r.SecondEntry = mark;
                                        }

                                        break;
                                    case OperationMode.AttendanceEntry:
                                        r.Status = TB_Mark.Text;
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (buf.Length == 1)
                        {
                            CTK.Data.InternalDS.MarkEntryTableRow r = (CTK.Data.InternalDS.MarkEntryTableRow)buf[0];
                            //Task : read the attendance status from RBs
                            //r.Status = TB_Mark.Text;
                            r.Status = (RB_Absent.Checked ? RB_Absent.Text : RB_Execused.Text);
                        }
                    }
                    UC_BarCodeControl.Focus();
                    TB_Mark.Text = "";
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataStatus == true)
                {
                    if(!BL.UpdateMasterTable(internalDS.MarkEntryTable))
                    {
                        string msg = string.Format("المادة تم رصدها و لكن لا يمكن اخراجها الي نظام MIS");
                        MessageBox.Show(msg, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                   
                    if (MessageBox.Show("لم تتم المراجعة. هل تريد انهاء الرصد؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!this.Validate())
                        {
                            if (MessageBox.Show("يوجد رصد لم يتم حفظه. هل تريد انهاء الرصد؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                this.DialogResult = System.Windows.Forms.DialogResult.No;
                                this.Close();
                            }
                            else
                            {
                                LOG.ReportInfo(this, "لم يتم الخروج من الرصد. ");
                            }
                        }
                        else
                        {
                            // No data to save. it is ok to exit.
                            this.DialogResult = System.Windows.Forms.DialogResult.No;
                            this.Close();
                        }
                    }
                    else
                    {

                    }
                }
                
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void RB_REG_First_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GB_ReportMark.Visible = RB_REG_First.Checked || RB_REG_Second.Checked;
                GB_ReportStatus.Visible = RB_RegAttendnace.Checked;
                if (RB_REG_First .Checked) m_nMode = OperationMode.FirstEntry;
                LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد أول");
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void RB_REG_Second_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GB_ReportMark.Visible = RB_REG_First.Checked || RB_REG_Second.Checked;
                GB_ReportStatus.Visible = RB_RegAttendnace.Checked;
                if(RB_REG_Second.Checked) m_nMode = OperationMode.SecondEntry;
                LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد ثاني");
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void RB_RegAttendnace_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                GB_ReportMark.Visible = RB_REG_First.Checked || RB_REG_Second.Checked;
                GB_ReportStatus.Visible = RB_RegAttendnace.Checked;
                if (RB_RegAttendnace.Checked) m_nMode = OperationMode.AttendanceEntry;
                LOG.ReportInfo(this, "الحالة تغيرت الى " + "رصد الغياب");
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }
        /// <summary>
        /// Return true in case of the current loaded course has no entries
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            bool res = true;
            try
            {
                //FirstEntry
                //    SecondEntry

                //DataRow[] buf1 = internalDS.MarkEntryTable.Select("FirstEntry <> null");
                DataTable dt =  internalDS.MarkEntryTable.GetChanges();
                if (dt != null)
                {
                    res = false;
                }
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
            return res;
        }
        private void CBX_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                {
                    if (MessageBox.Show("يوجد مادة في الرصد و بها مدخلات. هل تريد تغيير المادة و فقد المخلات؟", "رسالة تحذير", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        throw new Exception("لم يتم تغيير المادة...");
                    }

                }
                string CourseCode = BL. GetCourseCode(CBX_CourseName.Text);
                DataTable dt = BL.GetDecodedMasterCourse(CourseCode);
                internalDS.MarkEntryTable.Clear();
                TB_TempFileName.Text = string.Empty;
                foreach (DataRow r in dt.Rows)
                {
                    CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
                    m.Name = r["إسم الطالب"].ToString();
                    m.StudentID = Convert.ToInt32(r["رقم الجلوس"]);
                    m.Status = r["الحالة"].ToString();
                    m.BarCode = r["الرقم السري"].ToString();
                    m.CourseCode = CourseCode;
                    internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
                }

                internalDS.MarkEntryTable.AcceptChanges();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }
       

        bool validateCellValue(int? value)
        {
            bool res = false;
            try
            {
                //task: complete the function and create unit test to check for the proper values that generates the required exceptions to catch the numeric values
                if (value != null)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
               
            }
            catch (FormatException fx)
            {
                res = false;
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// To register Attendance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                BL.StudentCard sc = (BL.StudentCard)LBL_StudentName.Tag;
                DataRow[] buf = internalDS.MarkEntryTable.Select("StudentID = " + sc.StudentID);
                CTK.Data.InternalDS.MarkEntryTableRow r = (CTK.Data.InternalDS.MarkEntryTableRow)buf[0];
                //Task : read the attendance status from RBs
                //r.Status = TB_Mark.Text;
                bool EditCell = false;
                if (RB_Absent.Checked)
                {
                    bool HasFirstEntry = false;
                    bool HasSecondEntry = false;
                    try
                    {
                        int x = r.FirstEntry;
                        HasFirstEntry = true;
                        
                    }
                    catch (Exception rx)
                    {

                        //Do nothing
                    }

                    try
                    {
                        int x = r.SecondEntry;
                        HasSecondEntry = true;
                       
                    }
                    catch (Exception rx)
                    {

                        //Do nothing
                    }


                    if (HasFirstEntry || HasSecondEntry)
                    {
                        if (MessageBox.Show("يوجد درجة لهذا الطالب. هل تريد المتابعة و رصد غياب له؟" ,"تنبيه" ,  MessageBoxButtons.YesNo , MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            EditCell = true;
                        }
                        else
                        {

                            EditCell = false;
                        }
                    }
                    else
                    {
                        EditCell = true ;
                    }
                    if (EditCell)
                    {
                        r.Status = RB_Absent.Text.Trim();
                        RB_Absent.Checked = false;
                        r.FirstEntry = r.SecondEntry = 0;
                    }
                   
                }
                else
                {
                    if (RB_Attended.Checked)
                    {

                        bool HasFirstEntry = false;
                        bool HasSecondEntry = false;
                        try
                        {
                            int x = r.FirstEntry;
                            HasFirstEntry = true;

                        }
                        catch (Exception rx)
                        {

                            //Do nothing
                        }

                        try
                        {
                            int x = r.SecondEntry;
                            HasSecondEntry = true;

                        }
                        catch (Exception rx)
                        {

                            //Do nothing
                        }


                        if (HasFirstEntry || HasSecondEntry)
                        {
                            if (MessageBox.Show("يوجد درجة لهذا الطالب. هل تريد المتابعة و رصد غياب له؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                EditCell = true;
                            }
                            else
                            {

                                EditCell = false;
                            }
                        }
                        else
                        {
                            EditCell = true;
                        }
                        if (EditCell)
                        {
                            r.Status = RB_Attended.Text.Trim();
                            RB_Attended.Checked = false;
                            r.FirstEntry = r.SecondEntry = 0; 
                        }
                    }
                    else
                    {
                        if (RB_Execused.Checked)
                        {
                            bool HasFirstEntry = false;
                            bool HasSecondEntry = false;
                            try
                            {
                                int x = r.FirstEntry;
                                HasFirstEntry = true;

                            }
                            catch (Exception rx)
                            {

                                //Do nothing
                            }

                            try
                            {
                                int x = r.SecondEntry;
                                HasSecondEntry = true;

                            }
                            catch (Exception rx)
                            {

                                //Do nothing
                            }

                            if (HasFirstEntry || HasSecondEntry)
                           // if ( || !System.DBNull.Value.Equals(r.SecondEntry))
                            
                            {
                                if (MessageBox.Show("يوجد درجة لهذا الطالب. هل تريد المتابعة و رصد غياب له؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    EditCell = true;
                                }
                                else
                                {

                                    EditCell = false;
                                }
                            }
                            else
                            {
                                EditCell = true;
                            }
                            if (EditCell)
                            {
                                r.Status = RB_Execused.Text.Trim();
                                RB_Execused.Checked = false;
                                r.FirstEntry = r.SecondEntry = 0; 
                            }
                        }
                    }
                }

                UC_BarCodeControl.Focus();
               
            }
            catch (NullReferenceException exx)
            {
                LOG.ReportError(this, "لابد من الضغط على زر ادخال الباركود و ان يتم اختيار طالب قبل ادخال الغياب");
                MessageBox.Show("لابد من الضغط على زر ادخال الباركود و ان يتم اختيار طالب قبل ادخال الغياب", "تبيه", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void DG_CourseSheet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                    if (DG_CourseSheet.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
                    {
                        if (DG_CourseSheet[e.ColumnIndex, e.RowIndex].Value.ToString() != "ح")
                        {
                            DG_CourseSheet[4, e.RowIndex].Value = DG_CourseSheet[5, e.RowIndex].Value = 0;
                        }
                    }
               
                //if (e.ColumnIndex > 0)
                //{
                ////    int val = (int)DG_CourseSheet[e.ColumnIndex, e.RowIndex].Value;
                ////    if (val < 0)
                ////    {
                ////        DG_CourseSheet[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.OrangeRed;
                ////    }
                ////    else
                ////    {
                ////        DG_CourseSheet[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                ////    }
                //    int x = 5;
                //}
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
            
        }

        private void BTN_FinalReview_Click(object sender, EventArgs e)
        {
            string CourseCode = CBX_CourseName.Text.Trim().Split(':')[0];
            
            BL.ReviewFinalMarks(CourseCode,ref m_bNoMissingentries,ref m_bNoMismatch,ref m_bAttendanceRegistred,ref internalDS,MessageBox1);

            if (DataStatus == true)
            {
                MessageBox.Show("تمت المطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            #region Color Legend
            for (int i = 0; i < DG_CourseSheet.Rows.Count; i++)
            {
                int cv = (Int32)DG_CourseSheet[0, i].Value;
                switch (cv)
                {
                    case 1:
                        DG_CourseSheet[0, i].Style.BackColor = Color.Green;
                        break;
                    case 2:
                        DG_CourseSheet[0, i].Style.BackColor = Color.Yellow;
                        break;
                    case 3:
                        DG_CourseSheet[0, i].Style.BackColor = Color.Red;
                        break;

                    case 4:
                        DG_CourseSheet[0, i].Style.BackColor = Color.Orange;
                        break;
                }

            }
            #endregion


        
  

        }
        

     /*  private void ReviewFinalMarks(string CourseCode,DataGridView DG,bool m_bNoMissingentries)
        {
            try
            {
                
                if(CourseCode.Length==0)
 //               if (CBX_CourseName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("لا يوجد مادة لعمل المراجعة. رجاء ادخال المادة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LOG.ReportError(this, "لم يتم اختيار مادة قبل طلب المراجعة");
                    throw new Exception("لم يتم اختيار مادة قبل طلب المراجعة");
                }

                for (int i = 0; i < internalDS.MarkEntryTable.Rows.Count; i++)
                {
                    internalDS.MarkEntryTable[i].Review = 1;
                }

                #region Review for Missing Mark Entries
                DataRow[] buffer = internalDS.MarkEntryTable.Select("Firstentry is null or SecondEntry is null");

                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد بعض الدرجات  لم يتم رصدها سيتم تظليل الخلايا في الجدول باللون الاصفر ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 2;
                    }
                    m_bNoMissingentries = false;
                }
                else
                {
                    m_bNoMissingentries = true;

                }
                #endregion


                #region Check Logic Values


                buffer = internalDS.MarkEntryTable.Select("Firstentry < 0 or SecondEntry < 0");

                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد بعض الدرجات  اصغر من  0  سيتم تظليلها في الجدول باللون البرتقالي ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 4;
                    }
                    m_bNoMissingentries = false;
                }
                else
                {
                    m_bNoMissingentries = true;

                }

                #endregion



                #region Review for Mark mismatch

                buffer = internalDS.MarkEntryTable.Select("Firstentry <> SecondEntry ");
                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد عدم تطابق بين الرصدين الاول و الثاني سيتم تظليل الخلايا في الجدول باللون الاحمر ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 3;
                    }
                    m_bNoMismatch = false;
                }
                else
                {
                    m_bNoMismatch = true;
                }
                #endregion

                #region Review for Missing Attendnace
                // For now it is inherently calculated in Review for missing mark entries
                m_bAttendanceRegistred = true;
                #endregion


                if (DataStatus == true)
                {
                    MessageBox.Show("تمت المطابقة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                #region Color Legend
                for (int i = 0; i < DG_CourseSheet.Rows.Count; i++)
                {
                    int cv = (Int32)DG_CourseSheet[0, i].Value;
                    switch (cv)
                    {
                        case 1:
                            DG_CourseSheet[0, i].Style.BackColor = Color.Green;
                            break;
                        case 2:
                            DG_CourseSheet[0, i].Style.BackColor = Color.Yellow;
                            break;
                        case 3:
                            DG_CourseSheet[0, i].Style.BackColor = Color.Red;
                            break;

                        case 4:
                            DG_CourseSheet[0, i].Style.BackColor = Color.Orange;
                            break;
                    }

                }
                #endregion


            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }*/

        private void BTN_SaveTempFile_Click(object sender, EventArgs e)
        {
            try
            {
                string TempFileName = string.Empty;
                //if (TB_TempFileName.Text.Trim().Length > 0)
                //{
                    
                //    if (!System.IO.File.Exists(TB_TempFileName.Text.Trim()))
                //    {
                //        // File is deleted or moved from its previous location.
                //        SaveFileDialog sf = new SaveFileDialog();
                //        BL.CourseCard cc = BL.GetCourseCard(CBX_CourseName.Text.Trim());
                //        sf.FileName = cc.Code + cc.Name + "_Temp";
                //        sf.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                //        if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //        {
                //            TempFileName = sf.FileName;
                //        }
                //        else
                //        {
                //            // user wants to cancel operation
                //            throw new Exception(". لم يتم الحفظ .لقد تم الغاء العملية");
                //        }
                //    }
                //    else
                //    {
                //        // File already exists
                       
                //        TempFileName = TB_TempFileName.Text.Trim();
                //        System.IO.File.Delete(TempFileName);
                //    }
                //}
                //else
                //{
                //    // First time, file doesn't exist
                //    SaveFileDialog sf = new SaveFileDialog();
                //    BL.CourseCard cc = BL.GetCourseCard(CBX_CourseName.Text.Trim());
                //    sf.FileName = cc.Code + cc.Name + "_Temp";
                //    sf.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                //    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //    {
                //        TempFileName = sf.FileName;
                //    }
                //}


                SaveFileDialog sf = new SaveFileDialog();
                string CourseCode = CBX_CourseName.Text.Trim().Split(':')[0];
                BL.CourseCard cc = BL.GetCourseCard(CourseCode);
                sf.FileName = cc.Code + cc.Name + "_Temp";
                sf.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TempFileName = sf.FileName;
                }

                EOB.IO.ExcelFile.WriteDataTable_PP(TempFileName, internalDS.MarkEntryTable);
                internalDS.MarkEntryTable.AcceptChanges();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_LoadTempfile_Click(object sender, EventArgs e)
        {
            try
            {
                bool AllowLoading = true;
                if (internalDS.MarkEntryTable.Rows.Count > 0)
                {
                    AllowLoading = false;
                    if (MessageBox.Show("احذر يوجد مادة في حالة الرضد الان. هل تريد فعلا تحميل ماده اخرى و الغاء المادة الحالية ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        AllowLoading = true;
                    }
                    else
                    {
                        AllowLoading = false;
                    }
                }
                if (AllowLoading)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = "Untitled";
                    ofd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //Loading the file
                       // internalDS.MarkEntryTable = (CTK.Data.InternalDS.MarkEntryTableDataTable) EOB.IO.ExcelFile.Read(ofd.FileName);
                       DataTable dt =  EOB.IO.ExcelFile.Read(ofd.FileName);
                       if (dt.Rows.Count > 0)
                       {
                           string oldval = TB_TempFileName.Text;
                           string Code = dt.Rows[0]["CourseCode"].ToString().Trim();
                           BL.CourseCard c = BL.GetCourseCard(Code);
                           if (c.Code == null || c.Name == null)
                           {
                               MessageBox.Show("هذه المادة لا توجد في قاعدة البيانات");
                               throw new Exception("هذه المادة لا توجد في قاعدة البيانات");
                           }
                           CBX_CourseName.Text = c.Code+":"+c.Name;
                           
                           //In this step the table is automatically loaded to data grid using the event of index change in the combo box.
                           TB_TempFileName.Text = oldval;
                       }
                       else
                       {
                           throw new Exception("The file doesn't contain a valid data");
                       }

                        internalDS.MarkEntryTable.Clear();

                        
                        foreach (DataRow r in dt.Rows)
                        {
                            CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
                           
                            m.Name = r["Name"].ToString();
                            m.StudentID =Convert.ToInt32( r["StudentID"]);
                            m.Status = r["Status"].ToString();
                            m.BarCode = r["BarCode"].ToString();
                            try
                            {
                                m.FirstEntry = Convert.ToInt32(r["FirstEntry"]);
                            }
                            catch (Exception x1)
                            {
                                
                                
                            }
                            try
                            {
                                m.SecondEntry = Convert.ToInt32(r["SecondEntry"]);
                            }
                            catch (Exception)
                            {

                                
                            }
                            try
                            {
                                m.Review = Convert.ToInt32(r["Review"]);
                            }
                            catch (Exception)
                            {
                                
                                
                            }
                            m.CourseCode = r["CourseCode"].ToString();
                            internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
                        }
                        internalDS.MarkEntryTable.AcceptChanges();
                        TB_TempFileName.Text = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show("لقد تم الغاء التحميل", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("لقد تم الغاء التحميل", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void CHB_EnableEditing_CheckedChanged(object sender, EventArgs e)
        {
            DG_CourseSheet.Enabled = CHB_EnableEditing.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DG_CourseSheet.Enabled = CHB_EnableEditing.Checked;
                if (!DG_CourseSheet.Enabled)
                {
                    DG_CourseSheet.ClearSelection();
                }
                //DG_CourseSheet.Refresh();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void DG_CourseSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DG_CourseSheet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
