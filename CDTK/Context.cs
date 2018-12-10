using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTK
{
    public static class Context
    {
        public static string ApplicationPath
        {
            get
            {
                string res = string.Empty;
                res = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                return res;
            }
        }
        public static string LocalMISPath

        {
            get
            {
                string res = string.Empty;
                try
                {
                    res = string.Format("{0}\\MIS", ApplicationPath);
                    if (!System.IO.Directory.Exists(res))
                    {
                        System.IO.Directory.CreateDirectory(res);
                    }
                }
                catch (Exception ex)
                {

                    res = string.Empty;
                }
                return res;
            }
       }
    }
}