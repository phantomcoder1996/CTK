using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MasterTable = CTK.Data.CTKDBDataSet.MasterDataTable;
using MasterRow = CTK.Data.CTKDBDataSet.MasterRow;
using MasterTable_Adapter = CTK.Data.CTKDBDataSetTableAdapters.MasterTableAdapter;
using DBQueries = CTK.Data.CTKDBDataSetTableAdapters.QueriesTableAdapter;
using DT_CourseTable = CTK.Data.CTKDBDataSet.CoursesDataTable;
using TA_CourseTable = CTK.Data.CTKDBDataSetTableAdapters.CoursesTableAdapter;
using DR_CourseTable = CTK.Data.CTKDBDataSet.CoursesRow;
using LOG = EOB.EOBLog;
using TA_INFO = CTK.Data.CTKDBDataSetTableAdapters.INFOTableAdapter;
using DT_INFO = CTK.Data.CTKDBDataSet.INFODataTable;
using DR_INFOROW = CTK.Data.CTKDBDataSet.INFORow;
using TA_Students = CTK.Data.CTKDBDataSetTableAdapters.StudentsTableAdapter;
using DT_Studnets = CTK.Data.CTKDBDataSet.StudentsDataTable;
using DR_StudentRow = CTK.Data.CTKDBDataSet.StudentsRow;
using DS_CTK = CTK.Data.CTKDBDataSet;
using TA_CTK = CTK.Data.CTKDBDataSetTableAdapters.TableAdapterManager;
using System.Drawing;
using System.Data.Entity;
using CTK.Data;

namespace CTK
{



    public interface IMessageBoxWrapper
    {
        DialogResult Show(string message,string title,MessageBoxButtons MsgBoxBtn,MessageBoxIcon icon);
    }

    public class MessageBoxWrapper : IMessageBoxWrapper
    {

        public DialogResult Show(string message, string title, MessageBoxButtons MsgBoxBtn, MessageBoxIcon icon)
        {

            return MessageBox.Show(message,title,MsgBoxBtn,icon);
        }
    }


    public static class BL
    {




        
        public static List<string> m_strLogFileBuffer = new List<string>();

        /// <sIt extracts the course code from the combined course name. The combined course name is full name that combines the course code and the course name in colone seprated string>
        /// 
        /// </summary>
        /// <param name="CombinedCoursename"></param>
        /// <returns></returns>
        public static string GetCourseCode(string CombinedCoursename)
        {
            string res = string.Empty;
            try
            {
                res = CombinedCoursename.Split(':')[0].Trim();
            }
            catch(NullReferenceException)
            {
                res = string.Empty;
            }
            catch (Exception)
            {

                 
            }
            return res;
        }


        public static void ReviewFinalMarks(string CourseCode, ref bool m_bNoMissingentries,ref bool m_bNoMismatch,ref bool m_bAttendanceRegistred,ref CTK.Data.InternalDS internalDS,IMessageBoxWrapper MessageBox)
        {
            try
            {
                

                if (CourseCode.Length == 0)
                //               if (CBX_CourseName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("لا يوجد مادة لعمل المراجعة. رجاء ادخال المادة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // LOG.ReportError(this, "لم يتم اختيار مادة قبل طلب المراجعة");
                    throw new Exception("لم يتم اختيار مادة قبل طلب المراجعة");
                }

                for (int i = 0; i < internalDS.MarkEntryTable.Rows.Count; i++)
                {
                    internalDS.MarkEntryTable[i].Review = 1;
                }

                #region Review for Missing Mark Entries
                DataRow[] buffer = internalDS.MarkEntryTable.Select("Firstentry is null or SecondEntry is null");

                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد بعض الدرجات  لم يتم رصدها سيتم تظليل الخلايا في الجدول باللون الاصفر ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 2;
                    }
                    m_bNoMissingentries = false;
                }
                else
                {
                    m_bNoMissingentries = true;

                }
                #endregion


                #region Check Logic Values


                buffer = internalDS.MarkEntryTable.Select("Firstentry < 0 or SecondEntry < 0");

                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد بعض الدرجات  اصغر من  0  سيتم تظليلها في الجدول باللون البرتقالي ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 4;
                    }
                    m_bNoMissingentries = false;
                }
                else
                {
                    m_bNoMissingentries = true;

                }

                #endregion



                #region Review for Mark mismatch

                buffer = internalDS.MarkEntryTable.Select("Firstentry <> SecondEntry ");
                if (buffer.Length > 0)
                {
                    MessageBox.Show(" .يوجد عدم تطابق بين الرصدين الاول و الثاني سيتم تظليل الخلايا في الجدول باللون الاحمر ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    foreach (DataRow r in buffer)
                    {
                        r["Review"] = 3;
                    }
                    m_bNoMismatch = false;
                }
                else
                {
                    m_bNoMismatch = true;
                }
                #endregion

                #region Review for Missing Attendnace
                // For now it is inherently calculated in Review for missing mark entries
                m_bAttendanceRegistred = true;
                #endregion


           


            }
            catch (Exception ex)
            {

               // LOG.ReportError(this, ex.Message);
            }
        }





        public static string[] GetCourseInformation(string fileName)
        {
            List<string> res = new List<string>();
            string[] splitters = { "-" };
            string[] buffer = fileName.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            if (buffer.Length != 5)
            {
                throw new Exception("Check file name, it should be in the standard format مادة--ريض01 -رياضيات1دفعة اعدادى-الترم الثانى-2008");
            }

            for (int i = 1; i < 5; i++)
            {
                res.Add(buffer[i].ToUpper().Trim());
            }
            return res.ToArray();

        }

        internal static DataTable GetMISSheet(string courseCode)
        {
            DataTable res = new DataTable();
            string MISFileName = GetMisFile(courseCode);
            res = EOB.IO.ExcelFile.ReadDataSet_PP(MISFileName).Tables[0];
            CTKDB_NMEntities ds = new CTKDB_NMEntities();
            for(int i=0;i< res.Rows.Count;i++)
            {
                string MISKey = res.Rows[i][0].ToString().Trim();
                var query = from item in ds.Master
                            where string.Compare(item.CourseID, courseCode) == 0 && string.Compare(MISKey, item.MISID) == 0
                            select item;
                if(query !=null)
                {
                    if(query.Count()==1)
                    {
                        Master r = query.First();
                        res.Rows[i][4] = r.ExamMark;
                    }
                    
                } 
                else
                {
                    throw new Exception("الملف MIS الذي تم دخاله غير متوافق مع ملف البيانات");
                }

            }

            return res;
        }

        internal static string[] GetAcademicClassList()
        {
            List<string> res = new List<string>();
            try
            {
                string file = string.Format("{0}\\ClassList.TXT",Context.ApplicationPath);
                string[] buff =  { "اولى كهرباء" ,"ثانية كهرباء اتصالات","ثالثة كهرباء اتصالات","رابعة كهرباء اتصالات","ثانية كهرباء قوى","ثالثة كهرباء قوى","رابعة كهرباء قوى","اولى مدني","ثانية مدني","ثالثة مدني","رابعة مدني","اولى عمارة","ثانية عمارة","ثالثة عمارة","رابعة عمارة","اولى صناعية","ثانية صناعية","ثالثة صناعية","رابعة صناعية","اولى كهرباء حسبات","اولى كهرباء اتصالات","اولى كهرباء قوى"};
                if (System.IO.File.Exists(file))
                {
                    buff = System.IO.File.ReadAllLines(file);
                }
                
                 
                res.AddRange(buff);
                
            }
            catch (Exception)
            {

                
            }
            return res.ToArray();
        }

        private static string GetMisFile(string courseCode)
        {
            string res = string.Empty;
            try
            {
                CTKDB_NMEntities ds = new CTKDB_NMEntities();
                var query = from item in ds.Courses
                            where string.Compare(courseCode, item.Code) == 0
                            select item;
                Courses v = query.First();
                string fileid = v.MISFileID;
                res = string.Format("{0}\\{1}.xlsx", Context.LocalMISPath, fileid);
            }
            catch (Exception)
            {

                
            }
            return res;
        }

        public static int DBVersion(string FileName = "")
        {
            int res = 1;
            try
            {
               // TA_INFO ta = new TA_INFO();
                if (FileName.Trim().Length != 0)
                {
                    //ta.Connection.ConnectionString = "Data Source= " + FileName;
                }
                
                CTKDB_NMEntities ds = new CTKDB_NMEntities();
                res = ds.VER.First().Major;
                //DT_INFO dt = ta.GetData();
                //DR_INFOROW r = (DR_INFOROW)dt.Rows[0];
                //res = r.VER;
            }
            catch (System.Data.SqlServerCe.SqlCeException sx)
            {
                res = 1;
            }
            catch (Exception ex)
            {
                res = -1;
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public static string GetPrototypefilePath()
        {
            string res = string.Empty;
            try
            {
                res = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\CTKDB.sdf";
            }
            catch (Exception ex)
            {
                
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        #region OldSystem
        public static bool DBMigrate(string FromFileName, string ProtoTypeFile, string ToFileName, ref List<string> LogBuffer)
        {
            bool res = false;
            try
            {
                LogBuffer.Add("--------------------------------------------------------");
                //LogBuffer.Add("Database migration:");
                //string ProtoTypeFile = GetPrototypefilePath();
                if (System.IO.File.Exists(ToFileName))
                {
                    LogBuffer.Add("Target Database exist. " + ToFileName);
                    System.IO.File.Delete(ToFileName);
                    LogBuffer.Add("Target Database " + ToFileName + " is temporarily deleted");
                }
                System.IO.File.Copy(ProtoTypeFile, ToFileName, true);
                LogBuffer.Add(ProtoTypeFile + " is copied to " + ToFileName);
                int FVer = DBVersion(FromFileName);
                LogBuffer.Add(FromFileName + " database is version " + FVer.ToString());
                if (!DBMigrate(FromFileName, ToFileName,false))
                {
                    throw new Exception("Failed to migrate " + FromFileName + " to " + ToFileName);
                }
                res = true;
                #region OldCode
                //switch (FVer)
                //{
                //    case 1:
                //        #region Migrating the Courses Table
                //        LogBuffer.Add("Migration from version 1 is being started");


                //        TA_CourseTable tc = new TA_CourseTable();
                //        tc.Connection.ConnectionString = "Data Source=" + FromFileName;
                //        DT_CourseTable ct = tc.GetData();
                //        LogBuffer.Add(ct.Rows.Count.ToString() + " Rows and " + ct.Columns.Count.ToString() + " columns are read from Courses Table from " + FromFileName);
                //        TA_CourseTable TC = new TA_CourseTable();
                //        TC.Connection.ConnectionString = "Data Source=" + ToFileName;
                //        DT_CourseTable targ = new DT_CourseTable();
                //        TC.Fill(targ);
                //        targ.AcceptChanges();
                //        foreach (DR_CourseTable r in ct.Rows)
                //        {
                //            DR_CourseTable tr = targ.NewCoursesRow();
                //            tr.BeginEdit();
                //            try
                //            {
                //                tr.Code = r.Code;
                //                tr.Name = r.Name;
                //                tr.MaximumClass = r.MaximumClass;
                //                tr.MaximumExam = r.MaximumExam;
                //            }
                //            catch (System.Data.StrongTypingException sx)
                //            {


                //            }
                //            tr.EndEdit();
                //            targ.Rows.Add(tr);
                //        }

                //        TC.Update(targ);
                //        LogBuffer.Add(targ.Rows.Count.ToString() + " Rows and " + targ.Columns.Count.ToString() + " columns are wrote into Courses Table in " + ToFileName);
                //        #endregion

                //        #region Migrating the Master Table

                //        MasterTable_Adapter ma = new MasterTable_Adapter();
                //        ma.Connection.ConnectionString = "Data Source=" + FromFileName;
                //        MasterTable mt_From = ma.GetData();
                //        LogBuffer.Add(mt_From.Rows.Count.ToString() + " Rows and " + mt_From.Columns.Count.ToString() + " columns are read from Master Table from " + ToFileName);
                //        MasterTable_Adapter ma_To = new MasterTable_Adapter();
                //        ma_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                //        MasterTable mt_TO = new MasterTable();
                //        ma_To.Fill(mt_TO);
                //        mt_TO.AcceptChanges();



                //        foreach (MasterRow mr in mt_From.Rows)
                //        {
                //            MasterRow mr_To = mt_TO.NewMasterRow();
                //            mr_To.BeginEdit();
                //            try
                //            {
                //                mr_To.CourseID = mr.CourseID;
                //                mr_To.StudentID = mr.StudentID;
                //                mr_To.Status = mr.Status;
                //                mr_To.SSID = mr.SSID;
                //                mr_To.ExamMark = mr.ExamMark;
                //            }
                //            catch (System.Data.StrongTypingException sx)
                //            {
                //            }
                //            mr_To.EndEdit();
                //            mt_TO.Rows.Add(mr_To);
                //        }



                //        ma_To.Update(mt_TO);
                //        LogBuffer.Add(mt_TO.Rows.Count.ToString() + " Rows and " + mt_TO.Columns.Count.ToString() + " columns are wrote into Master Table in " + ToFileName);
                //        #endregion

                //        #region Migrating Students Table
                //        TA_Students sa = new TA_Students();
                //        sa.Connection.ConnectionString = "Data Source=" + FromFileName;
                //        DT_Studnets st_From = sa.GetData();
                //        LogBuffer.Add(st_From.Rows.Count.ToString() + " Rows and " + st_From.Columns.Count.ToString() + " columns are read from students Table from " + FromFileName);
                //        TA_Students sa_To = new TA_Students();
                //        sa_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                //        DT_Studnets st_TO = new DT_Studnets();
                //        sa_To.Fill(st_TO);
                //        st_TO.AcceptChanges();



                //        foreach (DR_StudentRow sr in st_From.Rows)
                //        {
                //            DR_StudentRow sr_To = st_TO.NewStudentsRow();
                //            sr_To.BeginEdit();
                //            try
                //            {
                //                sr_To.Name = sr.Name;
                //                sr_To.StudentID = sr.StudentID;
                //                sr_To.AcademicYear = sr.AcademicYear;
                //                sr_To.AcademicClass = sr.AcademicClass;
                //            }
                //            catch (System.Data.StrongTypingException sx)
                //            {
                //            }
                //            sr_To.EndEdit();
                //            st_TO.Rows.Add(sr_To);
                //        }



                //        sa_To.Update(st_TO);
                //        LogBuffer.Add(st_TO.Rows.Count.ToString() + " Rows and " + st_TO.Columns.Count.ToString() + " columns are wrote into Students Table in " + ToFileName);
                //        #endregion

                //        break;
                //    case 2:
                //        // No migration is needed
                //        System.IO.File.Copy(FromFileName, ToFileName, true);
                //        break;
                //    default:
                //        throw new Exception("Not supported Database version");
                //        break;
                //} 
                #endregion

            }
            catch (Exception ex)
            {
                LogBuffer.Add(ex.Message);
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        internal static Guid CopyMISFile(string fileName)
        {
            Guid res = new Guid();
            try
            {
                res = Guid.NewGuid();
                string LocalPath = Context.LocalMISPath;
                string TargetFile = string.Format("{0}\\{1}.xlsx", LocalPath,res);
                System.IO.File.Copy(fileName, TargetFile, true);
                if(!System.IO.File.Exists(TargetFile))
                {
                    throw new Exception("Failed to copy the MIS file into the local path");
                } 
            }
            catch (Exception ex)
            {
                res = new Guid(0,0,0,0,0,0,0,0,0,0,0);
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        internal static bool UpdateMasterTable(InternalDS.MarkEntryTableDataTable markEntryTable)
        {
            bool res = true;
            try
            {
                CTKDB_NMEntities ds = new CTKDB_NMEntities();
                for(int i=0;i<markEntryTable.Rows.Count;i++)
                {

                    InternalDS.MarkEntryTableRow r = markEntryTable[i];
                    string key = r.BarCode .ToString();
                    //var v = ds.Master.Select(x => x.StudentID == key);
                    var query = from item in ds.Master
                                where string.Compare( item.SSID.Trim() , key.Trim()) == 0
                                select item;
                    if(query !=null)
                    {
                        switch(query.Count())
                        {
                            case 1:
                                Master mr = query.First();
                                mr.ExamMark = r.FirstEntry;
                                
                                break;
                            default:
                                throw new Exception("اسم او كثر متكررين في ملف البيانات.");
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("اسم او كثرلا يوجد لهم رقم جلوس في ملف البيانات.");
                    }
                    
                    

                    
                }

                ds.SaveChanges();
                
            }
            catch (Exception ex)
            {

                res = false;
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        public static string RemoveInternSpaces(string input)
        {
            input = input.Trim();
            string pattern = @"\s+";
            input = System.Text.RegularExpressions.Regex.Replace(input, pattern, "");
            return input;

        }
        /// <summary>
        /// Remove all decorations and extra spaces. It also normalize the arabic letters by removing hamza, converting TeahMarbota into haa and adding dots to dot-less yah
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Normalize(string input)
        {
            string res = string.Empty;
            try
            {
                //  Normalization is defined as:

                //Normalization of hamza with alef seat to a bare alef.
                //Normalization of teh marbuta to heh
                //Normalization of dotless yeh (alef maksura) to yeh.
                //Removal of Arabic diacritics (the harakat)
                //Removal of tatweel(stretching character).
                input = input.Trim();
                string pattern = @"\s{2}\s*";
                input = System.Text.RegularExpressions.Regex.Replace(input, pattern, " ");
                int[] decoractives = { 1600, 1615, 1612, 1614, 1611, 1616, 1613, 1617, 1618 };
                int[] ALEF = { 1571, 1573, 1570 };//->1575
                int Tehmarbuta = 1577; //->1607
                int dotlessYeah = 1609; //->1610
                char[] buf = input.ToCharArray();
                List<char> obuf = new List<char>();
                for (int i = 0; i < buf.Length; i++)
                {
                    if (decoractives.Contains(buf[i]))
                    {
                        continue;
                    }
                    if (ALEF.Contains(buf[i]))
                    {
                        buf[i] = 'ا';
                    }
                    if (buf[i] == Tehmarbuta)
                    {
                        buf[i] = 'ه';
                    }
                    if (buf[i] == dotlessYeah)
                    {
                        buf[i] = 'ي';
                    }

                    obuf.Add(buf[i]);
                }
                res = string.Concat(obuf.ToArray());
            }
            catch (Exception)
            {


            }
            return res;
        }
        internal static bool ImportCourse(string courseName, string courseCode, int examMaximumLimit, int activityMaximumLimit, DataTable studentList, string AcademicTerm,string AcademicYear,Guid misLocalID,string AcademicClass)
        {
            bool res = true;
            try
            {
                if(courseCode.Trim().Length==0)
                {
                    throw new Exception("لابد من ادخال كود المادة للاستمرار");
                }
                courseCode = RemoveInternSpaces(courseCode);
                courseCode = Normalize(courseCode);

                CTKDB_NMEntities ds = new CTKDB_NMEntities();
                
                    foreach (DataRow r in studentList.Rows)
                    {
                        List<string> record = new List<string>();
                        record.Add(courseCode);
                        record.Add(courseName);
                        record.Add(AcademicTerm);
                        record.Add(AcademicYear);
                        record.Add(r["SID"].ToString());
                        record.Add(r["Name"].ToString());
                        record.Add(r["MISID"].ToString());
                        record.Add(examMaximumLimit.ToString());
                        record.Add(activityMaximumLimit.ToString());
                        record.Add(misLocalID.ToString());
                        record.Add(AcademicClass);  
                        if(!BL.InsertMasterRecord_NM(record.ToArray(),ref ds))
                        {
                        LOG.ReportError(null, "Can't  import the record for " + r["Name"].ToString());
                        }


                    }
                int n = ds.SaveChanges();
               
            }
            catch (Exception ex)
            {
                res = false;
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        private static bool InsertMasterRecord_NM(string[] record, ref CTKDB_NMEntities ds)
        {
            bool res = true;
            


            try
            {
                if (!IsNumeric(record[4]))
                {
                    throw new Exception("Student Id = " + record[4] + " is excluded.");


                }

                string CourseCode = record[0];
                string MISID = record[6];
                string LocalMISID = record[9];

                string StudentSeatID = record[4];


                if (!CourseExist_NM(ds, CourseCode))


                {
                    int temp = 0;
                    Courses x = new Courses();
                    x.Code = CourseCode;
                    x.Name = record[1];
                    // x. = LocalMISID;
                    x.MISFileID = LocalMISID;
                    if(int.TryParse(record[7],out temp))
                    {
                        x.MaximumExam = temp;
                    }
                    if (int.TryParse(record[8], out temp))
                    {
                        x.MaximumClass = temp;
                    }
                    ds.Courses.Add(x);
                    ds.SaveChanges();
                }



                if (!StudentExist_NM(ds, StudentSeatID))

                {


                    Students xx = new Students();
                    xx.Name = record[5];
                    xx.StudentID = record[4];
                    xx.AcademicYear = record[3];
                    xx.AcademicClass = record[10];
                    ds.Students.Add(xx);

                    ds.SaveChanges();

                }
                if (!ValidateMasterEntry_NM(ds, StudentSeatID, CourseCode))
                {
                    Master x = new Master();
                    x.StudentID = StudentSeatID;
                    x.CourseID = CourseCode;
                    x.MISID = MISID;
                    ds.Master.Add(x);

                }
                
            }
            catch (Exception ex)
            {
                res = false;
                
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        private static bool InsertMasterRecord_NM(string[] record)
        {
            bool res = true;
            CTKDB_NMEntities ds = new CTKDB_NMEntities();

            
            try
            {
                if (!IsNumeric(record[4]))
                {
                    throw new Exception("Student Id = " + record[4] + " is excluded.");


                }

                string CourseCode = record[0];
                string MISID = record[6];
                
                
                 string StudentSeatID = record[4];

                
                if (!CourseExist_NM(ds, CourseCode))

                
                {

                    Courses x = new Courses();
                    x.Code = CourseCode;
                    x.Name = record[1];
                    ds.Courses.Add(x);
                    
                }


               
                if (!StudentExist_NM(ds, StudentSeatID))

                {

                    
                    Students xx = new Students();
                    xx.Name = record[5];
                    xx.StudentID = record[4];
                    xx.AcademicYear = record[3];
                    ds.Students.Add(xx);
                        
                    
                    
                }
                if (!ValidateMasterEntry_NM(ds, StudentSeatID, CourseCode))
                {
                    Master x = new Master();
                    x.StudentID = StudentSeatID;
                    x.CourseID = CourseCode;
                    x.MISID = MISID;
                    ds.Master.Add(x);
                    
                }
                int n = ds.SaveChanges();
            }
            catch (Exception ex)
            {
                res = false;
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        private static bool ValidateMasterEntry_NM(CTKDB_NMEntities ds, string studentSeatID, string courseCode)
        {
            bool res = true;
            try
            {
                var items = from item in ds.Master
                            where item.StudentID == studentSeatID && item.CourseID == courseCode
                            select new
                            {

                            };
                if (items.Count() == 0)
                {
                    res = false;

                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }

        private static bool StudentExist_NM(CTKDB_NMEntities ds, string studentSeatID)
        {
            bool res = true;
            try
            {
                var items = from item in ds.Students
                            where item.StudentID == studentSeatID
                            select new
                            {

                            };
                if (items.Count() == 0)
                {
                    res = false;

                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }

        private static bool CourseExist_NM(CTKDB_NMEntities ds, string CourseCode)
        {
            bool res = true;
            try
            {
                var items = from item in ds.Courses
                            where item.Code == CourseCode
                            select new
                            {

                            };
                if (items.Count() == 0)
                {
                    res = false;

                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }

        internal static bool ImportFromMISFile(string fileName,out DataTable studentsList , ref string CourseName)
        {
            bool res = true;
            studentsList = new DataTable();
            studentsList.Columns.Add("MISID");
            studentsList.Columns.Add("SID");
            studentsList.Columns.Add("Name");
            try
            {
                DataSet ds = EOB.IO.ExcelFile.ReadDataSet_PP(fileName);
                if(ds.Tables.Count>1)
                {
                    throw new Exception(string.Format("{0} sheets in the file {1}. You should remove all sheets but not the required one. Do this correction and then try again"));
                }
                string[] splitters = { ":"}; 
                CourseName = ds.Tables[0].Columns[1].ColumnName.Trim().Split(splitters, StringSplitOptions.RemoveEmptyEntries)[1] ;

                //ds.Tables[0].Rows[0].Delete();
                //ds.Tables[0].Rows[1].Delete();
                //ds.Tables[0].Rows[2].Delete();
                //ds.AcceptChanges();
                var results = from item in ds.Tables[0].AsEnumerable()
                            select new
                            {
                                MISID = item.Field<string>(0),
                                SID = item.Field<string>(1),
                                Name = item.Field<string>(2)

                            };

               // foreach(var record in results)
               for(int i=2;i<results.Count();i++)
                {
                    var record = results.ToList()[i];
                    DataRow r = studentsList.NewRow();
                    r["MISID"] = record.MISID;
                    r["SID"] = CleanID (record.SID);
                    r["Name"] = record.Name;
                    studentsList.Rows.Add(r);
                }
            }
            catch(IndexOutOfRangeException xx)
            {
                res = false;
                LOG.ReportError(null,fileName+ " is open or is contains no sheets. Check it and try again");
            }
            catch (Exception ex)
            {

                res = false;
               
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        private static string CleanID(string input)
        {
            string res = string.Empty;
            string pattern = "([\"])";
            res = System.Text.RegularExpressions.Regex.Replace(input, pattern, "");
            return res;
        }

        /// <summary>
        /// migrate the database file given by Filename into the file given by ToFileName
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool DBMigrate(string FromFileName, string ToFileName, bool UsePrototype = true)
        {
            bool res = false;
            try
            {

                if (UsePrototype)
                {
                    string ProtoTypeFile = GetPrototypefilePath();
                    if (System.IO.File.Exists(ToFileName))
                    {
                        System.IO.File.Delete(ToFileName);
                    }
                    System.IO.File.Copy(ProtoTypeFile, ToFileName, true); 
                }
                int FVer = DBVersion(FromFileName);
                switch (FVer)
                {
                    case 1:
                        #region Migrating the Courses Table



                        TA_CourseTable tc = new TA_CourseTable();
                        tc.Connection.ConnectionString = "Data Source=" + FromFileName;
                        DT_CourseTable ct = tc.GetData();
                        TA_CourseTable TC = new TA_CourseTable();
                        TC.Connection.ConnectionString = "Data Source=" + ToFileName;
                        DT_CourseTable targ = new DT_CourseTable();
                        TC.Fill(targ);
                        targ.AcceptChanges();
                        foreach (DR_CourseTable r in ct.Rows)
                        {
                            DR_CourseTable tr = targ.NewCoursesRow();
                            tr.BeginEdit();
                            try
                            {
                                tr.Code = r.Code;
                                tr.Name = r.Name;
                                tr.MaximumClass = r.MaximumClass;
                                tr.MaximumExam = r.MaximumExam;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {


                            }
                            tr.EndEdit();
                            targ.Rows.Add(tr);
                        }

                        TC.Update(targ);
                        #endregion

                        #region Migrating the Master Table

                        MasterTable_Adapter ma = new MasterTable_Adapter();
                        ma.Connection.ConnectionString = "Data Source=" + FromFileName;
                        MasterTable mt_From = ma.GetData();
                        MasterTable_Adapter ma_To = new MasterTable_Adapter();
                        ma_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                        MasterTable mt_TO = new MasterTable();
                        ma_To.Fill(mt_TO);
                        mt_TO.AcceptChanges();



                        foreach (MasterRow mr in mt_From.Rows)
                        {
                            MasterRow mr_To = mt_TO.NewMasterRow();
                            mr_To.BeginEdit();
                            try
                            {
                                mr_To.CourseID = mr.CourseID;
                                mr_To.StudentID = mr.StudentID;
                                mr_To.Status = mr.Status;
                                mr_To.SSID = mr.SSID;
                                mr_To.ExamMark = mr.ExamMark;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {
                            }
                            mr_To.EndEdit();
                            mt_TO.Rows.Add(mr_To);
                        }



                        ma_To.Update(mt_TO);
                        #endregion

                        #region Migrating Students Table
                        TA_Students sa = new TA_Students();
                        sa.Connection.ConnectionString = "Data Source=" + FromFileName;
                        DT_Studnets st_From = sa.GetData();
                        TA_Students sa_To = new TA_Students();
                        sa_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                        DT_Studnets st_TO = new DT_Studnets();
                        sa_To.Fill(st_TO);
                        st_TO.AcceptChanges();



                        foreach (DR_StudentRow sr in st_From.Rows)
                        {
                            DR_StudentRow sr_To = st_TO.NewStudentsRow();
                            sr_To.BeginEdit();
                            try
                            {
                                sr_To.Name = sr.Name;
                                sr_To.StudentID = sr.StudentID;
                                sr_To.AcademicYear = sr.AcademicYear;
                                sr_To.Class = sr.Class;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {
                            }
                            sr_To.EndEdit();
                            st_TO.Rows.Add(sr_To);
                        }



                        sa_To.Update(st_TO);
                        #endregion

                        break;

                    case 2:
                        #region Migrating the Courses Table



                        tc = new TA_CourseTable();
                        tc.Connection.ConnectionString = "Data Source=" + FromFileName;
                        ct = tc.GetData();
                        TC = new TA_CourseTable();
                        TC.Connection.ConnectionString = "Data Source=" + ToFileName;
                        targ = new DT_CourseTable();
                        TC.Fill(targ);
                        targ.AcceptChanges();
                        foreach (DR_CourseTable r in ct.Rows)
                        {
                            DR_CourseTable tr = targ.NewCoursesRow();
                            tr.BeginEdit();
                            try
                            {
                                tr.Code = r.Code;
                                tr.Name = r.Name;
                                tr.MaximumClass = r.MaximumClass;
                                tr.MaximumExam = r.MaximumExam;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {


                            }
                            tr.EndEdit();
                            targ.Rows.Add(tr);
                        }

                        TC.Update(targ);
                        #endregion

                        #region Migrating the Master Table

                        ma = new MasterTable_Adapter();
                        ma.Connection.ConnectionString = "Data Source=" + FromFileName;
                        mt_From = ma.GetData();
                        ma_To = new MasterTable_Adapter();
                        ma_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                        mt_TO = new MasterTable();
                        ma_To.Fill(mt_TO);
                        mt_TO.AcceptChanges();



                        foreach (MasterRow mr in mt_From.Rows)
                        {
                            MasterRow mr_To = mt_TO.NewMasterRow();
                            mr_To.BeginEdit();
                            try
                            {
                                mr_To.CourseID = mr.CourseID;
                                mr_To.StudentID = mr.StudentID;
                                mr_To.Status = mr.Status;
                                mr_To.SSID = mr.SSID;
                                mr_To.ExamMark = mr.ExamMark;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {
                            }
                            mr_To.EndEdit();
                            mt_TO.Rows.Add(mr_To);
                        }



                        ma_To.Update(mt_TO);
                        #endregion

                        #region Migrating Students Table
                        sa = new TA_Students();
                        sa.Connection.ConnectionString = "Data Source=" + FromFileName;
                        st_From = sa.GetData();
                        sa_To = new TA_Students();
                        sa_To.Connection.ConnectionString = "Data Source=" + ToFileName;
                        st_TO = new DT_Studnets();
                        sa_To.Fill(st_TO);
                        st_TO.AcceptChanges();



                        foreach (DR_StudentRow sr in st_From.Rows)
                        {
                            DR_StudentRow sr_To = st_TO.NewStudentsRow();
                            sr_To.BeginEdit();
                            try
                            {
                                sr_To.Name = sr.Name;
                                sr_To.StudentID = sr.StudentID;
                                sr_To.AcademicYear = sr.AcademicYear;
                                sr_To.Class = sr.Class;
                            }
                            catch (System.Data.StrongTypingException sx)
                            {
                            }
                            sr_To.EndEdit();
                            st_TO.Rows.Add(sr_To);
                        }



                        sa_To.Update(st_TO);
                        #endregion

                        break;
                    case 3:
                        MessageBox.Show("Not supported version");
                        break;
                    case 4:
                    case 5:
                        // No migration is needed
                        System.IO.File.Copy(FromFileName, ToFileName, true);
                    
                        break;
                    default:
                        throw new Exception("Not supported Database version");
                        break;
                }
                res = true;
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public static DateTime DBReleaseDate(string FileName = "")
        {
            DateTime res = DateTime.Now;
            try
            {
                TA_INFO ta = new TA_INFO();
                if (FileName.Trim().Length != 0)
                {
                    ta.Connection.ConnectionString = "Data Source= " + FileName;
                }
                DT_INFO dt = ta.GetData();
                DR_INFOROW r = (DR_INFOROW)dt.Rows[0];
                res = r.RELEASE;
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Remove all occurrences for course from courses and master datatables.
        /// </summary>
        /// <param name="CourseCode"></param>
        /// <returns></returns>
        public static int RemoveCourse(string CourseCode)
        {
            int res = 0;
            try
            {
                //CTK.Data.CTKDBEntities db = new Data.CTKDBEntities();
                

                MasterTable_Adapter ta = new MasterTable_Adapter();
                res = ta.DeleteByCourseCode(CourseCode);
                LOG.ReportInfo(null, res.ToString() + " records are removed from Master database for " + CourseCode);
                TA_CourseTable ta1 = new TA_CourseTable();
                res = ta1.DeleteByCourseCode(CourseCode);
                LOG.ReportInfo(null, res.ToString() + " records are removed from courses database for " + CourseCode);
            }
            catch (Exception ex)
            {
                LOG.ReportError(null, ex.Message);

            }
            return res;
        }
        public static void UpdateGradesInMISSheet(string file, string CourseCode)
        {
            //1- Validate Grades into the specified Course
            //1- Import the MIS file into MIS Datatable 
            // UC_Screen.Print("Importing the file " + UC_MISFile.Text);
            EOB.IO.ExcelFile xf = null;

            try
            {
                DBQueries dbq = new DBQueries();
                xf = new EOB.IO.ExcelFile(file);
                int Columns = xf.ColumnsCount;
                int Rows = xf.RowsCount;
                string pattern = "\"";

                EOB.Windows.Forms.ShowWaitDialog();
                double count = xf.RowsCount - xf.StartingRow;
                for (int i = xf.StartingRow + 1; i < xf.RowsCount; i++)
                {
                    string SSID = xf.GetCell(i, 2);
                    SSID = System.Text.RegularExpressions.Regex.Replace(SSID, pattern, "");
                    int c = Convert.ToInt32(dbq.CheckStudentCourseExist(CourseCode, SSID));
                    if (c == 0)
                    {
                        EOB.EOBLog.ReportInfo(null, "Student " + SSID + " has no records into the course " + CourseCode);
                        continue;
                    }
                    int SMark = Convert.ToInt32(dbq.GetExamMark(CourseCode, SSID));
                    string oldval = xf.SetCell(i, 6, SMark.ToString());
                    EOB.Windows.Forms.ReportProgress(Convert.ToInt32(i * 100 / xf.RowsCount));
                    EOB.EOBLog.ReportInfo(null, "Student [" + SSID + "] :Value is changed from " + oldval + " to " + SMark.ToString());
                }



            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            EOB.Windows.Forms.ReportProgress(100);
            xf.Close();
            //DataTable MISTable = EOB.IO.ExcelFile.Import(UC_MISFile.Text,2);
            //2- Validate schema of MIS Datatable
            //3- Fill MIS datatable with Grades the key is Student ID
            //4- Export to Excel Sheet Same name with _U appended to the file name
        }


        public static string UpdateGradesInMISSheet_NM(string CourseCode)
        {
            //1- Validate Grades into the specified Course
            //1- Import the MIS file into MIS Datatable 
            // UC_Screen.Print("Importing the file " + UC_MISFile.Text);
            EOB.IO.ExcelFile xf = null;
            string res = string.Empty;
            try
            {
                string file = DAL.GetMISFile(CourseCode);
                DBQueries dbq = new DBQueries();
                xf = new EOB.IO.ExcelFile(file);
                //int Columns = xf.ColumnsCount;
                //int Rows = xf.RowsCount;
                //string pattern = "\"";

                EOB.Windows.Forms.ShowWaitDialog();
                double count = xf.RowsCount - xf.StartingRow;
                for (int i = xf.StartingRow + 1; i <= xf.RowsCount; i++)
                {
                    string MISID = xf.GetCell(i, 1);
                    if (MISID == null) continue;
                    if (!IsNumeric(MISID)) continue;
                    string StudentName = xf.GetCell(i, 3);
                    //SSID = System.Text.RegularExpressions.Regex.Replace(SSID, pattern, "");
                    //int c = Convert.ToInt32(dbq.CheckStudentCourseExist(CourseCode, SSID));
                    int c = DAL.GetMark(MISID);
                    if (c < 0)
                    {
                        EOB.EOBLog.ReportInfo(null, "Student " + StudentName + " has no records into the course " + CourseCode);
                        continue;
                    }
                    //int SMark = Convert.ToInt32(dbq.GetExamMark(CourseCode, SSID));
                    string oldval = xf.SetCell(i, 5, c.ToString());
                    EOB.Windows.Forms.ReportProgress(Convert.ToInt32(i * 100 / xf.RowsCount));
                    EOB.EOBLog.ReportInfo(null, "Student [" + StudentName + "] :Value is changed from " + oldval + " to " + c.ToString());
                }

                res = file;

            }
            catch (Exception ex)
            {
                res = string.Empty;
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            EOB.Windows.Forms.ReportProgress(100);
            xf.Close();
            return res;
            //DataTable MISTable = EOB.IO.ExcelFile.Import(UC_MISFile.Text,2);
            //2- Validate schema of MIS Datatable
            //3- Fill MIS datatable with Grades the key is Student ID
            //4- Export to Excel Sheet Same name with _U appended to the file name
        }
        public static void DBInstallerDBMigrate(string srcFile, string distFile)
        {
            //MasterTable mstr = new MasterTable();

            //System.Data.SqlServerCe.SqlCeConnection SrcCon = new System.Data.SqlServerCe.SqlCeConnection(Properties.Settings.Default.CTKDBConnectionString1);

            //System.Data.SqlServerCe.SqlCeConnection DistCon = new System.Data.SqlServerCe.SqlCeConnection(Properties.Settings.Default.CTKDBConnectionString);

            //System.Data.SqlServerCe.SqlCeCommand src_Master_Command = new System.Data.SqlServerCe.SqlCeCommand("SELECT ID, CourseID, StudentID, ExamMark FROM Master", SrcCon);

            //System.Data.SqlServerCe.SqlCeCommand dist_Insert_Command = new System.Data.SqlServerCe.SqlCeCommand( "INSERT INTO Master (CourseID, StudentID, ExamMark, SSID, Status) VALUES        (@p1,@p2,@p3,@P4,@P5)", DistCon);

            //System.Data.SqlServerCe.SqlCeDataAdapter distMasterAdapter = new System.Data.SqlServerCe.SqlCeDataAdapter();
            //distMasterAdapter.InsertCommand = dist_Insert_Command;


            //System.Data.SqlServerCe.SqlCeDataAdapter src_MAster_Adapter = new System.Data.SqlServerCe.SqlCeDataAdapter(src_Master_Command);
            //CTK.Data.CTKDBDataSet ds = new Data.CTKDBDataSet();

            //src_MAster_Adapter.Fill(mstr);   

        }
        public static void FixDbase()
        {
            try
            {
                string DBTargetFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\CTKDB.sdf";
                string DBSourceFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\CTKDB.sdf";
                string DataFolder = System.IO.Path.GetDirectoryName(DBTargetFile);



                if (System.IO.Directory.Exists(DataFolder))
                {
                    if (System.IO.File.Exists(DBTargetFile))
                    {
                        //Task: do not migaret unless wrong version
                        int ver = DBVersion();
                        if (ver != 5)
                        {
                            DBMigrate(DBSourceFile, DBTargetFile);
                        }


                    }
                    else
                    {
                        //Database file is missing. 
                        System.IO.File.Copy(DBSourceFile, DBTargetFile);
                    }
                }
                else
                {
                    // Directory is missing
                    System.IO.Directory.CreateDirectory(DataFolder);
                    System.IO.File.Copy(DBSourceFile, DBTargetFile);
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
        }
        public static void DBInstallerPost(string TargeDir, ref List<string> LogBuffer)
        {
            try
            {
                LogBuffer.Add("----------------------------------------------------");
                LogBuffer.Add("Post Install Activities:");
                string BackupFile = TargeDir + @"\Backup.SDF";//Old Dbfile before install
                string DBFile = TargeDir + @"\Data\CTKDB.SDF";// Installed DB file
                string ProtoType = TargeDir + @"\CTKDB.SDF";
                LogBuffer.Add("Database migration will start");
                DBMigrate(BackupFile, ProtoType, DBFile, ref LogBuffer);
                //if (!System.IO.File.Exists(DBFile))
                //{
                //    // In case of missing Dbfile, copy the prototype file into the data folder

                //    // System.IO.File.Copy(bac, DBFile, true);\
                //    DBMigrate(BackupFile, ProtoType, DBFile, ref LogBuffer);
                //    // LogBuffer.Add(DBFile + " is not detected. The prototype " + ProtoType + " is copied ");
                //}
                //else
                //{
                //    // Migrate From Backup to Current DB

                //    LogBuffer.Add("Database migration will start");
                //    DBMigrate(BackupFile, ProtoType, DBFile, ref LogBuffer);
                //}
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
        }
        public static void DBInstallerPre(string TargetDir, ref List<string> LogBuffer)
        {
            try
            {

                LogBuffer.Add("----------------------------------------------------");
                LogBuffer.Add("Pre Install Activities:");
                string BackupFile = TargetDir + @"\Backup.SDF";
                string DBFile = TargetDir + @"\Data\CTKDB.SDF";
                if (System.IO.File.Exists(DBFile))
                {
                    LogBuffer.Add(DBFile + " is detected into the subfolder Data under the Target Directory. This file will be moved to " + BackupFile);
                    System.IO.File.Copy(DBFile, BackupFile, true);
                    //System.IO.File.Delete(DBFile);
                }
                else
                {
                    LogBuffer.Add(DBFile + " is not detected into the subfolder Data under the Target Directory. ");
                }


            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
        }
        // public static string GetStatusFromUseer()
        /// <summary>
        /// Check the database foe the validity of changing secrete numbers. User is announced, then the function returns true in case of approving from user.
        /// </summary>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        public static bool ApproveEditSecreteNumbers(string courseCode)
        {
            bool res = false;
            try
            {
                if (!IsNULLSSID(courseCode))
                {
                    if (MessageBox.Show("يوجد بالفعل ارقام سرية لهذا المقرر. انت بصدد مسح هذه الارقام و استبدالها بأرقام أخرى. في هذه الحالة لا يمكن الرجوع مرة اخرى و لا يمكن ربط الارقام القديمة بكشوف رصد التحريري بشكل تلقائي. هل تريد الاستمرار؟ ", "إحذر", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MessageBox.Show("سيتم التغيير الان هل انت متأكد؟", "تحذير نهائي", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            throw new Exception("لم يحدث تغيير الارقام السرية");
                        }
                    }
                }
                res = true;
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Check the database if SSID is null for give course
        /// </summary>
        /// <param name="Coursecode"></param>
        /// <returns></returns>
        public static bool IsNULLSSID(string Coursecode)
        {
            bool res = false;// Default answer is No
            //DBQueries q = new DBQueries();
            //int c =(int) q.CountOfSSIDByCourseCode(Coursecode);
            //Task: need to refactor this function in order that to ensure nullable. Suggestion to make a pass over all SSID, if repeated as zero then put it as nullable 
            MasterTable dt = GetMAsterTableByCourseCode(Coursecode);
            foreach (MasterRow r in dt.Rows)
            {
                string prev = r.SSID;
                if (prev.Trim().Length == 0)
                {
                    res = true; // Case of Null entry, So the answer will be yes
                    break;
                }

            }
            //if (c > 0)
            //{
            //    res = false;
            //}
            return res;
        }
        /// <summary>
        /// Remove all data from Database
        /// </summary>
        public static void ClearDatabase()
        {
            try
            {
                DBQueries db = new DBQueries();
                int a = db.ClearCourseTable();
                int b = db.ClearMasterTable();
                int c = db.ClearStudentsTable();
                EOB.EOBLog.ReportInfo(null, "The following records are deleted:\n\r\tCourse Table:" + a.ToString() + "\n\r\tMaster Table:" + b.ToString() + "\n\r\tStudents Table:" + c.ToString());
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
        }

        public static MasterTable GetMasterTable()
        {
            MasterTable mt = new MasterTable();
            MasterTable_Adapter ma = new MasterTable_Adapter();
            ma.Fill(mt);
            return mt;
        }

        public static void UpdateMasterTable(MasterTable master)
        {
            MasterTable_Adapter ma = new MasterTable_Adapter();
            int m = ma.Update(master);
        }
        /// <summary>
        /// It use the data table to modify the master table SSID field.
        /// </summary>
        /// <param name="data"></param>
        public static void UpdateMasterTable_SecreteNumbers(DataTable data, string CourseCode)
        {
            MasterTable mt = GetMasterTable();

            foreach (DataRow r in data.Rows)
            {
                string SID = r["رقم الجلوس"].ToString();
                string SSID = r["الرقم السري"].ToString();
                string Status = r["الحالة"].ToString();
                MasterRow[] rbuffer = (MasterRow[])mt.Select("StudentID = '" + SID + "'" + " and CourseID = '" + CourseCode + "'");
                switch (rbuffer.Length)
                {
                    case 0:
                        throw new Exception("Student with ID = " + SID + " is not exist into the Database. This is fatal error. Check the integrity");
                        break;

                    case 1:
                        rbuffer[0].SSID = SSID;
                        rbuffer[0].Status = Status;
                        break;
                    default:
                        throw new Exception("Student with ID = " + SID + " appears " + rbuffer.Length.ToString() + " times into the same course [" + CourseCode + "]. This is fatal error. Check the integrity");
                        break;
                }
            }

            UpdateMasterTable(mt);

        }

        public static DataTable GetCourseConfData(string CourseCode)
        {

            MasterTable_Adapter ma = new MasterTable_Adapter();
            DataTable dt = new DataTable();
            try
            {
                MasterTable dtt = new MasterTable();
                ma.FillByCourseCode_All(dtt, CourseCode, "ح");
                List<UInt32> buffer = new List<uint>();
                foreach (DataRow c in dtt.Rows)
                {
                    DataRow r = dt.NewRow();
                    buffer.Add(Convert.ToUInt32(c["SSID"]));
                    //  r["الدرجة العظمى للتحريري"] = c["MaximumExam"];

                }
                buffer.Sort();

                dt.Columns.Add("درجة التحريري");
                dt.Columns.Add("الرقم السري");
                for (int i = 0; i < buffer.Count; i++)
                {
                    DataRow r = dt.NewRow();
                    r["الرقم السري"] = buffer[i];
                    //  r["الدرجة العظمى للتحريري"] = c["MaximumExam"];
                    dt.Rows.Add(r);
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return dt;
        }
        public static bool IsNumeric(string token)
        {
            bool res = false;
            string pattern = @"\d+";
            if (System.Text.RegularExpressions.Regex.IsMatch(token, pattern))
            {
                res = true;
            }
            return res;
        }
        /// <summary>
        /// Retrieve the list of students from the master table. It decods the codes into student name and course name 
        /// </summary>
        /// <param name="CourseCode"></param>
        /// <returns></returns>
        public static DataTable GetStudentListFromMasterTable(string CourseCode)
        {
            DataTable res = new DataTable();
            res.Columns.Add("الرقم السري");
            res.Columns.Add("اسم الطالب");
            res.Columns.Add("رقم الجلوس");
            res.Columns.Add("الحالة");
            MasterTable buffer = null;
            try
            {
                CTK.Data.CTKDBDataSetTableAdapters.MasterTableAdapter ms = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
                //  Students.Name AS [اسم الطالب], Master.StudentID AS [رقم الجلوس], Master.SSID AS [الرقم السري]
                buffer = ms.GetDataByCourseCode_Decoded(CourseCode);
                foreach (MasterRow r in buffer)
                {

                    DataRow v = res.NewRow();
                    v["رقم الجلوس"] = r["رقم الجلوس"];
                    v["الرقم السري"] = r["الرقم السري"];
                    v["اسم الطالب"] = r["اسم الطالب"];
                    v["الحالة"] = r["Status"];
                    res.Rows.Add(v);

                }

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }

            return res;

        }
        public static MasterTable GetMAsterTableByCourseCode(string CourseCode)
        {
            MasterTable ma = new MasterTable();
            try
            {
                MasterTable_Adapter msa = new MasterTable_Adapter();
                msa.FillByCourseCode_All(ma, CourseCode, "ح");
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return ma;

        }
        /// <summary>
        /// Retrieve the record from the mastre_Table for which SSID = SSID
        /// </summary>
        /// <param name="master_Table"></param>
        /// <param name="SSID"></param>
        /// <returns></returns>
        public static MasterRow GetMasterRowBySSID(MasterTable master_Table, string SSID)
        {
            MasterRow r = master_Table.NewMasterRow();
            try
            {
                MasterRow[] buffer = (MasterRow[])master_Table.Select("SSID = '" + SSID + "'");
                switch (buffer.Length)
                {
                    case 0:
                        throw new Exception("No match found for secrete number " + SSID);
                        break;
                    case 1:
                        r = buffer[0];
                        break;
                    default:
                        throw new Exception("Fatal error: " + SSID + " exists " + buffer.Length.ToString() + " times into the database.");

                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return r;
        }
        /// <summary>
        /// Validate schema for the marked files before adding the decoded information
        /// </summary>
        /// <param name="marked"></param>
        /// <returns></returns>
        public static bool ValidateExamMarkedSchema(DataTable marked)
        {
            bool res = false;
            if (marked.Columns.Count == 2)
            {
                if (marked.Columns.Contains("الرقم السري") && marked.Columns.Contains("درجة التحريري"))
                {
                    res = true;
                }
            }




            return res;
        }
        /// <summary>
        /// Get a ready to store master table with full of information added and all codes are decoded.
        /// </summary>
        /// <param name="CourseCode"></param>
        /// <returns></returns>
        public static DataTable GetDecodedMasterCourse(string CourseCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("رقم الجلوس");
                dt.Columns.Add("الرقم السري");
                dt.Columns.Add("إسم الطالب");
                dt.Columns.Add("الدرجة");
                dt.Columns.Add("الحالة");
                MasterTable_Adapter mstra = new MasterTable_Adapter();
                MasterTable mstr = new MasterTable();
                mstra.FillByCourseCode_Decoded_Final(mstr, CourseCode);
                foreach (MasterRow r in mstr.Rows)
                {
                    DataRow fr = dt.NewRow();
                    fr["رقم الجلوس"] = r.StudentID;
                    fr["الرقم السري"] = r.SSID;
                    fr["إسم الطالب"] = r["Name"].ToString();
                    try
                    {
                        fr["الدرجة"] = r.ExamMark.ToString();
                    }
                    catch (StrongTypingException ex)
                    {
                        int zero = 0;

                        fr["الدرجة"] = zero.ToString();
                    }
                    //Task: Consider to read Status from the File not from the master table according to the new policy.
                    fr["الحالة"] = r.Status;
                    dt.Rows.Add(fr);
                }

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return dt;
        }
        public static void ImportFinalMarks(string CourseCode, DataTable Data)
        {

            try
            {
                MasterTable mstr = GetMAsterTableByCourseCode(CourseCode);
                //1- Get master table for the course
                //2- Iterate the table data for each SSID 
                //3- Get the Exam mark and fill in the master table

                foreach (DataRow r in Data.Rows)
                {
                    string SID = string.Empty;
                    string SSID = r["الرقم السري"].ToString();
                    int ExamMark = 0;
                    try
                    {
                        ExamMark = Convert.ToInt32(r["درجة التحريري"].ToString());
                    }
                    catch (Exception exx)
                    {

                        int xx = 5;
                    }
                    MasterRow mr = GetMasterRowBySSID(mstr, SSID);
                    mr.ExamMark = ExamMark;



                }

                UpdateMasterTable(mstr);
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }

        }

        public static void ImportDB()
        {
            //Task: Modify import Database file in order that to make use of DBMigrate
            //if (!ValidatePassKey())
            //{
            //    MessageBox.Show("لابد من عمل مفتاح فبل تحميل قاعدة البيانات.");
            //    return;
            //}
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CTK file (*.ctk)|*.ctk";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string datapath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\CTKDB.sdf";

                // System.IO.File.Copy(ofd.FileName, datapath, true);
                if (BL.DBMigrate(ofd.FileName, datapath))
                {
                    MessageBox.Show("تم التحميل بنجاح", "CDTK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("لم يتم التحميل بنجاح", "CDTK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ExporttDB()
        {

            //if (!ValidatePassKey())
            //{
            //    MessageBox.Show("لابد من عمل مفتاح فبل حفظ قاعدة البيانات.");
            //    return;
            //}
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CTK file (*.ctk)|*.ctk";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string datapath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\CTKDB.sdf";

                System.IO.File.Copy(datapath, sfd.FileName, true);
                MessageBox.Show("Database is saved successfuly");
            }
        }
        public static bool ValidatePassKey()
        {
            bool res = false;
            try
            {
                string PassKey = Properties.Settings.Default.PassKey;
                string pattern = @"\d{8}";
                if (System.Text.RegularExpressions.Regex.IsMatch(PassKey, pattern))
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Map the required columns from the Master datatable to the standard datatable
        /// </summary>
        /// <param name="Master"></param>
        /// <returns></returns>
        public static DataTable MapMasterToBasicSecreteNumberTable(DataTable Master)
        {
            DataTable dt = new DataTable("Sheet1");
            try
            {
                dt.Columns.Add("أسم الطالب");
                dt.Columns.Add("الرقم السري");
                dt.Columns.Add("رقم الجلوس");
                foreach (DataRow r in Master.Rows)
                {
                    DataRow tr = dt.NewRow();
                    tr["أسم الطالب"] = r["Name"];//
                    tr["الرقم السري"] = r["SSID"];
                    tr["رقم الجلوس"] = r["StudentID"];
                    dt.Rows.Add(tr);
                }

            }

            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return dt;
        }
        public static string GetCourseCode(string coursename, Data.CTKDBDataSet.CoursesDataTable dt)
        {
            string res = string.Empty;
            Data.CTKDBDataSet.CoursesDataTable rt = (Data.CTKDBDataSet.CoursesDataTable)EOB.Database.Processing.FilteredTable(dt, "Code = '" + coursename + "'");
            //  Data.CTKDBDataSetTableAdapters.QueriesTableAdapter qta = new Data.CTKDBDataSetTableAdapters.QueriesTableAdapter();
            //  long cid = Convert.ToInt64( qta.GetCourseID(coursename));
            switch (rt.Rows.Count)
            {
                case 0:

                    break;
                case 1:
                    res = rt[0].Code;
                    break;
                default:
                    break;
            }
            GC.Collect();
            return res;
        }

        //public static long GetCourseID(string coursename, Data.CTKDBDataSet.CoursesDataTable dt)
        //{
        //    long res = long.MinValue;
        //  Data.CTKDBDataSet.CoursesDataTable rt = (Data.CTKDBDataSet.CoursesDataTable )   EOB.Database.Processing.FilteredTable(dt, "Code = '" + coursename + "'");
        ////  Data.CTKDBDataSetTableAdapters.QueriesTableAdapter qta = new Data.CTKDBDataSetTableAdapters.QueriesTableAdapter();
        ////  long cid = Convert.ToInt64( qta.GetCourseID(coursename));
        //    switch(rt.Rows.Count)
        //   {
        //       case 0:

        //           break;
        //       case 1:
        //           res = (rt[0].IDD<0? rt[0].IDD * -1: rt[0].IDD);
        //           break;
        //       default:
        //           break;
        //   }
        //    GC.Collect();
        //   return res;
        //}

        public static Data.CTKDBDataSet.StudentsDataTable GetStudentsByCourseCode(string CourseCode)
        {
            Data.CTKDBDataSet.StudentsDataTable dt = new Data.CTKDBDataSet.StudentsDataTable();

            try
            {
                Data.CTKDBDataSetTableAdapters.StudentsTableAdapter st = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
                //return  st.GetstudentsByCourseID(CourseID);
                dt = st.GetDataByCourseCode(CourseCode);
            }
            catch (Exception ex)
            {
                GC.Collect();
                EOB.EOBLog.ReportError(null, ex.Message);
            }

            return dt;
        }
        public static long GetStudentID(string StudentSeatNumber, Data.CTKDBDataSet.StudentsDataTable dt)
        {
            long res = long.MinValue;
            Data.CTKDBDataSet.StudentsDataTable rt = (Data.CTKDBDataSet.StudentsDataTable)EOB.Database.Processing.FilteredTable(dt, "StudentID = '" + StudentSeatNumber + "'");
            switch (rt.Rows.Count)
            {
                case 0:

                    break;
                case 1:
                    res = (rt[0].ID < 0 ? rt[0].ID * -1 : rt[0].ID);
                    break;
                default:
                    break;
            }
            return res;
        }
        private static bool ValidateMasterEntry(Data.CTKDBDataSet.MasterDataTable src, string studentseatID, string courseCode)
        {
            bool res = false;

            DataTable dt = EOB.Database.Processing.FilteredTable(src, "CourseID = '" + courseCode + "' and StudentID = '" + studentseatID + "'");
            if (dt.Rows.Count == 1)
            {
                res = true;
            }
            return res;
        }

        public static bool CourseExist(Data.CTKDBDataSet ds, string courseCode)
        {
            bool res = false;

            DataTable dt = EOB.Database.Processing.FilteredTable(ds.Courses, "Code = '" + courseCode + "'");
            try
            {
                switch (dt.Rows.Count)
                {
                    case 0:
                        break;
                    case 1:
                        res = true;
                        break;
                    default:
                        throw new Exception(dt.Rows.Count.ToString() + " repeating records for that course. Check the integrity of the database.");
                        break;
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        public static bool StudentExist(Data.CTKDBDataSet ds, string SeatID)
        {
            bool res = false;

            DataTable dt = EOB.Database.Processing.FilteredTable(ds.Students, "StudentID = '" + SeatID + "'");
            try
            {
                switch (dt.Rows.Count)
                {
                    case 0:
                        break;
                    case 1:
                        res = true;
                        break;
                    default:
                        throw new Exception(dt.Rows.Count.ToString() + " repeating records for that student. Check the integrity of the database.");
                        break;
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }
        public static void InsertMasterRecord(string[] record, ref Data.CTKDBDataSet ds)
        {
            //record.Add(CourseCode);
            //record.Add(Coursename);
            //record.Add(Semester);
            //record.Add(Year);
            //record.Add(r["0"].ToString()); // رقم الجلوس
            //record.Add(r["2"].ToString()); // إسم الطالب
            Data.CTKDBDataSet.MasterRow masterR = ds.Master.NewMasterRow();
            Data.CTKDBDataSet.StudentsRow StudentR = ds.Students.NewStudentsRow();
            Data.CTKDBDataSet.CoursesRow cr = ds.Courses.NewCoursesRow();

            // Search Courses table for existing entry
            // long CourseID = GetCourseID(record[0], ds.Courses);
            try
            {
                if (!IsNumeric(record[4]))
                {
                    throw new Exception("Student Id = " + record[4] + " is excluded.");


                }

                string CourseCode = record[0];
                string MISID =record.Length ==7? record[6]:"0";
                if (!CourseExist(ds, CourseCode))

                //if (CourseID == long.MinValue)
                {

                    cr.Name = record[1];
                    cr.Code = record[0];
                    ds.Courses.AddCoursesRow(cr);
                    //CourseID = GetCourseID(record[0], ds.Courses);
                }

                //long StudentID = GetStudentID(record[4], ds.Students);
                string StudentSeatID = record[4];
                if (!StudentExist(ds, StudentSeatID))
                // if (StudentID == long.MinValue)
                {

                    try
                    {
                        StudentR.Name = record[5];
                        StudentR.StudentID = record[4];
                        StudentR.AcademicYear = record[3];

                        ds.Students.AddStudentsRow(StudentR);
                    }
                    catch (Exception ex)
                    {

                        EOB.EOBLog.ReportError(null, ex.Message);
                    }
                    // StudentID = GetStudentID(record[4], ds.Students);
                }
                if (!ValidateMasterEntry(ds.Master, StudentSeatID, CourseCode))
                {
                    masterR.StudentID = StudentSeatID;
                    masterR.CourseID = CourseCode;
                    //masterR["MISID"] = MISID;
                    ds.Master.AddMasterRow(masterR);
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }



        }

        public static CourseStatus GetCourseStatus(string CourseCode)
        {
            CourseStatus res = new CourseStatus();
            DBQueries dbq = new DBQueries();
            res = CourseStatus.NotExist;
            try
            {
                int c = Convert.ToInt32(dbq.CheckCourse(CourseCode));
                if (c == 0)
                {
                    throw new Exception(CourseCode + " is not exist");
                }
                res = CourseStatus.State1;
                c = Convert.ToInt32(dbq.CountOfSSIDByCourseCode(CourseCode));
                if (c == 0)
                {

                    throw new Exception(CourseCode + " has no secrete numbers");
                }
                res = CourseStatus.State2;

                c = Convert.ToInt32(dbq.CountOfMarkedRecords(CourseCode));
                if (c == 0)
                {

                    throw new Exception(CourseCode + " has no marked records");
                }
                res = CourseStatus.State3;

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }
        public struct StudentCard
        {
            public string Name;
            public string Class;
            public string StudentID;
            public string academicYear;
        }
        public static StudentCard GetStudentCard(string studentID)
        {
            StudentCard res = new StudentCard();
            try
            {
                TA_Students ta = new TA_Students();

                 DT_Studnets dt =  ta.GetDataByStudentID(studentID);

                switch(dt.Rows.Count)
                {
                    case 0:
                        throw new Exception(" Student with studentID = " + studentID + " doesn't exist");
                        break;
                    case 1:
                        res.Name = dt[0].Name;
                        res.StudentID = dt[0].StudentID;
                        res.academicYear = dt[0].AcademicYear;
                        res.Class = dt[0].Class;
                        break;
                    default:
                        throw new Exception(" Student with studentID = " + studentID + " has more than one record into Student database table. this is a sign for problem in database integrity");
                        break;

                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public struct CourseCard
        {
            public string Name;
            public string Code;
            public int LimitExam;
            public int LimitActivities;
        }
        public static CourseCard GetCourseCard(string CourseCode)
        {
            CourseCard res = new CourseCard();
            try
            {
                TA_CourseTable ta = new TA_CourseTable();

                DT_CourseTable dt = ta.GetDataByCourseCode(CourseCode);

                switch (dt.Rows.Count)
                {
                    case 0:
                        throw new Exception(" Course with Course code = " + CourseCode + " doesn't exist");
                        break;
                    case 1:
                        res.Name = dt[0].Name;
                        res.Code = dt[0].Code;
                        res.LimitActivities = dt[0].MaximumClass;
                        res.LimitExam = dt[0].MaximumExam;
                        break;
                    default:
                        throw new Exception(" Course with code = " + CourseCode + " has more than one record into courses database table. this is a sign for problem in database integrity");
                        break;

                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }


        #endregion
        
        #region BarCode
        private static Data.CTKDBDataSet.BARCODEDataTable       m_objBARCODETable = null;
        private static Random m_objRandomNumberGenerator = new Random( DateTime.Now.Second + DateTime.Now.Minute+DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour);
        private static long m_nNextBarID = 0;
        
        public static long GetNextBarcodeID()
        {
            long res = -1;
            try
            {
                Data.CTKDBDataSetTableAdapters.QueriesTableAdapter ta = new DBQueries();
                long? temp = ta.GetMaxBarCodeID();
                if (temp == null)
                {
                    res = 1;
                }
                else
                {
                    res = Convert.ToInt64(temp) + 1;
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public static int InitializeBarCodeTable()
        {
            int res = -1;
            try
            {
                if (m_objBARCODETable == null)
                {
                    m_objBARCODETable = new DS_CTK.BARCODEDataTable();
                    Data.CTKDBDataSetTableAdapters.BARCODETableAdapter bta = new Data.CTKDBDataSetTableAdapters.BARCODETableAdapter();
                    m_nNextBarID = GetNextBarcodeID();
                    res = bta.Fill(m_objBARCODETable);
                }
            }
            catch (Exception ex)
            {
                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public static string GetNextBarCode(string CourseCode, string StID)
        {
            string res = "00000000000";
            try
            {

                if (m_objBARCODETable == null)
                {
                    int n = InitializeBarCodeTable();
                    LOG.ReportInfo(null, n + " Barcodes are imported from database");
                }
                //1- Check BARCODE Table for CourseCode and STID
                string SI = StID.Trim().ToUpper();
                string CID = CourseCode.Trim().ToUpper();
                Data.CTKDBDataSet.BARCODERow[] buf = (Data.CTKDBDataSet.BARCODERow[])m_objBARCODETable.Select("SID ='"+SI+"' and CID = '"+CID+"' ");
                switch( buf.Length)
                {
                    case 0:// New Barcode to be issued
                        string HSID = GetHSID(SI);
                        string HCID = GetHCID(CID);
                        string BC = HCID+HSID;
                        Data.CTKDBDataSet.BARCODERow r = m_objBARCODETable.NewBARCODERow();
                        r.ID = m_nNextBarID++;
                        r.HSID = HSID;
                        r.HCID = HCID;
                        r.BC = BC;
                        r.SID = SI;
                        r.CID = CID;
                        m_objBARCODETable.Rows.Add(r);
                        res =  BC ;
                        break;
                    case 1:// Existing Barcode to be recalled
                        res = buf[0].BC;
                        break;
                    default:// Mismatch situation , more than one occurrence of the barcode into the database.
                        throw new Exception("More than one occurrence for the barcode into database for student "+SI +" into course "+ CID);
                        break;
                }
                //if (buf.Length == 1)
                //{
                //    //2- If Exist
                //    //      res = Get BarCode from the record of STID & CourseCode
                   
                //}
                //else
                //{
                //    //3- Else
                //    //      BC = GetHID + GetHSID
                //    //      Save BC into BARCODE Table
                //    //      res = BC
                //}
                
                
                //Random a = new Random(DateTime.Now.Second);
                //string bar = string.Empty;
                //do
                //{
                //    bar = string.Empty;
                //    for (int i = 0; i < 4; i++)
                //    {
                //        int sub = a.Next(999);
                //        string buf = sub.ToString().PadRight(3, '0');
                //        bar += buf;
                //    }
                //}
                //while (!ValidateBarCode(bar.Substring(0, 11)));

                //res = bar.Substring(0, 11);

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }

            return res;
        }
        public static int UpdateBarCodeHasheTable()
        {
            int res = -1;
            try
            {
                Data.CTKDBDataSetTableAdapters.BARCODETableAdapter ta = new Data.CTKDBDataSetTableAdapters.BARCODETableAdapter();
                res = ta.Update(m_objBARCODETable);
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }
        public static string GetHCID(string CID)
        {
            string res = string.Empty;
            try
            {
                Data.CTKDBDataSet.BARCODERow[] buf = (Data.CTKDBDataSet.BARCODERow[])m_objBARCODETable.Select("CID = '" + CID + "'");
                if (buf.Length > 0)
                {
                    res = buf[0].HCID;
                }
                else
                {
                    //Random a = new Random(DateTime.Now.Second);
                    bool valid = false;
                    while (!valid)
                    {
                        string bar = string.Empty;
                        int sub = m_objRandomNumberGenerator.Next(99999);
                        bar = sub.ToString().PadRight(5, '0');
                        buf = (Data.CTKDBDataSet.BARCODERow[])m_objBARCODETable.Select("HCID = '" + bar + "'");
                        if (buf.Length == 0)
                        {
                            valid = true;
                            res = bar;
                        }
                    }



                }

            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }


       public static string GetHSID(string SID)
        {
            string res = string.Empty;
            try
            {
                Data.CTKDBDataSet.BARCODERow[] buf = (Data.CTKDBDataSet.BARCODERow[])m_objBARCODETable.Select("SID = '" + SID + "'");
                if (buf.Length > 0)
                {
                    res = buf[0].HSID;
                }
                else
                {
                    //Random a = new Random(DateTime.Now.Second);
                    bool valid = false;
                    while (!valid)
                    {
                        string bar = string.Empty;
                        int sub = m_objRandomNumberGenerator.Next(999999);
                        bar = sub.ToString().PadRight(6, '0');
                        buf = (Data.CTKDBDataSet.BARCODERow[])m_objBARCODETable.Select("HSID = '" + bar + "'");
                        if (buf.Length == 0)
                        {
                            valid = true;
                            res = bar;
                        }
                    }
                    

                    
                }
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Constructs a unique barcode for student in certain course
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public static string GetNextBarCode()
        {
            string res = "00000000000";
            try
            {
                Random a = new Random(DateTime.Now.Second);
                string bar = string.Empty;
                do
                {
                    bar = string.Empty;
                    for (int i = 0; i < 4; i++)
                    {
                        int sub = a.Next(999);
                        string buf = sub.ToString().PadRight(3, '0');
                        bar += buf;
                    }
                }
                while (!ValidateBarCode(bar.Substring(0,11)));
                
                res = bar.Substring(0,11);

            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }

            return res;
        }
        /// <summary>
        /// Valid barcode is not being used in database
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public static bool ValidateBarCode(string barCode)
        {
            bool res = false;
            try
            {
                Data.CTKDBDataSetTableAdapters.QueriesTableAdapter qta = new DBQueries();
                int? count = qta.ValidateBarCode(barCode);
                if (count == null | count == 0)
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        public static MasterRow GetMasterRecord(string coursecode,string StudentID)
        {
            MasterRow res = null;
            try
            {
                MasterTable_Adapter ma = new MasterTable_Adapter();
                MasterTable dt = ma.GetDataByCourseCodeandStudentID(coursecode, StudentID);
                if (dt.Rows.Count == 1)
                {
                    res =(MasterRow) dt.Rows[0];
                }
                else
                {
                    throw new Exception("Mismatch . Number of records for student =" + StudentID + " and course = " + coursecode + " is " + dt.Rows.Count.ToString());
                }
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportInfo(null, ex.Message);
            }
            return res;
        }
        public static int UpdateMasterTable(MasterRow r)
        {
            int res = 0;
            try
            {
                MasterTable_Adapter ma = new MasterTable_Adapter();
                res  = ma.Update(r);
            }
            catch (Exception ex)
            {

                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        private static string m_strCourseCodeToPrint;

        public static void ExportBarCodeSheet(string CourseCode, string ExamDate)
        {
            try
            {
                
                m_strCourseCodeToPrint = CourseCode;
                //ToDo: Select pages to print is required to be added 
                System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
                // doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
                int start = 0;
                MasterTable dt = GetMAsterTableByCourseCode(m_strCourseCodeToPrint);
                DataTable dtt = new DataTable();

                long template = 0;


                dtt = dt.Copy();
                dtt.Columns.Add("Temp", template.GetType(), "StudentID");

                DataView dv = dtt.DefaultView;

                dv.Sort = "Temp";
                DataTable dttt = dv.ToTable(true);

                doc.PrintPage += (sender, args) => PrinterHandler(dttt, ref start,ExamDate, args);
                
                PrintDialog pd = new PrintDialog();

                pd.Document = doc;
                pd.AllowSomePages = true;
                pd.AllowSelection = true;
                //pd.PrinterSettings.MinimumPage = 1;
                
                doc.DocumentName = "BarCode Export for " + m_strCourseCodeToPrint;
                
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    //doc.PrinterSettings = pd.PrinterSettings;
                    doc.PrinterSettings.PrintRange = pd.PrinterSettings.PrintRange;
                    doc.PrinterSettings.MinimumPage = doc.PrinterSettings.FromPage = pd.PrinterSettings.FromPage;
                    doc.PrinterSettings.MaximumPage =doc.PrinterSettings.ToPage = pd.PrinterSettings.ToPage;

                    doc.Print();
                }

            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
        }


        public static void PreviewExportBarCodeSheet(string CourseCode, string ExamDate)
        {
            try
            {

                m_strCourseCodeToPrint = CourseCode;
                //ToDo: Select pages to print is required to be added 
                System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
                // doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
                int start = 0;
                MasterTable dt = GetMAsterTableByCourseCode(m_strCourseCodeToPrint);
                DataTable dtt = new DataTable();

                long template = 0;


                dtt = dt.Copy();
                dtt.Columns.Add("Temp", template.GetType(), "StudentID");

                DataView dv = dtt.DefaultView;

                dv.Sort = "Temp";
                DataTable dttt = dv.ToTable(true);

                doc.PrintPage += (sender, args) => PrinterHandler(dttt, ref start, ExamDate, args);

                PrintDialog pd = new PrintDialog();

                pd.Document = doc;
                pd.AllowSomePages = true;
                pd.AllowSelection = true;
                doc.DocumentName = "BarCode Export for " + m_strCourseCodeToPrint;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.PrinterSettings = pd.PrinterSettings;
                    PrintPreviewDialog pv = new PrintPreviewDialog();
                    pv.Document = doc;

                    pv.ShowDialog();
                }

                
                
                //if (pd.ShowDialog() == DialogResult.OK)
                //{
                //    doc.PrinterSettings = pd.PrinterSettings;

                //    doc.Print();
                //}

            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
        }
 
        public static void ExportBarCodeSheet(string CourseCode)
        {
            try
            {
                m_strCourseCodeToPrint = CourseCode;
               //ToDo: Select pages to print is required to be added 
                System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
               // doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
                int start = 0;
                MasterTable dt = GetMAsterTableByCourseCode(m_strCourseCodeToPrint);
                DataTable dtt = new DataTable();
                
                long template = 0;
                
                
                dtt = dt.Copy();
                dtt.Columns.Add("Temp", template.GetType(), "StudentID");
                
                DataView dv = dtt.DefaultView;
                
                dv.Sort = "Temp";
                DataTable dttt =  dv.ToTable(true);

                doc.PrintPage += (sender, args) => PrinterHandler(dttt,ref start,DateTime.Today.ToString() ,args );
                
                PrintDialog pd = new PrintDialog();
               
                pd.Document = doc;
                
                doc.DocumentName = "BarCode Export for "+m_strCourseCodeToPrint;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.PrinterSettings = pd.PrinterSettings;
                    
                    doc.Print();
                    
                    
                }

            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
        }
        public static DDCL.BarCodeDevice.BarCodePrinter ptr = new DDCL.BarCodeDevice.BarCodePrinter();

        public static void PrinterHandler( DataTable data, ref int start, string ExamDate, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                
                string pageNmuber = Convert.ToString(start / 8 + 1);
                int pn = start / 8 + 1;
                bool IsPrint = false;
               


                
                    e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                    CourseCard cc = GetCourseCard(m_strCourseCodeToPrint);
                    Pen p = new Pen(Brushes.Black);
                    System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11.0F, FontStyle.Bold);
                    System.Drawing.StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    //int CellHeight =e.MarginBounds.Height/ 8;//font.Height * 3
                    int CellHeight = 36;
                    //Rectangle A = new Rectangle(new Point(e.MarginBounds.Width*70/100, e.MarginBounds.Top), new Size(e.PageBounds.Width / 3, CellHeight));
                    Rectangle A = new Rectangle(new Point(105, 0), new Size(105, 36));
                    //Point B = new Point(e.MarginBounds.Left, e.MarginBounds.Top-20);
                    Point B = new Point(0, 0);
                    int DY = CellHeight;
                    int Yindex = 0;
                    PictureBox pb = new PictureBox();
                    //e.Graphics.DrawRectangle(p, e.MarginBounds);
                    // foreach (MasterRow r in data.Rows)
                    int LinesPrePage = 8;// e.MarginBounds.Height / (font.Height * 3);

                    // e.Graphics.DrawString(cc.Name + " " + cc.Code, font, Brushes.Black, e.MarginBounds.Width , e.PageBounds.Top + 5, sf);
                    for (int i = start; i < data.Rows.Count; i++)
                    {
                        DataRow r = data.Rows[i];
                        StudentCard Studnet = GetStudentCard(r["StudentID"].ToString());
                        pb.Image = ptr.Print(r["SSID"].ToString(), 7, 1.75);
                        // e.Graphics.DrawRectangle(p, A);
                        Rectangle S = new Rectangle(new Point(A.Left - 15, A.Top + 8), new Size(A.Width - 5, A.Height - 8));
                        e.Graphics.DrawString(Studnet.Class+"-"+ cc.Name + "\n\r" + cc.Code + "  [" + pageNmuber.PadLeft(2, '0') + "]\n\r" + ExamDate + "\n\r" + Studnet.StudentID + "-" + Studnet.Name, font, Brushes.Black, S, sf);
                        Point C = new Point(B.X + 5, B.Y + 8);
                        e.Graphics.DrawImage(pb.Image, C);
                        A.Offset(0, DY);
                        B.Offset(0, DY);
                        start++;
                        if (Yindex == LinesPrePage - 1)
                        {
                            Yindex = 0;
                            e.HasMorePages = true;
                            break;
                        }
                        else
                        {
                            Yindex++;
                            // e.HasMorePages = false;
                        }
                        e.Graphics.DrawLine(p, B.X, B.Y, e.MarginBounds.Width, B.Y);

                    }
                


                //Rectangle Ss = new Rectangle(new Point(0, 0), new Size(A.Width - 5, A.Height - 8));
                //e.Graphics.DrawString(pageNmuber, font, Brushes.Black,Ss, sf);
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
                e.HasMorePages = false;
            }


            //int xx = 5;
            //start++;
            //e.HasMorePages = true;

        }

        public static void PrinterHandler(object sender, DataTable data,ref int start,string ExamDate ,System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Printing.PrintDocument doc = (System.Drawing.Printing.PrintDocument)sender;
                
                string pageNmuber = Convert.ToString(start/8+  1);
                int pn = start / 8 + 1;
                bool IsPrint = false;
                if (doc.PrinterSettings.FromPage == 0 && doc.PrinterSettings.ToPage == 0)
                {
                    //Print All Pages
                    IsPrint = true;
                }
                else 
                {
                    if (pn >= doc.PrinterSettings.FromPage && pn <= doc.PrinterSettings.ToPage)
                    {
                        IsPrint = true;
                    }
                    else
                    {
                        IsPrint = false;
                    }
                }


                if (IsPrint)
                {
                    e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                    CourseCard cc = GetCourseCard(m_strCourseCodeToPrint);
                    Pen p = new Pen(Brushes.Black);
                    System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 11.0F, FontStyle.Bold);
                    System.Drawing.StringFormat sf = new StringFormat();
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    //int CellHeight =e.MarginBounds.Height/ 8;//font.Height * 3
                    int CellHeight = 36;
                    //Rectangle A = new Rectangle(new Point(e.MarginBounds.Width*70/100, e.MarginBounds.Top), new Size(e.PageBounds.Width / 3, CellHeight));
                    Rectangle A = new Rectangle(new Point(105, 0), new Size(105, 36));
                    //Point B = new Point(e.MarginBounds.Left, e.MarginBounds.Top-20);
                    Point B = new Point(0, 0);
                    int DY = CellHeight;
                    int Yindex = 0;
                    PictureBox pb = new PictureBox();
                    //e.Graphics.DrawRectangle(p, e.MarginBounds);
                    // foreach (MasterRow r in data.Rows)
                    int LinesPrePage = 8;// e.MarginBounds.Height / (font.Height * 3);

                    // e.Graphics.DrawString(cc.Name + " " + cc.Code, font, Brushes.Black, e.MarginBounds.Width , e.PageBounds.Top + 5, sf);
                    for (int i = start; i < data.Rows.Count; i++)
                    {
                        DataRow r = data.Rows[i];
                        StudentCard Studnet = GetStudentCard(r["StudentID"].ToString());
                        pb.Image = ptr.Print(r["SSID"].ToString(), 7, 1.75);
                        // e.Graphics.DrawRectangle(p, A);
                        Rectangle S = new Rectangle(new Point(A.Left - 15, A.Top + 8), new Size(A.Width - 5, A.Height - 8));
                        e.Graphics.DrawString(cc.Name + "\n\r" + cc.Code + "  [" + pageNmuber.PadLeft(2, '0') + "]\n\r" + ExamDate + "\n\r" + Studnet.StudentID + "-" + Studnet.Name, font, Brushes.Black, S, sf);
                        Point C = new Point(B.X + 5, B.Y + 8);
                        e.Graphics.DrawImage(pb.Image, C);
                        A.Offset(0, DY);
                        B.Offset(0, DY);
                        start++;
                        if (Yindex == LinesPrePage - 1)
                        {
                            Yindex = 0;
                            e.HasMorePages = true;
                            break;
                        }
                        else
                        {
                            Yindex++;
                            // e.HasMorePages = false;
                        }
                        e.Graphics.DrawLine(p, B.X, B.Y, e.MarginBounds.Width, B.Y);

                    }
                }
                else
                {
                    start += 8;
                    if (data.Rows.Count >start)
                    {
                        e.HasMorePages = true;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                    
                }

                
                //Rectangle Ss = new Rectangle(new Point(0, 0), new Size(A.Width - 5, A.Height - 8));
                //e.Graphics.DrawString(pageNmuber, font, Brushes.Black,Ss, sf);
               
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
                e.HasMorePages = false;
            }


            //int xx = 5;
            //start++;
            //e.HasMorePages = true;

        }
        static void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //List<string> familes = new List<string>();
                //foreach ( FontFamily oneFontFamily in FontFamily.Families )
                //  {
                //      familes.Add(oneFontFamily.Name);
                //  }
                //System.IO.File.WriteAllLines(@"D:\fonts.txt",familes.ToArray());
               
                MasterTable dt = GetMAsterTableByCourseCode(m_strCourseCodeToPrint);
                System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12.0F);
                Pen p = new Pen( Brushes.Black );
                //e.Graphics.DrawString(m_strCourseCodeToPrint,font, Brushes.Black, new RectangleF(5,5,35,15)  );
                e.Graphics.DrawRectangle(p, e.PageSettings.Bounds);
                int DY = e.PageBounds.Height / 10;
                Rectangle A = new Rectangle(new Point(e.PageBounds.Width * 75 /100 , e.MarginBounds.Top), new Size(e.PageBounds.Width / 3, e.PageBounds.Height / 10));
                int Yindex = 0;
                e.Graphics.DrawRectangle(p, e.MarginBounds);
                foreach (MasterRow r in dt.Rows)
                {
                    StudentCard Studnet = GetStudentCard(r.StudentID);
                   
                    e.Graphics.DrawRectangle(p, A);
                
                    A.Offset(0, DY);
                    if (Yindex == 10)
                    {
                        Yindex = 0;
                        e.HasMorePages = true;
                       
                    }
                    else
                    {
                        Yindex++;
                       // e.HasMorePages = false;
                    }
                }

            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }

        }

        public static string[] GetCoursesList()
        {
            List<string> res = new List<string>();
            try
            {
                TA_CourseTable ta = new TA_CourseTable();

                DT_CourseTable dt = ta.GetData();
                DataTable dv = dt.DefaultView.ToTable(true, "Code","Name");
                foreach (DataRow r in dv.Rows)
                {
                    res.Add(r["code"].ToString()+":"+r["Name"].ToString());
                }
            }
            catch (Exception ex)
            {

                LOG.ReportError(null, ex.Message);
            }
            return res.ToArray();
        }

        #endregion



    }
}
