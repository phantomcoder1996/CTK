using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTK.Data;

namespace CTK
{
    /// <summary>
    /// Data Access Layer
    /// </summary>
    class DAL
    {
        internal static bool Load(ref Data.CTKDBDataSet m_obj_CTKdataSet)
        {
            bool res = true;
            try
            {
                Data.CTKDBDataSetTableAdapters.CoursesTableAdapter ta = new Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
                int n = ta.Fill(m_obj_CTKdataSet.Courses);

                Data.CTKDBDataSetTableAdapters.MasterTableAdapter ma = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
                n = ma.Fill(m_obj_CTKdataSet.Master);

                Data.CTKDBDataSetTableAdapters.StudentsTableAdapter st = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
                st.Fill(m_obj_CTKdataSet.Students);

                


            }
            catch (Exception ex)
            {
                res = false;
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        internal static bool Load_NM(ref Data.CTKDBDataSet m_obj_CTKdataSet)
        {
            bool res = true;
            try
            {
                //Data.CTKDBDataSetTableAdapters.CoursesTableAdapter ta = new Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
                //int n = ta.Fill(m_obj_CTKdataSet.Courses);

                //Data.CTKDBDataSetTableAdapters.MasterTableAdapter ma = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
                //n = ma.Fill(m_obj_CTKdataSet.Master);

                //Data.CTKDBDataSetTableAdapters.StudentsTableAdapter st = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
                //st.Fill(m_obj_CTKdataSet.Students);

                using (var ds = new CTKDB_NMEntities())
                {
                    Students st = new Students();
                    st.Name = "Amr";
                    ds.Students.Add(st);
                    ds.SaveChanges();
                }

                using (var ds1 = new CTKDB_NMEntities())
                {
                    int n = ds1.Students.Count();
                }


            }
            catch (Exception ex)
            {
                res = false;
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }


        internal static bool Update(ref CTKDBDataSet m_obj_CTKdataSet)
        {
            bool res = true;
            try
            {
                Data.CTKDBDataSetTableAdapters.CoursesTableAdapter ta = new Data.CTKDBDataSetTableAdapters.CoursesTableAdapter();
                int n = ta.Update (m_obj_CTKdataSet.Courses);
                
                Data.CTKDBDataSetTableAdapters.StudentsTableAdapter st = new Data.CTKDBDataSetTableAdapters.StudentsTableAdapter();
                st.Update(m_obj_CTKdataSet.Students);

                Data.CTKDBDataSetTableAdapters.MasterTableAdapter ma = new Data.CTKDBDataSetTableAdapters.MasterTableAdapter();
                n = ma.Update(m_obj_CTKdataSet.Master);
            }
            catch (Exception ex)
            {
                res = false;
                EOB.EOBLog.ReportError(null, ex.Message);
            }
            return res;
        }

        internal static int GetMark(string mISID)
        {
            int mark = -1;
            try
            {
                CTKDB_NMEntities ds = new CTKDB_NMEntities();
                var res = from item in ds.Master
                          where string.Compare(item.MISID, mISID) == 0
                          select item;
                mark = Convert.ToInt32(res.First().ExamMark);
            }
            catch (Exception)
            {

                mark = -1;
            }
            return mark;
        }

        internal static string GetMISFile(string courseCode)
        {
            string filename = string.Empty;
            CTKDB_NMEntities ds = new CTKDB_NMEntities();
            var res = from item in ds.Courses
                      where string.Compare(item.Code, courseCode) == 0
                      select item;
            filename =string.Format("{0}\\{1}.xlsx",Context.LocalMISPath, res.First().MISFileID);
            return filename;
        }
    }
}
