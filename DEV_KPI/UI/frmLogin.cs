using Core.BL;
using Core.Helper;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmLogin : frmBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> lstLocalData = null;
                if (LocalData.ReadLocalData(out lstLocalData))
                {
                    txtMaNhanVien.Text = lstLocalData[0];
                    txtMaNhanVien_Validated(null, null);
                    btnLogin.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtMaNhanVien_Validated(object sender, EventArgs e)
        {
            try
            {
                txtTenNhanVien.Text = "";
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    return;
                }
                var lstNhanVien = KPI_USERBL.Search(new KPI_USERModel() { EMPLOYER_CODE = txtMaNhanVien.Text.Trim() });
                if (lstNhanVien != null && lstNhanVien.Count > 0)
                {
                    txtTenNhanVien.Text = lstNhanVien[0].EMPLOYER_NAME;
                    LocalData.SetLocalDataEmployer(lstNhanVien[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên.");
                    txtMaNhanVien.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
                {
                    MessageBox.Show("Mã Nhân viên không tồn tại.");
                    txtMaNhanVien.Focus();
                    return;
                }

                LocalData.SaveLocalUser(txtMaNhanVien.Text.Trim());
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
