﻿namespace CTK.Data
{
    partial class KeyEntryDialog
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
            this.BTN_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.TB_PassKey = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(134, 93);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 0;
            this.BTN_OK.Text = "Ok";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pass Key";
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(34, 93);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.TabIndex = 3;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // TB_PassKey
            // 
            this.TB_PassKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CTK.Properties.Settings.Default, "PassKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_PassKey.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_PassKey.Location = new System.Drawing.Point(118, 39);
            this.TB_PassKey.Mask = "00000000";
            this.TB_PassKey.Name = "TB_PassKey";
            this.TB_PassKey.PasswordChar = '*';
            this.TB_PassKey.Size = new System.Drawing.Size(91, 30);
            this.TB_PassKey.TabIndex = 4;
            this.TB_PassKey.Text = global::CTK.Properties.Settings.Default.PassKey;
            // 
            // KeyEntryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CTK.Properties.Resources._12829820;
            this.ClientSize = new System.Drawing.Size(230, 149);
            this.Controls.Add(this.TB_PassKey);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyEntryDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KeyEntryDialog";
            this.Load += new System.EventHandler(this.KeyEntryDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.MaskedTextBox TB_PassKey;
    }
}