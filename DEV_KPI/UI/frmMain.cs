using Core.Helper;
using DEV_KPI.Common;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void CheckForUpdate()
        {
            try
            {
                CheckUpdate.InstallUpdateSyncWithInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                CheckForUpdate();
                var login = new frmLogin();
                var result = login.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                textBar.Caption = " Đăng nhập: " + LocalData.ObjUserLogIn.EMPLOYER_CODE + "- " + LocalData.ObjUserLogIn.EMPLOYER_NAME +
                                  "      " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void mnuChangeLog_Click(object sender, EventArgs e)
        {
            try
            {
                var changeLog = new frmChangeLog();
                changeLog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void mnuDoiNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LocalData.DeleteLocalData();
            Application.Restart();
        }

        private void btnQuanLyKPI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var frm = new frmQuanLy();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }
    }
}
