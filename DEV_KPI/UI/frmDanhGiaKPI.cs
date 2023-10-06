using Core.Helper;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmDanhGiaKPI : frmBase
    {
        public List<KPI_TEAM_DETAILModel> LstUpdate { get; set; }

        public frmDanhGiaKPI()
        {
            InitializeComponent();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDanhGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đánh giá.");
                    return;
                }
                if (LstUpdate.Count > 0)
                {
                    foreach (var item in LstUpdate)
                    {
                        var objUpDate = new KPI_TEAM_DETAILModel();
                        DevHelper.Inject(item, objUpDate);
                        objUpDate.LY_DO = txtLyDo.Text;
                        objUpDate.DANH_GIA = txtDanhGia.Text;
                        objUpDate.UPDATE_USER = LocalData.ObjUserLogIn.EMPLOYER_CODE;
                        objUpDate.UPDATE_DATE = DateTime.Now;
                        objUpDate.UPDATE_TIME = DateTime.Now;

                        DLHelper.Update(objUpDate);
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void frmDanhGiaKPI_Load(object sender, EventArgs e)
        {

        }
    }
}
