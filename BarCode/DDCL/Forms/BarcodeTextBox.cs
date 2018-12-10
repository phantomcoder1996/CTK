using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LOG = EOB.EOBLog;
namespace DDCL.Forms
{
    public partial class BarcodeTextBox : UserControl
    {
        private string m_strLastBarcode;
        public event OnNewBarCode OnNewBarcodeRecived;
    
        public BarcodeTextBox()
        {
            InitializeComponent();
            InitializeComponentEX();
        }
        void InitializeComponentEX()
        {
            m_status = true;
            
            TB_Barcode.Text = "";
            TB_Barcode.Focus();
            OnNewBarcodeRecived += new OnNewBarCode(BarcodeTextBox_OnNewBarcodeRecived);
        }

        void BarcodeTextBox_OnNewBarcodeRecived(object Sender, string BarCode)
        {
            //Do nothing
        }
        public string LastBarCode
        {
            get
            {
                return m_strLastBarcode;
            }
            set
            {
                m_strLastBarcode = value;
            }
        }

        private void TB_Barcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TB_Barcode.Text.Trim().Length > 0)
                {
                    timer1.Start();
                }
               
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
            if (TB_Barcode.Text.Trim().Length > 0)
            {
                LastBarCode = TB_Barcode.Text.Trim();
                TB_Barcode.Text = string.Empty;
                OnNewBarcodeRecived.Invoke(this, LastBarCode);
            }

            
           
        }
        bool m_status;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_status == false)
                {
                    m_status = true;
                    TB_Barcode.Enabled = true;
                    BTN_Start.Image = Properties.Resources.Go;
                    BTN_Start.Refresh();
                    TB_Barcode.Focus();
                }
                else
                {
                    m_status = false;
                    TB_Barcode.Enabled = false;
                    BTN_Start.Image = Properties.Resources.Stop;
                    BTN_Start.Refresh();
                }
                
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BTN_Start_KeyPress(object sender, KeyPressEventArgs e)
        {
           // button1_Click(sender, new EventArgs());
            //int xx = 5;
        }

        public void Focus()
        {
            try
            {
                button1_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void panel1_Leave(object sender, EventArgs e)
        {

        }

        private void TB_Barcode_Leave(object sender, EventArgs e)
        {
            try
            {
                m_status = false;
                TB_Barcode.Enabled = false;
                BTN_Start.Image = Properties.Resources.Stop;
                BTN_Start.Refresh();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void TB_Barcode_Enter(object sender, EventArgs e)
        {
            try
            {
                m_status = true;
                TB_Barcode.Enabled = true;
                BTN_Start.Image = Properties.Resources.Go;
                BTN_Start.Refresh();
                TB_Barcode.Focus();
            }
            catch (Exception ex)
            {

                LOG.ReportError(this, ex.Message);
            }
        }

        private void BarcodeTextBox_Load(object sender, EventArgs e)
        {
           // button1_Click(BTN_Start, new EventArgs());
            try
            {
                if (m_status == false)
                {
                    m_status = true;
                    TB_Barcode.Enabled = true;
                    BTN_Start.Image = Properties.Resources.Go;
                    BTN_Start.Refresh();
                    TB_Barcode.Focus();
                }
                else
                {
                    m_status = false;
                    TB_Barcode.Enabled = false;
                    BTN_Start.Image = Properties.Resources.Stop;
                    BTN_Start.Refresh();
                }

            }
            catch (Exception ex)
            {

               // LOG.ReportError(this, ex.Message);
            }
        }
    }

    public delegate void OnNewBarCode(object Sender, string BarCode);
}
