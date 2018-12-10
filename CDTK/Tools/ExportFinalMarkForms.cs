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
    public partial class ExportToMIS : Form
    {
        public string _courseCode { get; private set; }

        public ExportToMIS()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        private void InitializeComponentEX()
        {
            EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
            CBX_Course.Items.AddRange(BL.GetCoursesList());
            
        }

        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
            UC_Screen.Print(Message);
        }
        private void coursesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.coursesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cTKDBDataSet);

        }

        private void ExportToMIS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTKDBDataSet.Courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);

        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (LB_CourseStatus.GetItemChecked(0) && LB_CourseStatus.GetItemChecked(1))
                {
                    ExportMISFile();
                }
                else
                {
                    MessageBox.Show("لابد من رصد الدرجات قبل اخراج الملف");
                }
                    
            }
            catch (Exception ex)
            {

                UC_Screen.Print("Error:"+ex.Message);
            }
        }

        private void ExportMISFile()
        {
            string CourseCode = BL.GetCourseCode(CBX_Course.Text);
            _courseCode = CBX_Course.Text;
            //ExportMISFile(CourseCode);
            string misfile = BL.UpdateGradesInMISSheet_NM(CourseCode);
            if (misfile.Trim().Length > 0)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel 2007/2010 (*.xlsx)|*.xlsx";
                sf.FileName = "Untitled";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.Copy(misfile, sf.FileName, true);
                }
            }
        }

        private void ExportMISFile(string CourseCode)
        {
            if (LB_CourseStatus.GetItemChecked(0) && LB_CourseStatus.GetItemChecked(1))
            {
                DataTable filebuffer = BL.GetMISSheet(CourseCode);
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel 2007/2010 (*.xlsx)|*.xlsx";
                sf.FileName = filebuffer.TableName.Trim().ToUpper();
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    EOB.IO.ExcelFile.WriteDataTable_PP(sf.FileName, filebuffer, filebuffer.TableName);
                }
            }
            else
            {
                UC_Screen.Print(_courseCode + " is not either has secrete numbers or has grades entered. Check the status of the course then try again");
                MessageBox.Show(_courseCode + " is not either has secrete numbers or has grades entered. Check the status of the course then try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ExoprtinExisitingMISFile()
        {
            //if (!System.IO.File.Exists(UC_MISFile.Text))
            //{
            //    throw new Exception("The file " + UC_MISFile.Text + " is either not entered or not exist");
            //}
            //if (LB_CourseStatus.GetItemChecked(0) && LB_CourseStatus.GetItemChecked(1))
            //{
            //    BL.UpdateGradesInMISSheet(UC_MISFile.Text, codeTextBox.Text);
            //    UC_Screen.Print("Finished updating the file " + UC_MISFile.Text);
            //}
            //else
            //{
            //    UC_Screen.Print(codeTextBox.Text + " is not either has secrete numbers or has grades entered. Check the status of the course then try again");
            //    MessageBox.Show(codeTextBox.Text + " is not either has secrete numbers or has grades entered. Check the status of the course then try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
           //switch( BL.GetCourseStatus(codeTextBox.Text))
           //{
           //    case CourseStatus.State1:// Only names
           //        LB_CourseStatus.SetItemChecked(0, false);
           //        LB_CourseStatus.SetItemChecked(1, false);
           //        break;
           //    case CourseStatus.State2: // Secrete Numbers
           //        LB_CourseStatus.SetItemChecked(0, true);
           //        LB_CourseStatus.SetItemChecked(1, false);
           //        break;
           //    case CourseStatus.State3: // Grades
           //        LB_CourseStatus.SetItemChecked(0, true);
           //        LB_CourseStatus.SetItemChecked(1, true);
           //        break;
           //}
        }
        private void UpdateGUI(string CourseCode)
        {
            switch (BL.GetCourseStatus(CourseCode))
            {
                case CourseStatus.State1:// Only names
                    LB_CourseStatus.SetItemChecked(0, false);
                    LB_CourseStatus.SetItemChecked(1, false);
                    break;
                case CourseStatus.State2: // Secrete Numbers
                    LB_CourseStatus.SetItemChecked(0, true);
                    LB_CourseStatus.SetItemChecked(1, false);
                    break;
                case CourseStatus.State3: // Grades
                    LB_CourseStatus.SetItemChecked(0, true);
                    LB_CourseStatus.SetItemChecked(1, true);
                    break;
            }
        }

        private void CBX_Course_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateGUI(BL.GetCourseCode(CBX_Course.Text));
        }
    }
}
