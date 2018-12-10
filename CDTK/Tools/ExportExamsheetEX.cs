using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
namespace CTK.Tools
{
    public partial class ExportExamsheetEX : Form
    {
        private string m_strResultsFolder;
        private EOB.Reports.MisMatch m_objMismatchReport;
        private DataTable m_objDT_Results;
        private string m_strClass;
        private string m_strCourseName;
        private string m_strActivityFile;
        private string m_strFinalFile;
        private string m_strAcademicYear;
        public ExportExamsheetEX()
        {
            InitializeComponent();
            InitializeComponentEX();
        }

        private void InitializeComponentEX()
        {
            try
            {
                m_objMismatchReport = new EOB.Reports.MisMatch();
                LOG.LogMessage += new EOB.EventLogHandler(LOG_LogMessage);
                UC_Tool.UC_Filter = "Excel 2003 *.xls|*.xlsx";
                string temp = UC_Tool.UC_RootFolder;
                m_objDT_Results = new DataTable("Results");
                CreateTableStructureForResults();
                if(!System.IO.Directory.Exists(UC_Tool.UC_RootFolder+@"\Results"))
                {
                    System.IO.Directory.CreateDirectory(UC_Tool.UC_RootFolder + @"\Results");
                    m_strResultsFolder = UC_Tool.UC_RootFolder + @"\Results";
                    LOG.ReportInfo(this, m_strResultsFolder + " is created");
                }
               
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        private void SaveMismatch()
        {
            try
            {
                string Folder = UC_Tool.UC_RootFolder+@"\Reports";
                if(!System.IO.Directory.Exists(Folder))
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    UC_Tool.Print(Folder+" is created...");

                }
                string File = Folder + @"\Mismatch_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".xlsx";
                m_objMismatchReport.Save(File);
                UC_Tool.Print("Mismatch file is created in " + File);
            }
            catch (Exception ex)
            {

                LOG.ReportError(this,"!"+ ex.Message);
            }
        }
        void LOG_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                if (Message[1] == "Error")
                {
                    throw new Exception(Message[0]);
                }
                m_objMismatchReport.Add("LOG", Message[0], "ExportExamSheets");
                UC_Tool.Print(Message); 
            }
            catch (Exception ex)
            {
                m_objMismatchReport.Add("!LOG", Message[0], "ExportExamSheets");
                UC_Tool.Print(ex.Message);
            }
        }
        private void bulkFileProcessorStandardTool1_UC_Button1Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {

                LOG.ReportError(this,"!"+ ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                this.Close();
            }
        }
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bulkFileProcessorStandardTool1_UC_Initialize(object sender, EventArgs e)
        {
            try
            {
                LOG.ReportInfo(this, "Start at " + DateTime.Now.ToString());
                m_objDT_Results = new DataTable("Results");
                CreateTableStructureForResults();
                LOG.ReportInfo(this, "The cache database is cleared...");
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }
        /// <summary>
        /// Save Path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bulkFileProcessorStandardTool1_UC_SavePathClicked(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.WorkingFolder = UC_Tool.UC_RootFolder;
                Properties.Settings.Default.Save();
                UC_Tool.Print(Properties.Settings.Default.WorkingFolder + " is saved for future usage");
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        BL.CourseCard m_objCourseCard;
         private bool Validate(string file)
        {
            bool res = true;
            try
            {
                m_strCourseName= m_strAcademicYear= m_strClass =  m_strActivityFile = m_strFinalFile = string.Empty;
                //Rule1: is not mismatch report
                string Folder = System.IO.Path.GetDirectoryName(file);
                string xf = System.IO.Path.GetFileName(Folder).Trim().ToUpper();
                if (xf == "REPORTS" || xf == "RESULTS")
                {
                    throw new Exception(file+ " is a mismatch report not valid exam or activity file");
                }

                //Rule2: Naming convention Check
                string masterfile = System.IO.Path.GetFileNameWithoutExtension(file);
                string[] buffer = BL.GetCourseInformation(masterfile);
                if (buffer.Length != 4)
                {
                    m_objMismatchReport.Add("FILE", masterfile + " it seems is not in the format", "Validation");
                    throw new Exception(file + ": name  is not in the proper format or is not valid Activity file.");
                }
                m_strFinalFile = System.IO.Path.GetDirectoryName(file) + @"\" +buffer[0]+ buffer[1] + "_Final.xlsx";
                //Rule3: Check the availability of the final gradings file
                if (!System.IO.File.Exists(m_strFinalFile))
                {
                    m_objMismatchReport.Add("FILE", m_strFinalFile + " doesn't exist or " + file + " is in wrong format. make sure that the final file is exact match with the Activity file. Check spaces into the file name it must in match with the file name of the activity file. For example [كهع212كقهندسة ميكانيكية 2 دفعة  تانية هندسة القوى والالات الكهربية_Final] and [مادة--كهع212كق-هندسة ميكانيكية 2  دفعة  تانية هندسة القوى والالات الكهربية-الترم الاول-2013] are not matching. There is space after the name of course should be inserted in the final file in order to match with the activity file name", "Validation");
                    throw new Exception(m_strFinalFile +" doesn't exist");
                }
                m_strActivityFile = file;
                string[] splitters = { "دفعة" };
                string[] buf2 = buffer[1].Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                //Rule4: Naming convension
                if (buf2.Length != 2)
                {
                    m_objMismatchReport.Add("FILE", masterfile + " is not in the standard format , the part after course code should contains the Arabic word دفعة splitter between course name and class name", "Validation");
                }
                m_objCourseCard = BL.GetCourseCard(buffer[0].Trim());
                m_strCourseName = buf2[0].Trim();
                m_strClass = buf2[1].Trim();
                
                m_strAcademicYear = buffer[2]+"_" +buffer[3];
            }
            catch (Exception ex)
            {
                res = false;
                LOG.ReportError(this, "!" + ex.Message);

            }
            return res;
        }
        private void CreateTableStructureForResults()
        {
            try
            {

                DataColumn  c = new DataColumn("Class");
                c.Caption = "السنة الدراسية";
                m_objDT_Results.Columns.Add(c);


                c = new DataColumn("Year");
                c.Caption = "العام الدراسي";
                m_objDT_Results.Columns.Add(c);


                c = new DataColumn("BN");
                c.Caption ="رقم الجلوس";
                m_objDT_Results.Columns.Add(c);

                c = new DataColumn("Student");
                c.Caption = "اسم الطالب";
                m_objDT_Results.Columns.Add(c);
              
                
                
              }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private string GetRank(double Percentage)
        {
            string res = string.Empty;
            try
            {
                if (Percentage < 30)
                {
                    res = "ض ج";
                }
                if (Percentage >= 30 && Percentage < 50)
                {
                    res = "ض";
                }
                if (Percentage >= 50 && Percentage <65)
                {
                    res = "ل";
                }
                if (Percentage >= 65 && Percentage < 75)
                {
                    res = "ج";
                }
                if (Percentage >= 75 && Percentage < 85)
                {
                    res = "ج ج";
                }
                if (Percentage >= 85 )
                {
                    res = "م";
                }
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
            }
            return res;
        }
        private void Finalize()
        {
            try
            {
                for (int i = 4; i < m_objDT_Results.Columns.Count; i++)
                {
                    try
                    {
                         
                        string columnname = m_objDT_Results.Columns[i].ColumnName;
                        m_objDT_Results.Columns[i].ColumnName = "F" + i;
                        DataRow[] buf = m_objDT_Results.Select("F"+i + " is null");

                        foreach (DataRow r in buf)
                        {
                            r[i] = "معفى";
                        }
                        m_objDT_Results.Columns[i].ColumnName = columnname;
                    }
                    catch (EvaluateException xx)
                    {
                        continue;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        /// <summary>
        /// Compile all related exam results into single sheet for each class
        /// </summary>
        private void Compile()
        {
            try
            {
                DataTable finalDT = EOB.IO.ExcelFile.Read(m_strFinalFile);
                DataTable ActivityDT = EOB.IO.ExcelFile.Read(m_strActivityFile, "","A3:-");
                ActivityDT.Columns[0].ColumnName = "BN";
                finalDT.Columns[0].ColumnName = "BN";
                string ActivityAlia = "_" + "اعمال_السنة";
                string FinalAlias = "_" + "التحريري";
                //BL.CourseCard crd = BL.GetCourseCard(
                foreach (DataRow ar in ActivityDT.Rows)
                {
                    string BN = ar["BN"].ToString();
                    DataRow[] buf = finalDT.Select("BN = '"+BN+"'");
                    if (buf.Length == 1)
                    {
                        //Normal case , exits in Activity and in Final
                        try
                        {
                            string Status = buf[0][4].ToString().Trim();
                            double activity = 0;
                            try
                            {
                                activity = Convert.ToDouble(ar[3].ToString());
                            }
                            catch (Exception)
                            {

                                m_objMismatchReport.Add("Mark", "Activity Grade for student with BN = [" + BN + "] is not number in the course [" + m_objCourseCard.Name + "]. Check it", m_objCourseCard.Name);
                 
                            }

                           double final = 0;
                           try
                           {
                               final = Convert.ToDouble(buf[0][3].ToString());
                           }
                           catch (Exception)
                           {

                               m_objMismatchReport.Add("Mark", "Final exam Grade for student with BN = ["+BN+"] is not number in the course ["+m_objCourseCard.Name+"]. Check it", m_objCourseCard.Name);
                           }
                            double total = activity + final;
                            double CourseLimit =Convert.ToDouble( m_objCourseCard.LimitActivities+m_objCourseCard.LimitExam);
                            double Percentage = 0;
                            string Rank = string.Empty;
                            bool includeDetails = true;
                            try
                            {
                                
                                Percentage = Math.Round (total / CourseLimit * 100,2);
                                if (double.IsInfinity(Percentage))
                                {
                                    includeDetails = false;
                                    m_objMismatchReport.Add("Mark", "The limit of the course is not registered for the course ["+m_objCourseCard.Name+"]", "Compile");
                                }
                                else
                                {
                                    Rank = GetRank(Percentage);
                                }
                                
                            }
                            catch (Exception)
                            {

                                includeDetails = false;
                            }
                            
                            //1- Check if record is available for the given student
                            DataRow[] rbuff = m_objDT_Results.Select("BN ='"+BN+"'");
                            if (rbuff.Length == 1)
                            {
                                //Student already have course or more in the results

                                if (RB_FullDetails.Checked)
                                {
                                    if (!m_objDT_Results.Columns.Contains(m_strCourseName + ActivityAlia))
                                    {
                                        m_objDT_Results.Columns.Add(m_strCourseName + ActivityAlia);
                                    }
                                    if (!m_objDT_Results.Columns.Contains(m_strCourseName + FinalAlias))
                                    {
                                        m_objDT_Results.Columns.Add(m_strCourseName + FinalAlias);
                                    } 
                                }
                                if (!m_objDT_Results.Columns.Contains(m_strCourseName))
                                {
                                    m_objDT_Results.Columns.Add(m_strCourseName);
                                }
                                if (Status == "ح")
                                {
                                    if (RB_FullDetails.Checked)
                                    {
                                        rbuff[0][m_strCourseName + ActivityAlia] = activity.ToString();
                                        rbuff[0][m_strCourseName + FinalAlias] = final.ToString();
                                        
                                    } 
                                    rbuff[0][m_strCourseName] = total.ToString();
                                    if (includeDetails)
                                    {
                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_النسبة"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_النسبة");
                                        }
                                        rbuff[0][m_strCourseName + "_النسبة"] = Percentage.ToString();

                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_التقدير"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_التقدير");
                                        }
                                        rbuff[0][m_strCourseName + "_التقدير"] = Rank;
                                    }
                                }
                                else
                                {
                                    if (RB_FullDetails.Checked)
                                    {
                                        rbuff[0][m_strCourseName + ActivityAlia] = Status;
                                        rbuff[0][m_strCourseName + FinalAlias] = Status;
                                    }
                                    rbuff[0][m_strCourseName] = Status;
                                    if (includeDetails)
                                    {
                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_النسبة"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_النسبة");
                                        }
                                        rbuff[0][m_strCourseName + "_النسبة"] = Status;

                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_التقدير"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_التقدير");
                                        }
                                        rbuff[0][m_strCourseName + "_التقدير"] = Status;
                                    }
                                }
                                
                            }
                            else
                            {
                                //New record for the given BN 
                                #region Adding new student
                                DataRow r = m_objDT_Results.NewRow();
                                r["Class"] = m_strClass;
                                r["Year"] = m_strAcademicYear;
                                r["BN"] = BN;
                               // r["Course"] = m_strCourseName;
                                r["Student"] = ar[2].ToString();
                                if (RB_FullDetails.Checked)
                                {
                                    if (!m_objDT_Results.Columns.Contains(m_strCourseName + ActivityAlia))
                                    {
                                        m_objDT_Results.Columns.Add(m_strCourseName + ActivityAlia);
                                    }
                                    if (!m_objDT_Results.Columns.Contains(m_strCourseName + FinalAlias))
                                    {
                                        m_objDT_Results.Columns.Add(m_strCourseName + FinalAlias);
                                    } 
                                }
  
                                if (!m_objDT_Results.Columns.Contains(m_strCourseName))
                                {
                                    m_objDT_Results.Columns.Add(m_strCourseName);
                                }
                                if (Status == "ح")
                                {
                                    if (RB_FullDetails.Checked)
                                    {
                                        r[m_strCourseName + ActivityAlia] = activity.ToString();
                                        r[m_strCourseName + FinalAlias] = final.ToString();
                                    }
                                    r[m_strCourseName] = total.ToString();
                                    if (includeDetails)
                                    {
                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_النسبة"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_النسبة");
                                        }
                                        r[m_strCourseName + "_النسبة"] = Percentage.ToString();

                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_التقدير"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_التقدير");
                                        }
                                        r[m_strCourseName + "_التقدير"] = Rank;
                                    }
                                }
                                else
                                {
                                    if (RB_FullDetails.Checked)
                                    {
                                        r[m_strCourseName + ActivityAlia] = Status;
                                        r[m_strCourseName + FinalAlias] = Status;
                                    }
                                    r[m_strCourseName] = Status;
                                    if (includeDetails)
                                    {
                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_النسبة"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_النسبة");
                                        }
                                        r[m_strCourseName + "_النسبة"] = Status;

                                        if (!m_objDT_Results.Columns.Contains(m_strCourseName + "_التقدير"))
                                        {
                                            m_objDT_Results.Columns.Add(m_strCourseName + "_التقدير");
                                        }
                                        r[m_strCourseName + "_التقدير"] = Status;
                                    }
                                }
                               
                               

                                


                                m_objDT_Results.Rows.Add(r);
                                
                                #endregion
                            }

                         }
                        catch (Exception xx)
                        {

                            m_objMismatchReport.Add("Mark", "Student with bench number " + BN + " something wrong in his grades :" + xx.Message, m_strClass + "_" + m_strCourseName);
                        }

                    }
                    else
                    {
                        if (buf.Length == 0)
                        {
                            //Exist in Activity sheet but not in final. This is the case of missing from the final exam
                            m_objMismatchReport.Add("DB", "Student with bench number = " + BN + " exist in the class ["+m_strClass+"] but not in the final sheet.  " , m_objCourseCard.Name);
 
                        }
                        else
                        {
                            // More than one occurrences in final for the same student
                            m_objMismatchReport.Add("DB", buf.Length + "occurrences for student with bench number " + BN + " in the class " + m_strClass, m_objCourseCard.Name);
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        private void SaveResults()
        {
            try
            {
                if (m_objDT_Results.Rows.Count > 0)
                {
                    //Foreach class save result into results folder
                    string[] classes = EOB.Database.Processing.GetDistinct(m_objDT_Results, "Class" );
                    foreach (string cls in classes)
                    {
                        string filename = string.Empty;
                        
                        if (RB_FullDetails.Checked)
                        {
                            
                            filename = m_strResultsFolder + @"\" + cls + "_AdminSheets.xlsx";
                        }
                        else
                        {
                            filename = m_strResultsFolder + @"\" + cls + ".xlsx";
                        }
                        DataTable dt = EOB.Database.Processing.FilteredTable(m_objDT_Results, "Class ='"+cls+"'");
                        if (System.IO.File.Exists(filename))
                        {
                             retry:
                            try
                            {
                               
                                System.IO.File.Delete(filename);
                            }
                            catch (Exception ff)
                            {
                                MessageBox.Show("من فضلك اغلق الملف "+filename+" لاستكمال الحفظ و من ثم اضغط موافق");
                                goto retry;
                                LOG.ReportError(this, "!" + ff.Message);
                            }
                        }
                        EOB.IO.ExcelFile.WriteTableEX(filename, dt);
                        if(CHK_ProtectFiles.Checked)
                        {
                            EOB.IO.ExcelFile.protect(filename,"-","-", Properties.Settings.Default.PassKey);
                        }
                        
                        UC_Tool.Print(filename + " is created");
                    }
    
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        private void bulkFileProcessorStandardTool1_UC_FileCallbackFunction(object Sender, string Folder, string File, string Ext)
        {
            try
            {
                if(! Validate(Folder+@"\"+File+Ext)) 
                {
                    throw new Exception(Folder+@"\"+File+Ext + " is excluded from the processing");
                }

                // If validated then the files are ready for compilation
                Compile();

            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private void bulkFileProcessorStandardTool1_UC_TopFolderChanged(object sender, EventArgs e)
        {
            try
            {
                m_strResultsFolder = UC_Tool.UC_RootFolder + @"\Results";
                if (!System.IO.Directory.Exists(m_strResultsFolder))
                {
                    System.IO.Directory.CreateDirectory(m_strResultsFolder);
                    LOG.ReportInfo(this, m_strResultsFolder + " is created");
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private void bulkFileProcessorStandardTool1_UC_Complete(object sender, EventArgs e)
        {
            try
            {
                LOG.ReportInfo(this, "Finished at " + DateTime.Now.ToString());
                Finalize();
                SaveResults();
                SaveMismatch();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private void BTN_RecallCourseLimits_Click(object sender, EventArgs e)
        {
            try
            {
                Dialogs.GradeLimits gm = new Dialogs.GradeLimits();
                if (gm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }
                else
                {
                    throw new Exception("خطأ في ادخال الدرجات العظمى");
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
    }
}
