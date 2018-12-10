using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Microsoft.Win32;

namespace CTK
{
    [RunInstaller(true)]
    public partial class CTKInstaller : System.Configuration.Install.Installer
    {
        
    
        public CTKInstaller()
        {
            InitializeComponent();
        }

        /// <param name="stateSaver">An <see cref="T:System.Collections.IDictionary"/> used to save information needed to perform a commit, rollback, or uninstall operation.</param>
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            //throw new System.NotImplementedException();
            base.Install(stateSaver);
           // Context.Parameters[""];
        }

        /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the pre-installation state of the computer.</param>
        public override void Rollback(System.Collections.IDictionary savedState)
        {
            //throw new System.NotImplementedException();
            base.Rollback(savedState);
        }

        /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the state of the computer after the installation was complete.</param>
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            //throw new System.NotImplementedException();
            base.Uninstall(savedState);
        }

        /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the state of the computer after all the installers in the collection have run.</param>
        public override void Commit(System.Collections.IDictionary savedState)
        {
           // throw new System.NotImplementedException();
            base.Commit(savedState);
            
        }

        /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the state of the computer before the installers in the <see cref="P:System.Configuration.Install.Installer.Installers"/> property are installed. This <see cref="T:System.Collections.IDictionary"/> object should be empty at this point.</param>
        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);
            BL.m_strLogFileBuffer.Clear();
            List<string> m_strLogFileBuffer = BL.m_strLogFileBuffer;
           
           
            m_strLogFileBuffer.Add("Start at " + DateTime.Now.ToString());
            m_strLogFileBuffer.Add("Before Install");
            string TargetDir = System.IO.Path.GetDirectoryName(Context.Parameters["assemblypath"]);
            m_strLogFileBuffer.Add("Target Directory is " + TargetDir);
            string[] Buffer = System.IO.Directory.GetFiles( TargetDir, "*.*", System.IO.SearchOption.AllDirectories );
            m_strLogFileBuffer.Add("-----------------------------------------------------");
            m_strLogFileBuffer.Add("Files inside " + TargetDir + " before install are listed below:");
            m_strLogFileBuffer.AddRange(Buffer);
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey sk = rk.CreateSubKey(@"Software\FUSC");
            m_strLogFileBuffer.Add("-----------------------------------------------------");
            m_strLogFileBuffer.Add(@"Searching Registry Key HKEY_CURRENT_USER\Software\FUSC");
            m_strLogFileBuffer.Add("Path: " + sk.GetValue("Path"));
            sk.SetValue("Path", TargetDir, RegistryValueKind.String);
            BL.DBInstallerPre(TargetDir, ref m_strLogFileBuffer);

            //List<string> buffer = new List<string>();
            //foreach (string key in Context.Parameters.Keys)
            //{
            //    buffer.Add(key +"=" +Context.Parameters[key]);
            //}
            //System.IO.File.WriteAllLines(@"D:\keys.txt", buffer);
            //BL.DBInstallerPre();
        }

        /// <param name="savedState">An <see cref="T:System.Collections.IDictionary"/> that contains the state of the computer after all the installers contained in the <see cref="P:System.Configuration.Install.Installer.Installers"/> property have completed their installations.</param>
        protected override void OnAfterInstall(System.Collections.IDictionary savedState)
        {
           //Task: Test onafter install by put all code in commit here. 
            //Task: It seems that commit is execute before starting the physical copy of the files. Find another event that is run after install to put the code
            //Task: Find a way to check for Excel ole object 12 and install it if needed
            string outfile = string.Empty;
            try
            {
                string TargetDir = System.IO.Path.GetDirectoryName(Context.Parameters["assemblypath"]);
                BL.DBInstallerPost(TargetDir, ref BL.m_strLogFileBuffer);
                BL.m_strLogFileBuffer.Add("=========================================================");
                BL.m_strLogFileBuffer.Add("Finished at " + DateTime.Now.ToString());
               outfile = TargetDir + @"\InstallLog-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + "R" + "-0.TXT";
               
                System.Windows.Forms.MessageBox.Show("Installation log is saved into " + outfile, "CDTK", System.Windows.Forms.MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                BL.m_strLogFileBuffer.Add(ex.Message);
                
            }
            base.OnAfterInstall(savedState);
            System.IO.File.WriteAllLines(outfile, BL.m_strLogFileBuffer.ToArray());
        }
    }
}
