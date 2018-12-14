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
    [CodedUITest]
    public class _Ad5alK4ofAdara_FormTEST
    {
        WinWindow findWindow(ApplicationUnderTest app,string windowName)
        {
            var Window = new WinWindow(app);
            Window.WindowTitles.Add(windowName);
            return Window;
        }

        private WinButton FindButton(string controlName, WinWindow testScope)
        {
            var buttonWindow = new WinWindow(testScope);
            buttonWindow.SearchProperties.Add(WinWindow.PropertyNames.Name, controlName);
            return new WinButton(buttonWindow);
        }
        WinButton findButton(WinWindow window,string buttonName)
        {
            var buttonWindow = new WinWindow(window);
            buttonWindow.SearchProperties.Add(WinButton.PropertyNames.Name,buttonName);
            var button = new WinButton(buttonWindow);
            return button;
        }
        [TestMethod]
        public void TestMethod1()
        {
            var app = ApplicationUnderTest.Launch(Globals.appPath);
            var mainWindow = findWindow(app, "الشاشة الرئيسية");
            var BTN_Import_MasterFormsButton = findButton(mainWindow, "BTN_Import_MasterForms");
            Mouse.Click(BTN_Import_MasterFormsButton);
            var DBImportMasterWindow = findWindow(app, "DBImportMasterForms");
        }
    }
}
