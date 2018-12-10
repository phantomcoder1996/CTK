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
    public partial class DBImportExamMarkedForms : Form
    {
        public DBImportExamMarkedForms()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        private void InitializeComponentEX()
        {
            EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
        }

        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
            Tool.Print(Message);
        }
        private void Tool_UC_FileCallbackFunction(object Sender, string Folder, string File, string Ext)
        {
            //Task: Consider to include the newly added attendance column in this step. 
            DataTable dt = EOB.IO.ExcelFile.ReadDataTableEX(File + Ext);
            if (!BL.ValidateExamMarkedSchema(dt))
            {
                throw new Exception(File + Ext + " is not a valid file for importing process...");
            }
            Tool.Print(Folder + Ext + " is imported");
            BL.ImportFinalMarks(File, dt);
            string outfile =Folder+@"\"+ File + "_Final" + Ext;
            if (System.IO.File.Exists(outfile))
            {
                System.IO.File.Delete(outfile);
                Tool.Print(outfile + " is deleted");
            }
            DataTable dtt = BL.GetDecodedMasterCourse(File);
            EOB.IO.ExcelFile.WriteTableEX(outfile, dtt);
            Tool.Print(outfile + " is created into " + Folder);
        }

        private void Tool_UC_SavePathClicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.CurrentFolder = Tool.UC_RootFolder;
            Properties.Settings.Default.Save();
            Tool.Print(Properties.Settings.Default.CurrentFolder + "is saved for later on sessions");
        }

        private void BarCodeButtonClick(object sender, EventArgs e)
        {
            try
            {
                Tools.DBExamImportUsingBarCode bc = new DBExamImportUsingBarCode();
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Excel work sheet 2007 (*.xlsx)|*.xlsx";
               
                    if (bc.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                    {
                        sf.FileName = bc.FileName;
                        if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            
                            EOB.IO.ExcelFile.WriteTableEX(sf.FileName, bc.Data);
                            EOB.EOBLog.ReportInfo(this, bc.FileName + " is successfully save");
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

        private void Tool_Load(object sender, EventArgs e)
        {

        }
    }
}
