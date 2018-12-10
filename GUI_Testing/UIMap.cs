namespace GUI_Testing
{
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System.Collections.Specialized;
    using System.Configuration;

    public partial class UIMap{


        public void testEnterPassKey()
        {
            #region Variable Declarations
            WinEdit uITB_PassKeyEdit = this.UIKeyEntryDialogWindow.UI__Window.UITB_PassKeyEdit;
            WinButton uIOKButton = this.UIKeyEntryDialogWindow.UIOKWindow.UIOKButton;
            #endregion

            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            var key = appSettings["PassKey"];
            Console.WriteLine(key);
            // Last mouse action was not recorded.

            // Click 'TB_PassKey' text box
            Mouse.Click(uITB_PassKeyEdit, new Point(78, 12));

            // Type '__******' in 'TB_PassKey' text box
            uITB_PassKeyEdit.Text = this.TestEnterPassKeyParams.UITB_PassKeyEditText;

            // Click 'Ok' button
            Mouse.Click(uIOKButton, new Point(36, 12));


   //         NameValueCollection appSettings = ConfigurationManager.AppSettings;
     //       var key = appSettings["PassKey"];
            Console.WriteLine(key);
            Assert.AreEqual(key, uITB_PassKeyEdit.Text);
        }

    }
}
