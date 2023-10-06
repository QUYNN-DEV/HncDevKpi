using ApiClient.Models;
using Core.DL;
using Core.Helper;
using Core.Model;
using DEV_KPI.Common;
using DEV_KPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DEV_KPI.UI
{
    public partial class frmKPIDetail : frmBase
    {
        public frmKPIDetail()
        {
            InitializeComponent();
        }

        private void frmKPIDetail_Load(object sender, EventArgs e)
        {
            try
            {
                txtMaNV.Text = LocalData.ObjUserLogIn.EMPLOYER_CODE;
                txtTenNV.Text = LocalData.ObjUserLogIn.EMPLOYER_NAME;
                txtTeam.Text = LocalData.ObjUserLogIn.TEAM;
                dteNgayBaoCao.DateTime = DateTime.Now;

                var lstCodeName = new List<CodeNamModel>()
                {
                    new CodeNamModel { Code = "GIO", Name = "Giờ"},
                    new CodeNamModel { Code = "PHUT", Name = "Phút"},
                };
                cboDonViThoiGian.Properties.DataSource = lstCodeName;
                cboDonViThoiGian.Properties.DisplayMember = "Name";
                cboDonViThoiGian.Properties.ValueMember = "Code";
                cboDonViThoiGian.EditValue = "GIO";
                UICommonFunction.SetGridViewConfig(grcKPIDetail, typeof(KPI_TEAM_DETAILModel));
                rdgTypeInput_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }
        List<KPI_TEAM_DETAILModel> lstKPI = new List<KPI_TEAM_DETAILModel>();

        private bool ValidateUI()
        {
            if (string.IsNullOrWhiteSpace(txtCongViec.Text))
            {
                MessageHelper.ShowError("Vui lòng nhập công việc.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoGioLam.Text))
            {
                MessageHelper.ShowError("Vui lòng nhập số giờ làm.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTeam.Text))
            {
                MessageHelper.ShowError("Vui lòng nhập team.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTyLeHoanThanh.Text))
            {
                MessageHelper.ShowError("Vui lòng nhập tỷ lệ hoàn thành.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cboDonViThoiGian.Text))
            {
                MessageHelper.ShowError("Vui lòng nhập đơn vị thời gian.");
                return false;
            }
            return true;
        }

        private bool ValidateTaskDone()
        {
            var lstTask = grcKPIDetail.DataSource as List<KPI_TEAM_DETAILModel>;
            if (!lstTask.IsNullOrEmpty())
            {
                var lstTaskName = lstTask.Where(x => x.TY_LE_HOAN_THANH == 100).Select(x => x.CONG_VIEC).ToList();

                if (cboSections.ReadOnly == false || int.Parse(txtTyLeHoanThanh.Text) == 100)
                {
                    if (lstTaskName.Contains(txtCongViec.Text))
                    {
                        MessageHelper.ShowError("Task này đã được nhập hoàn thành ở trên. Vui lòng xóa đi để nhập lại!");
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUI())
                {
                    return;
                }

                if (!ValidateTaskDone())
                {
                    return;
                }

                var dto = new KPI_TEAM_DETAILModel();//
                dto.CONG_VIEC = txtCongViec.Text;
                dto.DON_VI_THOI_GIAN = cboDonViThoiGian.EditValue.ToString();
                dto.GIO_THUC_HIEN = Convert.ToInt32(txtSoGioLam.Text);
                dto.TY_LE_HOAN_THANH = int.Parse(txtTyLeHoanThanh.Text);
                dto.GHI_CHU = txtGhiChu.Text;
                lstKPI.Add(dto);
                //reset gitri cho txtbox
                txtCongViec.Text = null;
                txtGhiChu.Text = null;
                txtSoGioLam.Text = null;
                txtTyLeHoanThanh.Text = null;
                txtGhiChu.Text = null;

                grcKPIDetail.DataSource = lstKPI;
                grcKPIDetail.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (lstKPI.IsNullOrEmpty())
                {
                    MessageHelper.ShowError("Vui lòng nhập công việc để lưu");
                    return;
                }
                foreach (var item in lstKPI)
                {
                    item.EMPLOYER_CODE = txtMaNV.Text.Trim();
                    item.NGAY_THUC_HIEN = dteNgayBaoCao.DateTime.Date;
                    item.TY_LE_PHAN_TRAM = item.TY_LE_HOAN_THANH + " %";
                    item.INSERT_DATE = DateTime.Now;
                    item.INSERT_TIME = DateTime.Now;
                    item.INSERT_USER = txtMaNV.Text;
                    item.UPDATE_DATE = DateTime.Now;
                    item.UPDATE_TIME = DateTime.Now;
                    item.UPDATE_USER = txtMaNV.Text;
                    DLHelper.Insert(item);
                }
                MessageHelper.ShowInfomation("Thực hiện thành công.");
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lstAll = grcKPIDetail.DataSource as List<KPI_TEAM_DETAILModel>;
                var dtoSelect = UIControl.GetCurrentDataInGrid(grvKPIDetail) as KPI_TEAM_DETAILModel;
                if (dtoSelect == null)
                {
                    MessageHelper.ShowError("Vui lòng chọn ít nhất một dòng để xóa.");
                    return;
                }
                lstAll.Remove(dtoSelect);
                grcKPIDetail.DataSource = lstAll;
                grcKPIDetail.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void rdgTypeInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCongViec.Text = "";
                cboTask.Properties.DataSource = null;
                if (rdgTypeInput.EditValue == null)
                {
                    return;
                }
                switch (rdgTypeInput.EditValue)
                {
                    case "LOCAL":
                        cboProject.ReadOnly = true;
                        cboSections.ReadOnly = true;
                        cboTask.ReadOnly = false;
                        txtCongViec.ReadOnly = true;
                        var lstTaskOld = new List<CodeNamModel>();
                        lstTaskOld = GetTaskOldFromLocal(LocalData.ObjUserLogIn.EMPLOYER_CODE);
                        UICommonFunction.ConfigDataSourceAndDefaultValueToGridLookUpEdit(cboTask, lstTaskOld, "Code", "Code", lstTaskOld.IsNullOrEmpty() ? "" : lstTaskOld[0].Code, false, false, false);
                        cboTask_Validated(null, null);
                        break;
                    case "ASANA":
                        if (LocalData.ObjUserLogIn.TEAM == "WEB")
                        {
                            MessageHelper.ShowInfomation("Chỉ nhóm ERP và Mobile mới có thể sử dụng chức năng này");
                            return;
                        }
                        cboProject.ReadOnly = false;
                        cboSections.ReadOnly = false;
                        cboTask.ReadOnly = false;
                        txtCongViec.ReadOnly = true;

                        var lstLocal = KPI_PROJECTDL.Search();
                        string gid = LocalData.ObjUserLogIn.ASANA_ID;
                        var lstProject = Project.GetListProject(LocalData.ObjUserLogIn.TEAM);
                        //Xóa bỏ Task tồn
                        lstProject.RemoveAll(s => s.Gid == "1159549879397552");
                        UICommonFunction.ConfigDataSourceAndDefaultValueToGridLookUpEdit(cboProject, lstProject, "Gid", "Name");
                        break;
                    case "MANUAL":
                        cboProject.ReadOnly = true;
                        cboSections.ReadOnly = true;
                        cboTask.ReadOnly = true;
                        txtCongViec.ReadOnly = false;
                        break;
                    default:
                        txtCongViec.ReadOnly = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void ShowComboProject()
        {
            var lstProject = KPI_PROJECTDL.Search();
            UICommonFunction.ConfigDataSourceAndDefaultValueToGridLookUpEdit(cboProject, lstProject, "Gid", "Name", lstProject.IsNullOrEmpty() ? "" : lstProject[0].Gid);
            cboProject_Validated(null, null);
        }

        private List<CodeNamModel> GetTaskOldFromLocal(string employCode)
        {
            var lstTask = new List<CodeNamModel>();
            var lstResult = KPI_TEAM_DETAILDL.SearchUnCompleteTask(employCode);
            foreach (var item in lstResult)
            {
                string code = StringHelper.TaskCodeFromTaskName(item.CONG_VIEC);
                lstTask.Add(new CodeNamModel { Code = code, Name = item.CONG_VIEC });
            }
            return lstTask;
        }

        private void cboProject_Validated(object sender, EventArgs e)
        {
            try
            {
                var dtoSelect = UICommonFunction.GetCurentDataInGridLookupEdit(cboProject) as Project;
                if (dtoSelect == null)
                {
                    return;
                }
                // lấy section
                var lstSection = SectionHelper.GetSectionsList(dtoSelect.Gid, LocalData.ObjUserLogIn.TEAM);
                UICommonFunction.ConfigDataSourceAndDefaultValueToGridLookUpEdit(cboSections, lstSection, "Gid", "Name");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void cboTask_Validated(object sender, EventArgs e)
        {
            try
            {
                var dtoSelect = UICommonFunction.GetCurentDataInGridLookupEdit(cboTask) as CodeNamModel;
                if (dtoSelect == null)
                {
                    return;
                }
                txtCongViec.Text = dtoSelect.Name;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void cboSections_Validated(object sender, EventArgs e)
        {
            try
            {
                var dtoSelect = UICommonFunction.GetCurentDataInGridLookupEdit(cboSections) as Section;
                if (dtoSelect == null)
                {
                    return;
                }
                var lstTask = new List<CodeNamModel>();
                var lstResult = SectionHelper.GetTaskByAsanaIDSection(LocalData.ObjUserLogIn.ASANA_ID, cboSections.EditValue.ToString(), LocalData.ObjUserLogIn.TEAM);
                if (!lstResult.IsNullOrEmpty())
                {
                    foreach (var item in lstResult)
                    {
                        string code = StringHelper.TaskCodeFromTaskName(item.Name);
                        lstTask.Add(new CodeNamModel { Code = code, Name = item.Name });
                    }
                }
                UICommonFunction.ConfigDataSourceAndDefaultValueToGridLookUpEdit(cboTask, lstTask, "Code", "Code", lstTask.IsNullOrEmpty() ? "" : lstTask[0].Code, false, false, false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void txtTyLeHoanThanh_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTyLeHoanThanh.Text))
                {
                    return;
                }
                if (int.Parse(txtTyLeHoanThanh.Text) > 100)
                {
                    txtTyLeHoanThanh.Text = "100";
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }

        private void txtsogiolam_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoGioLam.Text))
                {
                    return;
                }
                int donVi = int.Parse(txtSoGioLam.Text);
                if (cboDonViThoiGian.EditValue.ToString() == "GIO")
                {
                    if (donVi > 8)
                    {
                        txtSoGioLam.Text = "8";
                    }
                }
                else
                {
                    if (donVi > 60)
                    {
                        txtSoGioLam.Text = "60";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex);
            }
        }
    }
}
