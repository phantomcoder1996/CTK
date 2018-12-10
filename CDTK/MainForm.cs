using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTK
{
    public partial class MainForm : Form
    {
        EOB.Reports.MisMatch m_objMismatchReport;
        public MainForm()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        private void InitializeComponentEX()
        {
            m_objMismatchReport = new EOB.Reports.MisMatch();
            EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
            //Task: Consider to ensure not to fix the database unless it is missing or old version

            BL.FixDbase();
           // BL.DBInstallerPre();
           
#if DEBUG
            Test(); 
#endif
        }
        private void Test()
        {
            //BL.DBInstallerDBMigrate(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\CTKDB.sdf", "");
        }
        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
           
            try
            {
                if (Sender.GetType().Name == "MisMatch") return;
            }
            catch (Exception )
            {
                
               
            }
            foreach (string msg in Message)
            {
                this.m_objMismatchReport.Add("LOG", msg, "NA");
            }
            LAB_Status.Text = string.Concat(Message);
            LAB_Date.Text = DateTime.Now.ToString();
        }
        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTN_Import_MasterForms_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.DBImportMasterForms mf = new Tools.DBImportMasterForms();
                if (mf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EOB.EOBLog.ReportInfo(this, "Importing the master forms is done successfully...");
                }
                else
                {
                    EOB.EOBLog.ReportError (this, "Importing the master forms is canceled or not normally terminated...");
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_Export_SecreteNumbers_Click(object sender, EventArgs e)
        {
            Tools.DBExportSecreteNumbersForms sf = new Tools.DBExportSecreteNumbersForms();
            sf.ShowDialog();
        }

        private void BTN_Export_ExamMarksForms_Click(object sender, EventArgs e)
        {
            //Tools.ExportMarkRegForms mf = new Tools.ExportMarkRegForms();
            //mf.ShowDialog();
            try
            {
               //Tools.ExportExamSheets es = new Tools.ExportExamSheets();
                Tools.ExportExamsheetEX es = new Tools.ExportExamsheetEX();
                es.ShowDialog();
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_Import_Exam_Click(object sender, EventArgs e)
        {
            //Tools.DBImportExamMarkedForms fr = new Tools.DBImportExamMarkedForms();
            //fr.ShowDialog();

            try
            {
                Tools.DBExamImportUsingBarCode bc = new Tools.DBExamImportUsingBarCode();
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel work sheet 2007 (*.xlsx)|*.xlsx";
                L1:
                if (bc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    sf.FileName = bc.FileName;
                    if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        EOB.IO.ExcelFile.WriteDataTable_PP(sf.FileName, bc.Data);
                        EOB.EOBLog.ReportInfo(this, bc.FileName + " is successfully save");
                    }
                    else
                    {
                        if (MessageBox.Show("لم يتم حفظ الرصد. هل تريد الانهاء من غير حفظ؟", "تحذير ", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (MessageBox.Show("لقد قمت باختيار عدم حفظ الرصد. كل ماتم رصده في هذه المادة لم يحفظ. هل انت متأكد من هذا الاختيار؟", "تحذير اخير", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                MessageBox.Show("لم يتم الحفظ بناء على اختياركم.", "رسالة", MessageBoxButtons.OK);
                            }
                            else
                            {
                                goto L1;
                            }
                        }
                        else
                        {
                            goto L1;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("لابد من عمل مطابقة و ادخال كل الدرجات و كذلك حالة الغياب قبل الحفظ", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }

        }

        private void BTN_ClearDB_Click(object sender, EventArgs e)
        {
            if (!BL.ValidatePassKey())
            {
                MessageBox.Show("لابد من وجود مفتاح للتشغيل قبل البداء في هذه الخدمة");
            }
            else
            {
                if (MessageBox.Show("Database will be cleared, are you sure?", "Take care", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    BL.ClearDatabase();
                }
            }
           
        }

        private void BTN_About_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void BTN_StoreDB_Click(object sender, EventArgs e)
        {
            BL.ExporttDB();
        }

        private void BTN_LoadDB_Click(object sender, EventArgs e)
        {
            BL.ImportDB();
        }

        private void BTN_KeyValidation_Click(object sender, EventArgs e)
        {
            Data.KeyEntryDialog dlg = new Data.KeyEntryDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string key = dlg.PassKey;
            }
        }

        private void BTN_Export_FinalExamMarkform_Click(object sender, EventArgs e)
        {
            Tools.ExportToMIS mis = new Tools.ExportToMIS();
            mis.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "SystemLog_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_00_R0";
                sf.Filter = "Excel File 2007 (*.XLSX)|*.xlsx|Excel File 2003 (*.XLS)|*.xls|Comma Delimited File Format (*.CSV)|*.CSV";
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_objMismatchReport.Save(sf.FileName);
                    MessageBox.Show(sf.FileName + " is saved successfully", "برنامج الكنترول", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {

                EOBLog_LogMessage(this, ex.Message);
            }
        }

        private void BTN_Monitor_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.MonitorForm mf = new Tools.MonitorForm();
                mf.Show();
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_BarCodeTest_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.BarCodeReaderForm mf = new Tools.BarCodeReaderForm();
                mf.ShowDialog();
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }

        private void BTN_ImportListsFromMIS_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.DB_MISImportList mf = new Tools.DB_MISImportList();
                if (mf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EOB.EOBLog.ReportInfo(this, "Importing the master forms is done successfully...");
                }
                else
                {
                    EOB.EOBLog.ReportError(this, "Importing the master forms is canceled or not normally terminated...");
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(this, ex.Message);
            }
        }
    }
}
