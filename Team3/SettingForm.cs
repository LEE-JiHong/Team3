using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team3
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtMachineName1.Text = ConfigurationManager.AppSettings["txtMachineName1"].ToString();
            txtMachineAddress1.Text = ConfigurationManager.AppSettings["txtMachineAddress1"].ToString();
            txtDataCollectTime.Text = ConfigurationManager.AppSettings["txtDataCollectTime"].ToString();
            txtLoadPlan.Text = ConfigurationManager.AppSettings["txtLoadPlan"].ToString();
        }

        private void btnOK(object sender, EventArgs e)
        {
            NewSetting();
        }

        private void NewSetting()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["txtMachineName1"].Value = txtDataCollectTime.Text; 
            configuration.AppSettings.Settings["txtMachineAddress1"].Value = txtMachineAddress1.Text;
            configuration.AppSettings.Settings["txtDataCollectTime"].Value = txtDataCollectTime.Text ;
            configuration.AppSettings.Settings["txtLoadPlan"].Value = txtLoadPlan.Text;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }
    }
}
