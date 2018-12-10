using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
using DT_ResultSheet = CTK.Data.InternalDS.ResultSheetDataTable;
using DR_ResultSheet = CTK.Data.InternalDS.ResultSheetRow;
namespace CTK.Controls
{
    public partial class ExamGradeCompiler : UserControl
    {
       //private DT_ResultSheet m_objResultSheet;
        private DataTable m_objFinalDT;
        private DataTable m_objActivityDT;
        private AcademicYearOptions m_nAcademicYearOptions;
        private AcademicClassOptions m_nAcademicClassOptions;
        private DepartmentOptions m_nDepartmenet;
        private bool m_bActivityValidated;
        private bool m_bGradesValidated;
        private string m_strWorkingFolder;
        public ExamGradeCompiler()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        private void InitializeComponentEX()
        {
            try
            {
                PIC_Status.Image = imageList1.Images["NO"] ;
              // m_objResultSheet = new DT_ResultSheet();
                AcademicYear = new AcademicYearOptions();
                Departmenet = new DepartmentOptions();
                AcademicClass = new AcademicClassOptions();
                m_objFinalDT = new DataTable();
                Workingfolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data";
                Clear();
               // Messages += new LogMessages(ExamGradeCompiler_Messages);
                LOG.LogMessage += new EOB.EventLogHandler(LOG_LogMessage);
                LOG.ReportInfo(this, System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                LOG.ReportError(this, ex.Message);
            }
        }

        

        void LOG_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                if (Sender != this) return;
                if (this.Messages != null)
                {
                    Messages(this, Message);
                }
                
            }
            catch (Exception ex)
            {
                
                
            }
        }
        public string Workingfolder
        {
            get
            {
                return m_strWorkingFolder;
            }
            set
            {
                m_strWorkingFolder = value;
            }
        }
       //  [System.ComponentModel.Browsable(true)]
        public AcademicYearOptions AcademicYear
        {
            get
            {
                try
                {
                    return m_nAcademicYearOptions;
                }
                catch (Exception)
                {
                    
                    throw new NotImplementedException();
                }
            }
            set
            {
                m_nAcademicYearOptions = value;
                LBL_AcademicYear.Text = value.ToString();
            }
        }
       //  [System.ComponentModel.Browsable(true)]
        public DepartmentOptions Departmenet
        {
            get
            {
                try
                {
                    return m_nDepartmenet;
                }
                catch (Exception)
                {
                    
                   throw new NotImplementedException();
                }
            }
            set
            {
                m_nDepartmenet = value;
                LBL_Departmenet.Text = value.ToString();
            }
        }
       //  [System.ComponentModel.Browsable(true)]
        public AcademicClassOptions AcademicClass
        {
            get
            {
                try
                {
                    return m_nAcademicClassOptions;
                }
                catch (Exception)
                {
                    
                    throw new NotImplementedException();
                }
            }
            set
            {
                m_nAcademicClassOptions = value;
                LBL_AcademicClass.Text = value.ToString();
            }
        }

        public enum AcademicYearOptions
        {
            Fall2013,
            Spring2014,
            Summer2014,
            Fall2014,
            Spring2015,
            Summer2015,
            Fall2015,
            none,
        }

        public enum DepartmentOptions
        {
            Math,
            ElectricalPowerEng,
            ElectricalCommEng,
            IdustrialEng,
            CivilEng,
            ArchEng,
            none,
        }

        public enum AcademicClassOptions
        {
            PrepYear,
            First,
            Second,
            Third,
            Fourth,
            none,
        }

        private void Clear()
        {
            try
            {
                m_bActivityValidated = m_bGradesValidated = false;
                m_nAcademicClassOptions = AcademicClassOptions.none;
                m_nAcademicYearOptions = AcademicYearOptions.none;
                m_nDepartmenet = DepartmentOptions.none;
                m_objActivityDT = new DataTable();
                m_objFinalDT = new DataTable();
                m_objActivityDT.Clear();
                m_objFinalDT.Clear();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }
        private void BTN_ImportExamSheet_Click(object sender, EventArgs e)
        {
            try
            {
                LOG.ReportInfo(this, DateTime.Now.ToString());
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    m_objFinalDT.Clear();
                    m_objFinalDT.AcceptChanges();
                    m_objFinalDT = EOB.IO.ExcelFile.Read(of.FileName);
                    MessageBox.Show(m_objFinalDT.Rows.Count + " records are imported...");
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_ImportActivitySheet_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                if (of.ShowDialog() == DialogResult.OK)
                {
                   
                    m_objActivityDT = EOB.IO.ExcelFile.Read(of.FileName,"","A3:-");
                    MessageBox.Show(m_objActivityDT.Rows.Count + " records are imported...");
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }


        public delegate void LogMessages(Object Sender, string[] Message);

        public event LogMessages Messages;
        private void ReportError(string message)
        {
            try
            {
                string[] msg = new string[2];
                msg[0] = message;
                msg[1] = string.Empty;
                Messages(this, msg);
            }
            catch (Exception)
            {
                
                
            }
        }
        private string EvaluateTotalMark(string Activity, string Final)
        {
            string res = string.Empty;

            return res;
        }
        private void BTN_ExportFinalSheets_Click(object sender, EventArgs e)
        {
            try
            {
                DT_ResultSheet dt = new DT_ResultSheet();
                m_objActivityDT.Columns[0].ColumnName = "BN";
                foreach (DataRow r in m_objFinalDT.Rows)
                {
                    try
                    {
                        string BN = r[0].ToString().Trim();
                        DataRow[] buf = m_objActivityDT.Select("BN = '" + BN + "'");
                        if (buf.Length == 1)
                        {
                            DR_ResultSheet rr = dt.NewResultSheetRow();
                            rr.Activities = buf[0][3].ToString();
                            rr.BenchNumber = BN;
                            rr.Final = r[3].ToString();
                            rr.Name = buf[0][2].ToString(); ;
                            rr.Rank = "";
                            rr.Status = buf[0][1].ToString();
                            rr.TotalMark = EvaluateTotalMark(rr.Activities, rr.Final);
                            dt.Rows.Add(rr);
                        }
                        else
                        {
                             
                        }
                    }
                    catch (Exception ex1)
                    {
                        
                        //Todo Add mismatch
                    }
                }// End of loop
                string resultsfile = Workingfolder +  "Results.xlsx";

                //SaveFileDialog sf = new SaveFileDialog();
            }
            catch (Exception ex)
            {

                ReportError(ex.Message);
            }
        }
    }

    

   
}
