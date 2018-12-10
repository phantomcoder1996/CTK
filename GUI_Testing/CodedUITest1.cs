using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace GUI_Testing
{

    public class AppMainWindow
    {
        private ApplicationUnderTest aut;
        private WinWindow mainWindow;
        public AppMainWindow(ApplicationUnderTest app)
        {
            aut = app;
            mainWindow = new WinWindow(aut);
            mainWindow.WindowTitles.Add("الشاشة الرئيسية");
        }


        private WinButton FindButton(string controlName,WinWindow testScope)
        {
            var buttonWindow = new WinWindow(testScope);
            buttonWindow.SearchProperties.Add(WinWindow.PropertyNames.Name, controlName);
            return new WinButton(buttonWindow);
        }
        public AppMainWindow selectImportMasterFormsButton()
        { 
            //Find the control that is a child of the Main Window
            var button = FindButton("BTN_Import_MasterForms",mainWindow);
           // button.SearchProperties.Add(WinButton.PropertyNames.Name, "BTN_Import_MasterForms");
            Mouse.Click(button);

            return this;
        }

    }
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {


        [TestMethod]
        public void TestMainScenario()
        {
         
            var appPath = @"C:\Users\Univ\Downloads\CTK\CDTK\bin\Debug\CTK.exe";
            var app = ApplicationUnderTest.Launch(appPath);
            AppMainWindow mainwindow = new  AppMainWindow(app);
            mainwindow.selectImportMasterFormsButton();
        }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
