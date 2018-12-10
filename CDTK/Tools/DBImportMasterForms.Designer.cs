namespace CTK.Tools
{
    partial class DBImportMasterForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tool = new EOB.UserControls.ToolsTypicals.BulkFileProcessorStandardTool();
            this.SuspendLayout();
            // 
            // Tool
            // 
            this.Tool.Condition1_Checked = false;
            this.Tool.Condition1_Text = "checkBox1";
            this.Tool.Condition1_Visible = false;
            this.Tool.Condition2_Checked = false;
            this.Tool.Condition2_Text = "checkBox2";
            this.Tool.Condition2_Visible = false;
            this.Tool.Condition3_Checked = false;
            this.Tool.Condition3_Text = "checkBox3";
            this.Tool.Condition3_Visible = false;
            this.Tool.Condition4_Checked = false;
            this.Tool.Condition4_Text = "checkBox4";
            this.Tool.Condition4_Visible = false;
            this.Tool.Condition5_Checked = false;
            this.Tool.Condition5_Text = "checkBox5";
            this.Tool.Condition5_Visible = false;
            this.Tool.DataBindings.Add(new System.Windows.Forms.Binding("UC_RootFolder", global::CTK.Properties.Settings.Default, "DBFolder1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tool.Location = new System.Drawing.Point(0, 0);
            this.Tool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(1316, 604);
            this.Tool.TabIndex = 0;
            this.Tool.UC_Button1Text = "button1";
            this.Tool.UC_Button2Text = "button2";
            this.Tool.UC_Button3Text = "button3";
            this.Tool.UC_EnableBooleanIndicators = false;
            this.Tool.UC_EnableButton1 = false;
            this.Tool.UC_EnableButton2 = false;
            this.Tool.UC_EnableButton3 = false;
            this.Tool.UC_EnableSidePRogress = false;
            this.Tool.UC_Filter = "*.xlsx";
            this.Tool.UC_Indicator1 = false;
            this.Tool.UC_Indicator1_Text = null;
            this.Tool.UC_Indicator2 = false;
            this.Tool.UC_Indicator2_Text = null;
            this.Tool.UC_Indicator3 = false;
            this.Tool.UC_Indicator3_Text = null;
            this.Tool.UC_Indicator4 = false;
            this.Tool.UC_Indicator4_Text = null;
            this.Tool.UC_RootFolder = global::CTK.Properties.Settings.Default.DBFolder1;
            this.Tool.UC_FileCallbackFunction += new EOB.EnumFileEventHandler(this.Tool_UC_FileCallbackFunction);
            this.Tool.UC_Complete += new System.EventHandler(this.Tool_UC_Complete);
            this.Tool.UC_Initialize += new System.EventHandler(this.Tool_UC_Initialize);
            this.Tool.UC_SavePathClicked += new System.EventHandler(this.Tool_UC_SavePathClicked);
            // 
            // DBImportMasterForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 604);
            this.Controls.Add(this.Tool);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DBImportMasterForms";
            this.Text = "DBImportMasterForms";
            this.ResumeLayout(false);

        }

        #endregion

        private EOB.UserControls.ToolsTypicals.BulkFileProcessorStandardTool Tool;
    }
}