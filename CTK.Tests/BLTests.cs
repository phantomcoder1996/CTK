using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Moq;
using System.Windows.Forms;

namespace CTK.Tests
{
    [TestClass()]
    public class BLTests
    {
        [TestMethod()]
        public void RemoveInternSpacesTest()
        {
            string text_with_space = "    أنا حزين   ";
            string expected_output = "أناحزين";

            BL.RemoveInternSpaces(text_with_space);
            Assert.AreEqual(expected_output, text_with_space);

            string withoutspace = "حزين";
            BL.RemoveInternSpaces(withoutspace);

            Assert.AreEqual(withoutspace, withoutspace);

        }


        [TestMethod()]
        public void NormalizeTest()
        {

            //  Normalization is defined as:

            //Normalization of hamza with alef seat to a bare alef.
            //Normalization of teh marbuta to heh
            //Normalization of dotless yeh (alef maksura) to yeh.
            //Removal of Arabic diacritics (the harakat)
            //Removal of tatweel(stretching character).

            string input = "أحمد";
            string expected = "احمد";
            string actual = BL.Normalize(input);
            Assert.AreEqual(expected, actual);

            input = "حزينة";
            expected = "حزينه";


            actual = BL.Normalize(input);
            Assert.AreEqual(expected, actual);

            input = "رىم";
            expected = "ريم";

            actual = BL.Normalize(input);
            Assert.AreEqual(expected, actual);

            input = "إيمان";
            expected = "ايمان";
            actual = BL.Normalize(input);
            Assert.AreEqual(expected, actual);
            input = "حَرَكَة";
            expected = "حركه";

            actual = BL.Normalize(input);
            Assert.AreEqual(expected, actual);






        }

        [TestMethod()]
        public void RemoveCourseTest()
        {
            Assert.Fail();



        }



        private CTK.Data.InternalDS createFakeInternalDataBase()
        {

            CTK.Data.InternalDS internalDS = new CTK.Data.InternalDS();


            DataTable dt = new DataTable();
            DataColumn column = new DataColumn();
            column.ColumnName = "Name";
            column.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "StudentID";
            column.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "BarCode";
            column.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "Status";
            column.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "CourseCode";
            column.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "FirstEntry";
            column.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "SecondEntry";
            column.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "Review";
            column.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(column);


            DataRow row = dt.NewRow();
            row["Name"] = "ريم جودي";
            row["StudentID"] = 1;
            row["Status"] = "ح";
            row["BarCode"] = "110156892340";
            row["CourseCode"] = "ريض10";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "محمود جودي";
            row["StudentID"] = 2;
            row["Status"] = "ح";
            row["BarCode"] = "110151892340";
            row["CourseCode"] = "ريض10";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Name"] = "هاجر";
            row["StudentID"] = 3;
            row["Status"] = "ح";
            row["BarCode"] = "110151892340";
            row["CourseCode"] = "ريض10";
            dt.Rows.Add(row);
            foreach (DataRow r in dt.Rows)
            {
                CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();

                m.Name = r["Name"].ToString();
                m.StudentID = Convert.ToInt32(r["StudentID"]);
                m.Status = r["Status"].ToString();
                m.BarCode = r["BarCode"].ToString();
                try
                {
                    m.FirstEntry = Convert.ToInt32(r["FirstEntry"]);
                }
                catch (Exception x1)
                {


                }
                try
                {
                    m.SecondEntry = Convert.ToInt32(r["SecondEntry"]);
                }
                catch (Exception)
                {


                }
                try
                {
                    m.Review = Convert.ToInt32(r["Review"]);
                }
                catch (Exception)
                {


                }
                m.CourseCode = r["CourseCode"].ToString();
                internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
            }
            internalDS.MarkEntryTable.AcceptChanges();

            return internalDS;
        }



        //Tester : @Reem Gody
        //=====================

        [TestMethod()]

        public void ReviewFinalMarksTest()
        {
            CTK.Data.InternalDS internalDS = createFakeInternalDataBase();

            var cnt = internalDS.MarkEntryTable.Count();
            Console.Write(cnt);

            bool no_missing_entries = true;
            bool no_mismatch = true;
            bool attendence_registered = true;


            //First : Mock the message box 
            //==============================

            Mock<CTK.IMessageBoxWrapper> messageBoxMock = new Mock<CTK.IMessageBoxWrapper>();
            messageBoxMock.Setup(n => n.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK, MessageBoxIcon.Stop));






            //-------------------------------------------------------------------------------

            //Test1: First entry or second entry is NULL
            //expected output : no_missing_entries = false
            //================================================

            BL.ReviewFinalMarks("ريض10", ref no_missing_entries, ref no_mismatch, ref attendence_registered, ref internalDS, messageBoxMock.Object);

            Assert.AreEqual(false, no_missing_entries); //Report bug

            //--------------------------------------------------------------------------------------

            //Test2: First entry and second entry are equal
            //expected output : no_mismatch = true
            //===================================================


            no_mismatch = false;
            no_missing_entries = true;



            CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
            m.CourseCode = "ريض10";
            m.SecondEntry = 100;
            m.FirstEntry = 100;
            m.StudentID = 3;
            m.BarCode = "123456789123";
            m.Name = "تمتم";
            m.Status = "ح";
            internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
            internalDS.MarkEntryTable.AcceptChanges();
            BL.ReviewFinalMarks("ريض10", ref no_missing_entries, ref no_mismatch, ref attendence_registered, ref internalDS, messageBoxMock.Object);


            Assert.AreEqual(true, no_mismatch);
            Assert.AreEqual(false, no_missing_entries); //Report bug
            //--------------------------------------------------------------------------------------------

            //Test3: First entry and second entry are not equal
            //expected output : no mismatch = false
            //===================================================



            no_mismatch = true;
            no_missing_entries = true;


            m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
            m.CourseCode = "ريض10";
            m.SecondEntry = 100;
            m.FirstEntry = 101;
            m.StudentID = 4;
            m.BarCode = "123456789023";
            m.Name = "مريم";
            m.Status = "ح";
            internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
            internalDS.MarkEntryTable.AcceptChanges();
            BL.ReviewFinalMarks("ريض10", ref no_missing_entries, ref no_mismatch, ref attendence_registered, ref internalDS, messageBoxMock.Object);


            Assert.AreEqual(false, no_mismatch);
            Assert.AreEqual(false, no_missing_entries); //Report bug



            //Test4: One of the two entries is less than 0
            //expected output: no missingentries = false
            //===============================================

            no_mismatch = true;
            no_missing_entries = true;


            m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
            m.CourseCode = "ريض10";
            m.SecondEntry = -100;
            m.FirstEntry = -101;
            m.StudentID = 4;
            m.BarCode = "123456789023";
            m.Name = "مريم";
            m.Status = "ح";
            internalDS.MarkEntryTable.AddMarkEntryTableRow(m);
            internalDS.MarkEntryTable.AcceptChanges();
            BL.ReviewFinalMarks("ريض10", ref no_missing_entries, ref no_mismatch, ref attendence_registered, ref internalDS, messageBoxMock.Object);

            Assert.AreEqual(false, no_mismatch);
            Assert.AreEqual(false, no_missing_entries); //Report bug


        }


        //Tester: @ Mariam Maher
        //Expected output : Filled Master table
        [TestMethod()]
        public void GetMasterTableTest()
        {
            Assert.Fail();
        }

        //Tester: @Reem AbdElSalam

        [TestMethod()]
        public void GetMasterRowBySSIDTest()
        {


            //TODO : create a function that creates a fake database similar to the function that I created above (createFakeDatabase),but for the master table

            Assert.Fail();
        }

        //Tester: @Hagar Hosny 
        [TestMethod()]
        public void IsNULLSSIDTest()
        {

            Assert.Fail();
        }

        //Tester: @Mariam Maher
        [TestMethod()]
        public void GetCourseCodeTest()
        {
            //Input = "ريض:10"
            //expected output = "ريض"

            Assert.Fail();
        }

        //Tester: @Reem AbdelSalam 
        //Note: Deal with msg boxes inside the function in the same way I did in ReviewFinalChanges
        [TestMethod()]
        public void ApproveEditSecreteNumbersTest()
        {
            Assert.Fail();
        }


        //Tester: @Hagar Hosny
        // You may need to use the function that creates fake tables that is created by Reem AbdelSalam
        [TestMethod()]
        public void RemoveCourseTest1()
        {
            Assert.Fail();
        }

        //Tester: @Reem Amr
        [TestMethod()]
        public void ValidateExamMarkedSchemaTest()
        {
            Assert.Fail();
        }
    }
}