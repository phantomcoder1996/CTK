using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTK.Data
{
    public partial class KeyEntryDialog : Form
    {
        private string m_oldKey;
        public KeyEntryDialog()
        {
            InitializeComponent();
        }

        public string PassKey
        {
            get
            {
                return  Properties.Settings.Default.PassKey;
            }
            set
            {
                Properties.Settings.Default.PassKey = value;
                Properties.Settings.Default.Save();
            }
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            PassKey = TB_PassKey.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PassKey = m_oldKey;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void KeyEntryDialog_Load(object sender, EventArgs e)
        {
            m_oldKey = Properties.Settings.Default.PassKey;
        }
    }
}
