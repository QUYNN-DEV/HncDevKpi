namespace DEV_KPI.UI
{
    partial class frmQuanLy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLy));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTenNV = new DevExpress.XtraEditors.TextEdit();
            this.txtTeam = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.dteDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dteTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grcKPI = new DevExpress.XtraGrid.GridControl();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.grvKPI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEMPLOYER_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMPLOYER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONG_VIEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDANH_GIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDON_VI_THOI_GIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGHI_CHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIO_THUC_HIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLY_DO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY_THUC_HIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTY_LE_HOAN_THANH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSELECT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhGia = new DevExpress.XtraBars.BarButtonItem();
            this.btnDong = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcKPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnTimKiem);
            this.panelControl1.Controls.Add(this.txtTenNV);
            this.panelControl1.Controls.Add(this.txtTeam);
            this.panelControl1.Controls.Add(this.txtMaNV);
            this.panelControl1.Controls.Add(this.dteDenNgay);
            this.panelControl1.Controls.Add(this.dteTuNgay);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1058, 83);
            this.panelControl1.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.ImageOptions.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(359, 52);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(81, 23);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(124, 9);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(231, 20);
            this.txtTenNV.TabIndex = 2;
            // 
            // txtTeam
            // 
            this.txtTeam.Location = new System.Drawing.Point(60, 32);
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.Size = new System.Drawing.Size(295, 20);
            this.txtTeam.TabIndex = 4;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(60, 9);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(64, 20);
            this.txtMaNV.TabIndex = 1;
            this.txtMaNV.Validated += new System.EventHandler(this.txtMaNV_Validated);
            // 
            // dteDenNgay
            // 
            this.dteDenNgay.EditValue = null;
            this.dteDenNgay.Location = new System.Drawing.Point(221, 54);
            this.dteDenNgay.Name = "dteDenNgay";
            this.dteDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dteDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dteDenNgay.Size = new System.Drawing.Size(134, 20);
            this.dteDenNgay.TabIndex = 8;
            // 
            // dteTuNgay
            // 
            this.dteTuNgay.EditValue = null;
            this.dteTuNgay.Location = new System.Drawing.Point(60, 54);
            this.dteTuNgay.Name = "dteTuNgay";
            this.dteTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dteTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dteTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dteTuNgay.Size = new System.Drawing.Size(111, 20);
            this.dteTuNgay.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(173, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Đến ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 35);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Team";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Từ ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã NV";
            // 
            // grcKPI
            // 
            this.grcKPI.DataSource = this.bsData;
            this.grcKPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcKPI.Location = new System.Drawing.Point(0, 107);
            this.grcKPI.MainView = this.grvKPI;
            this.grcKPI.Name = "grcKPI";
            this.grcKPI.Size = new System.Drawing.Size(1058, 454);
            this.grcKPI.TabIndex = 0;
            this.grcKPI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKPI});
            // 
            // bsData
            // 
            this.bsData.DataSource = typeof(Core.Model.KPI_TEAM_DETAILModel);
            // 
            // grvKPI
            // 
            this.grvKPI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEMPLOYER_CODE,
            this.colEMPLOYER_NAME,
            this.colTEAM,
            this.colCONG_VIEC,
            this.colDANH_GIA,
            this.colDON_VI_THOI_GIAN,
            this.colGHI_CHU,
            this.colGIO_THUC_HIEN,
            this.colLY_DO,
            this.colNGAY_THUC_HIEN,
            this.colTY_LE_HOAN_THANH,
            this.colSELECT});
            this.grvKPI.GridControl = this.grcKPI;
            this.grvKPI.GroupCount = 1;
            this.grvKPI.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "")});
            this.grvKPI.Name = "grvKPI";
            this.grvKPI.OptionsBehavior.ReadOnly = true;
            this.grvKPI.OptionsView.ColumnAutoWidth = false;
            this.grvKPI.OptionsView.ShowAutoFilterRow = true;
            this.grvKPI.OptionsView.ShowFooter = true;
            this.grvKPI.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNGAY_THUC_HIEN, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colEMPLOYER_CODE
            // 
            this.colEMPLOYER_CODE.Caption = "Mã nhân viên";
            this.colEMPLOYER_CODE.FieldName = "EMPLOYER_CODE";
            this.colEMPLOYER_CODE.Name = "colEMPLOYER_CODE";
            this.colEMPLOYER_CODE.OptionsColumn.AllowEdit = false;
            this.colEMPLOYER_CODE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EMPLOYER_CODE", "{0}")});
            this.colEMPLOYER_CODE.Visible = true;
            this.colEMPLOYER_CODE.VisibleIndex = 1;
            this.colEMPLOYER_CODE.Width = 84;
            // 
            // colEMPLOYER_NAME
            // 
            this.colEMPLOYER_NAME.Caption = "Tên nhân viên";
            this.colEMPLOYER_NAME.FieldName = "EMPLOYER_NAME";
            this.colEMPLOYER_NAME.Name = "colEMPLOYER_NAME";
            this.colEMPLOYER_NAME.OptionsColumn.AllowEdit = false;
            this.colEMPLOYER_NAME.Visible = true;
            this.colEMPLOYER_NAME.VisibleIndex = 2;
            this.colEMPLOYER_NAME.Width = 160;
            // 
            // colTEAM
            // 
            this.colTEAM.Caption = "Team";
            this.colTEAM.FieldName = "TEAM";
            this.colTEAM.Name = "colTEAM";
            this.colTEAM.OptionsColumn.AllowEdit = false;
            this.colTEAM.Visible = true;
            this.colTEAM.VisibleIndex = 3;
            this.colTEAM.Width = 100;
            // 
            // colCONG_VIEC
            // 
            this.colCONG_VIEC.Caption = "Công việc(task)";
            this.colCONG_VIEC.FieldName = "CONG_VIEC";
            this.colCONG_VIEC.Name = "colCONG_VIEC";
            this.colCONG_VIEC.OptionsColumn.AllowEdit = false;
            this.colCONG_VIEC.Visible = true;
            this.colCONG_VIEC.VisibleIndex = 4;
            this.colCONG_VIEC.Width = 196;
            // 
            // colDANH_GIA
            // 
            this.colDANH_GIA.Caption = "Đánh giá";
            this.colDANH_GIA.FieldName = "DANH_GIA";
            this.colDANH_GIA.Name = "colDANH_GIA";
            this.colDANH_GIA.OptionsColumn.AllowEdit = false;
            this.colDANH_GIA.Visible = true;
            this.colDANH_GIA.VisibleIndex = 10;
            this.colDANH_GIA.Width = 175;
            // 
            // colDON_VI_THOI_GIAN
            // 
            this.colDON_VI_THOI_GIAN.Caption = "Đơn vị";
            this.colDON_VI_THOI_GIAN.FieldName = "DON_VI_THOI_GIAN";
            this.colDON_VI_THOI_GIAN.Name = "colDON_VI_THOI_GIAN";
            this.colDON_VI_THOI_GIAN.OptionsColumn.AllowEdit = false;
            this.colDON_VI_THOI_GIAN.Visible = true;
            this.colDON_VI_THOI_GIAN.VisibleIndex = 6;
            this.colDON_VI_THOI_GIAN.Width = 95;
            // 
            // colGHI_CHU
            // 
            this.colGHI_CHU.Caption = "Ghi chú";
            this.colGHI_CHU.FieldName = "GHI_CHU";
            this.colGHI_CHU.Name = "colGHI_CHU";
            this.colGHI_CHU.OptionsColumn.AllowEdit = false;
            this.colGHI_CHU.Visible = true;
            this.colGHI_CHU.VisibleIndex = 9;
            this.colGHI_CHU.Width = 172;
            // 
            // colGIO_THUC_HIEN
            // 
            this.colGIO_THUC_HIEN.Caption = "Thời gian";
            this.colGIO_THUC_HIEN.FieldName = "GIO_THUC_HIEN";
            this.colGIO_THUC_HIEN.Name = "colGIO_THUC_HIEN";
            this.colGIO_THUC_HIEN.OptionsColumn.AllowEdit = false;
            this.colGIO_THUC_HIEN.Visible = true;
            this.colGIO_THUC_HIEN.VisibleIndex = 5;
            this.colGIO_THUC_HIEN.Width = 83;
            // 
            // colLY_DO
            // 
            this.colLY_DO.Caption = "Lý do";
            this.colLY_DO.FieldName = "LY_DO";
            this.colLY_DO.Name = "colLY_DO";
            this.colLY_DO.OptionsColumn.AllowEdit = false;
            this.colLY_DO.Visible = true;
            this.colLY_DO.VisibleIndex = 8;
            // 
            // colNGAY_THUC_HIEN
            // 
            this.colNGAY_THUC_HIEN.Caption = "Ngày thực hiện";
            this.colNGAY_THUC_HIEN.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNGAY_THUC_HIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAY_THUC_HIEN.FieldName = "NGAY_THUC_HIEN";
            this.colNGAY_THUC_HIEN.Name = "colNGAY_THUC_HIEN";
            this.colNGAY_THUC_HIEN.OptionsColumn.AllowEdit = false;
            this.colNGAY_THUC_HIEN.Visible = true;
            this.colNGAY_THUC_HIEN.VisibleIndex = 5;
            this.colNGAY_THUC_HIEN.Width = 93;
            // 
            // colTY_LE_HOAN_THANH
            // 
            this.colTY_LE_HOAN_THANH.Caption = "Tỷ lệ hoàn thành";
            this.colTY_LE_HOAN_THANH.FieldName = "TY_LE_PHAN_TRAM";
            this.colTY_LE_HOAN_THANH.Name = "colTY_LE_HOAN_THANH";
            this.colTY_LE_HOAN_THANH.OptionsColumn.AllowEdit = false;
            this.colTY_LE_HOAN_THANH.Visible = true;
            this.colTY_LE_HOAN_THANH.VisibleIndex = 7;
            this.colTY_LE_HOAN_THANH.Width = 101;
            // 
            // colSELECT
            // 
            this.colSELECT.Caption = "Chọn";
            this.colSELECT.FieldName = "SELECT";
            this.colSELECT.Name = "colSELECT";
            this.colSELECT.Visible = true;
            this.colSELECT.VisibleIndex = 0;
            this.colSELECT.Width = 55;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemMoi,
            this.btnDong,
            this.btnIn,
            this.btnDanhGia,
            this.btnXoa});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnIn, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDanhGia, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDong, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Caption = "Thêm mới";
            this.btnThemMoi.Id = 0;
            this.btnThemMoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.ImageOptions.Image")));
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemMoi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 4;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In";
            this.btnIn.Id = 2;
            this.btnIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.Image")));
            this.btnIn.Name = "btnIn";
            this.btnIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIn_ItemClick);
            // 
            // btnDanhGia
            // 
            this.btnDanhGia.Caption = "Đánh giá";
            this.btnDanhGia.Id = 3;
            this.btnDanhGia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhGia.ImageOptions.Image")));
            this.btnDanhGia.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDanhGia.ImageOptions.LargeImage")));
            this.btnDanhGia.Name = "btnDanhGia";
            this.btnDanhGia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDanhGia_ItemClick);
            // 
            // btnDong
            // 
            this.btnDong.Caption = "Đóng";
            this.btnDong.Id = 1;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.Name = "btnDong";
            this.btnDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDong_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1058, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1058, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1058, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 537);
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 561);
            this.Controls.Add(this.grcKPI);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.Name = "frmQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Task";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcKPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.TextEdit txtTenNV;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.DateEdit dteDenNgay;
        private DevExpress.XtraEditors.DateEdit dteTuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTeam;
        private DevExpress.XtraGrid.GridControl grcKPI;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKPI;
        private System.Windows.Forms.BindingSource bsData;
        private DevExpress.XtraGrid.Columns.GridColumn colEMPLOYER_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colEMPLOYER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colTEAM;
        private DevExpress.XtraGrid.Columns.GridColumn colCONG_VIEC;
        private DevExpress.XtraGrid.Columns.GridColumn colDANH_GIA;
        private DevExpress.XtraGrid.Columns.GridColumn colDON_VI_THOI_GIAN;
        private DevExpress.XtraGrid.Columns.GridColumn colGHI_CHU;
        private DevExpress.XtraGrid.Columns.GridColumn colGIO_THUC_HIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colLY_DO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY_THUC_HIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colTY_LE_HOAN_THANH;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThemMoi;
        private DevExpress.XtraBars.BarButtonItem btnDong;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnDanhGia;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraGrid.Columns.GridColumn colSELECT;
    }
}

