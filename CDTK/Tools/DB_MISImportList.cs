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
    public partial class DB_MISImportList : Form
    {
        DataTable StudentList = null;
        private Guid misLocalID;

        public DB_MISImportList()
        {
            InitializeComponent();
            CBX_AcademicClass.Items.AddRange(BL.GetAcademicClassList());

        }

        private void BTN_OpenMISFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = "Untitled";
                ofd.Filter = "Excel file (*.xlsx)|*.xlsx|Excel 97 format(*.xls)|*.xls";
               
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    ClearData();
                    TB_MISFilePath.Text = ofd.FileName;
                }
                else
                {
                    throw new Exception("Operation is canceled");
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void ClearData()
        {
            TB_CourseActivity.Text = string.Empty;
            TB_CourseCode.Text = string.Empty;
            TB_CourseExam.Text = string.Empty;
            TB_CourseName.Text = string.Empty;
            LBL_CountStudents.Text = string.Empty;

        }

        private void DTP_Calender_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                

               string today =  DTP_Calender.Text;

                string pattern = @"\w+,\s+(?<Month>\w+)\s+(?<Day>\d+),\s(?<Year>\w+)";
                System.Text.RegularExpressions.Match ma = System.Text.RegularExpressions.Regex.Match(today, pattern);
                if(ma.Success)
                {
                    string Year = ma.Groups["Year"].Value;
                    string Month = ma.Groups["Month"].Value.ToUpper();
                    int y = int.Parse(Year);
                   
                    switch (Month)
                    {
                        case "SEPTEMBER": // September
                        case "OCTOBER":
                        case "NOVEMBER":
                        case "DECEMBER":
                        
                            LBL_Year.Text = string.Format("{0}\\{1}", y, y + 1);
                            CBX_Term.Text = "الاول";                          break;
                        case "JANUARY":
                            LBL_Year.Text = string.Format("{0}\\{1}", y - 1, y);
                            CBX_Term.Text = "الاول";
                            break;
                        case "FEBRUARY":
                        case "MARCH":
                        case "APRIL":
                        case "MAY":
                        case "JUNE":
                        case "JULY":
                        case "AUGUST":
                            LBL_Year.Text = string.Format("{0}\\{1}", y-1, y);
                            CBX_Term.Text = "الثاني";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_LoadMISFile_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = TB_MISFilePath.Text;
                
                
                string CourseName = string.Empty;
                if( BL.ImportFromMISFile(FileName,out StudentList,ref CourseName))
                {
                    EOB.EOBLog.ReportInfo(this, "Success to import " + FileName);
                    TB_CourseName.Text = CourseName;
                    LBL_CountStudents.Text = StudentList.Rows.Count.ToString();
                    misLocalID = BL.CopyMISFile(FileName);
                }
                else
                {
                    throw new Exception("Failed to import " + FileName);
                }
                
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_ImportMISFile_Click(object sender, EventArgs e)
        {
            try
            {
                string CourseName = TB_CourseName.Text.Trim();
                string CourseCode = TB_CourseCode.Text.Trim();
                string AcademicTerm = CBX_Term.Text.Trim();
                string AcademicYear = LBL_Year.Text.Trim();
                int ExamMaximumLimit = 0;
                if(!int.TryParse(TB_CourseExam.Text,out ExamMaximumLimit))
                {
                    EOB.EOBLog.ReportError(this, string.Format("درجة التحريري  للمادة {0} غير موجودة. سوف يتم وضعها بصفر", CourseName));
                }

                int ActivityMaximumLimit = 0;
                if(!int.TryParse(TB_CourseActivity.Text,out ActivityMaximumLimit))
                {
                    EOB.EOBLog.ReportError(this,string.Format( "درجة اعمال السنة للمادة {0} غير موجودة. سوف يتم وضعها بصفر",CourseName));
                }
                if (!BL.ImportCourse(CourseName, CourseCode, ExamMaximumLimit,ActivityMaximumLimit,StudentList,AcademicTerm,AcademicYear,misLocalID,CBX_AcademicClass.Text))
                {
                    MessageBox.Show("Failed", "CTK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Failed to import the course into the database");
                }
                else
                {
                    MessageBox.Show("Done");
                    EOB.EOBLog.ReportInfo(this,"Success to import the course into the database");
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }
    }
}
