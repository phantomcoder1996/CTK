using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
using DT_Course = CTK.Data.CTKDBDataSet.CoursesDataTable;
using DR_Course = CTK.Data.CTKDBDataSet.CoursesRow;
namespace CTK.Dialogs
{
    public partial class GradeLimits : Form
    {
        public GradeLimits()
        {
            InitializeComponent();
            InitializeComponentEX();
        }

        private void InitializeComponentEX()
        {
            try
            {
                LOG.LogMessage += new EOB.EventLogHandler(LOG_LogMessage);
                
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
                
                LOG.ReportError(this, "!" + ex.Message);
            }
        }
        private void coursesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.coursesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.cTKDBDataSet);
                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
            }

        }

        private void GradeLimits_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTKDBDataSet.Courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);
            InitializeLists();
        }

        private void InitializeLists()
        {
            try
            {
                CBX_Class.Items.Add("---");
                CBX_Department.Items.Add("---");
                foreach (DR_Course r in cTKDBDataSet.Courses.Rows)
                {
                    string[] splitters1 = { "دفعة" };
                    string[] splitters2 = { " " };
                    string[] entry = r.Name.Split(splitters1, StringSplitOptions.RemoveEmptyEntries);
                    string Course = entry[0].Trim();
                    string[] buff = entry[1].Split(splitters2, StringSplitOptions.RemoveEmptyEntries);
                    string Class = buff[0];
                    string Special = entry[1].Trim(). Substring(Class.Length);
                    if (!CBX_Class.Items.Contains(Class))
                    {
                        CBX_Class.Items.Add(Class);
                    }
                    if (!CBX_Department.Items.Contains(Special))
                    {
                        CBX_Department.Items.Add(Special);
                    }
                }
                CBX_Class.SelectedItem = CBX_Department.SelectedItem =  "---";
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CBX_Department.SelectedItem == "---")
                {
                    coursesBindingSource.RemoveFilter();
                }
                else
                {
                    coursesBindingSource.Filter = "Name like '%" + CBX_Department.SelectedItem.ToString().Trim() + "%' and Name like '%"+CBX_Class.SelectedItem.ToString().Trim()+"%'";
                }
               
            }
            catch (Exception ex)
            {
                
                 LOG.ReportError(this, "!" + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = cTKDBDataSet.Courses.GetChanges();
                if (dt == null)
                {
                    coursesBindingNavigatorSaveItem.Enabled = false;
                }
                else
                {
                    coursesBindingNavigatorSaveItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(this, "!" + ex.Message);
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
            }
        }
    }
}
