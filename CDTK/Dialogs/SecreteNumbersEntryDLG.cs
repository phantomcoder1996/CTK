using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
using DT_SECRETNUMBERS = CTK.Data.InternalDS.SecreteNumbersDTDataTable;
using DR_SECRETENUMBERS = CTK.Data.InternalDS.SecreteNumbersDTRow;
using DT_Students = CTK.Data.CTKDBDataSet.StudentsDataTable;
using DR_StudentRow = CTK.Data.CTKDBDataSet.StudentsRow;
using TA_Master = CTK.Data.CTKDBDataSetTableAdapters.MasterTableAdapter;
using DT_Master = CTK.Data.CTKDBDataSet.MasterDataTable;
using DR_MasterRow = CTK.Data.CTKDBDataSet.MasterRow;
using DT_Mismatch = CTK.Data.InternalDS.MismatchTableDataTable;
using DR_MismatchRow = CTK.Data.InternalDS.MismatchTableRow;
namespace CTK.Dialogs
{
    public partial class SecreteNumbersEntryDLG : Form
    {

        DT_SECRETNUMBERS m_DTFirstEntry;
        DT_SECRETNUMBERS m_DTSecondEntry;
        bool m_bMismatch;
        public SecreteNumbersEntryDLG()
        {
            InitializeComponent();
            InitializeComponentEX();
        }

        public CTK.Data.InternalDS.SecreteNumbersDTDataTable SecreteNumbersTable
        {
            get
            {
                DT_SECRETNUMBERS res = new DT_SECRETNUMBERS();
                try
                {
                    if (m_bMismatch)
                    {
                        throw new Exception("يوجد عدم تطابق في الارقام السرية");
                    }
                    res = m_DTFirstEntry;
                }
                catch (Exception ex)
                {
                    
                    LOG.ReportError(this, ex.Message);
                }
                return res;
            }
            
        }
    
        private void InitializeComponentEX()
        {
            try
            {
                m_DTFirstEntry = new DT_SECRETNUMBERS();
                m_DTSecondEntry = new DT_SECRETNUMBERS();
                m_bMismatch = false;
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void SecreteNumbersEntryDLG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTKDBDataSet.Courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);

        }

        private void CB_CourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BTN_Update_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = this.tabControl1.TabPages[0];
                TA_Master ta = new TA_Master();
                DT_Master dt = ta.GetDataByCourseCode(CB_CourseCode.Text);
               
                m_DTFirstEntry.Clear();
                m_DTSecondEntry.Clear();
                foreach (DR_MasterRow r in dt.Rows)
                {
                    m_DTFirstEntry.Rows.Add(r.StudentID, "");
                    m_DTSecondEntry.Rows.Add(r.StudentID, "");
                }
                DG_FirstEntry.DataSource = m_DTFirstEntry;
                DG_SecondEntry.DataSource = m_DTSecondEntry;

            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_Match_Click(object sender, EventArgs e)
        {
            try
            {
               
              
                DT_Mismatch mt = new DT_Mismatch();
                foreach (DR_SECRETENUMBERS r in m_DTFirstEntry.Rows)
                {
                    
                    DataRow [] buff = m_DTSecondEntry.Select("STudentID = '"+r.STudentID+"'");
                    if (buff.Length != 1)
                    {
                        throw new Exception("يوجد رقم جلوس في الرصد الاول و غير موجود في الرصد الثاني. هذا يعتبر خطأ في البرنامج. رجاء الاتصال بالدعم الفني");
                    }
                    DR_SECRETENUMBERS d = (DR_SECRETENUMBERS)buff[0];
                    if (r.SecreteNumber.Trim().ToUpper() != d.SecreteNumber.Trim().ToUpper())
                    {
                        DR_MismatchRow mr = mt.NewMismatchTableRow();
                        mr.StudentID = r.STudentID;
                        mr.FirstEntry = r.SecreteNumber;
                        mr.SecondEntry = d.SecreteNumber;
                        mt.Rows.Add(mr);

                    }

                }
                if (mt.Rows.Count > 0)
                {
                    m_bMismatch = true;
                    DG_MismatchReport.DataSource = mt;
                    
                }
                else
                {
                    m_bMismatch = false;
                    DG_MismatchReport.DataSource = mt;
                    tabControl1.TabPages[2].Show();
                }
                tabControl1.SelectedTab = tabControl1.TabPages[2];
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_Correct_Click(object sender, EventArgs e)
        {
            try
            {
                foreach ( DataGridViewRow  r in DG_MismatchReport.Rows)
                {
                    DataRow[] buff = m_DTFirstEntry.Select("STudentID = '" + r.Cells[0].Value + "'");
                    DataRow[] buff1 = m_DTSecondEntry .Select("STudentID = '" + r.Cells[0].Value + "'");
                    DR_SECRETENUMBERS dr = (DR_SECRETENUMBERS)buff[0];
                    DR_SECRETENUMBERS sr = (DR_SECRETENUMBERS)buff1[0];
                    dr.SecreteNumber = r.Cells[1].Value.ToString();
                    sr.SecreteNumber = r.Cells[2].Value.ToString();
                }
                DG_FirstEntry.DataSource = null;
                DG_FirstEntry.DataSource = m_DTFirstEntry;
                DG_FirstEntry.Refresh();
                DG_SecondEntry.DataSource = m_DTSecondEntry;
                DG_SecondEntry.Refresh();
                BTN_Match_Click(this, new EventArgs());
               
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }
}
