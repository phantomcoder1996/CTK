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
    public partial class BarCodeReaderForm : Form
    {
        Data.CTKDBDataSet.MasterDataTable m_objMasterTable;
        public BarCodeReaderForm()
        {
            InitializeComponent();
            m_objMasterTable = BL.GetMasterTable();
        }

        private void barcodeTextBox1_OnNewBarcodeRecived(object Sender, string BarCode)
        {
            try
            {
                Data.CTKDBDataSet.MasterRow r = BL.GetMasterRowBySSID(m_objMasterTable, BarCode.Substring(0, 11));
                BL.CourseCard cc = BL.GetCourseCard(r.CourseID);
                BL.StudentCard sc = BL.GetStudentCard(r.StudentID);

                LBL_CourseName.Text = cc.Name;
                LBL_StudentName.Text = sc.Name;
                this.Invalidate();
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }
    }
}
