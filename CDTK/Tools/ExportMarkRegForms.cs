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
    public partial class ExportMarkRegForms : Form
    {
        public ExportMarkRegForms()
        {
            InitializeComponent();
        }

        private void coursesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.coursesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cTKDBDataSet);

        }

        private void ExportMarkRegForms_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTKDBDataSet.Master' table. You can move, or remove it, as needed.
            //this.masterTableAdapter.Fill(this.cTKDBDataSet.Master);
            //// TODO: This line of code loads data into the 'cTKDBDataSet.Students' table. You can move, or remove it, as needed.
            //this.studentsTableAdapter.Fill(this.cTKDBDataSet.Students);
            //// TODO: This line of code loads data into the 'cTKDBDataSet.Courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.cTKDBDataSet.Courses);

        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            // Read filterd data table by code

            

            DG_List.DataSource = BL.GetCourseConfData(codeTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!BL.ValidatePassKey())
            {
                MessageBox.Show("لابد من أدخال مفتاح تشغيل قبل تخزين الملفات");

            }
            else
            {
                //Task: Add column for Attendance into the export sheet.
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File (*.XLSX)|*.XLSX";
                sfd.FileName = codeTextBox.Text;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EOB.IO.ExcelFile.WriteTableEX(sfd.FileName, (DataTable)DG_List.DataSource);
                    EOB.IO.ExcelFile.protect(sfd.FileName, "B", "-", Properties.Settings.Default.PassKey);
                }
            }

            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
