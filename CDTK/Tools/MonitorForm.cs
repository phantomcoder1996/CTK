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
    public partial class MonitorForm : Form
    {
        public MonitorForm()
        {
            InitializeComponent();
            EOB.EOBLog.LogMessage += new EOB.EventLogHandler(EOBLog_LogMessage);
        }

        void EOBLog_LogMessage(object Sender, params string[] Message)
        {
            try
            {
                if (Sender != null)
                {
                    UC_LogScreen.Print(Sender.GetType().Name);
                }
                
                UC_LogScreen.Print(Message);
            }
            catch (Exception ex)
            {

                UC_LogScreen.Print(ex.Message);
            }
        }
    }
}
