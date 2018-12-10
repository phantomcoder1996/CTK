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
    
    public partial class DBImportMasterForms : Form
    {
        //private Data.CTKDBDataSet.CoursesDataTable m_Dtcourse = new Data.CTKDBDataSet.CoursesDataTable();
        //private Data.CTKDBDataSet.MasterDataTable m_DTmaster = new Data.CTKDBDataSet.MasterDataTable();
        //private Data.CTKDBDataSet.StudentsDataTable m_DTstudents = new Data.CTKDBDataSet.StudentsDataTable();
        Data.CTKDBDataSetTableAdapters.CoursesTableAdapter m_objCoursesTableadapter = new Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
        Data.CTKDBDataSetTableAdapters.MasterTableAdapter m_objMasterDataadapter = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
        Data.CTKDBDataSetTableAdapters.StudentsTableAdapter m_objstudentsDataadapter = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
        private Data.CTKDBDataSet m_obj_CTKdataSet;
        public DBImportMasterForms()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        void  InitializeComponentEX()
        {
            m_obj_CTKdataSet = new Data.CTKDBDataSet();
            
            Tool.UC_Filter = "*.xlsx";
            EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
            SynchDB();
            //this.m_objCoursesTableadapter.Fill(this.m_obj_CTKdataSet.Courses);
            //this.m_objMasterDataadapter.Fill(m_obj_CTKdataSet.Master);
            //this.m_objstudentsDataadapter.Fill( m_obj_CTKdataSet.Students);
            //m_obj_CTKdataSet.AcceptChanges();
        }

        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                //"New Mismatch is added to the mismatch report"
                //foreach (var v in Message)
                //{
                //    if (v.Contains("New Mismatch is added to the mismatch report"))
                //    {
                //        return;
                //    }
                //}
                Tool.Print(Message);
                
            }
            catch (Exception ex)
            {

                Tool.Print(ex.Message);
            }
        }
        public string[] GetCourseInformation(string fileName)
        {
            List<string> res = new List<string>();
            string[] splitters = { "-" };
            string[] buffer = fileName.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            if (buffer.Length != 5)
            {
                throw new Exception("Check file name, it should be in the standard format مادة--ريض01 -رياضيات1دفعة اعدادى-الترم الثانى-2008");
            }

            for (int i = 1; i < 5; i++)
            {
                res.Add(buffer[i].ToUpper().Trim());
            }
            return res.ToArray();

        }
        /// <summary>
        /// Updates the dataset with data into the database
        /// </summary>
        private void SynchDB()
        {

            //Data.CTKDBDataSetTableAdapters.TableAdapterManager ta = new Data.CTKDBDataSetTableAdapters.TableAdapterManager();
            //ta.UpdateAll(m_obj_CTKdataSet);

            try
            {
                if (m_obj_CTKdataSet.Courses.Rows.Count == 0)
                {
                    this.m_objCoursesTableadapter.Fill(m_obj_CTKdataSet.Courses);
                }
                else
                {
                    this.m_objCoursesTableadapter.Update(m_obj_CTKdataSet);

                }
            }
            catch (Exception ex)
            {

                Tool.Print(ex.Message);
            }

            try
            {
                if (m_obj_CTKdataSet.Students.Rows.Count == 0)
                {
                    this.m_objstudentsDataadapter.Fill(m_obj_CTKdataSet.Students);
                }
                else
                {
                    this.m_objstudentsDataadapter.Update(m_obj_CTKdataSet.Students);

                }
            }
            catch (Exception ex1)
            {
                
                
                Tool.Print(ex1.Message);
            }


            try
            {
                if (m_obj_CTKdataSet.Master.Rows.Count == 0)
                {
                    this.m_objMasterDataadapter.Fill(m_obj_CTKdataSet.Master);
                }
                else
                {
                    this.m_objMasterDataadapter.Update(m_obj_CTKdataSet);

                }
            }
            catch (Exception ex2)
            {
                
                Tool.Print(ex2.Message);
            }
            //this.m_objCoursesTableadapter.Fill(m_obj_CTKdataSet.Courses);
            //this.m_objstudentsDataadapter.Fill(m_obj_CTKdataSet.Students);
            //this.m_objMasterDataadapter.Fill(m_obj_CTKdataSet.Master);
            //m_obj_CTKdataSet.AcceptChanges();
            
        }
        private void Tool_UC_FileCallbackFunction(object Sender, string Folder, string File, string Ext)
        {
            try
            {
                SynchDB();
                //  this.m_objCoursesTableadapter.Fill(this.m_obj_CTKdataSet.Courses);
                EOB.EOBLog.ReportInfo(this, File + Ext + " is being processed");
                string[] info = GetCourseInformation(File);
                string CourseCode = info[0];
                string Coursename = info[1];
                string Semester = info[2];
                string Year = info[3];
                DataTable dt = EOB.IO.ExcelFile.Import(File + Ext, 2);
                foreach (DataRow r in dt.Rows)
                {
                    List<string> record = new List<string>();
                    record.Add(CourseCode);
                    record.Add(Coursename);
                    record.Add(Semester);
                    record.Add(Year);
                    record.Add(r[0].ToString());
                    record.Add(r[2].ToString());
                    BL.InsertMasterRecord(record.ToArray(), ref m_obj_CTKdataSet);


                }
            }
            catch (Exception ex)
            {

                Tool.Print(ex.Message);
            }
            //SynchDB();
        }

        private void Tool_UC_SavePathClicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.DBFolder1 = Tool.UC_RootFolder;
            Properties.Settings.Default.Save();
            EOB.EOBLog.ReportInfo(this, Tool.UC_RootFolder + " is saved for later on use...");
        }

        private void Tool_UC_Initialize(object sender, EventArgs e)
        {
            m_obj_CTKdataSet.Clear();

           
        }

        private void Tool_UC_Complete(object sender, EventArgs e)
        {
            SynchDB();
            //Data.CTKDBDataSetTableAdapters.CoursesTableAdapter a = new Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
           // this.m_objCoursesTableadapter.Update(m_obj_CTKdataSet.Courses);

           // //Data.CTKDBDataSetTableAdapters.MasterTableAdapter b = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
           //this.m_objMasterDataadapter.Update(m_obj_CTKdataSet.Master);

           // //Data.CTKDBDataSetTableAdapters.StudentsTableAdapter c = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
           // this.m_objstudentsDataadapter.Update(m_obj_CTKdataSet.Students);
        }
    }
}
