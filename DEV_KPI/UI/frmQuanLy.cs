using Core.BL;
using Core.DL;
using Core.Helper;
using Core.Model;
using DEV_KPI.Helper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmQuanLy : frmBase
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (LocalData.ObjUserLogIn.TEAM_LEAD)
                {
                    btnDanhGia.Enabled = true;
                }
                else
                {
                    btnDanhGia.Enabled = false;
                }
                dteTuNgay.DateTime = DateTime.Now.AddDays(-10);
                dteDenNgay.DateTime = DateTime.Now.AddDays(1);
                txtTeam.Text = LocalData.ObjUserLogIn.TEAM;
                txtMaNV.Text = LocalData.ObjUserLogIn.EMPLOYER_CODE;
                txtTenNV.Text = LocalData.ObjUserLogIn.EMPLOYER_NAME;
                UICommonFunction.SetGridViewConfig(grcKPI, typeof(KPI_TEAM_DETAILModel));
                UICommonFunction.SetGridColumnEnable(grvKPI, colSELECT);
                var lstDonVi = new List<CodeNamModel>
                {
                    new CodeNamModel{ Code = "GIO", Name = "Giờ" },
                    new CodeNamModel{ Code = "PHUT", Name = "Phút" }
                };
                UICommonFunction.AddGridViewGridLookUpToColumn(grvKPI, "DON_VI_THOI_GIAN", lstDonVi, "Code", "Name");
                UICommonFunction.SelectBySpace(grvKPI, false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }


        private void txtMaNV_Validated(object sender, EventArgs e)
        {
            try
            {
                txtTenNV.Text = "";
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    return;
                }
                var lstNhanVien = KPI_USERBL.Search(new KPI_USERModel() { EMPLOYER_CODE = txtMaNV.Text.Trim() });
                if (lstNhanVien != null && lstNhanVien.Count > 0)
                {
                    txtTenNV.Text = lstNhanVien[0].EMPLOYER_NAME;
                    LocalData.SetLocalDataEmployer(lstNhanVien[0]);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    var manv = txtMaNV.Text;
                    var team = txtTeam.Text;
                    var frDate = dteTuNgay.DateTime;
                    var toDate = dteDenNgay.DateTime;
                    var lstKPIMaNV = KPI_TEAM_DETAILDL.SearchMaNV(frDate, toDate, manv, team) as List<KPI_TEAM_DETAILModel>;
                    grcKPI.DataSource = lstKPIMaNV;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtTeam.Text))
                    {
                        MessageHelper.ShowWarning("Vui lòng nhập tên team.");
                        return;
                    }
                    var team = txtTeam.Text;
                    var frDate = dteTuNgay.DateTime;
                    var toDate = dteDenNgay.DateTime;
                    var lstKPITeam = KPI_TEAM_DETAILDL.SearchTeam(frDate, toDate, team) as List<KPI_TEAM_DETAILModel>;
                    grcKPI.DataSource = lstKPITeam;
                }

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

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var frm = new frmKPIDetail();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    btnTimKiem_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lst = grcKPI.DataSource as List<KPI_TEAM_DETAILModel>;

                foreach (var item in lst)
                {
                    if (item.DON_VI_THOI_GIAN == "GIO")
                    {
                        item.DON_VI_THOI_GIAN = "Giờ";
                    }
                    if (item.DON_VI_THOI_GIAN == "PHUT")
                    {
                        item.DON_VI_THOI_GIAN = "Phút";
                    }
                    item.GIO_THUC_HIEN_STRING = item.GIO_THUC_HIEN + " " + item.DON_VI_THOI_GIAN;
                }
                var rpt = new rptERP();
                rpt.Print(lst);
                rpt.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnDanhGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                var lstSelect = UICommonFunction.GetCheckedSelectRow<List<KPI_TEAM_DETAILModel>>(grcKPI);
                if (lstSelect.Count == 0)
                {
                    MessageHelper.ShowWarning("Vui lòng chọn ít nhất một dòng để nhập đánh giá.");
                    return;
                }
                using (var frm = new frmDanhGiaKPI())
                {
                    frm.LstUpdate = lstSelect;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        btnTimKiem.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lstSelect = UICommonFunction.GetCheckedSelectRow<List<KPI_TEAM_DETAILModel>>(grcKPI);
                if (lstSelect.Count == 0)
                {
                    MessageHelper.ShowWarning("Vui lòng chọn ít nhất một dòng để xóa.");
                    return;
                }
                var lstKhacMaNV = lstSelect.Where(s => s.EMPLOYER_CODE != LocalData.ObjUserLogIn.EMPLOYER_CODE).ToList();
                if (!lstKhacMaNV.IsNullOrEmpty())
                {
                    MessageHelper.ShowWarning("Không được xóa Task của nhân viên khác");
                    return;
                }
                if (lstSelect.Count > 0)
                {
                    if (MessageHelper.ShowQuestion("Bạn có chắc chắn muốn xóa Task này?") != DialogResult.OK)
                    {
                        return;
                    }
                    foreach (var item in lstSelect)
                    {
                        var objUpDate = new KPI_TEAM_DETAILModel();
                        DevHelper.Inject(item, objUpDate);

                        DLHelper.Delete(objUpDate);

                    }
                    MessageHelper.ShowInfomation("Đã xóa thành công");

                }
                btnTimKiem.PerformClick();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }
    }
}
