using Core.Helper;
using System;
using System.IO;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmChangeLog : frmBase
    {
        public frmChangeLog()
        {
            InitializeComponent();
        }

        private void frmChangeLog_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = Application.StartupPath + @"\changelog.txt";
                if (File.Exists(filePath))
                {
                    txtChangeLog.Text = File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }
    }
}
