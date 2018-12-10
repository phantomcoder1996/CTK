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
    public partial class ExportExamSheets : Form
    {
        public ExportExamSheets()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        private void InitializeComponentEX()
        {
            try
            {
                LOG.LogMessage += new EOB.EventLogHandler(LOG_LogMessage);
                //UC_ExamCompiler.Messages += new CTK.Controls.ExamGradeCompiler.LogMessages(UC_ExamCompiler_Messages);
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        void UC_ExamCompiler_Messages(object Sender, string[] Message)
        {
            try
            {
                LOG.ReportInfo(Sender, Message);
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        void LOG_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                UC_LogScreen.Print(Message);
            }
            catch (Exception ex)
            {

                UC_LogScreen.Print("!" + ex.Message);
            }
        }
        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            }
        }

        private void UC_ExamCompiler_Messages_1(object Sender, string[] Message)
        {
            try
            {
                LOG.ReportInfo(this, Message);
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }
    }
}
