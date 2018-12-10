using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTK.Dialogs
{
    public partial class DLGPrintBarCode : Form
    {
        private string m_strCourseName;
        private string m_strCourseCode;
        private string m_DTExamDate;
    
        public DLGPrintBarCode()
        {
            InitializeComponent();
        }

        public string CourseName
        {
            get
            {
                m_strCourseName = LBL_CourseName.Text;
                return m_strCourseName;
            }
            set
            {
                m_strCourseName = value;
                LBL_CourseName.Text = m_strCourseName;
            }
        }

        public string CourseCode
        {
            get
            {
                m_strCourseCode = LBL_CourseCode.Text;
                return m_strCourseCode;
            }
            set
            {
                m_strCourseCode = value;
                LBL_CourseCode.Text = value;
            }
        }

        public string ExamDate
        {
            get
            {
                m_DTExamDate = dateTimePicker1.Text;
                return m_DTExamDate;
            }
            set
            {
                m_DTExamDate = value;
                
            }
        }

        private void BTN_Print_Click(object sender, EventArgs e)
        {
            try
            {
                // For the course being active on display, it is required to export sheets for Barcode
                BL.ExportBarCodeSheet(CourseCode,ExamDate);
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                BL.PreviewExportBarCodeSheet(CourseCode, ExamDate);
            }
            catch (Exception ex)
            {
                
                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }
    }
}
