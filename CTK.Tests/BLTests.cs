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
            //this function checks if the courseCode is null -> not in the database 
            //return true if the course code not in the database 
            //return false if the course in the database 

            //case1:the code is not in the database and the function returns false (right)
            //case2:the code is not in the database and the function returns true (wrong)
            string input = "1011";
            bool expected = false;
            bool actual = BL.IsNULLSSID(input);
            Assert.AreEqual(expected, actual);

            //case3: the code is in the database and SSID!=null 
            //and the function returns false (right)
            //case4: the code is in the database and SSID!=null 
            //and the function returns ture (wrong)
            input = "100";
            expected = false;
            actual = BL.IsNULLSSID(input);
            Assert.AreEqual(expected, actual);

            //case5: the code is in the database and SSID=null and the function returns true (right)
            //case6: the code is in the database and SSID=null and the function returns false (wrong)
            input = "101";
            expected = true;
            actual = BL.IsNULLSSID(input);
            Assert.AreEqual(expected, actual);
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
        public void RemoveCourseTest()
        {
            //case1:the first record removed and the second one didn't and the result false

            //case2:the 2 records removed & return true

            //case3:the 2 records isn't removed & return fasle

            //case4:the first is not removed & the second one removed & return true


            Assert.Fail();
        }

        [TestMethod()]
        public void MapMasterToBasicSecreteNumberTableTest()
        {
            Assert.Fail();
        }
    }

    //Tester: @Reem Amr

    [TestClass()]
    public class ReviewFinalMarksTestClass
    {

        CTK.Data.InternalDS internalDS;
        bool no_missing_entries;
        bool no_mismatch;
        bool attendence_registered;
        static Mock<CTK.IMessageBoxWrapper> messageBoxMock;
        private void createFakeInternalDataBase()
        {

           internalDS = new CTK.Data.InternalDS();


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

           
        }


        [ClassInitialize()]
        public static void createMockMessageBox(TestContext context)
        {


            messageBoxMock = new Mock<CTK.IMessageBoxWrapper>();
            messageBoxMock.Setup(n => n.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK, MessageBoxIcon.Stop));
        }


        [TestInitialize()]
        public void initializeFakeInternalDS()
        {

            Console.Write("Test initialize called");
            createFakeInternalDataBase();


        }

        //Test1: First entry or second entry is NULL
        //expected output : no_missing_entries = false
        //================================================


        [TestMethod()]
        public void ReviewFinalMarksTest_null_entries()
        {
            no_missing_entries = true;
            no_mismatch = true;
            attendence_registered = true;
            BL.ReviewFinalMarks("ريض10", ref no_missing_entries, ref no_mismatch, ref attendence_registered, ref internalDS, messageBoxMock.Object);
            Assert.AreEqual(false, no_missing_entries); //Report bug
        }


        //Test2: First entry and second entry are equal
        //expected output : no_mismatch = true
        //===================================================
        [TestMethod()]

        public void ReviewFinalMarksTest_matching_entries()
        {

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
        }


        //Test3: First entry and second entry are not equal
        //expected output : no mismatch = false
        //===================================================
        [TestMethod()]
        public void ReviewFinalMarksTest_non_matching_entries()
        {


            no_mismatch = true;
            no_missing_entries = true;

            CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
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

        }


        //Test4: One of the two entries is less than 0
        //expected output: no missingentries = false
        //===============================================
        [TestMethod()]
        public void ReviewFinalMarksTest_negative_entry()
        {
            no_mismatch = true;
            no_missing_entries = true;

            CTK.Data.InternalDS.MarkEntryTableRow m = internalDS.MarkEntryTable.NewMarkEntryTableRow();
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
            Assert.AreEqual(false, no_missing_entries); 
        }


    }




    //Tester: @Reem Amr
    //Coverage criteria : EC
    //------------------------

    [TestClass()]
    public class ExamMarkedSchemaValidation 
        {

        DataTable dt;
        [TestInitialize()]
        public void createTable()
        {
            dt = new DataTable();
        }




        //Input: Data table with two columns (الرقم السري - درجة التحريري)
        //expected output : res=True
        [TestMethod()]
        public void ValidateExamMarkedSchemaTest_validtable()
        {
            DataColumn col = new DataColumn();
            col.ColumnName = "درجة التحريري";
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "الرقم السري";
            dt.Columns.Add(col);

            bool res = BL.ValidateExamMarkedSchema(dt);
            Assert.AreEqual(true, res);
        }


        //Input: Data table with three columns (الرقم السري - درجة التحريري-المجموع)
        //expected output : res=false
        [TestMethod()]
        public void ValidateExamMarkedSchemaTest_invalidtable_wrongcolcnt()
        {
            DataColumn col = new DataColumn();
            col.ColumnName = "درجة التحريري";
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "الرقم السري";
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "المجموع";
            dt.Columns.Add(col);

            bool res = BL.ValidateExamMarkedSchema(dt);
            Assert.AreEqual(false, res);
        }


        //Input: Data table with two columns ( درجة التحريري-المجموع)
        //expected output : res=false
        [TestMethod()]
        public void ValidateExamMarkedSchemaTest_invalidtable_correctcnt_wronglabel()
        {
            DataColumn col = new DataColumn();
            col.ColumnName = "درجة التحريري";
            dt.Columns.Add(col);
 
            col = new DataColumn();
            col.ColumnName = "المجموع";
            dt.Columns.Add(col);

            bool res = BL.ValidateExamMarkedSchema(dt);
            Assert.AreEqual(false, res);
        }

    }

    //Tester: @Mariam Maher
    //-----------------------

    [TestClass()]
    public class courseCode
    {

        [TestMethod()]
        public void GetCourseCodeTest1()
        {
            //Input = "ريض:10"
            //expected output = "ريض"
            string test = "تستنج:402";
            string expected = "تستنج";
            string output = BL.GetCourseCode(test);
            Assert.AreEqual(expected,output);
        }

        [TestMethod()]
        public void GetCourseCodeTest2()
        {
            //Input = "ريض:10"
            //expected output = "ريض"
            string test = "تستنج";
            bool exceptionThrown = false;
            try
            {
                string output = BL.GetCourseCode(test);
            }
            catch(Exception exception)
            {
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod()]
        public void GetCourseCodeTest3()
        {
            //Input = "ريض:10"
            //expected output = "ريض"
            string test = "تستنج:402:505";
            string expected = "تستنج";
            string output = BL.GetCourseCode(test);

            Assert.AreEqual(expected,output);
  
        }
    }
}